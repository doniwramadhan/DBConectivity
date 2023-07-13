using DBRefactoring.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRefactoring.View
{
    public class VLocations
    {
        public void DataEmpty()
        {
            Console.WriteLine("Data Not Found!");
        }

        public void Success()
        {
            Console.WriteLine("Success!");
        }

        public void Failure()
        {
            Console.WriteLine("Fail, Id not found!");
        }

        public void Error()
        {
            Console.WriteLine("Error retrieving from database!");
        }

        public int Menu()
        {
            Console.WriteLine("== Menu Locations ==");
            Console.WriteLine("1. Tambah");
            Console.WriteLine("2. Update");
            Console.WriteLine("3. Hapus");
            Console.WriteLine("4. Search By Id");
            Console.WriteLine("5. Get All");
            Console.WriteLine("6. Main Menu");
            Console.WriteLine("Pilih: ");

            int input = Int32.Parse(Console.ReadLine());
            return input;
        }

        public void GetAll(List<Locations> locations)
        {
            foreach (var loc in locations)
            {
                GetById(loc);
            }
        }

        public void GetById(Locations locations)
        {
            Console.WriteLine("Id: " + locations.Id);
            Console.WriteLine("Street Address: " + locations.StreetAddress);
            Console.WriteLine("Postal Code: " + locations.PostalCode);
            Console.WriteLine("City: " + locations.City);
            Console.WriteLine("State Province: " + locations.StateProvince);
            Console.WriteLine("Country Id: " + locations.CountryId);
            Console.WriteLine("==========================");
        }

        public Locations InsertMenu()
        {
            Console.WriteLine("Masukan Locations Id : ");
            int inputLocationId = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Masukan Street Adress :");
            string? streetAddress = Console.ReadLine();
            Console.WriteLine("Masukan Postal Code :");
            string? postalCode = Console.ReadLine();
            Console.WriteLine("Masukan City :");
            string? city = Console.ReadLine();
            Console.WriteLine("Masukan State Province :");
            string? stateProvince = Console.ReadLine();
            Console.WriteLine("Masukan Country Id :");
            string? countryId = Console.ReadLine();

            return new Locations
            {
                Id = inputLocationId,
                StreetAddress = streetAddress,
                PostalCode = postalCode,
                City = city,
                StateProvince = stateProvince,
                CountryId = countryId
            };
        }

        public Locations UpdateMenu()
        {
            Console.WriteLine("Masukan Locations Id : ");
            int inputLocationId = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Masukan Street Adress :");
            string? streetAddress = Console.ReadLine();
            Console.WriteLine("Masukan Postal Code :");
            string? postalCode = Console.ReadLine();
            Console.WriteLine("Masukan City :");
            string? city = Console.ReadLine();
            Console.WriteLine("Masukan State Province :");
            string? stateProvince = Console.ReadLine();
            Console.WriteLine("Masukan Country Id :");
            string? countryId = Console.ReadLine();

            return new Locations
            {
                Id = inputLocationId,
                StreetAddress = streetAddress,
                PostalCode = postalCode,
                City = city,
                StateProvince = stateProvince,
                CountryId = countryId
            };
        }

        public int LocationsId()
        {
            Console.WriteLine("Masukan id yang dibutuhkan:");
            int inputId = Int32.Parse(Console.ReadLine());

            return inputId;
        }

    }
}
