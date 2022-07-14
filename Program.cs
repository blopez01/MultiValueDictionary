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
                string[] inputs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = inputs[0];
                if (command.Equals("KEYS"))
                {
                    Keys(dict);
                }
                else if (command.Equals("MEMBERS"))
                {
                    Members(dict, inputs);
                }
                else if (command.Equals("ADD"))
                {
                    Add(dict, inputs);
                }
                else if (command.Equals("REMOVE"))
                {
                    Remove(dict, inputs);
                }
                else if (command.Equals("REMOVEALL"))
                {
                    RemoveAll(dict, inputs);
                }
                else if (command.Equals("CLEAR"))
                {
                    Clear(dict);
                }
                else if (command.Equals("KEYEXISTS"))
                {
                    KeyExists(dict, inputs, true);
                }
                else if (command.Equals("MEMBEREXISTS"))
                {
                    MemberExists(dict, inputs, true);
                }
                else if (command.Equals("ALLMEMBERS"))
                {
                    AllMembers(dict);
                }
                else if (command.Equals("ITEMS"))
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
