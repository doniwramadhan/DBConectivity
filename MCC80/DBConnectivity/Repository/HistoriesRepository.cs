using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DBConnectivity.Repository
{
    public class HistoriesRepository : IHistoriesRepository
    {
        private static string connectionString = "Data Source=(localdb)\\local;Initial Catalog=MCC;Integrated Security=True;Connect Timeout=30;";

        private static SqlConnection _connection;
        public void GetHistory()
        {
            _connection = new SqlConnection(connectionString);
            try
            {
                _connection.Open();
                string sql = "SELECT * FROM HISTORIES";
                SqlCommand command = new SqlCommand(sql, _connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("================================");
                        Console.WriteLine("Start Date: " + reader.GetDateTime(0));
                        Console.WriteLine("Employee Id: " + reader.GetInt32(1));
                        Console.WriteLine("End Date: " + reader.GetDateTime(2));
                        Console.WriteLine("Department Id: " + reader.GetInt32(3));
                        Console.WriteLine("Job Id: " + reader.GetString(4));
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
        public void InsertHistory(string startDate, int employeeId, string endDate, int departmentId, string jobId)
        {
            _connection = new SqlConnection(connectionString);
            string sql = "INSERT INTO HISTORIES VALUES (@startDate,@employeeId,@endDate,@departmentId,@jobId)";
            SqlCommand command = new SqlCommand(sql, _connection);
            _connection.Open();
            SqlTransaction transaction = _connection.BeginTransaction();
            command.Transaction = transaction;

            try
            {
                command.Parameters.AddWithValue("@startDate", startDate);
                command.Parameters.AddWithValue("@employeeId", employeeId);
                command.Parameters.AddWithValue("@endDate", endDate);
                command.Parameters.AddWithValue("@departmentId", departmentId);
                command.Parameters.AddWithValue("@jobId", jobId);



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
        public void UpdateHistory(string startDate, int employeeId, string endDate, int departmentId, string jobId)
        {
            _connection = new SqlConnection(connectionString);
            string sql = "UPDATE HISTORIES SET start_date = @startDate, employee_id = @employeeId, end_date = @endDate, department_id = @departmentId, job_id = @jobId WHERE ID = @id";
            SqlCommand command = new SqlCommand(sql, _connection);
            _connection.Open();
            SqlTransaction transaction = _connection.BeginTransaction();
            command.Transaction = transaction;

            try
            {
                command.Parameters.AddWithValue("@startDate", startDate);
                command.Parameters.AddWithValue("@employeeId", employeeId);
                command.Parameters.AddWithValue("@endDate", endDate);
                command.Parameters.AddWithValue("@departmentId", departmentId);
                command.Parameters.AddWithValue("@jobId", jobId);



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
        public void DeleteHistory(int id)
        {
            _connection = new SqlConnection(connectionString);
            string sql = "DELETE FROM HISTORIES WHERE ID = @id";
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
        public void FindHistory(int id)
        {
            _connection = new SqlConnection(connectionString);
            try
            {
                _connection.Open();
                string sql = "SELECT * FROM HISTORIES WHERE ID = @id";
                SqlCommand command = new SqlCommand(sql, _connection);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("================================");
                        Console.WriteLine("Start Date: " + reader.GetDateTime(0));
                        Console.WriteLine("Employee Id: " + reader.GetInt32(1));
                        Console.WriteLine("End Date: " + reader.GetDateTime(2));
                        Console.WriteLine("Department Id: " + reader.GetInt32(3));
                        Console.WriteLine("Job Id: " + reader.GetString(4));
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
