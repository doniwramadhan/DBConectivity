using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnectivity.Repository
{
    public class CountriesRepository : ICountriesRepository
    {
        private static string connectionString = "Data Source=(localdb)\\local;Initial Catalog=MCC;Integrated Security=True;Connect Timeout=30;";

        private static SqlConnection _connection;

        public void GetCountries()
        {
            _connection = new SqlConnection(connectionString);
            try
            {
                _connection.Open();
                string sql = "SELECT * FROM COUNTRIES";
                SqlCommand command = new SqlCommand(sql, _connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("================================");
                        Console.WriteLine("Id: " + reader.GetString(0));
                        Console.WriteLine("Name: " + reader.GetString(1));
                        Console.WriteLine("RegionId: " + reader.GetInt32(2));
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

        public void InsertCountries(int Id,string Name,int Regionid)
        {
            _connection = new SqlConnection(connectionString);
            string sql = "INSERT INTO COUNTRIES VALUES (@Id,@Name,@RegionId)";
            SqlCommand command = new SqlCommand(sql, _connection);
            _connection.Open();
            SqlTransaction transaction = _connection.BeginTransaction();
            command.Transaction = transaction;

            try
            {
                command.Parameters.AddWithValue("@Id", Id);
                command.Parameters.AddWithValue("@Name", Name);
                command.Parameters.AddWithValue("@RegionId", Regionid);

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

        public void UpdateCountries(int Id,string Name, int RegionId)
        {
            _connection = new SqlConnection(connectionString);
            string sql = "UPDATE COUNTRIES SET NAME = @Name, REGION_ID = @RegionId WHERE ID = @Id";
            SqlCommand command = new SqlCommand(sql, _connection);
            _connection.Open();
            SqlTransaction transaction = _connection.BeginTransaction();
            command.Parameters.AddWithValue("@Id", Id);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@RegionId", RegionId);
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

        public void DeleteCountries(int Id)
        {
            _connection = new SqlConnection(connectionString);
            string sql = "DELETE FROM COUNTRIES WHERE ID = @Id";
            SqlCommand command = new SqlCommand(sql, _connection);
            _connection.Open();
            SqlTransaction transaction = _connection.BeginTransaction();
            command.Parameters.AddWithValue("@Id", Id);
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

        public void FindCountries(int Id)
        {
            _connection = new SqlConnection(connectionString);
            try
            {
                _connection.Open();
                string sql = "SELECT * FROM COUNTRIES WHERE ID = @Id";
                SqlCommand command = new SqlCommand(sql, _connection);
                command.Parameters.AddWithValue("@Id", Id);
                
                SqlDataReader reader = command.ExecuteReader();


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("================================");
                        Console.WriteLine("Id: " + reader.GetString(0));
                        Console.WriteLine("Name: " + reader.GetString(1));
                        Console.WriteLine("RegionId: " + reader.GetInt32(2));
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
