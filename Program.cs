using System;
using System.Collections.Generic;

namespace MultiValueDictionary
{
    partial class Program
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
    }
}
