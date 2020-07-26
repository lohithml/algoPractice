using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary.Classes.LC.amzOnsite
{
    public class AR_STR_TopKwords
    {
        //Medium
        //692
        //Given a non-empty list of words, return the k most frequent elements.
        //Your answer should be sorted by frequency from highest to lowest. 
        //If two words have the same frequency, then the word with the lower alphabetical order comes first.

        //Example 1:
        //Input: ["i", "love", "leetcode", "i", "love", "coding"], k = 2
        //Output: ["i", "love"]
        //Explanation: "i" and "love" are the two most frequent words.
        //    Note that "i" comes before "love" due to a lower alphabetical order.

        //Example 2:
        //Input: ["the", "day", "is", "sunny", "the", "the", "the", "sunny", "is", "is"], k = 4
        //Output: ["the", "is", "sunny", "day"]
        //Explanation: "the", "is", "sunny" and "day" are the four most frequent words,
        //with the number of occurrence being 4, 3, 2 and 1 respectively.
        //Note:
        //You may assume k is always valid, 1 ≤ k ≤ number of unique elements.
        //Input words contain only lowercase letters.

        public List<String> TopKFrequentWords(String[] words, int k)
        {
        var dict = new Dictionary<String, int>();
        for (int i = 0; i < words.Length; i++)
        {
            if (!dict.ContainsKey(words[i]))
                dict.Add(words[i], 1);
            else
                dict[words[i]]++;
        }

        List<KeyValuePair<String, int>> res = dict.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToList();

        return res.Select(y => y.Key).Take(k).ToList();
        }

        //Time-O(N logN)?
        //Space- O(N)?
    }
}