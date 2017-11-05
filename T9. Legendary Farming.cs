using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T9.Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
                var itemValues = new Dictionary<string, long>();
                itemValues.Add("fragments", 0);
                itemValues.Add("shards", 0);
                itemValues.Add("motes", 0);
                int count = 1;

                while (count != 10)
                {
                    string[] inputedInfo = Console.ReadLine().ToLower().Split().ToArray();
                    var optainedItem = "";


                    for (int i = 1; i < inputedInfo.Length; i = i + 2)
                    {
                        int materialValue = int.Parse(inputedInfo[i - 1]);
                        string material = inputedInfo[i];

                        if (!itemValues.ContainsKey(material))
                        {
                            itemValues.Add(material, 0);
                        }

                        itemValues[material] += materialValue;

                        optainedItem = CheckForLegendery(itemValues);

                        if (optainedItem != "")
                        {
                            Console.WriteLine($"{optainedItem} obtained!");
                            break;
                        }

                    }

                    if (optainedItem != "")
                    {
                        break;
                    }
                    count++;

                }

                PrintAllItems(itemValues);
            }

            private static void PrintAllItems(Dictionary<string, long> itemValues)
            {
              
            var rareItems = itemValues.Take(3).OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToList();
            var junkItems = itemValues.Skip(3).OrderBy(x => x.Key).ToList();


                foreach (var rareItem in rareItems)
                {
                    Console.WriteLine($"{rareItem.Key}: {rareItem.Value}");
                }


                foreach (var item in junkItems)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }


            }

            private static string CheckForLegendery(Dictionary<string, long> itemValues)
            {
                string itemForCraft = "";
                if (itemValues["fragments"] >= 250)
                {
                    itemForCraft = "Valanyr";
                    itemValues["fragments"] -= 250;
                }

                if (itemValues["shards"] >= 250)
                {
                    itemForCraft = "Shadowmourne";
                    itemValues["shards"] -= 250;
                }

                if (itemValues["motes"] >= 250)
                {
                    itemForCraft = "Dragonwrath";
                    itemValues["motes"] -= 250;
                }

                return itemForCraft;
            }
        }
    }

