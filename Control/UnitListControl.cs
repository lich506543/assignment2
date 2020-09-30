using assignment2.teaching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment2.Control
{
    class UnitListController
    {
        private List<Unit> Unit;
        public List<Unit> courseList { get { return Unit; } set { } }

        private ObservableCollection<Unit> visibleUnit;
        public ObservableCollection<Unit> visibleUnitList { get { return visibleUnit; } set { } }

        public UnitListController()
        {
            Unit = UnitDB.loadAll();
            visibleUnit = new ObservableCollection<Unit>(Unit); //this list we will modify later

            foreach (Unit s in Unit)
            {
                s.setClassTime(ClassTimeDB.loadByState(s.UnitCode));
            }
        }

        public ObservableCollection<Unit> getVisibleList()
        {
            return visibleUnitList;
        }
        public void filterByName(string str)
        {
            // LINQ writing, filter based on last name and first name respectively
            var selected = from Unit s in Unit
                           where s.unitCode.Contains(str) || s.unitName.Contains(str)
                           select s;
            visibleUnit.Clear();

            selected.ToList().ForEach(visibleUnit.Add);

            Console.WriteLine("Filter function is called by name！");
        }
    }
}