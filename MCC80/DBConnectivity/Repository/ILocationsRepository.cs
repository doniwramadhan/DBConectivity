using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnectivity.Repository
{
    public interface ILocationsRepository
    {
        public void GetLocation();
        public void InsertLocation(int id, string streetAddress, string postalCode, string city, string stateProvince, string countryId);
        public void UpdateLocation(int id, string streetAddress, string postalCode, string city, string stateProvince, string countryId);
        public void DeleteLocation(int id);
        public void FindLocation(int id);
    }
}
