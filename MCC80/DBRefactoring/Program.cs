using DBRefactoring.Controller;
using System.Security.Cryptography.X509Certificates;
using DBRefactoring.View;
using DBRefactoring.Model;
using DBRefactoring.Controller;

namespace DBRefactoring
{
    internal class Program
    {

        public static void Main(string[] args)
        {
            MainMenu();
        }

        public static void MainMenu()
        {
            bool ulang = true;

            do
            {
                Console.WriteLine("Pilih menu untuk masuk ke menunya");
                Console.WriteLine("1. Regions");
                Console.WriteLine("2. Countries");
                Console.WriteLine("3. Locations");
                Console.WriteLine("4. Departments");
                Console.WriteLine("5. Jobs");
                Console.WriteLine("6. Employees");
                Console.WriteLine("7. Histories");
                Console.WriteLine("8. Exit");
                Console.WriteLine("Pilih: ");

                try
                {
                    int pilihMenu = Int32.Parse(Console.ReadLine());

                    switch (pilihMenu)
                    {
                        case 1:
                            RegionMenu();
                            break;
                        case 2:
                            CountryMenu();
                            break;
                        case 3:
                            LocationsMenu();
                            break;
                        case 4:
                            DepartmentsMenu();
                            break;
                        case 5:
                            JobsMenu();
                            break;
                        case 6:
                            EmployeesMenu();
                            break;
                        case 7:
                            HistoryMenu();
                            break;
                        case 8:
                            ulang = false;
                            break;
                        default:
                            Console.WriteLine("Silahkan Pilih Nomor 1-7");
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Input Hanya diantara 1-7!");
                }
            } while (ulang);
        }

        private static void RegionMenu()
        {
            Regions region = new Regions();
            VRegions vRegion = new VRegions();
            RegionsController regionController = new RegionsController(region, vRegion);

            bool isTrue = true;
            do
            {
                int pilihMenu = vRegion.Menu();
                switch (pilihMenu)
                {
                    case 1:
                        regionController.Insert();
                        PressAnyKey();
                        break;
                    case 2:
                        regionController.Update();
                        PressAnyKey();
                        break;
                    case 3:
                        regionController.Delete();
                        PressAnyKey();
                        break;
                    case 4:
                        regionController.GetById();
                        PressAnyKey();
                        break;
                    case 5:
                        regionController.GetAll();
                        PressAnyKey();
                        break;
                    case 6:
                        isTrue = false;
                        break;
                    default:
                        InvalidInput();
                        break;
                }
            } while (isTrue);
        }

        private static void CountryMenu()
        {
            Country country = new Country();
            VCountry vCountry = new VCountry();
            CountryController countryController = new CountryController(country, vCountry);

            bool isTrue = true;
            do
            {
                int pilihMenu = vCountry.Menu();
                switch (pilihMenu)
                {
                    case 1:
                        countryController.Insert();
                        PressAnyKey();
                        break;
                    case 2:
                        countryController.Update();
                        PressAnyKey();
                        break;
                    case 3:
                        countryController.Delete();
                        PressAnyKey();
                        break;
                    case 4:
                        countryController.GetById();
                        PressAnyKey();
                        break;
                    case 5:
                        countryController.GetAll();
                        PressAnyKey();
                        break;
                    case 6:
                        isTrue = false;
                        break;
                    default:
                        InvalidInput();
                        break;
                }
            } while (isTrue);
        }

        private static void LocationsMenu()
        {
            Locations locations = new Locations();
            VLocations vLocations = new VLocations();
            LocationsController locationsController = new LocationsController(locations, vLocations);

            bool isTrue = true;
            do
            {
                int pilihMenu = vLocations.Menu();
                switch (pilihMenu)
                {
                    case 1:
                        locationsController.Insert();
                        PressAnyKey();
                        break;
                    case 2:
                        locationsController.Update();
                        PressAnyKey();
                        break;
                    case 3:
                        locationsController.Delete();
                        PressAnyKey();
                        break;
                    case 4:
                        locationsController.GetById();
                        PressAnyKey();
                        break;
                    case 5:
                        locationsController.GetAll();
                        PressAnyKey();
                        break;
                    case 6:
                        isTrue = false;
                        break;
                    default:
                        InvalidInput();
                        break;
                }
            } while (isTrue);
        }

        private static void DepartmentsMenu()
        {
            Department dep = new Department();
            VDepartment vDep = new VDepartment();
            DepartmentController depController = new DepartmentController(dep, vDep);

            bool isTrue = true;
            do
            {
                int pilihMenu = vDep.Menu();
                switch (pilihMenu)
                {
                    case 1:
                        depController.Insert();
                        PressAnyKey();
                        break;
                    case 2:
                        depController.Update();
                        PressAnyKey();
                        break;
                    case 3:
                        depController.Delete();
                        PressAnyKey();
                        break;
                    case 4:
                        depController.GetById();
                        PressAnyKey();
                        break;
                    case 5:
                        depController.GetAll();
                        PressAnyKey();
                        break;
                    case 6:
                        isTrue = false;
                        break;
                    default:
                        InvalidInput();
                        break;
                }
            } while (isTrue);
        }

        private static void JobsMenu()
        {
            Jobs jobs = new Jobs();
            VJobs vJobs = new VJobs();
            JobsController jobsController = new JobsController(jobs, vJobs);

            bool isTrue = true;
            do
            {
                int pilihMenu = vJobs.Menu();
                switch (pilihMenu)
                {
                    case 1:
                        jobsController.Insert();
                        PressAnyKey();
                        break;
                    case 2:
                        jobsController.Update();
                        PressAnyKey();
                        break;
                    case 3:
                        jobsController.Delete();
                        PressAnyKey();
                        break;
                    case 4:
                        jobsController.GetById();
                        PressAnyKey();
                        break;
                    case 5:
                        jobsController.GetAll();
                        PressAnyKey();
                        break;
                    case 6:
                        isTrue = false;
                        break;
                    default:
                        InvalidInput();
                        break;
                }
            } while (isTrue);
        }

        private static void EmployeesMenu()
        {
            Employees emp = new Employees();
            VEmployees vEmp = new VEmployees();
            EmployeesController empController = new EmployeesController(emp, vEmp);

            bool isTrue = true;
            do
            {
                int pilihMenu = vEmp.Menu();
                switch (pilihMenu)
                {
                    case 1:
                        empController.Insert();
                        PressAnyKey();
                        break;
                    case 2:
                        empController.Update();
                        PressAnyKey();
                        break;
                    case 3:
                        empController.Delete();
                        PressAnyKey();
                        break;
                    case 4:
                        empController.GetById();
                        PressAnyKey();
                        break;
                    case 5:
                        empController.GetAll();
                        PressAnyKey();
                        break;
                    case 6:
                        isTrue = false;
                        break;
                    default:
                        InvalidInput();
                        break;
                }
            } while (isTrue);
        }

        private static void HistoryMenu()
        {
            History his = new History();
            VHistories vHis = new VHistories();
            HistoryController hisController = new HistoryController(his, vHis);

            bool isTrue = true;
            do
            {
                int pilihMenu = vHis.Menu();
                switch (pilihMenu)
                {
                    case 1:
                        hisController.Insert();
                        PressAnyKey();
                        break;
                    case 2:
                        hisController.Update();
                        PressAnyKey();
                        break;
                    case 3:
                        hisController.Delete();
                        PressAnyKey();
                        break;
                    case 4:
                        hisController.GetById();
                        PressAnyKey();
                        break;
                    case 5:
                        hisController.GetAll();
                        PressAnyKey();
                        break;
                    case 6:
                        isTrue = false;
                        break;
                    default:
                        InvalidInput();
                        break;
                }
            } while (isTrue);
        }
        private static void InvalidInput()
        {
            Console.WriteLine("Your input is not valid!");
        }

        private static void PressAnyKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}