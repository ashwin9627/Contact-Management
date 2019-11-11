using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Files
    {
        FileStream fi;
        StreamReader sr;
        StreamWriter sw;

        public static string ExceptionInBussinessLogic = "E:\\Projectcontact_ExceptionInBussinessLogic.txt";
        public static string ExceptionInDataAccessLayer = "E:\\Projectcontact_ExceptionInDataAccessLayer.txt";
        public static string ExceptionInUILayer = "E:\\Projectcontact_ExceptionInUILayer.txt";
        public static string ExcptionSharedLayer = "E:\\Projectcontact_SharedLayer.txt";

       // public static void Path()
        //{

        //}


        public void FileReader(string path)
        {
            try
            {
                using (fi = new FileStream(path, FileMode.Open))
                {
                    using (sr = new StreamReader(fi))
                    {
                        string sr1 = sr.ReadLine();
                        foreach (var read1 in sr1)
                        {
                            Console.WriteLine(read1);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
             // FileWriterAppend("E:\\ExceptionCatcher.txt", (new List<string>() { ex.Message, ex.StackTrace }));
                FileWriterAppend(Files.ExcptionSharedLayer, (new List<string>() { ex.Message, ex.StackTrace }));
            }
        }

        public void FileWriterAppend(string path, List<string> writer)
        {
            try
            {
                if (File.Exists(path))
                {
                    using (fi = new FileStream(path, FileMode.Append))
                    {
                        using (sw = new StreamWriter(fi))
                        {
                            sw.Write(writer);
                        }
                    }
                }
                else
                    Console.WriteLine("File not Found");
            }
            catch (Exception ex)
            {
                FileWriterAppend(Files.ExcptionSharedLayer, (new List<string>() { ex.Message, ex.StackTrace }));
                Console.WriteLine(ex.Message);
            }
        }
    }
}