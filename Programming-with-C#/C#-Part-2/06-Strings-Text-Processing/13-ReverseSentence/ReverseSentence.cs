namespace ReverseSentence
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Problem 13. Reverse sentence
    /// Write a program that reverses the words in given sentence.
    /// Example:
    /// |                   input                  |                  output                  |
    /// |:----------------------------------------:|:----------------------------------------:|
    /// | `C# is not C++, not PHP and not Delphi!` | `Delphi not and PHP, not C++ not is C#!` |
    /// </summary>
    public class ReverseSentence
    {
        private static readonly char[] Punctuation = { '.', ',', '!', '?', '-', ':', ';' };

        public static void Main()
        {
            Console.WriteLine("Problem 13. Reverse sentence \nWrite a program that reverses the words in given sentence.\n");

            string sentence = "C# is not C++, not PHP and not Delphi!";
            string reversed = ReverseWordsInSentence(sentence);

            Console.WriteLine("Input: {0}", sentence);
            Console.WriteLine("Reversed: {0}", reversed);
        }

        public static string ReverseWordsInSentence(string sentence)
        {
            string[] splitSentence = SplitSentence(sentence);
            Dictionary<int, char>[] punctuationIndexes = GetPunctuation(splitSentence);
            Array.Reverse(splitSentence);
            splitSentence = SetPunctuation(splitSentence, punctuationIndexes[0], punctuationIndexes[1]);

            return string.Join(" ", splitSentence);
        }

        private static string[] SetPunctuation(string[] reversedSentence, Dictionary<int, char> punctuationIndexesEnd, Dictionary<int, char> punctuationIndexesStart)
        {
            // append punctioation to word at given index
            foreach (var k in punctuationIndexesEnd.Keys)
            {
                reversedSentence[k] += punctuationIndexesEnd[k];
            }

            // prepend punctioation to word at given index
            foreach (var k in punctuationIndexesStart.Keys)
            {
                reversedSentence[k] = punctuationIndexesStart[k] + reversedSentence[k];
            }

            return reversedSentence;
        }

        private static Dictionary<int, char>[] GetPunctuation(string[] splitSentence)
        {
            Dictionary<int, char> punctuationIndexesEnd = new Dictionary<int, char>();
            Dictionary<int, char> punctuationIndexesStart = new Dictionary<int, char>();

            // if word contains punctuation, add its index to the dictionary and trim the word
            for (int i = 0; i < splitSentence.Length; i++)
            {
                foreach (var character in Punctuation)
                {
                    // check for punctuation at the end of a word
                    if (splitSentence[i].EndsWith(character.ToString()))
                    {
                        punctuationIndexesEnd.Add(Array.IndexOf(splitSentence, splitSentence[i]), character);
                        splitSentence[i] = splitSentence[i].TrimEnd(character);
                    }

                    // check for punctuation at the beginning of a word
                    if (splitSentence[i].StartsWith(character.ToString()))
                    {
                        punctuationIndexesStart.Add(Array.IndexOf(splitSentence, splitSentence[i]), character);
                        splitSentence[i] = splitSentence[i].TrimStart(character);
                    }
                }
            }

            return new Dictionary<int, char>[] { punctuationIndexesEnd, punctuationIndexesStart };
        }

        private static string[] SplitSentence(string sentence)
        {
            return sentence.Split(' ');
        }
    }
}
