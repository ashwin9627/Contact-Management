using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class ContactInfo
    {
        private int _contactId;
        private string _firstName;
        private string _middleName;
        private string _lastName;
        private DateTime _birthday;
        private string _email;
        private string _workNumber;
        private string _homeNumber;
        private string _mobileNumber;
        private bool _isActive;

       

        public int ContactId { get { return _contactId; } set { _contactId = value; } }



        [Required(ErrorMessage = "First Name {0} is required")]
        //[StringLength(100, MinimumLength = 3,
        //ErrorMessage = "Name Should be minimum 3 characters and a maximum of 100 characters")]
        [DataType(DataType.Text)]

        public string firstName { get { return _firstName; } set { _firstName = value; } }
        public string middleName { get { return _middleName; } set { _middleName = value; } }
        [Required(ErrorMessage = "Last Name {0} is required")]        
        public string lastName { get { return _lastName; } set { _lastName = value; } }
        [Required]
        public DateTime Birthday { get { return _birthday; } set { _birthday = value; } }
        [EmailAddress]
        public string Email { get { return _email; } set { _email = value; } }
        public string WorkNumber { get { return _workNumber; } set { _workNumber = value; } }
        public string HomeNumber { get { return _homeNumber; } set { _homeNumber = value; } }
        [Phone]
        public string MobileNumber { get { return _mobileNumber; } set { _mobileNumber = value; } }
        public bool IsActive { get { return _isActive; } set { _isActive = value; } }

        public string fullName { get { return _firstName + _middleName + _lastName; } }
        //public ContactInfo(int contactId1, string fName1, string mName1, string lName1, DateTime birthDate1, string email1, string workNumber1, string homeNumber1, string mobileNumber1, bool isActive1)
        //{
        //    _contactId = contactId1;
        //    _firstName = fName1;
        //    _middleName = mName1;
        //    _lastName = lName1;
        //    _birthday = birthDate1;
        //    _email = email1;
        //    _workNumber = workNumber1;
        //    _homeNumber = homeNumber1;
        //    _mobileNumber = mobileNumber1;
        //    _isActive = isActive1;
        //}
    }
}