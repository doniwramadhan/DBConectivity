using DBRefactoring.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRefactoring.View
{
    public class VHistories
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
            Console.WriteLine("== Menu Histories ==");
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

        public void GetAll(List<History> history)
        {
            foreach (var his in history)
            {
                GetById(his);
            }
        }

        public void GetById(History history)
        {
            Console.WriteLine("Start date: " + history.StartDate);
            Console.WriteLine("Employee Id: " + history.EmployeeId);
            Console.WriteLine("End Date: " + history.EndDate);
            Console.WriteLine("Department Id: " + history.DepartmentId);
            Console.WriteLine("Job Id: " + history.JobId);
            Console.WriteLine("==========================");
        }

        public History InsertMenu()
        {
            Console.WriteLine("Enter Start Date (Format: yyyy-MM-dd): ");
            string hireDate = Console.ReadLine();

            DateTime date;

            if (DateTime.TryParseExact(hireDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                Console.WriteLine("Input date: " + date.ToString());
            }
            else
            {
                Console.WriteLine("Wrong date format");
            }

            Console.WriteLine("Enter Employee Id: ");
            int employeeId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter End Date(Format: yyyy-MM-dd):");
            string endDate = Console.ReadLine();

            if (DateTime.TryParseExact(endDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                Console.WriteLine("Input date: " + date.ToString());
            }
            else
            {
                Console.WriteLine("Wrong date format");
            }
            Console.WriteLine("Enter Department Id: ");
            int departmentId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Job Id: ");
            string jobId = Console.ReadLine();


            return new History
            {
                StartDate = date,
                EmployeeId = employeeId,
                EndDate = date,
                DepartmentId = departmentId,
                JobId = jobId,

            };
        }

        public History UpdateMenu()
        {
            Console.WriteLine("Enter Start Date (Format: yyyy-MM-dd): ");
            string hireDate = Console.ReadLine();

            DateTime date;

            if (DateTime.TryParseExact(hireDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                Console.WriteLine("Input date: " + date.ToString());
            }
            else
            {
                Console.WriteLine("Wrong date format");
            }

            Console.WriteLine("Enter Employee Id: ");
            int employeeId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter End Date(Format: yyyy-MM-dd):");
            string endDate = Console.ReadLine();

            if (DateTime.TryParseExact(endDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                Console.WriteLine("Input date: " + date.ToString());
            }
            else
            {
                Console.WriteLine("Wrong date format");
            }
            Console.WriteLine("Enter Department Id: ");
            int departmentId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Job Id: ");
            string jobId = Console.ReadLine();


            return new History
            {
                StartDate = date,
                EmployeeId = employeeId,
                EndDate = date,
                DepartmentId = departmentId,
                JobId = jobId,

            };
        }

        public int HistoryId()
        {
            Console.WriteLine("Masukan id yang dibutuhkan:");
            int inputId = Int32.Parse(Console.ReadLine());

            return inputId;
        }
    }
}
