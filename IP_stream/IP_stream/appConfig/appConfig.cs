using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace IP_stream
{
    public static class appConfig
    {
        public  static string GetConnectionStringsConfig(string connectionName)
        {
            string connectionString =
                    ConfigurationManager.ConnectionStrings[connectionName].ConnectionString.ToString();
            //Console.WriteLine(connectionString);
            return connectionString;
        }
        public static void SaveConnectionString(string name, string connectionString)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.ConnectionStrings.ConnectionStrings[name] == null)
            {
                config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings(name, connectionString));
            }
            else
            {
                config.ConnectionStrings.ConnectionStrings[name].ConnectionString = connectionString;
            }
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");

        }
 
    }
}
