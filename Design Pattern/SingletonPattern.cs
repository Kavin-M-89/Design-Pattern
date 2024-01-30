using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Design_Pattern
{
    public class SingletonPattern : IDesignPatten
    {
        //Here DB connection will be created only once
        public void Main()
        {
            Console.WriteLine(DateTime.Now.ToString());
            var con =  DBConnection.GetDBConnection();
            Console.WriteLine("DB connection created at " + con.ConnectedDateTime.ToString());
            Thread.Sleep(1000);
            Console.WriteLine(DateTime.Now.ToString());
            var con1 = DBConnection.GetDBConnection();
            Console.WriteLine("DB connection created at " + con1.ConnectedDateTime.ToString());
        }
    }

    public sealed class DBConnection
    {
        private static DBConnection dbConnection = null;
        public string ConnectionString;
        public DateTime ConnectedDateTime;
        private DBConnection()
        {
        }

        public static DBConnection GetDBConnection()
        {
            //want to use lock
            if (dbConnection == null)
            {
                dbConnection = new DBConnection();
                dbConnection.ConnectionString = "con";
                dbConnection.ConnectedDateTime = DateTime.Now;
            }
            return dbConnection;
        }
    }
}
