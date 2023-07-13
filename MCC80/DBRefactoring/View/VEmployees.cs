using DBRefactoring.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRefactoring.View
{
    public class VEmployees
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
            Console.WriteLine("== Menu Employees ==");
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

        public void GetAll(List<Employees> employees)
        {
            foreach (var emp in employees)
            {
                GetById(emp);
            }
        }

        public void GetById(Employees emp)
        {
            Console.WriteLine("Id: " + emp.Id);
            Console.WriteLine("First name: " + emp.FirstName);
            Console.WriteLine("Last name: " + emp.LastName);
            Console.WriteLine("Email : " + emp.Email);
            Console.WriteLine("Phone number: " + emp.PhoneNumber);
            Console.WriteLine("Hire date: " + emp.HireDate);
            Console.WriteLine("Salary: " + emp.Salary);
            Console.WriteLine("Comission: " + emp.Comission);
            Console.WriteLine("Manager Id: " + emp.ManagerId);
            Console.WriteLine("Job Id: " + emp.JobId);
            Console.WriteLine("Department Id: " + emp.DepartmentId);
            Console.WriteLine("==========================");
        }

        public Employees InsertMenu()
        {
            Console.WriteLine("Enter ID you want to add: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter First name : ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Last name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Phone number: ");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("Masukkan tanggal (Format: yyyy-MM-dd):");
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

            Console.WriteLine("Enter Salary: ");
            int salary = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Comission: ");
            int comission = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Manager Id: ");
            int managerId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Job Id: ");
            string jobId = Console.ReadLine();
            Console.WriteLine("Enter Department Id: ");
            int departmentId = Convert.ToInt32(Console.ReadLine());


            return new Employees
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                HireDate = date,
                Salary = salary,
                Comission = comission,
                ManagerId = managerId,
                JobId = jobId,
                DepartmentId = departmentId,

            };
        }

        public Employees UpdateMenu()
        {
            Console.WriteLine("Enter ID you want to add: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter First name : ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Last name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Phone number: ");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("Masukkan tanggal (Format: yyyy-MM-dd):");
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

            Console.WriteLine("Enter Salary: ");
            int salary = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Comission: ");
            int comission = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Manager Id: ");
            int managerId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Job Id: ");
            string jobId = Console.ReadLine();
            Console.WriteLine("Enter Department Id: ");
            int departmentId = Convert.ToInt32(Console.ReadLine());


            return new Employees
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                HireDate = date,
                Salary = salary,
                Comission = comission,
                ManagerId = managerId,
                JobId = jobId,
                DepartmentId = departmentId,

            };
        }

        public int EmployeesId()
        {
            Console.WriteLine("Masukan id yang dibutuhkan:");
            int inputId = Int32.Parse(Console.ReadLine());

            return inputId;
        }
    }
}
