using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4.Fix_emails
{
    class Program
    {
        static void Main(string[] args)
        {
            var emailList = new Dictionary<string, string>();  // name, email

            while (true)
            {
                string name = Console.ReadLine();
                if (name=="stop")
                {
                    break;
                }
                string email = Console.ReadLine();

                string domain = email.Substring(email.Length - 2);

                if (domain=="uk" || domain=="us")
                {
                    continue;
                }
                else
                {
                    emailList.Add(name, email);
                }
            }
            foreach (var item in emailList)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }


        }
    }
}
