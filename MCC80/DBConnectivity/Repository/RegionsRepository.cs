
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBConnectivity.Interface;

namespace DBConnectivity.Repository
{
    public class RegionsRepository : IRegionsRepository
    {
        private static string connectionString = "Data Source=(localdb)\\local;Initial Catalog=MCC;Integrated Security=True;Connect Timeout=30;";

        private static SqlConnection _connection;

        public void GetRegion()
        {
            _connection = new SqlConnection(connectionString);
            try
            {
                _connection.Open();
                string sql = "SELECT * FROM REGIONS";
                SqlCommand command = new SqlCommand(sql, _connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("================================");
                        Console.WriteLine("Id: " + reader.GetInt32(0));
                        Console.WriteLine("Name: " + reader.GetString(1));
                        Console.WriteLine("================================");
                    }
                }
                else
                {
                    Console.WriteLine("Data not found");
                }
                reader.Close();
                _connection.Close();
            }
            catch
            {
                Console.WriteLine("Connection Eror");
            }
        }
        public void InsertRegion(string name)
        {
            _connection = new SqlConnection(connectionString);
            string sql = "INSERT INTO REGIONS VALUES (@name)";
            SqlCommand command = new SqlCommand(sql, _connection);
            _connection.Open();
            SqlTransaction transaction = _connection.BeginTransaction();
            command.Transaction = transaction;

            try
            {
                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.SqlDbType = SqlDbType.VarChar;
                pName.Value = name;
                command.Parameters.Add(pName);

                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Insert success");
                }
                else
                {
                    Console.WriteLine("Insert failed");
                }
                transaction.Commit();
                _connection.Close();
            }
            catch
            {
                transaction.Rollback();
                Console.WriteLine("Error connecting to database");
            }
        }
        public void UpdateRegion(int id, string name)
        {
            _connection = new SqlConnection(connectionString);
            string sql = "UPDATE REGIONS SET NAME = @name WHERE ID = @id";
            SqlCommand command = new SqlCommand(sql, _connection);
            _connection.Open();
            SqlTransaction transaction = _connection.BeginTransaction();
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@name", name);
            command.Transaction = transaction;

            try
            {

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Data was updated");
                }
                else
                {
                    Console.WriteLine("No rows updated");
                }
                transaction.Commit();
                _connection.Close();
            }
            catch
            {
                transaction.Rollback();
                Console.WriteLine("Error connecting to database");
            }
        }
        public void DeleteRegions(int id)
        {
            _connection = new SqlConnection(connectionString);
            string sql = "DELETE FROM REGIONS WHERE ID = @id";
            SqlCommand command = new SqlCommand(sql, _connection);
            _connection.Open();
            SqlTransaction transaction = _connection.BeginTransaction();
            command.Parameters.AddWithValue("@id", id);
            command.Transaction = transaction;

            try
            {
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Data was deleted");
                }
                else
                {
                    Console.WriteLine("Data not found");
                }
                transaction.Commit();
                _connection.Close();
            }
            catch
            {
                transaction.Rollback();
                Console.Write("Error connecting to database");
            }
        }
        public void FindRegions(int id)
        {
            _connection = new SqlConnection(connectionString);
            try
            {
                _connection.Open();
                string sql = "SELECT * FROM REGIONS WHERE ID = @id";
                SqlCommand command = new SqlCommand(sql, _connection);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("================================");
                        Console.WriteLine("Id: " + reader.GetInt32(0));
                        Console.WriteLine("Name: " + reader.GetString(1));
                        Console.WriteLine("================================");
                    }
                }
                else
                {
                    Console.WriteLine("Data not found");
                }
                reader.Close();
                _connection.Close();
            }
            catch
            {
                Console.WriteLine("Error connecting to database");
            }
        }
    }
}
