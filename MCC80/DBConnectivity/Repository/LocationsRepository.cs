using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBConnectivity.Interface;

namespace DBConnectivity.Repository
{
    public class LocationsRepository : ILocationsRepository
    {
        private static string connectionString = "Data Source=(localdb)\\local;Initial Catalog=MCC;Integrated Security=True;Connect Timeout=30;";

        private static SqlConnection _connection;

        public void GetLocation()
        {
            _connection = new SqlConnection(connectionString);
            try
            {
                _connection.Open();
                string sql = "SELECT * FROM LOCATIONS";
                SqlCommand command = new SqlCommand(sql, _connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("================================");
                        Console.WriteLine("Id: " + reader.GetInt32(0));
                        Console.WriteLine("Street Address: " + reader.GetString(1));
                        Console.WriteLine("Post Code: " + reader.GetString(2));
                        Console.WriteLine("City: " + reader.GetString(3));
                        Console.WriteLine("State Province: " + reader.GetString(4));
                        Console.WriteLine("Country Id: " + reader.GetString(5));
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
        public void InsertLocation(int id, string streetAddress, string postalCode, string city, string stateProvince, string countryId)
        {
            _connection = new SqlConnection(connectionString);
            string sql = "INSERT INTO LOCATIONS VALUES (@id,@streetAddress,@postalCode,@city,@stateProvince,@countryId)";
            SqlCommand command = new SqlCommand(sql, _connection);
            _connection.Open();
            SqlTransaction transaction = _connection.BeginTransaction();
            command.Transaction = transaction;

            try
            {
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@streetAddress", streetAddress);
                command.Parameters.AddWithValue("@postalCode", postalCode);
                command.Parameters.AddWithValue("@city", city);
                command.Parameters.AddWithValue("@stateProvince", stateProvince);
                command.Parameters.AddWithValue("@countryId", countryId);
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
        public void UpdateLocation(int id, string streetAddress, string postalCode, string city, string stateProvince, string countryId)
        {
            _connection = new SqlConnection(connectionString);
            string sql = "UPDATE LOCATIONS SET STREET_ADDRESS = @streetAddress, POSTAL_CODE = @postalCode, CITY = @city, STATE_PROVINCE = @stateProvince, COUNTRY_ID = @countryId WHERE ID = @id";
            SqlCommand command = new SqlCommand(sql, _connection);
            _connection.Open();
            SqlTransaction transaction = _connection.BeginTransaction();
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@streetAddress", streetAddress);
            command.Parameters.AddWithValue("@postalCode", postalCode);
            command.Parameters.AddWithValue("@city", city);
            command.Parameters.AddWithValue("@stateProvince", stateProvince);
            command.Parameters.AddWithValue("@countryId", countryId);
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
        public void DeleteLocation(int id)
        {
            _connection = new SqlConnection(connectionString);
            string sql = "DELETE FROM LOCATIONS WHERE ID = @id";
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
        public void FindLocation(int id)
        {
            _connection = new SqlConnection(connectionString);
            try
            {
                _connection.Open();
                string sql = "SELECT * FROM LOCATIONS WHERE ID = @id";
                SqlCommand command = new SqlCommand(sql, _connection);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("================================");
                        Console.WriteLine("Id: " + reader.GetInt32(0));
                        Console.WriteLine("Street Address: " + reader.GetString(1));
                        Console.WriteLine("Post Code: " + reader.GetString(2));
                        Console.WriteLine("City: " + reader.GetString(3));
                        Console.WriteLine("State Province: " + reader.GetString(4));
                        Console.WriteLine("Country Id: " + reader.GetString(5));
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

