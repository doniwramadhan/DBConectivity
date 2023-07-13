using DBRefactoring.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRefactoring.View
{
    public class VCountry
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
            Console.WriteLine("== Menu Countries ==");
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

        public void GetAll(List<Country> country)
        {
            foreach (var count in country)
            {
                GetById(count);
            }
        }

        public void GetById(Country country)
        {
            Console.WriteLine("Id: " + country.Id);
            Console.WriteLine("Name: " + country.Name);
            Console.WriteLine("Name: " + country.RegionId);
            Console.WriteLine("==========================");
        }

        public Country InsertMenu()
        {
            Console.WriteLine("Masukan Id country :");
            string? inputId = Console.ReadLine();
            Console.WriteLine("Masukan nama country :");
            string? inputName = Console.ReadLine();
            Console.WriteLine("Masukan Region Id : ");
            int inputRegionId = Int32.Parse(Console.ReadLine());
            return new Country
            {
                Id = inputId,
                Name = inputName,
                RegionId = inputRegionId
            };
        }

        public Country UpdateMenu()
        {
            Console.WriteLine("Masukan Id country :");
            string? inputId = Console.ReadLine();
            Console.WriteLine("Masukan nama country :");
            string? inputName = Console.ReadLine();
            Console.WriteLine("Masukan Region Id : ");
            int inputRegionId = Int32.Parse(Console.ReadLine());
            return new Country
            {
                Id = inputId,
                Name = inputName,
                RegionId = inputRegionId
            };
        }

        public int CountryId()
        {
            Console.WriteLine("Masukan id yang dibutuhkan:");
            int inputId = Int32.Parse(Console.ReadLine());

            return inputId;
        }

    }
}
