using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var handsOfCards = new Dictionary<string, List<string>>();

        string inputLine = Console.ReadLine();

        while (inputLine != "JOKER")
        {
            var input = inputLine.Trim()
                .Split(new char[] { ':', }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            string name = input[0];

            List<string> newHand = input[1].Trim().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            if (handsOfCards.ContainsKey(name))
            {
                handsOfCards[name].AddRange(newHand);
                handsOfCards[name] = DistinctHand(handsOfCards[name]);
            }
            else
            {
                handsOfCards.Add(name, newHand);
                handsOfCards[name] = DistinctHand(handsOfCards[name]);
            }

            inputLine = Console.ReadLine();
        }

        foreach (var hand in handsOfCards)
        {
            int personalResult = CalculateHandValue(hand.Value);
            Console.WriteLine("{0}: {1}", hand.Key, personalResult);
        }

    }

    private static List<string> DistinctHand(List<string> hand)
    {
        List<string> distinctHand = new List<string>();
        distinctHand.AddRange(hand.Distinct());
        return distinctHand;
    }

    private static int CalculateHandValue(List<string> hand)
    {
        int result = 0;

        foreach (string card in hand)
        {
            char first = card.First();
            char last = card.Last();
            int power = 0;
            int type = 0;

            switch (first)
            {
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    power = int.Parse(first.ToString());
                    break;
                case 'J':
                    power = 11;
                    break;
                case 'Q':
                    power = 12;
                    break;
                case 'K':
                    power = 13;
                    break;
                case 'A':
                    power = 14;
                    break;
                default:
                    power = 10;
                    break;
            }
            switch (last)
            {
                case 'S':
                    type = 4;
                    break;
                case 'H':
                    type = 3;
                    break;
                case 'D':
                    type = 2;
                    break;
                case 'C':
                    type = 1;
                    break;
            }
            result += power * type;
        }
        return result;
    }

}