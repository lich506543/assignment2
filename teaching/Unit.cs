using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment2.teaching
{

    class Unit
    {
        // This must be a public type, because changing to another type will cause the binding to fail and the interface cannot be displayed
        // But be aware that this writing method does not conform to the OO design philosophy and is not well packaged
        // So I changed to public get and private set
        // It is free to read, not free to write. If you write, the set method is provided below (this is a typical packaging method)
        public string unitCode { get; private set; }
        public string unitName { get; private set; }
        public int staffID { get; private set; }
        public List<ClassTime> activityTimes { get; private set; }
        // get, set methods, the purpose is to achieve encapsulation
        public void setUnitCode(string unitCode)
        {
            this.unitCode = unitCode;
        }
        // get, set methods, the purpose is to achieve encapsulation
        public void setUnitName(string unitName)
        {
            this.unitName = unitName;
        }
        // get, set methods, the purpose is to achieve encapsulation
        public void setStaffID(int staffID)
        {
            this.staffID = staffID;
        }
        // get, set methods, the purpose is to achieve encapsulation
        public void setActivityTimes(List<ClassTime> activityTimes)
        {
            this.activityTimes = activityTimes;
        }
        // Rewrite the ToString method, the purpose is to facilitate the display of a specific format
        public override string ToString()
        {
            return unitCode + " " + unitName;
        }
    }
}
