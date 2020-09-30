using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment2.teaching
{
    // Enumerated type, the purpose is to record the type of activity
    public enum ClassType { Concert, Opera, Cosplay, Show };
    // Subclass of Time class
    // ActivityTime class, corresponding to the class in your HRIS
    class ClassTime : Time
    {
        // This must be a public type, because changing to another type will cause the binding to fail and the interface cannot be displayed
        // But be aware that this writing method does not conform to the OO design philosophy and is not well packaged
        // Public get and private set are used here
        // It is free to read, not free to write. If you write, the set method is provided below (this is a typical packaging method)

        public string UnitCode { get; private set; }
        public string cityBranch { get; private set; }
        public ClassType activityType { get; private set; }
        public string postalCode { get; private set; }
        public int StaffID { get; private set; }
        // unitCode's set method, the purpose is to achieve encapsulation
        public void setUnitCode(string UnitCode)
        {
            this.UnitCode = UnitCode;
        }
        // The set method of cityBranch is to achieve encapsulation
        public void setCityBranch(string cityBranch)
        {
            this.cityBranch = cityBranch;
        }
        // The set method of cityBranch is to achieve encapsulation
        public void setActivityType(ClassType activityType)
        {
            this.activityType = activityType;
        }
        // The set method of cityBranch is to achieve encapsulation
        public void setPostalCode(string postalCode)
        {
            this.postalCode = postalCode;
        }
        // The set method of cityBranch is to achieve encapsulation
        public void setCoordinatorID(int StaffID)
        {
            this.StaffID = StaffID;
        }
        // Override the ToString method, the purpose is to facilitate the display of a specific format
        public override string ToString()
        {
            return day + " " + start + "--" + end;
        }
    }
}
