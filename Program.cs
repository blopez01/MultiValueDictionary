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
                Console.Write(">");
                string input = Console.ReadLine();
                Console.WriteLine("You entered " + input);
                if (input.StartsWith("ADD"))
                {
                    Add(dict, input);
                }
            }
        }
        private static void Add(Dictionary<string, string> dict, string input)
        {
            string[] inputs = input.Split(' ');
            string key = inputs[1];
            string value = inputs[2];
            dict.Add(key, value);
        }
    }
}
