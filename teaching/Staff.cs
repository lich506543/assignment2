using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment2.teaching
{
    // Enumerated type, the purpose is to record the type of 
    public enum StaffCategory { Primary, Secondary, Tertiary };
    // Enumerated type, the purpose is to record the type of 
    public enum CityBranch { Canberra, Sydney, Darwin, Brisbane, Adelaide, Hobart, Melbourne, Perth };
    // Coordinator class, corresponding to the staff class in your HRIS
    class Staff
    {
        public int StaffID { get; private set; }
        public string firstName { get; private set; }
        public string lastName { get; private set; }
        public string StaffTitle { get; private set; }
        public CityBranch cityBranch { get; private set; }
        public string phoneNumber { get; private set; }
        public string postalCode { get; private set; }
        public string StaffEmail { get; private set; }
        public string StaffPhoto { get; private set; }
        public StaffCategory StaffCategory { get; private set; }
        public List<Consultation> ConsultationTimes { get; private set; }
        public List<Unit> StaffUnit { get; private set; }
        // set method, the purpose is to achieve encapsulation
        public void setStaffID(int StaffID)
        {
            this.StaffID = StaffID;
        }
        // set method, the purpose is to achieve encapsulation
        public void setFirstName(string firstName)
        {
            this.firstName = firstName;
        }
        // set method, the purpose is to achieve encapsulation
        public void setLastName(string lastName)
        {
            this.lastName = lastName;
        }
        // set method, the purpose is to achieve encapsulation
        public void setCoordinatorTitle(string coordinatorTitle)
        {
            this.StaffTitle = coordinatorTitle;
        }
        // set method, the purpose is to achieve encapsulation
        public void setCityBranch(CityBranch cityBranch)
        {
            this.cityBranch = cityBranch;
        }
        // set method, the purpose is to achieve encapsulation
        public void setPhoneNumber(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
        }
        // set method, the purpose is to achieve encapsulation
        public void setPostalCode(string postalCode)
        {
            this.postalCode = postalCode;
        }
        // set method, the purpose is to achieve encapsulation
        public void setStaffEmail(string StaffEmail)
        {
            this.StaffEmail = StaffEmail;
        }
        // set method, the purpose is to achieve encapsulation
        public void setStaffPhoto(string StaffPhoto)
        {
            this.StaffPhoto = StaffPhoto;
        }
        // set method, the purpose is to achieve encapsulation
        public void setStaffCategory(StaffCategory staffCategory)
        {
            this.StaffCategory = staffCategory;
        }
        // set method, the purpose is to achieve encapsulation
        public void setWorktingTimes(List<Consultation> Consultation)
        {
            this.ConsultationTimes = Consultation;
        }
        // set method, the purpose is to achieve encapsulation
        public void setStaffUnit(List<Unit> StaffUnit)
        {
            this.StaffUnit = StaffUnit;
        }
        // Override the ToString method, the purpose is to facilitate the display of a specific format
        public override string ToString()
        {
            return firstName + " " + lastName;
        }
    }
}
