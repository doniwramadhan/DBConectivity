using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnectivity.Repository
{
    public interface IJobsRepository
    {
        public void GetJob();
        public void InsertJob(int id, string title, int minSalary, int maxSalary);
        public void UpdateJob(int id, string title, int minSalary, int maxSalary);
        public void DeleteJob(int id);
        public void FindJob(int id);
    }
}
