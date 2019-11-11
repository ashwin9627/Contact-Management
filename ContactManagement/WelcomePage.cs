using BussinessLogic;
using Model;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagement
{
    public class WelcomePage
    {
        Contact c1 = new Contact();
        Files filesshared = new Files();
        Program p1 = new Program();
        string Retry = "No";
        public void welcome()
        {
            int UserInput;
            try
            {
                do
                {
                    Console.WriteLine("************************************************************************************************************************");
                    Console.WriteLine("****************************************************Contact Management**************************************************");
                    Console.WriteLine("************************************************************************************************************************");

                    Console.WriteLine("");
                    Console.WriteLine("\t1. Show All Contacts");
                    Console.WriteLine("\t2. Contact Details");
                    Console.WriteLine("\t3.Filter with starting Name");
                    Console.WriteLine("\t4. Add a Contact");
                    Console.WriteLine("\t5. Update a Contact");
                    Console.WriteLine("\t6. Delete a Contact");
                    Console.WriteLine("\t7. Exit");
                    int choice;
                    // UserInput = Convert.ToInt32(Console.ReadLine());

                    if (int.TryParse(Console.ReadLine(), out choice))
                    {
                        switch (choice)
                        {
                            case 1:

                                Test();
                                retrymethod();
                                break;
                            case 2:
                                Console.WriteLine("Enter the ID that you want to display the details");
                                if (int.TryParse(Console.ReadLine(), out choice))
                                    Test2(choice);
                                else
                                    Console.WriteLine("Enter the valid ID");
                                retrymethod();
                                break;
                            case 3:
                                Console.WriteLine("Enter the first name letters that you want to display the details");
                                var choice1 = Console.ReadLine();
                                Test3(choice1);
                                retrymethod();
                                break;
                            case 4:
                                p1.InsertContacts();
                                retrymethod();
                                break;
                            case 5:
                                Console.WriteLine("To update all details Click '1' ,To update selected fields Click '2'");
                                if(int.TryParse(Console.ReadLine(),out choice))
                                    if(choice==1)
                                    p1.UpdateContacts();
                                if (choice == 2)
                                    p1.UpdateContactsChoice();
                                retrymethod();
                                break;
                            case 6:
                                p1.DeleteContacts();
                                retrymethod();
                                break;
                            case 7:
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Your Number is Invalid\n");
                                retrymethod();
                                break;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Your Input is not a valid number");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                while (Retry == "yes");
            }
            catch(Exception ex)
            {
                filesshared.FileWriterAppend(Files.ExceptionInUILayer, (new List<string>() { ex.Message, ex.StackTrace }));
            }

        }
        public bool retrymethod()
        {
            bool status = true;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Do You want to retry: Yes|No");
            Retry = Console.ReadLine().ToLower();
            if (Retry == "yes")
                Retry = "yes";
            else
                Environment.Exit(0);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            return status;
        }
        public void Test()
        {
           //  Contact c1 = new Contact();
            Console.WriteLine("retrieving all products");
            try
            {
                var list = c1.ShowContactInfo();
                foreach (var item in list)
                {
                    //  Console.WriteLine("{0},{1},{2},{3},{4}",
                    //    item.ContactId, item.firstName, item.middleName, item.lastName, item.Birthday,
                    //  item.Email,item.WorkNumber,item.HomeNumber,item.MobileNumber,item.IsActive);

                    Console.WriteLine($"{item.ContactId}, {item.firstName}, {item.middleName}, {item.lastName}, { item.Birthday.Date}, "+
                        $"{item.Email}, {item.WorkNumber}, {item.HomeNumber}, {item.MobileNumber}, {item.IsActive}");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Test2(int para)
        {
            Contact c1 = new Contact();
            Console.WriteLine("retrieving Contacts with ID");
            try
            {
                //string criteria = "";
                //c1.ShowContactInfo();
                ContactInfo obj = new ContactInfo();
                 obj = c1.ShowContactInfoById(para);
               // bool flag = false;
                //foreach (var item in list)
                //{
                //    //Console.WriteLine("{0},{1},{2},{3},{4}",
                //    //    item.ContactId, item.firstName, item.middleName, item.lastName, item.Birthday,
                //    //    item.Email, item.WorkNumber, item.HomeNumber, item.MobileNumber, item.IsActive);
                //    Console.WriteLine($"{item.ContactId}, {item.firstName}, {item.middleName}, {item.lastName}, { item.Birthday.Date}, " +
                //      $"{item.Email}, {item.WorkNumber}, {item.HomeNumber}, {item.MobileNumber}, {item.IsActive}");

                    if (obj.ContactId == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    throw new UserIDException("Contact Id not found");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    //Console.WriteLine("{0},{1},{2},{3},{4}",
                    //    item.ContactId, item.firstName, item.middleName, item.lastName, item.Birthday,
                    //    item.Email, item.WorkNumber, item.HomeNumber, item.MobileNumber, item.IsActive);
                    Console.WriteLine($"{obj.ContactId}, {obj.firstName}, {obj.middleName}, {obj.lastName}, { obj.Birthday.Date}, " +
                      $"{obj.Email}, {obj.WorkNumber}, {obj.HomeNumber}, {obj.MobileNumber}, {obj.IsActive}");
                }
                //        flag = true;
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Test3(string para)
        {
            Contact c1 = new Contact();
            Console.WriteLine("retrieving Contacts with first letter of contact");
            try
            {
                var list = c1.ShowContactInfoByStartingLetter(para);
                foreach (var item in list)
                {
                    Console.WriteLine("{0},{1},{2},{3},{4}",
                        item.ContactId, item.firstName, item.middleName, item.lastName, item.Birthday,
                        item.Email, item.WorkNumber, item.HomeNumber, item.MobileNumber, item.IsActive);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}    