using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary.Classes.LC.amzOnsite
{
    public class AR_STR_DFS_wordBreak2
    {
        //Hard
        //140
        //Given a non-empty string s and a dictionary wordDict containing a list of non-empty words, 
        //add spaces in s to construct a sentence where each word is a valid dictionary word. 
        //Return all such possible sentences.

        //Note:
        //The same word in the dictionary may be reused multiple times in the segmentation.
        //You may assume the dictionary does not contain duplicate words.

        //Example 1:
        //Input:
        //s = "catsanddog"
        //wordDict = ["cat", "cats", "and", "sand", "dog"]
        //Output:
        //[
        //  "cats and dog",
        //  "cat sand dog"
        //]

        //Example 2:
        //Input:
        //s = "pineapplepenapple"
        //wordDict = ["apple", "pen", "applepen", "pine", "pineapple"]
        //Output:
        //[
        //  "pine apple pen apple",
        //  "pineapple pen apple",
        //  "pine applepen apple"
        //]
        //Explanation: Note that you are allowed to reuse a dictionary word.

        //Example 3:
        //Input:
        //s = "catsandog"
        //wordDict = ["cats", "dog", "sand", "and", "cat"]
        //Output:
        //[]

        //https://leetcode.com/problems/word-break-ii/discuss/465408/Accepted-C-(DFS)-solution%3A-Easy-to-understand

        private Dictionary<string, List<string>> map;
        private HashSet<string> words;

        public List<string> WordBreak(string s, List<string> wordDict)                        
        {
            //Input: catsanddog, ["cat", "cats", "and", "sand", "dog"]
            if (s == null || s.Length == 0)
                return new List<String>();

            map = new Dictionary<string, List<string>>();
            words = new HashSet<string>(wordDict);
            return dfs(s);            
        }
        public List<string> dfs(string s)
        {
            if (map.ContainsKey(s))
                return map[s];

            var res = new List<String>();
            if (words.Contains(s))
                res.Add(s);

            for (int i = 1; i < s.Length; i++)
            {
                string word = s.Substring(i); //it removes first char in the first round... first word it results is dog
                if (words.Contains(word))
                {
                    var tmp = dfs(s.Substring(0, i));//from 0 to i... first iteration it removes dog from s which leaves catsand
                    foreach (string t in tmp)
                        res.Add(t + " " + word); //first cat sand
                 }
            }

            map[s] = res; //first word it finds is cat through recursive calls
            //cat,1
            //cats,1
            //catsand,2 values...cat sand, cats and
            //catsanddog,2 values... cats and dog, cat sand dog

            return res;
        }

        //Time: O(M2*N) where M is the length of words and N is the total number of words in the input word list. Substring take O(M).
        //Space: O(M2*N) to map stores all combinations
    
    }

}