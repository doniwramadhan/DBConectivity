using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DBRefactoring.Model
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }
        public int ManagerId { get; set; }

        public List<Department> GetAll()
        {
            var dBConnection = DBConnection.Get();
            var department = new List<Department>();

            string sql = "SELECT * FROM DEPARTMENTS";
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
                        Department dep = new Department();
                        dep.Id = reader.GetInt32(0);
                        dep.Name = reader.GetString(1);
                        dep.LocationId = reader.GetInt32(2);
                        if (!reader.IsDBNull(3))
                        {
                            dep.ManagerId = reader.GetInt32(3);
                        }


                        department.Add(dep);
                    }
                }
                else
                {
                    reader.Close();
                    dBConnection.Close();

                }
                return department;
            }
            catch
            {
                return new List<Department>();
            }
        }

        public int Insert(Department department)
        {
            var dBConnection = DBConnection.Get();

            string sql = "INSERT INTO DEPARTMENTS VALUES (@id,@name,@locationId,@managerId)";
            SqlCommand command = new SqlCommand(sql);
            command.Connection = dBConnection;
            dBConnection.Open();
            SqlTransaction transaction = dBConnection.BeginTransaction();
            command.Transaction = transaction;

            try
            {
                command.Parameters.AddWithValue("@id", department.Id);
                command.Parameters.AddWithValue("@name", department.Name);
                command.Parameters.AddWithValue("@locationId", department.LocationId);
                command.Parameters.AddWithValue("@managerId", department.ManagerId);
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

        public int Update(Department department)
        {
            var dBConnection = DBConnection.Get();

            string sql = "UPDATE DEPARTMENTS SET name = @name, location_Id = @locationId, manager_Id = @managerId WHERE ID = @id";
            SqlCommand command = new SqlCommand(sql);
            command.Connection = dBConnection;
            dBConnection.Open();
            SqlTransaction transaction = dBConnection.BeginTransaction();
            command.Transaction = transaction;

            try
            {
                command.Parameters.AddWithValue("@id", department.Id);
                command.Parameters.AddWithValue("@name", department.Name);
                command.Parameters.AddWithValue("@locationId", department.LocationId);
                command.Parameters.AddWithValue("@managerId", department.ManagerId);
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

        public Department GetById(int id)
        {
            var dep = new Department();

            var dBConnection = DBConnection.Get();

            string sql = "SELECT * FROM DEPARTMENTS WHERE ID = @id";
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
                    dep.Id = reader.GetInt32(0);
                    dep.Name = reader.GetString(1);
                    dep.LocationId = reader.GetInt32(2);
                    if (!reader.IsDBNull(3))
                    {
                        dep.ManagerId = reader.GetInt32(3);
                    }

                }

                reader.Close();
                dBConnection.Close();

                return new Department();
            }
            catch
            {
                return new Department();
            }
        }
    }
}
