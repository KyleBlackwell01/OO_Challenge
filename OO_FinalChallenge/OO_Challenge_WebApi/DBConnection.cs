using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace OO_Challenge_WebApi
{
    public static class DBConnection
    {

        public static SqlConnection GetConnection()
        {
            string connString = @"Server=tcp:civapi.database.windows.net,1433;Database=civapi;User ID =civ_user; Password=Monday1330;";
            return new SqlConnection(connString);
        }


    }
}