using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary.Classes.LC.amzOnsite
{
    public class AR_STR_DFS_wordConcat
    {
        //Concatenated Words

        //Given a list of words(without duplicates), please write a program that returns all concatenated words in the given list of words.
        //A concatenated word is defined as a string that is comprised entirely of at least two shorter words in the given array.

        //Example:
        //Input: ["cat","cats","catsdogcats","dog","dogcatsdog","hippopotamuses","rat","ratcatdogcat"]

        //        Output: ["catsdogcats","dogcatsdog","ratcatdogcat"]

        //        Explanation: "catsdogcats" can be concatenated by "cats", "dog" and "cats"; 
        // "dogcatsdog" can be concatenated by "dog", "cats" and "dog"; 
        //"ratcatdogcat" can be concatenated by "rat", "cat", "dog" and "cat".
        //Note:
        //The number of elements of the given array will not exceed 10,000
        //The length sum of elements in the given array will not exceed 600,000.
        //All the input string will only include lower case letters.
        //The returned elements order does not matter.

        public IList<string> FindAllConcatenatedWordsInADict(string[] words)
        {
            HashSet<string> hsInput = new HashSet<string>();
            foreach (var s in words)
                hsInput.Add(s);

            Dictionary<string, bool> dictConcat = new Dictionary<string, bool>();
            IList<string> result = new List<string>();
            foreach (var word in words)
            {
                if (formConcat(word, hsInput, dictConcat))
                    result.Add(word);
            }
            return result;
        }

        bool formConcat(string wrd, HashSet<string> hs, Dictionary<string, bool> dict)
        {
            if (dict.ContainsKey(wrd))
                return dict[wrd];
            for (int i = 1; i <= wrd.Length; i++)
            {
                string test = wrd.Substring(0, i);
                if (hs.Contains(test))
                {
                    string concat = wrd.Substring(i);
                    if (concat.Length > 0 && (hs.Contains(concat) || formConcat(concat, hs, dict)))
                    {
                        dict.Add(wrd, true);
                        return true;
                    }
                }
            }
            dict.Add(wrd, false);
            return false;
        }
    }   
}