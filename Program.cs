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
                else if (inputs[0].Equals("ALLMEMBERS"))
                {
                    AllMembers(dict);
                }
                else if (inputs[0].Equals("KEYS"))
                {
                    Keys(dict);
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
        private static void AllMembers(List<KeyValuePair<string, string>> dict)
        {
            int i = 1;
            foreach (KeyValuePair<string, string> kvp in dict)
            {
                Console.Write($"{i}) {kvp.Value}\n");
                i++;
            }
        }
        private static void Keys(List<KeyValuePair<string, string>> dict)
        {
            //are keys unique? or can they be copied
            int i = 1;
            List<string> uniqueKeys = new List<string>();
            foreach (KeyValuePair<string, string> kvp in dict)
            {
                if (!uniqueKeys.Contains(kvp.Key))
                {
                    uniqueKeys.Add(kvp.Key);
                }
            }
            if (uniqueKeys.Count.Equals(0))
            {
                Console.Write(") empty set\n");
            }
            else
            {
                foreach (string key in uniqueKeys)
                {
                    Console.Write($"{i}) {key}\n");
                    i++;
                }
            }
        }
    }
}
