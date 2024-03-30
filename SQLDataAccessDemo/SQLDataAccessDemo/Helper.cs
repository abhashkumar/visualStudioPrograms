using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace SQLDataAccessDemo
{
    public static class Helper
    {
        public static string getConnectionString()
        {
             // return ConfigurationManager.ConnectionStrings[name].ConnectionString;
             return @"Server = .\SQLEXPRESS; Database = master; Trusted_Connection = True;";
        }
    }
}
