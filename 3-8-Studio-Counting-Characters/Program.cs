using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;

namespace _3_8_Studio_Counting_Characters
{
    class Program
    {
        static void countChars(string input)
        {
            Console.WriteLine("Counting alphabetic characters in the string:");
            Console.WriteLine(input);
            Console.WriteLine(">-----<");

            string inputStr = input.ToLower(); // ToLower makes our search case insensitive

            IEnumerable<char> uniqueChars = inputStr.Distinct(); // Distinct removes duplicates

            Dictionary<char, int> charCount = new Dictionary<char, int>();

            foreach (char character in uniqueChars) {
                int count = inputStr.Count(a => a == character && Regex.IsMatch(character.ToString(), @"^[a-zA-Z]+$")); // our friend Regex prevents non-alphabetic characters from incrementing

                if ( count > 0) { // Thanks to Regex, non alphabetic characters are represented by 0 count .. could have done this a few different ways but this works
                    charCount.Add(character, count);  // since alphabetic characters have a positive count we Add them to our dictionary
                }
            }

            foreach (char character in charCount.Keys)
            {
                Console.WriteLine($"[{character}] - {charCount[character]}");
            }

            Console.WriteLine(">-----<");
        }

        static void Main(string[] args)
        {
            countChars("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc accumsan sem ut ligula scelerisque sollicitudin. Ut at sagittis augue. Praesent quis rhoncus justo. Aliquam erat volutpat. Donec sit amet suscipit metus, non lobortis massa. Vestibulum augue ex, dapibus ac suscipit vel, volutpat eget massa. Donec nec velit non ligula efficitur luctus.");
            countChars("abcdefghijklmnopqrstuvwxyz.!01234567890 ?");
            countChars("aBbCcCdDdDeEeEe");

            Console.WriteLine("Enter the path to a text file to read:");
            string path = Console.ReadLine(); // Bonus Mission: Read a text file

            if (System.IO.File.Exists(path))
            {
                string text = System.IO.File.ReadAllText(path);

                countChars(text);
            } else
            {
                Console.WriteLine($"{path} was not found");
            }

                
            string userInput;

            do
            {
                Console.WriteLine("Enter a string to see the alphabetic character count (blank to exit):");
                userInput = Console.ReadLine();
                if (userInput.Length> 0) countChars(userInput);
            } while (userInput.Length > 0);
        }
    }
}

// take input .. try to read from a file