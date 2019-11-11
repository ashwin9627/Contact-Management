using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BussinessLogic
{
    public class RegexExpression
    {
        public static bool IsPhoneNumber(string number)
        {
            return Regex.Match(number, @"^[0-9]{10}$").Success;
        }
        public static bool IsEmail(string email)
        {
            string pattern = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
            bool status = false;
            if (email != "")
            {
                if (Regex.IsMatch(email, pattern))
                {
                    status = true;
                }
            }
            else
            {
                status = false;
            }
            return status;

             //   return Regex.Match(email, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            //    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
             //   RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)).Success;
        }
        public static bool HomePhoneNumber(string number)
        {
            int num1;
           // string num123;
            bool status = false;
            if (number == null || number == "")
            {
                status = false;
            }
            else
            {
               //  num123 = number.;
                //  num1 = Convert.ToInt32(num123);
                int check;
                //num1 = int.Parse(number);
                //if (num1 > 6000000)
                //{
                  if (Regex.Match(number, @"^([6-9]\d|\d{7,})$").Success)   //   @" ^[0 - 9]{ 7}$
                    status = true;
             //   }
              //  else
               // {
                 //   num123 = num1.ToString();
                  //  status = false;
              //  }
            }
            
         // return Regex.Match(number, @"^[0-9]{7}$").Success;
            return status;
        }

        public static bool IsValidDate(DateTime date)
        {
            int Age;
            bool status = false;
            try
            {
                
                //DateTime BirthDate = date;
                //  DateTime BirthDate = Convert.ToDateTime(date);
                DateTime BirthDate1;
                string date1 = date.ToString();
                if(DateTime.TryParse(date1, out BirthDate1))
                {
                    DateTime CurrentDate = DateTime.Today;
                    Age = CurrentDate.Year - BirthDate1.Year;
                    string dateconvert = date.ToString();
                    if (dateconvert == " " || dateconvert == null)
                    {
                        status = false;
                    }


                    else
                    {
                        if (Age < 18)
                        {
                            string pattern = @"([0-2][0-9]|(3)[0-1])(\-)(((0)[0-9])|((1)[0-2]))(\-)\d";
                            if (Regex.IsMatch(Convert.ToString(BirthDate1), pattern))
                            {
                                status = true;
                            }
                        }

                    }
                }
                else
                {

                }

                //Birthdate validations 
                // string b1 = date.ToString("yyyy:MM:dd");
                
                
            }
            catch(Exception)
            {
                Console.WriteLine("Give the Proper Date");
            }
            //return Regex.Match(date.ToLongDateString(),"^\\d{ 4}-((0\\d)| (1[012]))-(([012]\\d)| 3[01])$").Success;
            //return Regex.Match(date.ToLongDateString(), "^\\d{ 4}- ((0[1 - 9]) | (1[012])) - ((0[1 - 9] |[12]\\d) | 3[01])$").Success;
            //return Regex.Match(date.ToLongDateString(), "\\d{4}(?:/\\d{1,2}){2}").Success;
            //  return Regex.Match(date.ToLongDateString(), "^(?:(?:(?:(?:(?:[13579][26]|[2468][048])00)|(?:[0-9]{2}(?:(?:[13579][26])|(?:[2468][048]|0[48]))))(?:(?:(?:09|04|06|11)(?:0[1-9]|1[0-9]|2[0-9]|30))|(?:(?:01|03|05|07|08|10|12)(?:0[1-9]|1[0-9]|2[0-9]|3[01]))|(?:02(?:0[1-9]|1[0-9]|2[0-9]))))|(?:[0-9]{4}(?:(?:(?:09|04|06|11)(?:0[1-9]|1[0-9]|2[0-9]|30))|(?:(?:01|03|05|07|08|10|12)(?:0[1-9]|1[0-9]|2[0-9]|3[01]))|(?:02(?:[01][0-9]|2[0-8])))))$").Success;
            // return Regex.Match(b1.ToString(), @"([0-2][0-9]|(3)[0-1])(\/)(((0)[0-9])|").Success;
            //return Regex.Match(BirthDate.ToLongDateString(), @"(^([0-2][0-9]|(3)[0-1])(\/-)(((0)[0-9])|((1)[0-2]))(\/-)\d{4}$").Success;
            return status;
        }
        public static bool NameValidation(string name)
        {
            return Regex.Match(name, @"^[a-zA-Z\s]+$").Success;
        }

        public static bool IsActivecheck(bool isActive)
        {
            if(isActive!=true || isActive!=false)
            {
                return false;
            }
            return true;
        }
    }
}