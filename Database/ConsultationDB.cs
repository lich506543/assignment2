using assignment2.teaching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment2.Database
{
    // Abstract class: For the time being, it can be understood as a class that only needs to use its methods or only needs to inherit some of its characteristics
    // Subclass of DBconn
    // Corresponding to the staffDB class in HRIS
    abstract class ConsultationDB : DBconn
    {
        // The function of this method is to load information by coordinatorID
        public static List<Consultation> loadByID(int StaffID)
        {
            List<Consultation> Consultation = new List<Consultation>();

            // Connect to the database
            MySqlConnection conn = getConnection();
            MySqlDataReader rdr = null;

            // This short paragraph is for testing purposes only, and should be deleted when submitting
            if (conn != null)
            {
                Console.WriteLine("In ConsultationDB, the database connection is successful！");
            }
            else
            {
                Console.WriteLine("In ConsultationDB, the database connection is unsuccessful！");
            }
            // delete above

            try
            {
                conn.Open();

                //! ! ! Note the modification here! ! !
                // select [day_of_week, start_time, end_time] The content in []: day_of_week, start_time, end_time represents the select data is day_of_week, start_time, end_time, change it to the corresponding column name in the staff table in your database
                // from [aiis_working_time] [] content: aiis_working_time, change it to the corresponding table in your database, it should be consultation
                // where [coordinator_id=?coordinatorID] [] content: coordinator_id=?coordinatorID, the front coordinator_id represents the column name in the table in the database, change it to the corresponding column name in the consultation table in your database
                // The coordinatorID behind corresponds to the first variable in cmd.Parameters.AddWithValue("coordinatorID", coordinatorID);
                // cmd.Parameters.AddWithValue("coordinatorID", coordinatorID); The second variable in the corresponding function entry is the value passed in: public static List<State> loadByID(int coordinatorID)
                MySqlCommand cmd = new MySqlCommand("select day_of_week, start_time, end_time from aiis_working_time where coordinator_id=?coordinatorID", conn);
                cmd.Parameters.AddWithValue("StaffID", StaffID);
                rdr = cmd.ExecuteReader();

                // This short paragraph is for testing purposes only, and should be deleted when submitting
                if (rdr != null)
                {
                    Console.WriteLine("WorkingTime data read successfully！");
                }
                else
                {
                    Console.WriteLine("WorkingTime data read unsuccessfully");
                }
                // delete above

                // After reading from the database, store it in the qa variable we declared
                while (rdr.Read())
                {
                    // // set method
                    Consultation w = new Consultation();
                    w.setDay(parseEnum<DayOfWeek>(rdr.GetString(0)));
                    w.setStart(rdr.GetTimeSpan(1));
                    w.setEnd(rdr.GetTimeSpan(2));

                    Consultation.Add(w);
                }
            }
            // For fault tolerance
            catch (MySqlException e)
            {
                ReportError("loading working times", e);
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

            return Consultation;
        }
    }
}
