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
                if (inputs[0].Equals("KEYS"))
                {
                    Keys(dict);
                }
                else if (inputs[0].Equals("MEMBERS"))
                {
                    Members(dict, inputs);
                }
                else if (inputs[0].Equals("ADD"))
                {
                    Add(dict, inputs);
                }
                else if (inputs[0].Equals("REMOVE"))
                {
                    Remove(dict, inputs);
                }
                else if (inputs[0].Equals("REMOVEALL"))
                {
                    RemoveAll(dict, inputs);
                }
                else if (inputs[0].Equals("CLEAR"))
                {
                    Clear(dict);
                }
                else if (inputs[0].Equals("KEYEXISTS"))
                {
                    KeyExists(dict, inputs, true);
                }
                else if (inputs[0].Equals("MEMBEREXISTS"))
                {
                    MemberExists(dict, inputs, true);
                }
                else if (inputs[0].Equals("ALLMEMBERS"))
                {
                    AllMembers(dict);
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
        private static void Clear(List<KeyValuePair<string, string>> dict)
        {
            dict.Clear();
            Console.Write(") Cleared\n");
        }
        private static void Members(List<KeyValuePair<string, string>> dict, string[] inputs)
        {
            List<string> uniqueMembers = new List<string>();
            int i = 1;
            foreach (KeyValuePair<string, string> kvp in dict)
            {
                if (kvp.Key.Equals(inputs[1]))
                {
                    uniqueMembers.Add(kvp.Value);
                }
            }
            if (uniqueMembers.Count.Equals(0))
            {
                Console.Write(") ERROR, key does not exist.\n");
            }
            else
            {
                foreach (string member in uniqueMembers)
                {
                    Console.Write($"{i}) {member}\n");
                    i++;
                }
            }
        }
        private static bool KeyExists(List<KeyValuePair<string, string>> dict, string[] inputs, bool print)
        {
            bool isExistingKey = false;
            foreach (KeyValuePair<string, string> kvp in dict)
            {
                if (kvp.Key.Equals(inputs[1]))
                {
                    isExistingKey = true;
                }
            }
            if (print)
            {
                Console.Write($") {isExistingKey.ToString().ToLower()}\n");
            }
            return isExistingKey;
        }
        private static bool MemberExists(List<KeyValuePair<string, string>> dict, string[] inputs, bool print)
        {
            bool isExistingMember = false;
            foreach (KeyValuePair<string, string> kvp in dict)
            {
                if (kvp.Key.Equals(inputs[1]) && kvp.Value.Equals(inputs[2]))
                {
                    isExistingMember = true;
                }
            }
            if (print)
            {
                Console.Write($") {isExistingMember.ToString().ToLower()}\n");
            }
            return isExistingMember;
        }
        private static void Remove(List<KeyValuePair<string, string>> dict, string[] inputs)
        {
            if (KeyExists(dict, inputs, false))
            {
                if (MemberExists(dict, inputs, false))
                {
                    dict.RemoveAll(a => a.Key.Equals(inputs[1]) && a.Value.Equals(inputs[2]));
                    Console.Write(") Removed\n");
                }
                else
                {
                    Console.Write(") ERROR, member does not exist\n");
                }
            }
            else
            {
                Console.Write(") ERROR, key does not exist\n");
            }
        }
        private static void RemoveAll(List<KeyValuePair<string, string>> dict, string[] inputs)
        {
            if (KeyExists(dict, inputs, false))
            {
                dict.RemoveAll(a => a.Key.Equals(inputs[1]));
                Console.Write(") Removed\n");
            }
            else
            {
                Console.Write(") ERROR, key does not exist\n");
                return;
            }
        }
    }
}
