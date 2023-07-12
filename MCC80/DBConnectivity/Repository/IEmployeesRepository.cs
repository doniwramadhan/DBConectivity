using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnectivity.Repository
{
    public interface IEmployeesRepository
    {
        public void GetEmployee();
        public void InsertEmployee(int id, string firstName, string lastName, string email, string phoneNumber, string hireDate, int salary, decimal commision, int managerId, string jobId, int departmenId);
        public void UpdateEmployee(int id, string firstName, string lastName, string email, string phoneNumber, string hireDate, int salary, decimal commision, int managerId, string jobId, int departmenId);
        public void DeleteEmployee(int id);
        public void FindEmployee(int id);
    }
}
