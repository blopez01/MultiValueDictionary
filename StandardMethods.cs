using System;
using System.Collections.Generic;

namespace MultiValueDictionary
{
    partial class Program
    {
        /// <summary>
        /// Method <c>Keys</c> displays all keys in the MultiValueDictionary.
        /// </summary>
        /// <param name="dict">the MultiValueDictionary being manipulated.</param>
        /// <returns>Returns all the keys in the MultiValueDictionary. Order is not guaranteed.</returns>
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
        /// <summary>
        /// Method <c>Members</c> displays all members in the MultiValueDictionary.
        /// </summary>
        /// <param name="dict">the MultiValueDictionary being manipulated.</param>
        /// <param name="inputs">the string array of user inputs.</param>
        /// <returns>Returns the collection of strings for the given key. Return order is not guaranteed. Returns an error if the key does not exists.</returns>
        private static void Members(List<KeyValuePair<string, string>> dict, string[] inputs)
        {
            if (!inputs.Length.Equals(2))
            {
                Console.Write(") ERROR, USAGE - MEMBERS {value}\n");
                return;
            }
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
        /// <summary>
        /// Method <c>Add</c> adds a key value pair to the MultiValueDictionary.
        /// </summary>
        /// <param name="dict">the MultiValueDictionary being manipulated.</param>
        /// <param name="inputs">the string array of user inputs.</param>
        /// <returns>Adds a member to a collection for a given key. Displays an error if the member already exists for the key.</returns>
        private static void Add(List<KeyValuePair<string, string>> dict, string[] inputs)
        {
            if (!inputs.Length.Equals(3))
            {
                Console.Write(") ERROR, USAGE - ADD {key} {value}\n");
                return;
            }
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
        /// <summary>
        /// Method <c>Remove</c> removes a key value pair from the MultiValueDictionary.
        /// </summary>
        /// <param name="dict">the MultiValueDictionary being manipulated.</param>
        /// <param name="inputs">the string array of user inputs.</param>
        /// <returns>Removes a member from a key. If the last member is removed from the key, the key is removed from the dictionary. If the key or member does not exist, displays an error.</returns>
        private static void Remove(List<KeyValuePair<string, string>> dict, string[] inputs)
        {
            if (!inputs.Length.Equals(3))
            {
                Console.Write(") ERROR, USAGE - REMOVE {key} {value}\n");
                return;
            }
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
        /// <summary>
        /// Method <c>RemoveAll</c> removes all key value pairs from the MultiValueDictionary which contain a specified key.
        /// </summary>
        /// <param name="dict">the MultiValueDictionary being manipulated.</param>
        /// <param name="inputs">the string array of user inputs.</param>
        /// <returns>Removes all members for a key and removes the key from the dictionary. Returns an error if the key does not exist.</returns>
        private static void RemoveAll(List<KeyValuePair<string, string>> dict, string[] inputs)
        {
            if (!inputs.Length.Equals(3))
            {
                Console.Write(") ERROR, USAGE - REMOVEALL {key}\n");
                return;
            }
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
        /// <summary>
        /// Method <c>Clear</c> removes all key value pairs from the MultiValueDictionary.
        /// </summary>
        /// <param name="dict">the MultiValueDictionary being manipulated.</param>
        /// <returns>Removes all keys and all members from the dictionary.</returns>
        private static void Clear(List<KeyValuePair<string, string>> dict)
        {
            dict.Clear();
            Console.Write(") Cleared\n");
        }
        /// <summary>
        /// Method <c>KeyExists</c> checks for a valid key in the MultiValueDictionary.
        /// </summary>
        /// <param name="dict">the MultiValueDictionary being manipulated.</param>
        /// <param name="inputs">the string array of user inputs.</param>
        /// <param name="print">specifies printing functionality.</param>
        /// <returns>Returns true if a key exists or not. Returns false if the key does not exist.</returns>
        private static bool KeyExists(List<KeyValuePair<string, string>> dict, string[] inputs, bool print)
        {
            if (!inputs.Length.Equals(2))
            {
                if (print)
                {
                    Console.Write(") ERROR, USAGE - KEYEXISTS {key}\n");
                    return false;
                }
            }
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
        /// <summary>
        /// Method <c>MemberExists</c> checks for a valid key value pair in the MultiValueDictionary.
        /// </summary>
        /// <param name="dict">the MultiValueDictionary being manipulated.</param>
        /// <param name="inputs">the string array of user inputs.</param>
        /// <param name="print">specifies printing functionality.</param>
        /// <returns>Returns true if a member exists within a key. Returns false if the key does not exist or if the member does not exist.</returns>
        private static bool MemberExists(List<KeyValuePair<string, string>> dict, string[] inputs, bool print)
        {
            if (!inputs.Length.Equals(3))
            {
                if (print)
                {
                    Console.Write(") ERROR, USAGE - MEMBEREXISTS {key} {value}\n");
                    return false;
                }
            }
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
        /// <summary>
        /// Method <c>AllMembers</c> displays all values in the MultiValueDictionary.
        /// </summary>
        /// <param name="dict">the MultiValueDictionary being manipulated.</param>
        /// <returns>Returns all the members in the dictionary. Returns nothing if there are none. Order is not guaranteed.</returns>
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
        /// <summary>
        /// Method <c>Items</c> displays all key value pairs in the MultiValueDictionary.
        /// </summary>
        /// <param name="dict">the MultiValueDictionary being manipulated.</param>
        /// <returns>Returns all keys in the dictionary and all of their members. Returns nothing if there are none. Order is not guaranteed.</returns>
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
