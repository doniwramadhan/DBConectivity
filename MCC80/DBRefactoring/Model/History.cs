using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DBRefactoring.Model
{
    public class History
    {
        public DateTime StartDate { get; set; }
        public int EmployeeId { get; set; }
        public DateTime EndDate { get; set; }
        public int DepartmentId { get; set; }
        public string JobId { get; set; }

        public List<History> GetAll()
        {
            var dBConnection = DBConnection.Get();
            var history = new List<History>();

            string sql = "SELECT * FROM HISTORIES";
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
                        History his = new History();
                        his.StartDate = reader.GetDateTime(0);
                        his.EmployeeId = reader.GetInt32(1);
                        his.EndDate = reader.GetDateTime(2);
                        his.DepartmentId = reader.GetInt32(3);
                        his.JobId = reader.GetString(4);


                        history.Add(his);
                    }
                }
                else
                {
                    reader.Close();
                    dBConnection.Close();

                }
                return history;
            }
            catch
            {
                return new List<History>();
            }
        }

        public int Insert(History his)
        {
            var dBConnection = DBConnection.Get();

            string sql = "INSERT INTO HISTORIES VALUES (@startDate,@employeeId,@endDate,@departmentId,@jobId)";
            SqlCommand command = new SqlCommand(sql);
            command.Connection = dBConnection;
            dBConnection.Open();
            SqlTransaction transaction = dBConnection.BeginTransaction();
            command.Transaction = transaction;

            try
            {
                command.Parameters.AddWithValue("@startDate", his.StartDate);
                command.Parameters.AddWithValue("@employeeId", his.EmployeeId);
                command.Parameters.AddWithValue("@endDate", his.EndDate);
                command.Parameters.AddWithValue("@departmentId", his.DepartmentId);
                command.Parameters.AddWithValue("@jobId", his.JobId);
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

        public int Update(History his)
        {
            var dBConnection = DBConnection.Get();

            string sql = "UPDATE HISTORIES SET start_date = @startDate, employee_id = @employeeId, end_date = @endDate, department_id = @departmentId, job_id = @jobId WHERE employee_id = @employeeId";
            SqlCommand command = new SqlCommand(sql);
            command.Connection = dBConnection;
            dBConnection.Open();
            SqlTransaction transaction = dBConnection.BeginTransaction();
            command.Transaction = transaction;

            try
            {
                command.Parameters.AddWithValue("@startDate", his.StartDate);
                command.Parameters.AddWithValue("@employeeId", his.EmployeeId);
                command.Parameters.AddWithValue("@endDate", his.EndDate);
                command.Parameters.AddWithValue("@departmentId", his.DepartmentId);
                command.Parameters.AddWithValue("@jobId", his.JobId);
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

            string sql = "DELETE FROM HISTORIES WHERE ID = @id";
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

        public History GetById(int id)
        {
            var his = new History();

            var dBConnection = DBConnection.Get();

            string sql = "SELECT * FROM HISTORIES WHERE ID = @id";
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
                    his.StartDate = reader.GetDateTime(0);
                    his.EmployeeId = reader.GetInt32(1);
                    his.EndDate = reader.GetDateTime(2);
                    his.DepartmentId = reader.GetInt32(3);
                    his.JobId = reader.GetString(4);

                }

                reader.Close();
                dBConnection.Close();

                return new History();
            }
            catch
            {
                return new History();
            }
        }

    }
}
