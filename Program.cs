using System;
using System.Collections.Generic;

namespace MultiValueDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            List<KeyValuePair<string, string>> dict = new List<KeyValuePair<string, string>>();
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
        private static void Add(List<KeyValuePair<string, string>> dict, string[] inputs)
        {
            string key = inputs[1];
            string value = inputs[2];
            KeyValuePair<string, string> kvp = new KeyValuePair<string, string>(key, value);
            string valueFound;
            if (dict.Contains(kvp))
            {
                Console.Write(") ERROR, member already exists for key\n");
                return;
            }
            dict.Add(kvp);
            Console.Write(") Added\n");
        }
        private static void Items(List<KeyValuePair<string, string>> dict)
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
