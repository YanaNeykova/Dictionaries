using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _T1.Phonebook
{
    class Phonebook
    {
        static void Main()
        {
            string[] entry = Console.ReadLine().Split();
            IDictionary<string, string> phoneBookDictionary = new Dictionary<string, string>();
            while (entry[0] != "END")
            {
                if (entry[0] == "A")
                {
                    if (phoneBookDictionary.ContainsKey(entry[1]))
                    {
                        phoneBookDictionary.Remove(entry[1]);
                    }
                    phoneBookDictionary.Add(entry[1], entry[2]);
                }
                else
                {
                    if (phoneBookDictionary.ContainsKey(entry[1]))
                    {
                        Console.WriteLine("{0} -> {1}", entry[1], phoneBookDictionary[entry[1]]);
                    }
                    else if (entry[0] == "S")
                    {
                        Console.WriteLine("Contact {0} does not exist.", entry[1]);
                    }
                }
                entry = Console.ReadLine().Split();
            }
        }
    }
}