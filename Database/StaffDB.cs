using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment2.Database
{
    // Abstract class: For the time being, it can be understood as a class that only needs to use its methods or only needs to inherit some of its characteristics
    // Subclass of DBconn
    abstract class CoordinatorDB : DBconn
    {
        // The function of this method is to load all the information, be careful with loading all this idea
        public static List<Staff> loadAll()
        {
            List<Staff> Staff = new List<Staff>();
            // Note the change in writing here, it used to be MySqlConnection conn = DBconn.getConnection();
            // Now because of the inheritance relationship, you can directly access the protected method of the parent class
            MySqlConnection conn = getConnection();
            MySqlDataReader rdr = null;

            // This short paragraph is for testing purposes only, and should be deleted when submitting
            if (conn != null)
            {
                Console.WriteLine("In StaffDB, the database connection is successful！");
            }
            else
            {
                Console.WriteLine("In StaffDB, the database connection is unsuccessful!");
            }
            // delete above

            try
            {
                conn.Open();

                //! ! ! Note the modification here! ! !
                // select [*] [] content: * means select all, if not select all, write the column names in the staff table in the database
                // from [aiis_coordinator] [] Content: The target of select is the aiis_coordinator table, which should be changed to the corresponding table in your database, which should be staff
                MySqlCommand cmd = new MySqlCommand("select * from aiis_coordinator", conn);
                rdr = cmd.ExecuteReader();

                // This short paragraph is for testing purposes only, and should be deleted when submitting
                if (rdr != null)
                {
                    Console.WriteLine("Coordinator data read successfully!");
                }
                else
                {
                    Console.WriteLine("Coordinator data read unsuccessfully!");
                }
                // delete above

                while (rdr.Read())
                {
                    //set method
                    Staff c = new Staff();
                    c.setStaffID(rdr.GetInt32(0));
                    c.setFirstName(rdr.GetString(1));
                    c.setLastName(rdr.GetString(2));
                    c.setStaffTitle(rdr.GetString(3));
                    c.setCityBranch(parseEnum<CityBranch>(rdr.GetString(4)));
                    c.setPhoneNumber(rdr.GetString(5));
                    c.setPostalCode(rdr.GetString(6));
                    c.setStaffEmail(rdr.GetString(7));
                    c.setStaffPhoto(rdr.GetString(8));
                    c.setStaffCategory(parseEnum<StaffCategory>(rdr.GetString(9)));

                    Staff.Add(c);
                }
            }
            // For fault tolerance
            catch (MySqlException e)
            {
                Console.WriteLine("Error connecting to database: " + e);
            }
            // Close database connection
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return Staff;
        }
    }
}
