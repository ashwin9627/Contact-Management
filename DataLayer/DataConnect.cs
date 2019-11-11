using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataConnect:DataAccessLayer
    {
        public const string GETALL = "SelectAllContacts";
        public const string GETDETAILS = "SelectContactsWithId";
        public const string INSERT = "InsertContactsToContactTable";
        public const string UPDATE = "UpdateContactsWithId";
        public const string DELETE = "DeleteContactFromTable";


        //  public string connection = @"server=KALIDASA\SQLDEV2016;database=testdb;integrated security=sspi";
        static SqlConnection connection = new SqlConnection(@"server=KALIDASA\SQLDEV2016;database=testdb;integrated security=sspi");
        public static void connect()
        {
            if (connection != null)

                if (connection.State != ConnectionState.Closed)
                    connection.Open();
        }
        public static void disconnect()
        {
            if (connection != null)

                if (connection.State != ConnectionState.Open)
                    connection.Close();
        }
    }
}
