using assignment2.teaching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment2.Control
{
    class StaffListController
    {
        // Mainly used to save the teacher data read in
        private List<Staff> Staff;
        public List<Staff> staffList { get { return Staff; } set { } }

        // Mainly used to save the teacher data currently visible on the interface
        private ObservableCollection<Staff> visibleStaff;
        public ObservableCollection<Staff> visibleCoordinatorList { get { return visibleStaff; } set { } }

        // Constructor function to load the list of teachers
        public StaffListController()
        {
            // Read all the information in the teacher table
            Staff = StaffDB.loadAll();
            visibleStaff = new ObservableCollection<Staff>(Staff); //this list we will modify later

            // Read qa information for every teacher
            foreach (Staff c in Staff)
            {
                c.setConsultation(consultationDB.loadByID(c.StaffID));
                c.setStaffUnit(UnitDB.loadByID(c.StaffID));
            }
        }

        public ObservableCollection<Staff> getVisibleList()
        {
            return visibleCoordinatorList;
        }

        // Filter by category, using LINQ expressions
        public void filterByCategory(StaffCategory StaffCategory)
        {
            var selected = from Staff c in Staff
                           where c.StaffCategory == StaffCategory
                           select c;
            visibleStaff.Clear();
            selected.ToList().ForEach(visibleStaff.Add);
        }

        // Filter by name, using LINQ expressions
        public void filterByName(string str)
        {
            // LINQ writing, filter based on last name and first name respectively
            var selected = from Staff c in Staff
                           where c.firstName.Contains(str) || c.lastName.Contains(str)
                           select c;
            visibleStaff.Clear();

            selected.ToList().ForEach(visibleStaff.Add);

            Console.WriteLine("Filter function is called by name！");
        }
    }
}
