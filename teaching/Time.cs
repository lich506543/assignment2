using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment2.teaching
{
    // Abstract class: For the time being, it can be understood as a class that only needs to use its methods or only needs to inherit some of its characteristics
    // is the parent class of ActivityTime and WorkTime
    // Because the above two actually require time information, then inheritance can be used to reflect their common characteristics
    // This is mainly considering the need to examine the use of OO features in the homework grading standard. Inheritance is one of the three major features of OO
    abstract class Time
    {
        // This must be a public type, because changing to another type will cause the binding to fail and the interface cannot be displayed
        // But be aware that this writing method does not conform to the OO design philosophy and is not well packaged
        // public get and private set
        // It is free to read, not free to write. If you write, the set method is provided below (this is a typical packaging method)
        public DayOfWeek day { get; private set; }
        public TimeSpan start { get; private set; }
        public TimeSpan end { get; private set; }
        //set method, the purpose is to achieve encapsulation
        public void setDay(DayOfWeek day)
        {
            this.day = day;
        }
        // set method, the purpose is to achieve encapsulation
        public void setStart(TimeSpan start)
        {
            this.start = start;
        }
        // set method, the purpose is to achieve encapsulation
        public void setEnd(TimeSpan end)
        {
            this.end = end;
        }
    }
}
