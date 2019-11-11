using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    class CustomExceptions:Exception
    {
        public CustomExceptions()
        {

        }
        public CustomExceptions(string Message):base(Message)
        {

        }
        public CustomExceptions(string Message,Exception inner):base(Message,inner)
        {

        }

    }

    public class UserIDException:Exception
    {
        public UserIDException()
        {
            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.WriteLine("Contact ID Not Found");
            //Console.ForegroundColor = ConsoleColor.White;
        }
        public UserIDException(string msg):base(msg)
        {
        }
    }
    class DateTimeNullException:Exception
    {
        public DateTimeNullException()
        {
            Console.WriteLine("Date of birth should not be null");
        }
    }
 
}