using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnectivity.Interface
{
    public interface ICountriesRepository
    {
        public void GetCountries();
        public void InsertCountries(int Id, string Name, int RegionId);
        public void UpdateCountries(int Id, string Name, int RegionId);
        public void DeleteCountries(int Id);
        public void FindCountries(int Id);
    }
}
