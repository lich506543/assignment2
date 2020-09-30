using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment2.Database
{
    // Abstract class: For the time being, it can be understood as a class that only needs to use its methods or only needs to inherit some of its characteristics
    // It is the parent class of CoordinatorDB, StateDB, WorkingTimeDB and ActivityTimeDB
    // Because the above four DBs actually require operations such as connecting to the database, parsing enumeration, and reporting errors, then inheritance relationships can be used to reflect their common characteristics
    // This is mainly considering the need to examine the use of OO features in the homework grading standard. Inheritance is one of the three major features of OO
    abstract class DBconn
    {
        // In this class, all member variables can be declared as private, which is a good package to avoid external access
        // But the member methods of this class can be accessed freely. At the same time, you need to pay attention to the member methods should be protected to facilitate subclass access, but not allow external access
        // parseEnum<T>(string value) This method declaration is called public, because it seems to be a method that may also be used externally, so it leaves an external interface
        private static bool reportingErrors = false;
        // Database connection information, note that this is a local database
        // The last assignment must be connected to the school database. I commented out the information corresponding to the school database below
        private const string db = "test";
        private const string user = "root";
        private const string pass = "";
        private const string server = "localhost";
        //private const string db = "kit206";
        //private const string user = "kit206";
        //private const string pass = "kit206";
        //private const string server = "alacritas.cis.utas.edu.au";
       

        private static MySqlConnection conn = null;

        // This function is mainly used to connect to the database
        protected static MySqlConnection getConnection()
        {
            if (conn == null)
            {
                string connectionString = String.Format("Database={0};Data Source={1};User Id={2};Password={3}", db, server, user, pass);
                conn = new MySqlConnection(connectionString);
            }
            return conn;
        }
        // Note that the following method was written in the subclass before, but since this function is universal, it is changed to the parent class this time
        // The function of this method is to convert a string variable into an enumeration type, where generic knowledge is used, so you don’t have to go into it deeply, just know its function
        // The function is to turn the string variable read from the database into an enumerated type we defined
        public static T parseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }
        // Put it in the parent class here to reflect the idea of reuse
        protected static void ReportError(string msg, Exception e)
        {
            if (reportingErrors)
            {
                MessageBox.Show("An error occurred while " + msg + ". Try again later.\n\nError Details:\n" + e,
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
