using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRefactoring.Model
{
    public class Locations
    {
        public int Id { get; set; }
        public string StreetAddress { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string CountryId { get; set; }


        public List<Locations> GetAll()
        {
            var dBConnection = DBConnection.Get();
            var locations = new List<Locations>();

            string sql = "SELECT * FROM LOCATIONS";
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
                        Locations loc = new Locations();
                        loc.Id = reader.GetInt32(0);
                        loc.StreetAddress = reader.GetString(1);
                        loc.PostalCode = reader.GetString(2);
                        loc.City = reader.GetString(3);
                        loc.StateProvince = reader.GetString(4);
                        loc.CountryId = reader.GetString(5);


                        locations.Add(loc);
                    }
                }
                else
                {
                    reader.Close();
                    dBConnection.Close();

                }
                return locations;
            }
            catch
            {
                return new List<Locations>();
            }
        }

        public int Insert(Locations locations)
        {
            var dBConnection = DBConnection.Get();

            string sql = "INSERT INTO LOCATIONS VALUES (@id,@streetAddress,@postalCode,@city,@stateProvince,@countryId)";
            SqlCommand command = new SqlCommand(sql);
            command.Connection = dBConnection;
            dBConnection.Open();
            SqlTransaction transaction = dBConnection.BeginTransaction();
            command.Transaction = transaction;

            try
            {
                command.Parameters.AddWithValue("@id", locations.Id);
                command.Parameters.AddWithValue("@streetAddress", locations.StreetAddress);
                command.Parameters.AddWithValue("@postalCode", locations.PostalCode);
                command.Parameters.AddWithValue("@city", locations.City);
                command.Parameters.AddWithValue("@stateProvince", locations.StateProvince);
                command.Parameters.AddWithValue("@countryId", locations.CountryId);
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

        public int Update(Locations locations)
        {
            var dBConnection = DBConnection.Get();

            string sql = "UPDATE LOCATIONS SET STREET_ADDRESS = @streetAddress, POSTAL_CODE = @postalCode, CITY = @city, STATE_PROVINCE = @stateProvince, COUNTRY_ID = @countryId WHERE ID = @id";
            SqlCommand command = new SqlCommand(sql);
            command.Connection = dBConnection;
            dBConnection.Open();
            SqlTransaction transaction = dBConnection.BeginTransaction();
            command.Transaction = transaction;

            try
            {
                command.Parameters.AddWithValue("@id", locations.Id);
                command.Parameters.AddWithValue("@streetAddress", locations.StreetAddress);
                command.Parameters.AddWithValue("@postalCode", locations.PostalCode);
                command.Parameters.AddWithValue("@city", locations.City);
                command.Parameters.AddWithValue("@stateProvince", locations.StateProvince);
                command.Parameters.AddWithValue("@countryId", locations.CountryId);
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

            string sql = "DELETE FROM LOCATIONS WHERE ID = @id";
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

        public Locations GetById(int id)
        {
            var loc = new Locations();

            var dBConnection = DBConnection.Get();

            string sql = "SELECT * FROM LOACATIONS WHERE ID = @id";
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
                    loc.Id = reader.GetInt32(0);
                    loc.StreetAddress = reader.GetString(1);
                    loc.PostalCode = reader.GetString(2);
                    loc.City = reader.GetString(3);
                    loc.StateProvince = reader.GetString(4);
                    loc.CountryId = reader.GetString(5);
                }

                reader.Close();
                dBConnection.Close();

                return new Locations();
            }
            catch
            {
                return new Locations();
            }
        }

    }
}
