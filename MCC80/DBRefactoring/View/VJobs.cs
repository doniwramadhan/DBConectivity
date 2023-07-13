using DBRefactoring.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRefactoring.View
{
    public class VJobs
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
            Console.WriteLine("== Menu Jobs ==");
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

        public void GetAll(List<Jobs> jobs)
        {
            foreach (var job in jobs)
            {
                GetById(job);
            }
        }

        public void GetById(Jobs jobs)
        {
            Console.WriteLine("Id: " + jobs.Id);
            Console.WriteLine("Jobs title: " + jobs.Title);
            Console.WriteLine("Minimal salary: " + jobs.MinSalary);
            Console.WriteLine("Maximal salary: " + jobs.MaxSalary);
            Console.WriteLine("==========================");
        }

        public Jobs InsertMenu()
        {
            Console.WriteLine("Masukan Jobs Id : ");
            string? jobId = Console.ReadLine();
            Console.WriteLine("Masukan Job Title :");
            string? jobTitle = Console.ReadLine();
            Console.WriteLine("Masukan Minimal salary :");
            int minsalary = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Masukan Maximal salary :");
            int maxsalary = Int32.Parse(Console.ReadLine());


            return new Jobs
            {
                Id = jobId,
                Title = jobTitle,
                MinSalary =  minsalary,
                MaxSalary = maxsalary
            };
        }

        public Jobs UpdateMenu()
        {
            Console.WriteLine("Masukan Jobs Id : ");
            string? jobId = Console.ReadLine();
            Console.WriteLine("Masukan Job Title :");
            string? jobTitle = Console.ReadLine();
            Console.WriteLine("Masukan Minimal salary :");
            int minsalary = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Masukan Maximal salary :");
            int maxsalary = Int32.Parse(Console.ReadLine());


            return new Jobs
            {
                Id = jobId,
                Title = jobTitle,
                MinSalary = minsalary,
                MaxSalary = maxsalary
            };
        }

        public int JobsId()
        {
            Console.WriteLine("Masukan id yang dibutuhkan:");
            int inputId = Int32.Parse(Console.ReadLine());

            return inputId;
        }
    }
}
