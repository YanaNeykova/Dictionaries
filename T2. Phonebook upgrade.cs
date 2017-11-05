using System;
using System.Collections.Generic;
using System.Linq;
namespace T2. PhonebookUpgrade
{
    class Program
    {
        static void Main(string[] args)
        {
            string entryLine = Console.ReadLine();
            SortedDictionary<string, string> phonebook = new SortedDictionary<string, string>();
            while (!entryLine.Equals("END"))
            {
                string[] dictionaryLines = entryLine.Split(' ');
                string command = dictionaryLines[0];
                if (command.Equals("A"))
                {
                    AddNewEntry(phonebook, dictionaryLines);
                }
                else if (command.Equals("S"))
                {
                    PrintEntry(phonebook, dictionaryLines);
                }
                else if (command.Equals("ListAll"))
                {
                    PrintAllEntries(phonebook);
                }
                entryLine = Console.ReadLine();
            }
        }



        private static void PrintAllEntries(SortedDictionary<string, string> phonebook)
        {
           
            foreach (KeyValuePair<string, string> entry in phonebook)
            {
                Console.WriteLine($"{entry.Key} -> {entry.Value}");
            }
        }



        private static void PrintEntry(SortedDictionary<string, string> phonebook, string[] dictionaryLines)
        {
            string contact = dictionaryLines[1];
            if (phonebook.ContainsKey(contact))
            {
                Console.WriteLine($"{contact} -> {phonebook[contact]}");
            }
            else
            {
                Console.WriteLine($"Contact {contact} does not exist.");
            }
        }



        private static void AddNewEntry(SortedDictionary<string, string> phonebook, string[] dictionaryLines)
        {
            string contact = dictionaryLines[1];
            string number = dictionaryLines[2];
            phonebook[contact] = number;
        }


    }
}