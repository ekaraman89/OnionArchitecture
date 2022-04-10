using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace OnionArchitecture.Persistance
{
    static class Configuration
    {
        public static string GetConnectionString
        {
            get
            {
                ConfigurationManager manager = new ConfigurationManager();
                manager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/OnionArchitecture.API"));
                manager.AddJsonFile("appsettings.json");
                return manager.GetConnectionString("PostgreSQL");
            }
        }
    }
}
