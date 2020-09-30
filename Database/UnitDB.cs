using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment2.Database
{
    // Abstract class: For the time being, it can be understood as a class that only needs to use its methods or only needs to inherit some of its characteristics
    // Subclass of DBconn

    abstract class UnitDB : DBconn
    {
        // This method is to load all the information

        public static List<Unit> loadAll()
        {
            List<Unit> Unit = new List<Unit>();
            // Now because of the inheritance relationship, you can directly access the protected method of the parent class
            MySqlConnection conn = getConnection();
            MySqlDataReader rdr = null;

            // This short paragraph is for testing purposes only, and should be deleted when submitting
            if (conn != null)
            {
                Console.WriteLine("In unitDB, the database connection is successful!！");
            }
            else
            {
                Console.WriteLine("In unitDB, the database connection is unsuccessful!！");
            }
            // delete above

            try
            {
                conn.Open();
                //! ! ! Note the modification here! ! !
                // select [*] [] content: * means select all, if not select all, write the column names in the state table in the database
                // from [aiis_state] [] content: the target of select is the aiis_state table, which should be changed to the corresponding table in your database, which should be unit
                MySqlCommand cmd = new MySqlCommand("select * from aiis_state", conn);
                rdr = cmd.ExecuteReader();

                // This short paragraph is for testing purposes only, and should be deleted when submitting
                if (rdr != null)
                {
                    Console.WriteLine("Unit data read successfully!");
                }
                else
                {
                    Console.WriteLine("Unit data read unsuccessfully!");
                }
                // delete above

                while (rdr.Read())
                {
                    // set method
                    Unit s = new Unit();
                    s.setUnitCode(rdr.GetString(0));
                    s.setUnitName(rdr.GetString(1));
                    s.setStaffID(rdr.GetInt32(2));

                    Unit.Add(s);
                }
            }
            // For fault tolerance
            catch (MySqlException e)
            {
                Console.WriteLine("Error connecting to database: " + e);
            }
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

            return Unit;
        }

        // The function of this method is to load information by staffID
        public static List<Unit> loadByID(int StaffID)
        {
            List<Unit> unit = new List<Unit>();
            // Now because of the inheritance relationship, you can directly access the protected method of the parent class
            MySqlConnection conn = getConnection();
            MySqlDataReader rdr = null;

            // This short paragraph is for testing purposes only, and should be deleted when submitting
            if (conn != null)
            {
                Console.WriteLine("In unitDB, the database connection is successful!！");
            }
            else
            {
                Console.WriteLine("In unitDB, the database connection is unsuccessful!！");
            }
            // delete above

            try
            {
                conn.Open();

                //! ! ! Note the modification here! ! !
                // select [state_code, state_name] [] Contents: state_code, state_name represents the select data is state_code, state_name, you must change it to the corresponding column name in the state table in your database
                // from [aiis_state] [] content: aiis_state, change it to the corresponding table in your database, it should be unit
                // where [coordinator_id=?coordinatorID] [] content: coordinator_id=?coordinatorID, the front coordinator_id represents the column name in the table in the database, change it to the corresponding column name in the staff table in your database
                // The coordinatorID behind corresponds to the first variable in cmd.Parameters.AddWithValue("coordinatorID", coordinatorID);
                // cmd.Parameters.AddWithValue("coordinatorID", coordinatorID); The second variable in the corresponding function entry is the value passed in: public static List<State> loadByID(int coordinatorID)
                MySqlCommand cmd = new MySqlCommand("select state_code, state_name from aiis_state where coordinator_id=?coordinatorID", conn);
                cmd.Parameters.AddWithValue("coordinatorID", StaffID);
                rdr = cmd.ExecuteReader();

                // This short paragraph is for testing purposes only, and should be deleted when submitting
                if (rdr != null)
                {
                    Console.WriteLine("Unit data read successfully!");
                }
                else
                {
                    Console.WriteLine("Unit data read unsuccessfully!");
                }
                // delete above

                while (rdr.Read())
                {
                    // set method
                    Unit s = new Unit();
                    s.setUnitCode(rdr.GetString(0));
                    s.setUnitName(rdr.GetString(1));

                    unit.Add(s);
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

            return unit;
        }
    }
}
