using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnectivity.Interface
{
    public interface IDepartmentRepository
    {
        public void GetDepartment();
        public void InsertDepartment(int id, string name, int locationId, int managerId);
        public void UpdateDepartment(int id, string name, int locationId, int managerId);
        public void DeleteDepartment(int Id);
        public void FindDepartment(int Id);
    }
}
