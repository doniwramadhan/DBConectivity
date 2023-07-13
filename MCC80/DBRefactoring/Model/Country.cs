using DBRefactoring.View;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRefactoring.Model
{
    public class Country
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }


        public List<Country> GetAll()
        {
            var dBConnection = DBConnection.Get();
            var country = new List<Country>();

            string sql = "SELECT * FROM COUNTRIES";
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
                        Country count = new Country();
                        count.Id = reader.GetString(0);
                        count.Name = reader.GetString(1);
                        count.RegionId = reader.GetInt32(2);
                        

                        country.Add(count);
                    }
                }
                else
                {
                    reader.Close();
                    dBConnection.Close();

                }
                return country;
            }
            catch
            {
                return new List<Country>();
            }
        }

        public int Insert(Country country)
        {
            var dBConnection = DBConnection.Get();

            string sql = "INSERT INTO COUNTRIES VALUES (@id,@name,@regionId)";
            SqlCommand command = new SqlCommand(sql);
            command.Connection = dBConnection;
            dBConnection.Open();
            SqlTransaction transaction = dBConnection.BeginTransaction();
            command.Transaction = transaction;

            try
            {
                command.Parameters.AddWithValue("@id", country.Id);
                command.Parameters.AddWithValue("@name", country.Name);
                command.Parameters.AddWithValue("@regionId", country.RegionId);
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

        public int Update(Country country)
        {
            var dBConnection = DBConnection.Get();

            string sql = "UPDATE COUNTRIES SET ID = @id, NAME = @name, REGION_ID = @regionId WHERE ID = @id";
            SqlCommand command = new SqlCommand(sql);
            command.Connection = dBConnection;
            dBConnection.Open();
            SqlTransaction transaction = dBConnection.BeginTransaction();
            command.Transaction = transaction;

            try
            {
                command.Parameters.AddWithValue("@id", country.Id);
                command.Parameters.AddWithValue("@name", country.Name);
                command.Parameters.AddWithValue("@regionId", country.RegionId);
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

            string sql = "DELETE FROM COUNTRIES WHERE ID = @id";
            SqlCommand command = new SqlCommand(sql);

            command.Connection = dBConnection;
            dBConnection.Open();
            SqlTransaction transaction = dBConnection.BeginTransaction();
            command.Transaction = transaction;

            try
            {
                command.Parameters.AddWithValue("@id", id);
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

        public Country GetById(int id)
        {
            var count = new Country();

            var dBConnection = DBConnection.Get();

            string sql = "SELECT * FROM COUNTRIES WHERE ID = @id";
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

                    count.Id = reader.GetString(0);
                    count.Name = reader.GetString(1);
                    count.RegionId = reader.GetInt32(2);

                }

                reader.Close();
                dBConnection.Close();

                return new Country();
            }
            catch
            {
                return new Country();
            }
        }
    }
}
