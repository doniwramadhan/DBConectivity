using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DBRefactoring.Model
{
    public class Employees
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        public int Salary { get; set; }
        public decimal Comission { get; set; }
        public int ManagerId { get; set; }
        public string JobId { get; set; }
        public int DepartmentId { get; set; }

        public List<Employees> GetAll()
        {
            var dBConnection = DBConnection.Get();
            var employees = new List<Employees>();

            string sql = "SELECT * FROM EMPLOYEES";
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
                        Employees emp = new Employees();
                        emp.Id = reader.GetInt32(0);
                        emp.FirstName = reader.GetString(1);
                        emp.LastName = reader.GetString(2);
                        emp.Email = reader.GetString(3);
                        emp.PhoneNumber = reader.GetString(4);
                        emp.HireDate = reader.GetDateTime(5);
                        emp.Salary =  reader.GetInt32(6);
                        emp.Comission = reader.GetDecimal(7);
                        emp.ManagerId = reader.GetInt32(8);
                        emp.JobId = reader.GetString(9);
                        emp.DepartmentId = reader.GetInt32(10);



                        employees.Add(emp);
                    }
                }
                else
                {
                    reader.Close();
                    dBConnection.Close();

                }
                return employees;
            }
            catch
            {
                return new List<Employees>();
            }
        }

        public int Insert(Employees employees)
        {
            var dBConnection = DBConnection.Get();

            string sql = "INSERT INTO EMPLOYEES VALUES (@id,@firstName,@lastName,@email,@phoneNumber,@hireDate,@salary,@comission,@managerId,@jobId,@departmentId)";
            SqlCommand command = new SqlCommand(sql);
            command.Connection = dBConnection;
            dBConnection.Open();
            SqlTransaction transaction = dBConnection.BeginTransaction();
            command.Transaction = transaction;

            try
            {
                command.Parameters.AddWithValue("@id", employees.Id);
                command.Parameters.AddWithValue("@firstName", employees.FirstName);
                command.Parameters.AddWithValue("@lastName", employees.LastName);
                command.Parameters.AddWithValue("@email", employees.Email);
                command.Parameters.AddWithValue("@phoneNumber", employees.PhoneNumber);
                command.Parameters.AddWithValue("@hireDate", employees.HireDate);
                command.Parameters.AddWithValue("@salary", employees.Salary);
                command.Parameters.AddWithValue("@comission", employees.Comission);
                command.Parameters.AddWithValue("@managerId", employees.ManagerId);
                command.Parameters.AddWithValue("@jobId", employees.JobId);
                command.Parameters.AddWithValue("@departmentId", employees.DepartmentId);
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

        public int Update(Employees employees)
        {
            var dBConnection = DBConnection.Get();

            string sql = "UPDATE EMPLOYEES SET first_name = @firstName, last_name = @lastName, email = @email, phone_number = @phoneNumber, hire_date = @hireDate, salary = @salary , comission_pct = @comission, manager_id = @managerId, job_id = @jobId, department_id = @departmentId  WHERE ID = @id";
            SqlCommand command = new SqlCommand(sql);
            command.Connection = dBConnection;
            dBConnection.Open();
            SqlTransaction transaction = dBConnection.BeginTransaction();
            command.Transaction = transaction;

            try
            {
                command.Parameters.AddWithValue("@id", employees.Id);
                command.Parameters.AddWithValue("@firstName", employees.FirstName);
                command.Parameters.AddWithValue("@lastName", employees.LastName);
                command.Parameters.AddWithValue("@email", employees.Email);
                command.Parameters.AddWithValue("@phoneNumber", employees.PhoneNumber);
                command.Parameters.AddWithValue("@hireDate", employees.HireDate);
                command.Parameters.AddWithValue("@salary", employees.Salary);
                command.Parameters.AddWithValue("@comission", employees.Comission);
                command.Parameters.AddWithValue("@managerId", employees.ManagerId);
                command.Parameters.AddWithValue("@jobId", employees.JobId);
                command.Parameters.AddWithValue("@departmentId", employees.DepartmentId);
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

            string sql = "DELETE FROM DEPARTMENTS WHERE ID = @id";
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

        public Employees GetById(int id)
        {
            var emp = new Employees();

            var dBConnection = DBConnection.Get();

            string sql = "SELECT * FROM EMPLOYEES WHERE ID = @id";
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
                    emp.Id = reader.GetInt32(0);
                    emp.FirstName = reader.GetString(1);
                    emp.LastName = reader.GetString(2);
                    emp.Email = reader.GetString(3);
                    emp.PhoneNumber = reader.GetString(4);
                    emp.HireDate = reader.GetDateTime(5);
                    emp.Salary = reader.GetInt32(6);
                    emp.Comission = reader.GetDecimal(7);
                    emp.ManagerId = reader.GetInt32(8);
                    emp.JobId = reader.GetString(9);
                    emp.DepartmentId = reader.GetInt32(10);

                }

                reader.Close();
                dBConnection.Close();

                return new Employees();
            }
            catch
            {
                return new Employees();
            }
        }

    }
}
