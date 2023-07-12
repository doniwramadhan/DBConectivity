using DBConnectivity.Repository;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace DBConnectivity
{
    public class Program
    {
        private static RegionsRepository _reg;
        private static CountriesRepository _cour;
        private static LocationsRepository _loc;
        private static DepartmentRepository _dep;
        private static JobRepository _job;
        private static EmployeeRepository _emp;
        private static HistoriesRepository _his;

        public static void Main(string[] args)
        {
            

            _reg = new RegionsRepository();
            _cour = new CountriesRepository();
            _loc = new LocationsRepository();
            _dep = new DepartmentRepository();
            _job = new JobRepository();
            _emp = new EmployeeRepository();
            _his = new HistoriesRepository();


            MainMenu();

        }

        private static void MainMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Regions Menu:");
                Console.WriteLine("1. Regions");
                Console.WriteLine("2. Countries");
                Console.WriteLine("3. Locations");
                Console.WriteLine("4. Departments");
                Console.WriteLine("5. Jobs");
                Console.WriteLine("6. Employees");
                Console.WriteLine("7. Histories");

                Console.WriteLine("0. Exit");
                string menuOption = Console.ReadLine();

                Console.WriteLine();

                switch (menuOption)
                {
                    case "1":
                        Regions();
                        break;
                    case "2":
                        Countries();
                        break;
                    case "3":
                        Locations();
                        break;
                    case "4":
                        Departments();
                        break;
                    case "5":
                        Jobs();
                        break;
                    case "6":
                        Employees();
                        break;
                    case "7":
                        Histories();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Your option is not valid");
                        break;
                }

                Console.WriteLine();

            }
        }
        private static void Regions()
        {
            Console.WriteLine("Regions Menu:");
            Console.WriteLine("1. Show All Regions");
            Console.WriteLine("2. Insert Regions");
            Console.WriteLine("3. Update Regions");
            Console.WriteLine("4. Delete Regions");
            Console.WriteLine("5. Find Regions by Id");
            Console.WriteLine("6. Back");
            string menuOption = Console.ReadLine();

            Console.WriteLine();

            switch (menuOption)
            {
                case "1":
                    _reg.GetRegion();
                    Regions();
                    break;
                case "2":
                    InsertRegion();
                    Regions();
                    break;
                case "3":
                    UpdateRegion();
                    Regions();
                    break;
                case "4":
                    DeleteRegion();
                    Regions();
                    break;
                case "5":
                    FindRegionById();
                    Regions();
                    break;
                case "6":
                    break;
                default:
                    Console.WriteLine("Your option is not valid");
                    break;
            }
        }

       
        private static void Countries()
        {
            Console.WriteLine("Countries Menu:");
            Console.WriteLine("1. Show All Countries");
            Console.WriteLine("2. Insert Countries");
            Console.WriteLine("3. Update Countries");
            Console.WriteLine("4. Delete Countries");
            Console.WriteLine("5. Find Countries by Id");
            Console.WriteLine("6. Back");
            string menuOption = Console.ReadLine();

            Console.WriteLine();

            switch (menuOption)
            {
                case "1":
                    _cour.GetCountries();
                    Countries();
                    break;
                case "2":
                    InsertCountries();
                    Countries();
                    break;
                case "3":
                    UpdateCountries();
                    Countries();
                    break;
                case "4":
                    DeleteCountries();
                    Countries();
                    break;
                case "5":
                    FindCountries();
                    Countries();
                    break;
                case "6":
                    break;
                default:
                    Console.WriteLine("Your option is not valid");
                    break;
            }
        }
        private static void Locations()
        {
            Console.WriteLine("Locations Menu:");
            Console.WriteLine("1. Show All Locations");
            Console.WriteLine("2. Insert Locations");
            Console.WriteLine("3. Update Locations");
            Console.WriteLine("4. Delete Locations");
            Console.WriteLine("5. Find Locations by Id");
            Console.WriteLine("6. Back");
            string menuOption = Console.ReadLine();

            Console.WriteLine();

            switch (menuOption)
            {
                case "1":
                    _loc.GetLocation();
                    Locations();
                    break;
                case "2":
                    InsertLocation();
                    Locations();
                    break;
                case "3":
                    UpdateLocation();
                    Locations();
                    break;
                case "4":
                    DeleteLocation();
                    Locations();
                    break;
                case "5":
                    FindLocation();
                    Locations();
                    break;
                case "6":
                    break;
                default:
                    Console.WriteLine("Your option is not valid");
                    break;
            }
        }

        private static void Departments()
        {
            Console.WriteLine("Departments Menu:");
            Console.WriteLine("1. Show All Departments");
            Console.WriteLine("2. Insert Departments");
            Console.WriteLine("3. Update Departments");
            Console.WriteLine("4. Delete Departments");
            Console.WriteLine("5. Find Departments by Id");
            Console.WriteLine("6. Back");
            string menuOption = Console.ReadLine();

            Console.WriteLine();

            switch (menuOption)
            {
                case "1":
                    _dep.GetDepartment();
                    Departments();
                    break;
                case "2":
                    InsertDepartment();
                    Departments();
                    break;
                case "3":
                    UpdateDepartment();
                    Departments();
                    break;
                case "4":
                    DeleteDepartment();
                    Departments();
                    break;
                case "5":
                    FindDepartment();
                    Departments();
                    break;
                case "6":
                    break;
                default:
                    Console.WriteLine("Your option is not valid");
                    break;
            }
        }

        private static void Jobs()
        {
            Console.WriteLine("Jobs Menu:");
            Console.WriteLine("1. Show All Jobs");
            Console.WriteLine("2. Insert Jobs");
            Console.WriteLine("3. Update Jobs");
            Console.WriteLine("4. Delete Jobs");
            Console.WriteLine("5. Find Jobs by Id");
            Console.WriteLine("6. Back");
            string menuOption = Console.ReadLine();

            Console.WriteLine();

            switch (menuOption)
            {
                case "1":
                    _job.GetJob();
                    Jobs();
                    break;
                case "2":
                    InsertJob();
                    Jobs();
                    break;
                case "3":
                    UpdateJob();
                    Jobs();
                    break;
                case "4":
                    DeleteJob();
                    Jobs();
                    break;
                case "5":
                    FindJob();
                    Jobs();
                    break;
                case "6":
                    break;
                default:
                    Console.WriteLine("Your option is not valid");
                    break;
            }
        }

        private static void Employees()
        {
            Console.WriteLine("Employees Menu:");
            Console.WriteLine("1. Show All Employees");
            Console.WriteLine("2. Insert Employees");
            Console.WriteLine("3. Update Employeess");
            Console.WriteLine("4. Delete Employees");
            Console.WriteLine("5. Find Employees by Id");
            Console.WriteLine("6. Back");
            string menuOption = Console.ReadLine();

            Console.WriteLine();

            switch (menuOption)
            {
                case "1":
                    _emp.GetEmployee();
                    Employees();
                    break;
                case "2":
                    InsertEmployee();
                    Employees();
                    break;
                case "3":
                    UpdateEmployee();
                    Employees();
                    break;
                case "4":
                    DeleteEmployee();
                    Employees();
                    break;
                case "5":
                    FindEmployee();
                    Employees();
                    break;
                case "6":
                    break;
                default:
                    Console.WriteLine("Your option is not valid");
                    break;
            }
        }

        private static void Histories()
        {
            Console.WriteLine("Histories Menu:");
            Console.WriteLine("1. Show All Histories");
            Console.WriteLine("2. Insert Histories");
            Console.WriteLine("3. Update Histories");
            Console.WriteLine("4. Delete Histories");
            Console.WriteLine("5. Find Histories by Id");
            Console.WriteLine("6. Back");
            string menuOption = Console.ReadLine();

            Console.WriteLine();

            switch (menuOption)
            {
                case "1":
                    _his.GetHistory();
                    Histories();
                    break;
                case "2":
                    InsertHistory();
                    Histories();
                    break;
                case "3":
                    UpdateHistory();
                    Histories();
                    break;
                case "4":
                    DeleteHistory();
                    Histories();
                    break;
                case "5":
                    FindHistory();
                    Histories();
                    break;
                case "6":
                    break;
                default:
                    Console.WriteLine("Your option is not valid");
                    break;
            }
        }

        //======================== REGIONS ==============================
        public static void InsertRegion()
        {
            Console.WriteLine("Enter Regions name : ");
            string Name = Console.ReadLine();

            _reg.InsertRegion(Name);
        }

        public static void UpdateRegion()
        {
            Console.WriteLine("Enter ID you want to edit: ");
            int regionId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter new region name: ");
            string newRegionName = Console.ReadLine();

            _reg.UpdateRegion(regionId,newRegionName);
        }

        public static void DeleteRegion()
        {
            Console.WriteLine("Enter ID you want to delete: ");
            int regionId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Are you sure want to delete this {regionId}? (y/n)");
            string confirm = Console.ReadLine();

            if(confirm.ToLower() == "y")
            {
                _reg.DeleteRegions(regionId);
            }
            else
            {
                Console.WriteLine("Cancel delete");
            }
        }

        public static void FindRegionById()
        {
            Console.WriteLine("Enter ID you want to find: ");
            int regionId = Convert.ToInt32(Console.ReadLine());
            _reg.FindRegions(regionId);
        }

        //======================== COUNTRIES ==============================
        public static void InsertCountries()
        {
            Console.WriteLine("Enter ID you want to add: ");
            int courId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Regions name : ");
            string Name = Console.ReadLine();
            Console.WriteLine("Enter Regions Id you want to add: ");
            int regionId = Convert.ToInt32(Console.ReadLine());

            _cour.InsertCountries(courId, Name, regionId);
        }

        public static void UpdateCountries()
        {
            Console.WriteLine("Enter ID you want to edit: ");
            int courId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter new region name: ");
            string newCountriesName = Console.ReadLine();
            Console.WriteLine("Enter Regions ID you want to edit: ");
            int newRegionId = Convert.ToInt32(Console.ReadLine());

            _cour.UpdateCountries(courId, newCountriesName, newRegionId);
        }

        public static void DeleteCountries()
        {
            Console.WriteLine("Enter ID you want to delete: ");
            int courId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Are you sure want to delete this {courId}? (y/n)");
            string confirm = Console.ReadLine();

            if (confirm.ToLower() == "y")
            {
                _cour.DeleteCountries(courId);
            }
            else
            {
                Console.WriteLine("Cancel delete");
            }
        }

        public static void FindCountries()
        {
            Console.WriteLine("Enter ID you want to find: ");
            int courId = Convert.ToInt32(Console.ReadLine());
            _cour.FindCountries(courId);
        }

        //======================== LOCATIONS ==============================

        public static void InsertLocation()
        {
            Console.WriteLine("Enter ID you want to add: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Street Address : ");
            string streetAddress = Console.ReadLine();
            Console.WriteLine("Enter Postal Code : ");
            string postalCode = Console.ReadLine();
            Console.WriteLine("Enter City : ");
            string city = Console.ReadLine();
            Console.WriteLine("Enter State Province : ");
            string stateProvince = Console.ReadLine();
            Console.WriteLine("Enter Country Id : ");
            string countryId = Console.ReadLine();

            _loc.InsertLocation(id, streetAddress, postalCode, city, stateProvince, countryId);
        }

        public static void UpdateLocation()
        {
            Console.WriteLine("Enter ID you want to edit: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Street Address : ");
            string streetAddress = Console.ReadLine();
            Console.WriteLine("Enter Postal Code : ");
            string postalCode = Console.ReadLine();
            Console.WriteLine("Enter City : ");
            string city = Console.ReadLine();
            Console.WriteLine("Enter State Province : ");
            string stateProvince = Console.ReadLine();
            Console.WriteLine("Enter Country Id : ");
            string countryId = Console.ReadLine();

            _loc.UpdateLocation(id,streetAddress, postalCode, city, stateProvince, countryId);
        }

        public static void DeleteLocation()
        {
            Console.WriteLine("Enter ID you want to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Are you sure want to delete this {id}? (y/n)");
            string confirm = Console.ReadLine();

            if (confirm.ToLower() == "y")
            {
                _loc.DeleteLocation(id);
            }
            else
            {
                Console.WriteLine("Cancel delete");
            }
        }

        public static void FindLocation()
        {
            Console.WriteLine("Enter ID you want to find: ");
            int id = Convert.ToInt32(Console.ReadLine());
            _loc.FindLocation(id);
        }

        //======================== DEPARTMENTS ==============================

        public static void InsertDepartment()
        {
            Console.WriteLine("Enter ID you want to add: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Department Name : ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Location Id : ");
            int locationId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Manager Id : ");
            int managerId = Convert.ToInt32(Console.ReadLine());

            _dep.InsertDepartment(id, name, locationId, managerId);
        }

        public static void UpdateDepartment()
        {
            Console.WriteLine("Enter ID you want to edit: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Department Name : ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Location Id : ");
            int locationId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Manager Id : ");
            int managerId = Convert.ToInt32(Console.ReadLine());

            _dep.UpdateDepartment(id, name, locationId, managerId);
        }

        public static void DeleteDepartment()
        {
            Console.WriteLine("Enter ID you want to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Are you sure want to delete this {id}? (y/n)");
            string confirm = Console.ReadLine();

            if (confirm.ToLower() == "y")
            {
                _dep.DeleteDepartment(id);
            }
            else
            {
                Console.WriteLine("Cancel delete");
            }
        }

        public static void FindDepartment()
        {
            Console.WriteLine("Enter ID you want to find: ");
            int id = Convert.ToInt32(Console.ReadLine());
            _dep.FindDepartment(id);
        }

        //======================== JOBS ==============================
        public static void InsertJob()
        {
            Console.WriteLine("Enter ID you want to add: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Job Title name : ");
            string title = Console.ReadLine();
            Console.WriteLine("Enter Min salary: ");
            int minSalary = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Max salary: ");
            int maxSalary = Convert.ToInt32(Console.ReadLine());

            _job.InsertJob(id,title,minSalary,maxSalary);
        }

        public static void UpdateJob()
        {
            Console.WriteLine("Enter ID you want to edit: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Job Title name : ");
            string title = Console.ReadLine();
            Console.WriteLine("Enter Min salary: ");
            int minSalary = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Max salary: ");
            int maxSalary = Convert.ToInt32(Console.ReadLine());

            _job.UpdateJob(id, title, minSalary, maxSalary);
        }

        public static void DeleteJob()
        {
            Console.WriteLine("Enter ID you want to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Are you sure want to delete this {id}? (y/n)");
            string confirm = Console.ReadLine();

            if (confirm.ToLower() == "y")
            {
                _job.DeleteJob(id);
            }
            else
            {
                Console.WriteLine("Cancel delete");
            }
        }

        public static void FindJob()
        {
            Console.WriteLine("Enter ID you want to find: ");
            int id = Convert.ToInt32(Console.ReadLine());
            _job.FindJob(id);
        }


        //======================== EMPLOYEES ==============================
        public static void InsertEmployee()
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

            DateOnly date;

            if (DateOnly.TryParseExact(hireDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
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

            _emp.InsertEmployee(id, firstName, lastName, email, phoneNumber, hireDate, salary, comission, managerId, jobId, departmentId);
        }

        public static void UpdateEmployee()
        {
            Console.WriteLine("Enter ID you want to edit: ");
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

            DateOnly date;

            if (DateOnly.TryParseExact(hireDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
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

            _emp.UpdateEmployee(id, firstName, lastName, email, phoneNumber, hireDate, salary, comission, managerId, jobId, departmentId);
        }

        public static void DeleteEmployee()
        {
            Console.WriteLine("Enter ID you want to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Are you sure want to delete this {id}? (y/n)");
            string confirm = Console.ReadLine();

            if (confirm.ToLower() == "y")
            {
                _emp.DeleteEmployee(id);
            }
            else
            {
                Console.WriteLine("Cancel delete");
            }
        }

        public static void FindEmployee()
        {
            Console.WriteLine("Enter ID you want to find: ");
            int id = Convert.ToInt32(Console.ReadLine());
            _emp.FindEmployee(id);
        }

        //======================== HISTORIES ==============================
        public static void InsertHistory()
        {
            Console.WriteLine("Enter Start Date (Format: yyyy-MM-dd): ");
            string hireDate = Console.ReadLine();

            DateOnly date;

            if (DateOnly.TryParseExact(hireDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
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

            if (DateOnly.TryParseExact(endDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
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

            _his.InsertHistory(hireDate,employeeId,endDate,departmentId,jobId);
        }

        public static void UpdateHistory()
        {
            Console.WriteLine("Enter Start Date (Format: yyyy-MM-dd): ");
            string hireDate = Console.ReadLine();

            DateOnly date;

            if (DateOnly.TryParseExact(hireDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
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

            if (DateOnly.TryParseExact(endDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
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

            _his.InsertHistory(hireDate, employeeId, endDate, departmentId, jobId);
        }

        public static void DeleteHistory()
        {
            Console.WriteLine("Enter ID you want to delete: ");
            int employeeId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Are you sure want to delete this {employeeId}? (y/n)");
            string confirm = Console.ReadLine();

            if (confirm.ToLower() == "y")
            {
                _his.DeleteHistory(employeeId);
            }
            else
            {
                Console.WriteLine("Cancel delete");
            }
        }

        public static void FindHistory()
        {
            Console.WriteLine("Enter ID you want to find: ");
            int employeeId = Convert.ToInt32(Console.ReadLine());
            _his.FindHistory(employeeId);
        }
    }
}   

