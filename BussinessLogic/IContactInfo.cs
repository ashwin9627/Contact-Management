using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic
{
    public interface IContactInfo
    {
        void ShowContactInfo();
        void ShowContactInfoById();
        void InsertNewContact();
        void DeleteContact();
        void UpdateContact();
    }
    public static class ContactInfointer
    {
        //public static IContactInfo GetDetails(int contactId, string fName, string lName, DateTime birthdate, string email, string workNumber, string homeNumber, string mobileNumber, bool isActive)
        //public static void GetDetails(ContactInfo obj)
        //{

        //}
            // Contact.CreateNew(contactId, fName, lName, birthdate, email, workNumber, homeNumber, mobileNumber, isActive);
            //    return Contact.CreateNew(contactId, fName, lName, birthdate, email, workNumber, homeNumber,mobileNumber,isActive) as IContactInfo;
            //if (obj == null)
            //    throw new ArgumentNullException(nameof(obj), "Required argument missing");
            //CreateConnection();
            ////build a command and assign all the parameters
            //SqlCommand command = new SqlCommand(INSERT, connection);
            //command.CommandType = System.Data.CommandType.StoredProcedure;
            //command.CommandText = INSERT;

            //SqlParameter p1 = new SqlParameter();
            //p1.ParameterName = "@ProductName";
            //p1.SqlDbType = SqlDbType.VarChar;
            //p1.Size = 50;
            //p1.Direction = ParameterDirection.Input;
            //p1.Value = item.ProductName;
            //command.Parameters.Add(p1);

            //command.Parameters.Add(new SqlParameter("@unitPrice", item.UnitPrice));
            //command.Parameters.Add(new SqlParameter("@unitsInStock", item.UnitsInStock));
            //command.Parameters.Add(new SqlParameter("@discontinued", item.Discontinued));
            //command.Parameters.Add(new SqlParameter("@categoryid", item.CategoryId));

            //OpenConnection();
            //SqlTransaction trans = connection.BeginTransaction();
            //command.CommandText = INSERT;
            //try
            //{
            //    command.ExecuteNonQuery();
            //    trans.Commit();
            //}
            //catch (SqlException)
            //{

            //    trans.Rollback();
            //    throw;
            //}
            //catch (Exception)
            //{
            //    trans.Rollback();
            //}
            //finally
            //{
            //    CloseConnection();
            //}
        }
    }
   