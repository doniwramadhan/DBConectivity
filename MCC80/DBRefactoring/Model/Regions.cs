using DBRefactoring.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DBRefactoring.Model
{
    public class Regions
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Regions> GetAll()
        {
            var dBConnection = DBConnection.Get();
            var regions = new List<Regions>();

            string sql = "SELECT * FROM REGIONS";
            SqlCommand command = new SqlCommand(sql);
            command.Connection = dBConnection;


            try
            {
                dBConnection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Regions region = new Regions();
                        region.Id = reader.GetInt32(0);
                        region.Name = reader.GetString(1);

                        regions.Add(region);
                    }
                }
                else
                {
                    reader.Close();
                    dBConnection.Close();

                }
                return regions;
            }
            catch
            {
                return new List<Regions>();
            }
        }

        public int Insert(Regions regions)
        {
            var dBConnection = DBConnection.Get();

            string sql = "INSERT INTO REGIONS VALUES (@name)";
            SqlCommand command = new SqlCommand(sql);
            command.Connection = dBConnection;
            dBConnection.Open();
            SqlTransaction transaction = dBConnection.BeginTransaction();
            command.Transaction = transaction;

            try
            {
                command.Parameters.AddWithValue("@name", regions.Name);
                int result = command.ExecuteNonQuery();

                transaction.Commit();
                dBConnection.Close();

                return result;
            }
            catch
            {
                transaction.Rollback();
                return -1;
            }
        }

        public int Update(Regions regions)
        {
            var dBConnection = DBConnection.Get();

            string sql = "UPDATE REGIONS SET NAME = @name WHERE ID = @id";
            SqlCommand command = new SqlCommand(sql);
            command.Connection = dBConnection;
            dBConnection.Open();
            SqlTransaction transaction = dBConnection.BeginTransaction();
            command.Transaction = transaction;

            try
            {
                command.Parameters.AddWithValue("@id", regions.Id);
                command.Parameters.AddWithValue("@name", regions.Name);
                int result = command.ExecuteNonQuery();

                transaction.Commit();
                dBConnection.Close();

                return result;
            }
            catch
            {
                transaction.Rollback();
                return -1;
            }
        }

        public int Delete(int id)
        {
            var dBConnection = DBConnection.Get();

            string sql = "DELETE FROM REGIONS WHERE ID = @id";
            SqlCommand command = new SqlCommand(sql);
            
            command.Connection = dBConnection;
            dBConnection.Open();
            SqlTransaction transaction = dBConnection.BeginTransaction();
            command.Transaction = transaction;

            try
            {
                command.Parameters.AddWithValue("@id",id);
                int result = command.ExecuteNonQuery();

                transaction.Commit();
                dBConnection.Close();

                return result;
            }
            catch
            {
                transaction.Rollback();
                return -1;
            }
        }

        public Regions GetById(int id)
        {
            var region = new Regions();

            var dBConnection = DBConnection.Get();

            string sql = "SELECT * FROM REGIONS WHERE ID = @id";
            SqlCommand command = new SqlCommand(sql);
            command.Connection = dBConnection;
            command.Parameters.AddWithValue("@id", id);

            try
            {
                dBConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();

                    region.Id = reader.GetInt32(0);
                    region.Name = reader.GetString(1);
                }

                reader.Close();
                dBConnection.Close();

                return new Regions();
            }
            catch
            {
                return new Regions();
            }
        }
    }
}

