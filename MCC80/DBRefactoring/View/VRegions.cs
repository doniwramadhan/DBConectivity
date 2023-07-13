using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBRefactoring.Model;

namespace DBRefactoring.View
{
    public class VRegions
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
            Console.WriteLine("== Menu Regions ==");
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

        public void GetAll(List<Regions> regions)
        {
            foreach (var region in regions)
            {
                GetById(region);
            }
        }

        public void GetById(Regions regions)
        {
            Console.WriteLine("Id: " + regions.Id);
            Console.WriteLine("Name: " + regions.Name);
            Console.WriteLine("==========================");
        }

        public Regions InsertMenu()
        {
            Console.WriteLine("Masukan nama regions :");
            string? inputName = Console.ReadLine();
            return new Regions
            {
                Id = 0,
                Name = inputName
            };
        }

        public Regions UpdateMenu()
        {
            Console.WriteLine("Masukan id yang dibutuhkan:");
            int inputId = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Masukan nama regions :");
            string? inputName = Console.ReadLine();
            return new Regions
            {
                Id = inputId,
                Name = inputName
            };
        }

        public int RegionsId()
        {
            Console.WriteLine("Masukan id yang dibutuhkan:");
            int inputId = Int32.Parse(Console.ReadLine());

            return inputId;
        }


    }
}
