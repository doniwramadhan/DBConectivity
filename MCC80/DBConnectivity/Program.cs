using DBConnectivity.Interface;
using DBConnectivity.Repository;
using DBConnectivity.View;
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
     
        public static void Main(string[] args)
        {
             DBView dbView = new DBView();

             dbView.MainMenu();

            
        }

        
    }
}   

