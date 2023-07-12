using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnectivity.Repository
{
    public interface IHistoriesRepository
    {
        public void GetHistory();
        public void InsertHistory(string startDate, int employeeId, string endDate, int departmentId, string jobI);
        public void UpdateHistory(string startDate, int employeeId, string endDate, int departmentId, string jobId);
        public void DeleteHistory(int id);
        public void FindHistory(int id);
    }
}
