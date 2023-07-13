using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBConnectivity.Interface;

namespace DBConnectivity.Repository
{
    public class EmployeeRepository : IEmployeesRepository
    {
        private static string connectionString = "Data Source=(localdb)\\local;Initial Catalog=MCC;Integrated Security=True;Connect Timeout=30;";

        private static SqlConnection _connection;

        public void GetEmployee()
        {
            _connection = new SqlConnection(connectionString);
            try
            {
                _connection.Open();
                string sql = "SELECT * FROM EMPLOYEES";
                SqlCommand command = new SqlCommand(sql, _connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("================================");
                        Console.WriteLine("Id: " + reader.GetInt32(0));
                        Console.WriteLine("First Name: " + reader.GetString(1));
                        Console.WriteLine("Last Name: " + reader.GetString(2));
                        Console.WriteLine("Email: " + reader.GetString(3));
                        Console.WriteLine("Phone Number: " + reader.GetString(4));
                        Console.WriteLine("Hire Date: " + reader.GetDateTime(5));
                        Console.WriteLine("Salary: " + reader.GetInt32(6));
                        Console.WriteLine("Comission: " + reader.GetDecimal(7));
                        Console.WriteLine("Manager Id: " + reader.GetInt32(8));
                        Console.WriteLine("Job Id: " + reader.GetString(9));
                        Console.WriteLine("Department Id: " + reader.GetInt32(10));
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
        public void InsertEmployee(int id, string firstName, string lastName, string email, string phoneNumber, string hireDate, int salary, decimal comission, int managerId, string jobId, int departmenId)
        {
            _connection = new SqlConnection(connectionString);
            string sql = "INSERT INTO EMPLOYEES VALUES (@id,@firstName,@lastName,@email,@phoneNumber,@hireDate,@salary,@comission,@managerId,@jobId,@departmentId)";
            SqlCommand command = new SqlCommand(sql, _connection);
            _connection.Open();
            SqlTransaction transaction = _connection.BeginTransaction();
            command.Transaction = transaction;

            try
            {
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@firstName", firstName);
                command.Parameters.AddWithValue("@lastName", lastName);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                command.Parameters.AddWithValue("@hireDate", hireDate);
                command.Parameters.AddWithValue("@salary", salary);
                command.Parameters.AddWithValue("@comission", comission);
                command.Parameters.AddWithValue("@managerId", managerId);
                command.Parameters.AddWithValue("@jobId", jobId);
                command.Parameters.AddWithValue("@departmentId", departmenId);


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
        public void UpdateEmployee(int id, string firstName, string lastName, string email, string phoneNumber, string hireDate, int salary, decimal comission, int managerId, string jobId, int departmenId)
        {
            _connection = new SqlConnection(connectionString);
            string sql = "UPDATE EMPLOYEES SET first_name = @firstName, last_name = @lastName, email = @email, phone_number = @phoneNumber, hire_date = @hireDate, salary = @salary , comission_pct = @comission, manager_id = @managerId, job_id = @jobId, department_id = @departmentId  WHERE ID = @id";
            SqlCommand command = new SqlCommand(sql, _connection);
            _connection.Open();
            SqlTransaction transaction = _connection.BeginTransaction();
            command.Transaction = transaction;

            try
            {
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@firstName", firstName);
                command.Parameters.AddWithValue("@lastName", lastName);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                command.Parameters.AddWithValue("@hireDate", hireDate);
                command.Parameters.AddWithValue("@salary", salary);
                command.Parameters.AddWithValue("@comission", comission);
                command.Parameters.AddWithValue("@managerId", managerId);
                command.Parameters.AddWithValue("@jobId", jobId);
                command.Parameters.AddWithValue("@departmentId", departmenId);

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
        public void DeleteEmployee(int id)
        {
            _connection = new SqlConnection(connectionString);
            string sql = "DELETE FROM EMPLOYEES WHERE ID = @id";
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
        public void FindEmployee(int id)
        {
            _connection = new SqlConnection(connectionString);
            try
            {
                _connection.Open();
                string sql = "SELECT * FROM EMPLOYEES WHERE ID = @id";
                SqlCommand command = new SqlCommand(sql, _connection);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("================================");
                        Console.WriteLine("Id: " + reader.GetInt32(0));
                        Console.WriteLine("First Name: " + reader.GetString(1));
                        Console.WriteLine("Last Name: " + reader.GetString(2));
                        Console.WriteLine("Email: " + reader.GetString(3));
                        Console.WriteLine("Phone Number: " + reader.GetString(4));
                        Console.WriteLine("Hire Date: " + reader.GetDateTime(5));
                        Console.WriteLine("Salary: " + reader.GetInt32(6));
                        Console.WriteLine("Comission: " + reader.GetDecimal(7));
                        Console.WriteLine("Manager Id: " + reader.GetInt32(8));
                        Console.WriteLine("Job Id: " + reader.GetString(9));
                        Console.WriteLine("Department Id: " + reader.GetInt32(10));
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
