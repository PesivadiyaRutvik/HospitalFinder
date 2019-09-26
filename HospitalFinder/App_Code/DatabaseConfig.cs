using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;

public static class DatabaseConfig
{
    public static string ConnectionString = ConfigurationManager.ConnectionStrings["HospitalFinderConnectionString"].ConnectionString;
}