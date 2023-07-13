using DBRefactoring.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRefactoring.View
{
    public class VDepartment
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
            Console.WriteLine("== Menu Departments ==");
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

        public void GetAll(List<Department> departments)
        {
            foreach (var dep in departments)
            {
                GetById(dep);
            }
        }

        public void GetById(Department department)
        {
            Console.WriteLine("Id: " + department.Id);
            Console.WriteLine("Department name: " + department.Name);
            Console.WriteLine("Location Id: " + department.LocationId);
            Console.WriteLine("Manager Id: " + department.ManagerId);
            Console.WriteLine("==========================");
        }

        public Department InsertMenu()
        {
            Console.WriteLine("Masukan Department Id : ");
            int inputDepartmentId = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Masukan Department Name :");
            string? depName = Console.ReadLine();
            Console.WriteLine("Masukan Location Id :");
            int locationId = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Masukan Manager Id :");
            int managerId = Int32.Parse(Console.ReadLine());


            return new Department
            {
                Id = inputDepartmentId,
                Name = depName,
                LocationId = locationId,
                ManagerId = managerId
            };
        }

        public Department UpdateMenu()
        {
            Console.WriteLine("Masukan Department Id : ");
            int inputDepartmentId = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Masukan Department Name :");
            string? depName = Console.ReadLine();
            Console.WriteLine("Masukan Location Id :");
            int locationId = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Masukan Manager Id :");
            int managerId = Int32.Parse(Console.ReadLine());


            return new Department
            {
                Id = inputDepartmentId,
                Name = depName,
                LocationId = locationId,
                ManagerId = managerId
            };
        }

        public int DepartmentId()
        {
            Console.WriteLine("Masukan id yang dibutuhkan:");
            int inputId = Int32.Parse(Console.ReadLine());

            return inputId;
        }
    }
}
