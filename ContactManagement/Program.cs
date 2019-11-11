using BussinessLogic;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.RegularExpressions;

namespace ContactManagement
{
    public class Program
    {
        
        Contact c1 = new Contact();
       
        static void Main(string[] args)
        {

            WelcomePage welcome123 = new WelcomePage();
            welcome123.welcome();
         }

        //public static bool IsPhoneNumber(string number)
        //{
        //    return Regex.Match(number, @"^[0-9]{6}$").Success;
        //}
        //public static bool IsEmail(string email)
        //{
        //    return Regex.Match(email,@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
        //        @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
        //        RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)).Success;
        //}

        //public static bool IsValidDate(DateTime date)
        //{
        //    //Birthdate validations 

        //    // string b1 = date.ToString("yyyy:MM:dd");
        //    DateTime BirthDate = date;
        //    DateTime CurrentDate = DateTime.Today;
        //    int Age = CurrentDate.Year - BirthDate.Year;
        //    if (Age > 18)
        //    {

        //          return false;
        //    }
        //    return Regex.Match(BirthDate.ToLongDateString(), @"(^([0-2][0-9]|(3)[0-1])(\/-)(((0)[0-9])|((1)[0-2]))(\/-)\d{4}$").Success;
        //}

        public void UpdateContactsChoice()
        {
            string retry1 = "no";
            do
            {
                Console.WriteLine("1. To Update First Name");
                Console.WriteLine("2. To Update Middle Name");
                Console.WriteLine("3. To Update last Name");
                Console.WriteLine("4. To Update Date of Birthday");
                Console.WriteLine("5. To Update Email Id");
                Console.WriteLine("6. To Update Work Phone");
                Console.WriteLine("7. To Update Home Name");
                Console.WriteLine("8. To Update Mobile Number");
                int choice1 = 0;
                int contactid1 = 0;
                if (int.TryParse(Console.ReadLine(), out choice1))
                    Console.WriteLine("Enter your Contact ID");
                else
                {
                    Console.WriteLine("Enter the valid choice");
                    Environment.Exit(0);
                }
                if (int.TryParse(Console.ReadLine(), out contactid1))
                {
                    Console.WriteLine("Enter the data to update");
                    string updateValue = Console.ReadLine();
                    c1.UpdateContactsChoiceProcess(choice1, contactid1, updateValue);
                }
                else
                {
                    Console.WriteLine("Enter the Valid Contact Id");
                    Environment.Exit(0);
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Do You want to update one more data,Press 'yes',else 'no'");
                string retrychoice=Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                if (retrychoice == "yes")
                {
                    retry1 = "yes";
                    Console.Clear();
                }
                  
                else
                {
                    WelcomePage w1 = new WelcomePage();
                    Console.Clear();
                    w1.welcome();
                }
                    
            }
            while (retry1 =="yes");
        }

        public static bool NameValidation(string name)
        {
            return Regex.Match(name, @"^[a-zA-Z\s]+$").Success;
        }

        RegexExpression ex = new RegexExpression();
      //  static bool temp = true;

        public bool SatisfyCondition(bool data,string name)
        {
            bool temp = true;
            name.ToLower();
            if (data == false)
            {
                switch(name)
                {
                    case "name":
                        Console.WriteLine("Name should not contain special characters or numbers");
                        break;
                    case "email":
                        Console.WriteLine("Enter the Valid Email Id");
                        break;
                    case "phone":
                        Console.WriteLine("Enter valid Phone number ");
                        break;
                    case "date":
                        Console.WriteLine("Enter a valid date");
                        break;
                    case "mobile":
                        Console.WriteLine("Enter a valid mobile number");
                        break;
                    case "isactive":
                        Console.WriteLine("Your boolean data 'true' or 'false' ");
                        break;
                }
                
                temp = false;
            }
            else
            {
                temp = true;
            }
            return temp;
        }

        public void InsertContacts()
        {
            Console.WriteLine();
            Console.WriteLine("Add a new Contact");
            
            
            var temp1 = true;
            ContactInfo obj = new ContactInfo();
            try
            {
                do
                {
                    Console.Write("First Name\t:\t");
                    obj.firstName = Console.ReadLine();
                    var fname1 = RegexExpression.NameValidation(obj.firstName);
                    temp1 = SatisfyCondition(fname1, "name");
                }
                while (temp1 == false);
                Console.Write("Middle Name\t:\t");
                obj.middleName = Console.ReadLine();
                var mname1 = RegexExpression.NameValidation(obj.middleName);
                temp1 = SatisfyCondition(mname1, "name");


                Console.Write("Last Name\t:\t");
                obj.lastName = Console.ReadLine();
                var lname1 = RegexExpression.NameValidation(obj.lastName);
                temp1 = SatisfyCondition(lname1, "name");

                do
                {
                    Console.Write("Date of Birth (DD-MM-YYYY)\t:\t");
                    // string datestring = Console.ReadLine();
                    DateTime birth;
                    // obj.Birthday =
                    if (DateTime.TryParse(Console.ReadLine(), out birth))
                        obj.Birthday = birth;
                    else
                    {
                        Console.WriteLine("Date is not valid");
                    }
                    
                    var Birthday1 = RegexExpression.IsValidDate(obj.Birthday);
                    temp1 = SatisfyCondition(Birthday1, "Date");
                  //  obj.Birthday = Convert.ToDateTime(datestring);
                }
                while (temp1 == false);

                do
                {
                    try
                    {
                        Console.Write("Email\t:\t");
                        obj.Email = Console.ReadLine();
                        var Email1 = RegexExpression.IsEmail(obj.Email);
                        temp1 = SatisfyCondition(Email1, "email");
                    }
                    catch(Exception)
                    {
                        Console.WriteLine("Enter the valid date");
                    }
                }
                while (temp1 == false);
                do
                {
                    Console.Write("Work Number\t:\t");
                    obj.WorkNumber = Console.ReadLine();
                    var WorkNumber1 = RegexExpression.HomePhoneNumber(obj.WorkNumber);
                    temp1 = SatisfyCondition(WorkNumber1, "phone");
                }
                while (temp1 == false);
                do
                {
                    Console.Write("Home Number\t:\t");
                    obj.HomeNumber = Console.ReadLine();
                    var HomeNumber1 = RegexExpression.HomePhoneNumber(obj.HomeNumber);
                    temp1 = SatisfyCondition(HomeNumber1, "phone");
                }
                while (temp1 == false);
                do
                {
                    Console.Write("Mobile Number\t:\t");
                    obj.MobileNumber = Console.ReadLine();
                    var MobileNumber1 = RegexExpression.IsPhoneNumber(obj.MobileNumber);
                    temp1 = SatisfyCondition(MobileNumber1, "mobile");
                }
                 while (temp1 == false);
            //    do
            //    {
            //        Console.Write("Active status\t:\t");
            //        obj.IsActive = Convert.ToBoolean(Console.ReadLine());
            //        var IsActive1 = RegexExpression.IsActivecheck(obj.IsActive);
            //        temp1 = SatisfyCondition(IsActive1, "isactive");
            //    }
            //    while (temp1 == false);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //ValidationContext context = new ValidationContext(obj, null, null);
            //List<ValidationResult> results = new List<ValidationResult>();
            //bool valid = Validator.TryValidateObject(obj, context, results, true);

            //if (!valid)
            //{
            //    foreach (ValidationResult vr in results)
            //    {
            //        Console.ForegroundColor = ConsoleColor.Blue;
            //     //   Console.Write("Member Name :{0}", vr.MemberNames.First());
            //   
          //  Console.Write("Member Name :{0}", vr.MemberNames);
            //        Console.ForegroundColor = ConsoleColor.Red;
            //        Console.Write("   ::  {0}{1}", vr.ErrorMessage, Environment.NewLine);
            //    }
            //}
            //Console.ForegroundColor = ConsoleColor.White;
            //Console.WriteLine("\nPress any key to exit");
            //Console.ReadKey();

            try
            {
                //    productProcess process = new productProcess();  
                             
                bool status= c1.InsertNewContact(obj);
                if(status==true)
                {
                    Console.WriteLine("\nContact Successfully added");
                }
                else
                {
                    Console.WriteLine("Insertion failed");
                }                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void UpdateContacts()
        {
            Console.WriteLine();
            Console.WriteLine("Update Contact Details");


            ContactInfo obj = new ContactInfo();

            Console.WriteLine("Enter the ContactId that you want to update");
            obj.ContactId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Update the Fields that you want to update");
            //Console.Write("First Name\t:\t");
            //obj.firstName = Console.ReadLine();
            //Console.Write("Middle Name\t:\t");
            //obj.middleName = Console.ReadLine();
            //Console.Write("Last Name\t:\t");
            //obj.lastName = Console.ReadLine();
            //Console.Write("Date of Birth (YY/MM/DD)\t:\t");
            //obj.Birthday = Convert.ToDateTime(Console.ReadLine());


            //Console.Write("Email\t:\t");
            //obj.Email = Console.ReadLine();
            //Console.Write("Work Number\t:\t");
            //obj.WorkNumber = Console.ReadLine();
            //Console.Write("Home Number\t:\t");
            //obj.HomeNumber = Console.ReadLine();
            //Console.Write("Mobile Number\t:\t");
            //obj.MobileNumber = Console.ReadLine();
            //Console.Write("Active status\t:\t");
            //obj.IsActive = Convert.ToBoolean(Console.ReadLine());
            //WelcomePage w1 = new WelcomePage();
            //w1.Test2(obj.ContactId);
            var st1=c1.ShowContactInfoById(obj.ContactId);
            Console.Write("First Name\t':{0}'\t Update FirstName:\t", st1.firstName);
            
            obj.firstName = Console.ReadLine().ToString();
            if (obj.firstName == "" || obj.firstName == null)
            {
                st1.firstName = obj.firstName;
            }
            var fname1 = RegexExpression.NameValidation(obj.firstName);

                Console.Write("Middle Name\t:{0}'\tUpdate MiddleName:\t",st1.middleName);
                obj.middleName = Console.ReadLine().ToString();
                var mname1 = RegexExpression.NameValidation(obj.middleName);
      
        Console.Write("Last Name\t:'{0}'\tUpdate LastName:\t",st1.lastName);
                obj.lastName = Console.ReadLine().ToString();
                var lname1 = RegexExpression.NameValidation(obj.lastName);
      

                    Console.Write("Date of Birth (DD-MM-YYYY)\t:\t :'{0}'\t Update BirthDate\t:",st1.Birthday);
                    // string datestring = Console.ReadLine();
                    DateTime birth;
            // obj.Birthday =
            try
            {
                if (DateTime.TryParse(Console.ReadLine(), out birth))
                    obj.Birthday = birth;
                //else
                //{
                //    Console.WriteLine("Date is not valid");
                //}
            }
            catch(Exception e)
            {
                Console.WriteLine("DateTime is not valid");
            }
            var Birthday1 = RegexExpression.IsValidDate(obj.Birthday);
                    try
                   {
                        Console.Write("Email\t: '{0}'\tUpdate Email ID:\t",st1.Email);
                        obj.Email = Console.ReadLine();
                        var Email1 = RegexExpression.IsEmail(obj.Email);
                    }
                    catch(Exception)
                    {
                        Console.WriteLine("Enter the valid date");
                    }
                    Console.Write("Work Number :'{0}'\tUpdate Work Number:\t",st1.WorkNumber);
                    obj.WorkNumber = Console.ReadLine();
                    var WorkNumber1 = RegexExpression.HomePhoneNumber(obj.WorkNumber);
                    Console.Write("Home Number :'{0}'\tUpdate Home Number:\t",st1.HomeNumber);
                    obj.HomeNumber = Console.ReadLine();
                    var HomeNumber1 = RegexExpression.HomePhoneNumber(obj.HomeNumber);
                    Console.Write("Mobile Number :'{0}'\tUpdate Mobile Number:\t",st1.MobileNumber);
                    obj.MobileNumber = Console.ReadLine();
                    var MobileNumber1 = RegexExpression.IsPhoneNumber(obj.MobileNumber);
            try
            {
                //    productProcess process = new productProcess();  
                Contact c1 = new Contact();
               // c1.UpdateContact(obj);

                bool status = c1.UpdateContact(obj);
                if (status == true)
                {
                    Console.WriteLine("\nContact Successfully Updated");
                }
                else
                {
                    Console.WriteLine("Updation failed");
                }
                //  ContactInfointer.GetDetails(obj);
                // Console.WriteLine("\nProduct Successfully added");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void DeleteContacts()
        {
            Console.WriteLine();
            Console.WriteLine("Delete Contact Details");
            ContactInfo obj = new ContactInfo();
            Console.WriteLine("Enter the ContactId that you want to Remove");
            int id = Convert.ToInt32(Console.ReadLine());
            c1.DeleteContact(id);
        }
        }
    }