using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Anagram
{
    public class AnagramSelector
    {
        public bool WordPairIsAnagram(string word1, string word2) {
            //Insert the correct implementation here
            char[] word_array1 = word1.ToCharArray();
            char[] word_array2 = word2.ToCharArray();
            if(word_array1.Length == word_array2.Length)
            {
                Array.Sort(word_array1);
                Array.Sort(word_array2);
                return Enumerable.SequenceEqual(word_array1, word_array2);
            }
            return false;
        }
        public List<string> SelectAnagrams(string word, List<string> candidates) {
            
            for(int index=0; index< candidates.Count; index++)
            {
                if (WordPairIsAnagram(word, candidates[index]) == false)
                {
                    candidates.RemoveAt(index);
                    index--;
                }
            }
            return candidates;
        }
        static void Main(string[] args)
        {
            // Display the number of command line arguments.
            AnagramSelector selector = new AnagramSelector();
            var selection = selector.SelectAnagrams("master",
                new List<string> { "stream", "something", "maters" });

            Console.WriteLine(selection.SequenceEqual(
                new List<string> { "stream", "maters" }));
        }
    }
    
}
