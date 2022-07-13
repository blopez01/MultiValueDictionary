using System;
using System.Collections.Generic;

namespace MultiValueDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            while (true)
            {
                Console.Write("> ");
                string input = Console.ReadLine();
                string[] inputs = input.Split(' ');
                if (inputs[0].Equals("ADD"))
                {
                    Add(dict, inputs);
                }
                else if (inputs[0].Equals("ITEMS"))
                {
                    Items(dict);
                }
                else
                {
                    Console.Write("Bad command\n");
                }
            }
        }
        private static void Add(Dictionary<string, string> dict, string[] inputs)
        {
            string key = inputs[1];
            string value = inputs[2];
            string valueFound;
            if (dict.TryGetValue(key, out valueFound))
            {
                if (valueFound.Equals(value))
                {
                    Console.Write(") ERROR, member already exists for key\n");
                    return;
                }
            }
            dict.Add(key, value);
            Console.Write(") Added\n");
        }
        private static void Items(Dictionary<string, string> dict)
        {
            int i = 1;
            foreach (KeyValuePair<string, string> kvp in dict)
            {
                Console.Write($"{i}) {kvp.Key}: {kvp.Value}\n");
                i++;
            }
        }
    }
}
