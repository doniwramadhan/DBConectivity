using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DBConnectivity.Repository
{
    public interface IRegionsRepository
    {
        public void GetRegion();
        public void InsertRegion(string Name);
        public void UpdateRegion(int Id, string Name);
        public void DeleteRegions(int Id);
        public void FindRegions(int Id);
    }
}
