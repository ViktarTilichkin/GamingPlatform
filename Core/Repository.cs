using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Core.Repository
{
    public class RepositoryData
    {
        public bool Read()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine(path);
            StreamReader sr1 = null;
            StringBuilder stringBuilde = new StringBuilder();
            sr1 = new StreamReader(@"..\Data.txt");

            //string[] Lines = File.ReadAllLines(@"C:\Users\Flog\Documents\Hscool\GamingPlatform\Core\Data.txt");
            //    if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(pass))
            //    {
            //        Console.WriteLine("ERROR");
            //        return false;
            //    }
            //    for (int i = 0; i < Lines.Length; i++)
            //    {
            //        string[] strings = Lines[i].Split(',');
            //        if (strings[0] == login && strings[1] == pass)
            //        {
            //            Console.WriteLine("Login Succesful");
            //            return true;
            //        }
            //    }
            //    System.Console.WriteLine("ERROR input");
            return false;
        }
        public bool Write()
        {
            return false;
        }
        public bool Update()
        {
            return false;
        }
        public bool Delete()
        {
            return false;
        }
    }
}
