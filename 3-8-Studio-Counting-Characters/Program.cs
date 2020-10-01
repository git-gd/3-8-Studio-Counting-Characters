using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _3_8_Studio_Counting_Characters
{
    class Program
    {
        static void countChars(string input)
        {
            Console.WriteLine(input);
            Console.WriteLine("_______________________");

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

            Console.WriteLine("_______________________");
        }

        static void Main(string[] args)
        {
            countChars("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc accumsan sem ut ligula scelerisque sollicitudin. Ut at sagittis augue. Praesent quis rhoncus justo. Aliquam erat volutpat. Donec sit amet suscipit metus, non lobortis massa. Vestibulum augue ex, dapibus ac suscipit vel, volutpat eget massa. Donec nec velit non ligula efficitur luctus.");
            countChars("abcdefghijklmnopqrstuvwxyz.!01234567890 ?");
            countChars("aBbCcCdDdDeEeEe");
        }
    }
}

// take input .. try to read from a file