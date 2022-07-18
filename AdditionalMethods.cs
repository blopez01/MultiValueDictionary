using System;
using System.Collections.Generic;

namespace MultiValueDictionary
{
    partial class Program
    {
        /// <summary>
        /// Method <c>Edit</c> finds a key value pair in the MultiValueDictionary and changes its values to the user's specification.
        /// </summary>
        /// <param name="dict">the MultiValueDictionary being manipulated.</param>
        /// <param name="inputs">the string array of user inputs.</param>
        /// <returns>Edits a key value pair given a valid key value pair is provided by the user. Displays an error if the key value pair is not found.</returns>
        private static void Edit(List<KeyValuePair<string, string>> dict, string[] inputs)
        {
            if (!inputs.Length.Equals(5))
            {
                Console.Write(") ERROR, USAGE - EDIT {key} {value} {newkey} {newvalue}\n");
                return;
            }
            if (KeyExists(dict, inputs, false))
            {
                if (MemberExists(dict, inputs, false))
                {
                    string[] newValues = { "ADD", inputs[3], inputs[4] };
                    dict.RemoveAll(a => a.Key.Equals(inputs[1]) && a.Value.Equals(inputs[2]));
                    Add(dict, newValues);
                    Console.Write($") Changed {inputs[1]} : {inputs[2]} to {inputs[3]} : {inputs[4]}\n");
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
        /// Method <c>ListFunctions</c> displays all functions used with the MultiValueDictionary.
        /// </summary>
        /// <returns>Returns all functions used with the MultiValueDictionary.</returns>
        private static void ListFunctions()
        {
            Console.Write("=========================\n");
            Console.Write(") KEYS\n) USAGE - KEYS\n) Displays all keys in the MultiValueDictionary.\n=========================\n");
            Console.Write(") MEMBERS\n) USAGE - MEMBERS {value}\n) Displays all members in the MultiValueDictionary.\n=========================\n");
            Console.Write(") ADD\n) USAGE - ADD {key} {value}\n) Adds a key value pair to the MultiValueDictionary.\n=========================\n");
            Console.Write(") REMOVE\n) USAGE - REMOVE {key} {value}\n) Removes a key value pair from the MultiValueDictionary.\n=========================\n");
            Console.Write(") REMOVEALL\n) USAGE - REMOVEALL {key}\n) Removes all key value pairs from the MultiValueDictionary which contain a specified key.\n=========================\n");
            Console.Write(") CLEAR\n) USAGE - CLEAR\n) Removes all key value pairs from the MultiValueDictionary.\n=========================\n");
            Console.Write(") KEYEXISTS\n) USAGE - KEYEXISTS {key}\n) Checks for a valid key in the MultiValueDictionary.\n=========================\n");
            Console.Write(") MEMBEREXISTS\n) USAGE - MEMBEREXISTS {key} {value}\n) Checks for a valid key value pair in the MultiValueDictionary.\n=========================\n");
            Console.Write(") ALLMEMBERS\n) USAGE - ALLMEMBERS\n) Displays all values in the MultiValueDictionary.\n=========================\n");
            Console.Write(") ITEMS\n) USAGE - ITEMS\n) Displays all key value pairs in the MultiValueDictionary.\n=========================\n");
            Console.Write(") EDIT\n) USAGE - EDIT {key} {value} {newkey} {newvalue}\n) Finds a key value pair in the MultiValueDictionary and changes its values to the user's specification.\n=========================\n");
            Console.Write(") HELP\n) USAGE - HELP\n) Displays information and usage of all functions in the program.\n=========================\n");
        }
    }
}
