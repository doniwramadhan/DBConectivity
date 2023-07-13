using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRefactoring.Model
{
    public class Jobs
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int MinSalary { get; set; }
        public int MaxSalary { get; set;}

        public List<Jobs> GetAll()
        {
            var dBConnection = DBConnection.Get();
            var jobs = new List<Jobs>();

            string sql = "SELECT * FROM JOBS";
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
                        Jobs job = new Jobs();
                        job.Id = reader.GetString(0);
                        job.Title = reader.GetString(1);
                        job.MinSalary = reader.GetInt32(2);
                        job.MaxSalary = reader.GetInt32(3);


                        jobs.Add(job);
                    }
                }
                else
                {
                    reader.Close();
                    dBConnection.Close();

                }
                return jobs;
            }
            catch
            {
                return new List<Jobs>();
            }
        }

        public int Insert(Jobs jobs)
        {
            var dBConnection = DBConnection.Get();

            string sql = "INSERT INTO JOBS VALUES (@id,@title,@minSalary,@maxSalary)";
            SqlCommand command = new SqlCommand(sql);
            command.Connection = dBConnection;
            dBConnection.Open();
            SqlTransaction transaction = dBConnection.BeginTransaction();
            command.Transaction = transaction;

            try
            {
                command.Parameters.AddWithValue("@id", jobs.Id);
                command.Parameters.AddWithValue("@title", jobs.Title);
                command.Parameters.AddWithValue("@minSalary", jobs.MinSalary);
                command.Parameters.AddWithValue("@maxSalary", jobs.MaxSalary);
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

        public int Update(Jobs jobs)
        {
            var dBConnection = DBConnection.Get();

            string sql = "UPDATE JOBS SET title = @title, min_Salary = @minSalary, max_salary = @maxSalary WHERE ID = @id";
            SqlCommand command = new SqlCommand(sql);
            command.Connection = dBConnection;
            dBConnection.Open();
            SqlTransaction transaction = dBConnection.BeginTransaction();
            command.Transaction = transaction;

            try
            {
                command.Parameters.AddWithValue("@id", jobs.Id);
                command.Parameters.AddWithValue("@title", jobs.Title);
                command.Parameters.AddWithValue("@minSalary", jobs.MinSalary);
                command.Parameters.AddWithValue("@maxSalary", jobs.MaxSalary);
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

            string sql = "DELETE FROM JOBS WHERE ID = @id";
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

        public Jobs GetById(int id)
        {
            var jobs = new Jobs();

            var dBConnection = DBConnection.Get();

            string sql = "SELECT * FROM JOBS WHERE ID = @id";
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
                    jobs.Id = reader.GetString(0);
                    jobs.Title = reader.GetString(1);
                    jobs.MinSalary = reader.GetInt32(2);
                    jobs.MaxSalary = reader.GetInt32(3);

                }

                reader.Close();
                dBConnection.Close();

                return new Jobs();
            }
            catch
            {
                return new Jobs();
            }
        }
    }
}
