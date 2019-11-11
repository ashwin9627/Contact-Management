using Model;
using Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataAccessLayer
    {
        public const string GETALL = "SelectAllContacts";
        public const string GETDETAILS = "SelectContactsWithId";
        public const string GETDETAILSWITHSTART = "SelectContactsWithStartingletter123";
        public const string INSERT = "InsertContactsToContactTable";
        public const string UPDATE = "UpdateContactsWithId";
        public const string UPDATEINDIVIDUAL = "UpdateContactsWithIdIndividual";
        public const string DELETE = "DeleteContactFromTable";

        string connectionString = "server=KALIDASA\\SQLDEV2016;database=testdb;integrated security=sspi";
        SqlConnection connection = new SqlConnection(@"server=KALIDASA\SQLDEV2016;database=testdb;integrated security=sspi");

        Files filewriter = new Files();

        public void connect()
        {
            if (connection != null)

                if (connection.State == ConnectionState.Closed)
                    connection.Open();
        }
        public void disconnect()
        {
            try
            {
                if (connection != null)

                    if (connection.State == ConnectionState.Open)
                        connection.Close();
            }
            catch(Exception ex)
            {
                filewriter.FileWriterAppend(Files.ExceptionInDataAccessLayer, (new List<string>() { ex.Message, ex.StackTrace }));
            }
        }

        public ContactInfo GetDetails(int id)
        {
            ContactInfo contact = new ContactInfo();
            connect();
            SqlCommand command = connection.CreateCommand();
            command.Connection = connection;
            command.CommandText = GETDETAILS;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ContactID", id);

            SqlDataReader reader = null;

            try
            {                
                //   OpenConnection();
                connect();
                reader = command.ExecuteReader();
                    while (reader.Read())
                 {                    
                         contact = Createproductfromreader(reader);
                       // contactlist.Add(Product);
                 }
                 
            }
            catch (SqlException ex)
            {
                filewriter.FileWriterAppend(Files.ExceptionInDataAccessLayer, (new List<string>() { ex.Message, ex.StackTrace }));
                Console.WriteLine(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                filewriter.FileWriterAppend(Files.ExceptionInDataAccessLayer, (new List<string>() { ex.Message, ex.StackTrace }));
                throw;
            }
            finally
            {
                if (reader != null) if (reader.IsClosed) reader.Close();
                // CloseConnection();
                disconnect();
            }
            return contact;
        }

        public List<ContactInfo> GetDetailsWithLetter(string para)
        {
            List<ContactInfo> contactlist = new List<ContactInfo>();
            try
            {
                
                connect();
                SqlCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = GETDETAILSWITHSTART;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@startletter", para);

                SqlDataReader reader = null;

                try
                {
                    //   OpenConnection();
                    connect();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var Product = Createproductfromreader(reader);
                        contactlist.Add(Product);
                    }
                }
                catch (SqlException ex)
                {
                    filewriter.FileWriterAppend(Files.ExceptionInDataAccessLayer, (new List<string>() { ex.Message, ex.StackTrace }));
                    Console.WriteLine(ex.Message);
                    throw;
                }
                catch (Exception ex)
                {
                    filewriter.FileWriterAppend(Files.ExceptionInDataAccessLayer, (new List<string>() { ex.Message, ex.StackTrace }));
                    throw;
                }
                finally
                {
                    if (reader != null) if (reader.IsClosed) reader.Close();
                    // CloseConnection();
                    disconnect();
                }
            }
            catch(Exception ex)
            {
                filewriter.FileWriterAppend(Files.ExceptionInDataAccessLayer, (new List<string>() { ex.Message, ex.StackTrace }));
            }
            return contactlist;
        }
        //Get products2 is a getallcontactslist
        public List<ContactInfo> GetProducts2(/*string criteria*/)
        {
            List<ContactInfo> contactlist = new List<ContactInfo>();
            try
            {
                connect();
                SqlCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = GETALL;
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader reader = null;

                try
                {
                    connect();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {                     
                        var Product = Createproductfromreader(reader);
                        contactlist.Add(Product);
                    }
                }
                catch (SqlException ex)
                {
                    filewriter.FileWriterAppend(Files.ExceptionInDataAccessLayer, (new List<string>() { ex.Message, ex.StackTrace }));
                    throw;
                }
                catch (Exception ex)
                {
                    filewriter.FileWriterAppend(Files.ExceptionInDataAccessLayer, (new List<string>() { ex.Message, ex.StackTrace }));
                    throw;
                }
                finally
                {
                    if (reader != null) if (reader.IsClosed) reader.Close();
                    disconnect();
                }
            }
            catch(Exception ex)
            {
                filewriter.FileWriterAppend(Files.ExceptionInDataAccessLayer, (new List<string>() { ex.Message, ex.StackTrace }));
            }
            return contactlist;
        }
        public bool InsertDataToContactTable(ContactInfo obj)
        {
            bool status = false;
            try
            {
                connect();
                //   SqlCommand command = new SqlCommand(INSERT, connection);
                SqlCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = INSERT;
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@ContactfirstName", obj.firstName));
                command.Parameters.Add(new SqlParameter("@ContactMiddleName", obj.middleName));
                command.Parameters.Add(new SqlParameter("@ContactlastName", obj.lastName));
                command.Parameters.Add(new SqlParameter("@BithDay", obj.Birthday));
                command.Parameters.Add(new SqlParameter("@Email", obj.Email));
                command.Parameters.Add(new SqlParameter("@WorkPhone", obj.WorkNumber));
                command.Parameters.Add(new SqlParameter("@HomePhone", obj.HomeNumber));
                command.Parameters.Add(new SqlParameter("@MobileNumber", obj.MobileNumber));
                //command.Parameters.Add(new SqlParameter("@IsActive", obj.IsActive));
                connect();
                SqlTransaction trans = connection.BeginTransaction();
                //command.CommandText = INSERT;
                command.Transaction = trans;
                try
                {
                    command.ExecuteNonQuery();
                    trans.Commit();
                    status = true;
                }
                catch (SqlException ex)
                {
                    filewriter.FileWriterAppend(Files.ExceptionInDataAccessLayer, (new List<string>() { ex.Message, ex.StackTrace }));
                    Console.WriteLine(ex.Message);
                    trans.Rollback();
                    status = false;
                    throw;
                }
                catch (Exception ex)
                {
                    filewriter.FileWriterAppend(Files.ExceptionInDataAccessLayer, (new List<string>() { ex.Message, ex.StackTrace }));
                    Console.WriteLine(ex.Message);
                    trans.Rollback();
                    status = false;
                }
                finally
                {
                    disconnect();
                }
            }
            catch(Exception ex)
            {
                filewriter.FileWriterAppend(Files.ExceptionInDataAccessLayer, (new List<string>() { ex.Message, ex.StackTrace }));
                status = false;
            }
            return status;
        }
        public bool UpdateToContactTable(ContactInfo obj)
        {
            bool status = false;
            try
            {
                
                //   connect();
                //   SqlCommand command = new SqlCommand(INSERT, connection);
                //if(!obj.Birthday)
                //{
                //    DateTime date123 =new DateTime(01-01-0001);
                //    obj.Birthday =date123;
                //}
                DateTime d1 = Convert.ToDateTime("01/01/0001");
                if (obj.Birthday == d1)
                {
                    obj.Birthday = Convert.ToDateTime("1/1/1753");
                }
                SqlCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = UPDATE;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ContactID", obj.ContactId));
                command.Parameters.Add(new SqlParameter("@ContactfirstName", obj.firstName));
                command.Parameters.Add(new SqlParameter("@ContactMiddleName", obj.middleName));
                command.Parameters.Add(new SqlParameter("@ContactlastName", obj.lastName));
                command.Parameters.Add(new SqlParameter("@BithDay", obj.Birthday));
                command.Parameters.Add(new SqlParameter("@Email", obj.Email));
                command.Parameters.Add(new SqlParameter("@WorkPhone", obj.WorkNumber));
                command.Parameters.Add(new SqlParameter("@HomePhone", obj.HomeNumber));
                command.Parameters.Add(new SqlParameter("@MobileNumber", obj.MobileNumber));
               // command.Parameters.Add(new SqlParameter("@IsActive", obj.IsActive));
                connect();
                SqlTransaction trans = connection.BeginTransaction();
                //command.CommandText = INSERT;
                command.Transaction = trans;
                try
                {
                    command.ExecuteNonQuery();
                    trans.Commit();
                    status = true;
                }
                catch (SqlException ex)
                {
                    filewriter.FileWriterAppend(Files.ExceptionInDataAccessLayer, (new List<string>() { ex.Message, ex.StackTrace }));
                    Console.WriteLine(ex.Message);
                    trans.Rollback();
                    status = false;
                    throw;
                    
                }
                catch (Exception ex)
                {
                    filewriter.FileWriterAppend(Files.ExceptionInDataAccessLayer, (new List<string>() { ex.Message, ex.StackTrace }));
                    Console.WriteLine(ex.Message);
                    trans.Rollback();
                    status = false;
                }
                finally
                {
                    disconnect();
                }
            }
            catch(Exception ex)
            {
                filewriter.FileWriterAppend(Files.ExceptionInDataAccessLayer, (new List<string>() { ex.Message, ex.StackTrace }));
            }
            return status;
        }
        public void DeleteToContactTable(int id)
        {
            try
            {
                SqlCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = DELETE;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ContactId", id));
                connect();
                SqlTransaction trans = connection.BeginTransaction();
                //command.CommandText = INSERT;
                command.Transaction = trans;
                try
                {
                    command.ExecuteNonQuery();
                    trans.Commit();
                }
                catch (SqlException ex)
                {
                    filewriter.FileWriterAppend(Files.ExceptionInDataAccessLayer, (new List<string>() { ex.Message, ex.StackTrace }));
                    Console.WriteLine(ex.Message);
                    trans.Rollback();
                    throw;
                }
                catch (Exception ex)
                {
                    filewriter.FileWriterAppend(Files.ExceptionInDataAccessLayer, (new List<string>() { ex.Message, ex.StackTrace }));
                    Console.WriteLine(ex.Message);
                    trans.Rollback();
                }
                finally
                {
                    disconnect();
                }
            }
            catch(Exception ex)
            {
                filewriter.FileWriterAppend(Files.ExceptionInDataAccessLayer, (new List<string>() { ex.Message, ex.StackTrace }));
            }
        }

        //        public void GetAllData()
        //        {
        //            //    SqlConnection sql = new SqlConnection(connectionString);
        //            connection.Open();
        //            // DataConnect.connect();
        //       //     connect();
        //            SqlCommand command = new SqlCommand();
        //            //    command.Connection = new SqlConnection(connection);
        //            command.Connection = new SqlConnection(connectionString);
        //            command.CommandText = "SelectAllContacts";
        //            command.CommandType = System.Data.CommandType.StoredProcedure;
        //            //  command.Parameters.AddWithValue("@search", Id);
        //            //SqlConnection sql = new SqlConnection(connection);
        //        //    SqlConnection sql = new SqlConnection(connectionString);
        //           // sql.Open();
        //            command.Connection = new SqlConnection(connectionString);
        //            connection.Open();
        //            SqlDataReader reader = command.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                for (int i = 0; reader.HasRows; i++)
        //                {


        //                    Console.WriteLine(reader.GetValue(i));

        //                }
        //            }
        //            reader.Close();
        //            // DataConnect.disconnect();
        //            //disconnect();
        //            connection.Close();
        //        }

        // public void Get_By_Id(int Id)
        //{
        //    DataConnect.connect();
        //    SqlCommand command = new SqlCommand();
        //            //    command.Connection = new SqlConnection(connection);
        //            command.Connection = new SqlConnection(connectionString);
        //            command.CommandText = "SelectAllContacts";
        //    command.CommandType = System.Data.CommandType.StoredProcedure;
        //            //  command.Parameters.AddWithValue("@search", Id);
        //            //SqlConnection sql = new SqlConnection(connection);
        //            SqlConnection sql = new SqlConnection(connectionString);
        //            command.Connection = new SqlConnection(connectionString);
        //    SqlDataReader reader = command.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        for (int i = 0; reader.HasRows; i++)
        //        {
        //            Console.WriteLine(reader.GetValue(i));
        //        }
        //    }
        //    reader.Close();
        //    DataConnect.disconnect();
        //}
        private ContactInfo Createproductfromreader(SqlDataReader reader)
        {
            ContactInfo P = new ContactInfo();
            try
            {
               
                P.ContactId = Convert.ToInt32("0" + reader["ContactId"].ToString());
                P.firstName = reader["firstName"].ToString();
                P.middleName = reader["MiddleName"].ToString();
                P.lastName = reader["lastName"].ToString();
                P.Birthday = Convert.ToDateTime(reader["Birthday"]);
                P.Email = reader["Email"].ToString();
                P.WorkNumber = reader["Workphone"].ToString();
                P.HomeNumber = reader["HomePhone"].ToString();
                P.MobileNumber = reader["MobileNumber"].ToString();
                P.IsActive = Convert.ToBoolean(reader["IsActive"].ToString());
                return P;
            }
            catch (Exception ex)
            {
                filewriter.FileWriterAppend(Files.ExceptionInDataAccessLayer, (new List<string>() { ex.Message, ex.StackTrace }));
            }
            return P;
        }




        //Update with the choice

        public void UpdateToContactTableWithChoice(int choice, int contactId,string updateValue)
        {
            try
            {
                //   connect();
                //   SqlCommand command = new SqlCommand(INSERT, connection);
                SqlCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = UPDATEINDIVIDUAL;
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@Choice", choice));
                command.Parameters.Add(new SqlParameter("@ContactID", contactId));
                switch (choice)
                {
                    case 1:
                        command.Parameters.Add(new SqlParameter("@ContactFieldValue", updateValue));
                        break;
                    case 2:
                        command.Parameters.Add(new SqlParameter("@ContactFieldValue", updateValue));
                        break;
                    case 3:
                        command.Parameters.Add(new SqlParameter("@ContactFieldValue", updateValue));
                        break;
                    case 4:
                        command.Parameters.Add(new SqlParameter("@ContactFieldValue", updateValue));
                        break;
                    case 5:
                        command.Parameters.Add(new SqlParameter("@ContactFieldValue", updateValue));
                        break;
                    case 6:
                        command.Parameters.Add(new SqlParameter("@ContactFieldValue", updateValue));
                        break;
                    case 7:
                        command.Parameters.Add(new SqlParameter("@ContactFieldValue", updateValue));
                        break;
                    case 8:
                        command.Parameters.Add(new SqlParameter("@ContactFieldValue", updateValue));
                        break;
                }  
                
                //command.Parameters.Add(new SqlParameter("@MobileNumber", updateValue));
                // command.Parameters.Add(new SqlParameter("@IsActive", obj.IsActive));
                connect();
                SqlTransaction trans = connection.BeginTransaction();
                //command.CommandText = INSERT;
                command.Transaction = trans;
                try
                {
                    command.ExecuteNonQuery();
                    trans.Commit();
                }
                catch (SqlException ex)
                {
                    filewriter.FileWriterAppend(Files.ExceptionInDataAccessLayer, (new List<string>() { ex.Message, ex.StackTrace }));
                    Console.WriteLine(ex.Message);
                    trans.Rollback();
                    throw;
                }
                catch (Exception ex)
                {
                    filewriter.FileWriterAppend(Files.ExceptionInDataAccessLayer, (new List<string>() { ex.Message, ex.StackTrace }));
                    Console.WriteLine(ex.Message);
                    trans.Rollback();
                }
                finally
                {
                    disconnect();
                }
            }
            catch (Exception ex)
            {
                filewriter.FileWriterAppend(Files.ExceptionInDataAccessLayer, (new List<string>() { ex.Message, ex.StackTrace }));
            }
        }
    }
}