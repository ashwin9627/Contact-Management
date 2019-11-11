
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataLayer;

namespace BussinessLogic
{
    public class Contact  //:IContactInfo
    {

        DataAccessLayer Di = new DataAccessLayer();
        public List<ContactInfo> ShowContactInfo()
        {

            return Di.GetProducts2();            
        }
        public ContactInfo ShowContactInfoById(int id)
        {
            return Di.GetDetails(id);
        }
        public List<ContactInfo> ShowContactInfoByStartingLetter(string para)
        {
            return Di.GetDetailsWithLetter(para);
        }
        public bool InsertNewContact(ContactInfo obj)
        {
              var status= Di.InsertDataToContactTable(obj);
            return status;

              }
        public bool UpdateContact(ContactInfo obj)
        {
            var status=Di.UpdateToContactTable(obj);
            return status;
        }
        public void DeleteContact(int id)
        {
            Di.DeleteToContactTable(id);
        }

        public static Contact CreateNew(int contactId, string fName, string lName, DateTime birthdate, string email, string workNumber, string homeNumber, string mobileNumber, bool isActive)
        {
            Contact con = new Contact();
            
            return con;
        }

        public void UpdateContactsChoiceProcess(int choice,int id,string updateValue)
        {
           Di.UpdateToContactTableWithChoice(choice,id, updateValue);
        }
    }
}