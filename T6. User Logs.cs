using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T6.User_Logs
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new Dictionary<string, Dictionary<string, int>>();  // user, IP, count

            while (true)
            {
                string line = Console.ReadLine();
                if (line =="end")
                {
                    break;
                }

                string[] commandArgs = line.Split(' ');
                string name = commandArgs[2].Replace("user=","");
                string IP = commandArgs[0].Replace("IP=", "");
         


                if (!users.ContainsKey(name))
                {
                    users.Add(name, new Dictionary<string, int>());
                }
                if (!users[name].ContainsKey(IP))
                {
                    users[name].Add(IP, 0);
                }
                users[name][IP] = users[name][IP] + 1;
            }
            foreach (var user in users.OrderBy(x=> x.Key))
            {
                Console.WriteLine(user.Key+": ");

                StringBuilder sb = new StringBuilder();

                foreach (var IPandCount in user.Value)
                {
                    sb.Append(IPandCount.Key).Append(" => ").Append(IPandCount.Value + ", ");
                  
                }
                sb.Remove(sb.Length - 2, 2);
                sb.Append(".");
                Console.WriteLine(sb.ToString());
            }
        }
    }
}
