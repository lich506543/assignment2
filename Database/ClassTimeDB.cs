using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment2.Database
{
    // Abstract class: For the time being, it can be understood as a class that only needs to use its methods or only needs to inherit some of its characteristics
    // Subclass of DBconn
    abstract class ClassTimeDB : DBconn
    {
        // The function of this method is to load information according to stateCode
        public static List<ClassTime> loadByState(string unitCode)
        {
            List<ClassTime> ClassTime = new List<ClassTime>();
            // You can use MySqlConnection conn = DBconn.getConnection();
            // Now because of the inheritance relationship, you can directly access the protected method of the parent class
            MySqlConnection conn = getConnection();
            MySqlDataReader rdr = null;

            // This short paragraph is for testing purposes only, and should be deleted when submitting
            if (conn != null)
            {
                Console.WriteLine("In ClasstimeDB, the database connection is successful！");
            }
            else
            {
                Console.WriteLine("In ClasstimeDB, the database connection is unsuccessful！");
            }
            // delete above

            try
            {
                conn.Open();

                //! ! ! Note the modification here! ! !
                // select [*] [] content: * means select all, if not select all, write the column names in the class table in the database
                // from [aiis_activity_time] [] content: aiis_activity_time, change it to the corresponding table in your database, it should be class
                // where [state_code=?stateCode] The content in []: state_code=?stateCode, the previous state_code represents the name of the column in the table in the database, change it to the corresponding column name in the class table in your database
                // The following stateCode corresponds to the first variable in cmd.Parameters.AddWithValue("stateCode", stateCode);
                // cmd.Parameters.AddWithValue("stateCode", stateCode); The second variable in the corresponding function entry is the value passed in: public static List<ActivityTime> loadByState(string stateCode)
                MySqlCommand cmd = new MySqlCommand("select * from aiis_activity_time where state_code=?stateCode", conn);
                cmd.Parameters.AddWithValue("unitCode", unitCode);
                rdr = cmd.ExecuteReader();

                // This short paragraph is for testing purposes only, and should be deleted when submitting
                if (rdr != null)
                {
                    Console.WriteLine("ActivityTime Data read successfully！");
                }
                else
                {
                    Console.WriteLine("ActivityTime Data read unsuccessfully！");

                }// delete above

                while (rdr.Read())
                {
                    // set method
                    ClassTime a = new ClassTime();
                    a.setUnitCode(rdr.GetString(0));
                    a.setCityBranch(rdr.GetString(1));
                    a.setDay(parseEnum<DayOfWeek>(rdr.GetString(2)));
                    a.setStart(rdr.GetTimeSpan(3));
                    a.setEnd(rdr.GetTimeSpan(4));
                    a.setClassType(parseEnum<ClassType>(rdr.GetString(5)));
                    a.setPostalCode(rdr.GetString(6));
                    a.setStaffID(rdr.GetInt32(7));

                    ClassTime.Add(a);
                }
            }
            // For fault tolerance
            catch (MySqlException e)
            {
                ReportError("loading unit staff times", e);
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

            return ClassTime;
        }
    }
}
