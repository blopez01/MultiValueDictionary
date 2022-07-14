using System;
using System.Collections.Generic;

namespace MultiValueDictionary
{
    partial class Program
    {
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
        private static void Add(List<KeyValuePair<string, string>> dict, string[] inputs)
        {
            KeyValuePair<string, string> kvp = new KeyValuePair<string, string>(inputs[1], inputs[2]);
            if (!dict.Contains(kvp))
            {
                dict.Add(kvp);
                Console.Write(") Added\n");
            }
            else
            {
                Console.Write(") ERROR, member already exists for key\n");
                return;
            }
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
        private static void Clear(List<KeyValuePair<string, string>> dict)
        {
            dict.Clear();
            Console.Write(") Cleared\n");
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
        private static void AllMembers(List<KeyValuePair<string, string>> dict)
        {
            if (dict.Count.Equals(0))
            {
                Console.Write(") empty set\n");
                return;
            }
            int i = 1;
            foreach (KeyValuePair<string, string> kvp in dict)
            {
                Console.Write($"{i}) {kvp.Value}\n");
                i++;
            }
        }
        private static void Items(List<KeyValuePair<string, string>> dict)
        {
            if (dict.Count.Equals(0))
            {
                Console.Write(") empty set\n");
                return;
            }
            int i = 1;
            foreach (KeyValuePair<string, string> kvp in dict)
            {
                Console.Write($"{i}) {kvp.Key}: {kvp.Value}\n");
                i++;
            }
        }
    }
}
