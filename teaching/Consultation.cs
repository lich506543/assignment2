using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment2.teaching
{
    // Subclass of Time class
    // WorkingTime class, corresponding to the consultation class in your HRIS
    class Consultation : Time
    {
        // This must be a public type, because changing to another type will cause the binding to fail and the interface cannot be displayed
        // But be aware that this writing method does not conform to the OO design philosophy and is not well packaged
        // So I changed to public get and private set
        // It is free to read, not free to write. If you write, the set method is provided below (this is a typical packaging method)
       
        private int StaffID;
        // The get and set methods of coordinatorID are for encapsulation
        public void setStaffID(int StaffID)
        {
            this.StaffID = StaffID;
        }
        public int getStaffID()
        {
            return this.StaffID;
        }
        // Override the ToString method, the purpose is to facilitate the display of a specific format
        public override string ToString()
        {
            return day + " " + start + "--" + end;
        }
    }
}
