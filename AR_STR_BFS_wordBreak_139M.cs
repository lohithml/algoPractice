using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary.Classes.LC.amzOnsite
{
    public class AR_STR_BFS_wordBreak
    {
        //Medium
        //139. Word Break
        //Given a non-empty string s and a dictionary wordDict containing a list of non-empty words, 
        //determine if s can be segmented into a space-separated sequence of one or more dictionary words.
        //Note:
        //The same word in the dictionary may be reused multiple times in the segmentation.
        //You may assume the dictionary does not contain duplicate words.
        //Example 1:
        //Input: s = "leetcode", wordDict = ["leet", "code"]
        //Output: true
        //Explanation: Return true because "leetcode" can be segmented as "leet code".
        //Example 2:
        //Input: s = "applepenapple", wordDict = ["apple", "pen"]
        //Output: true
        //Explanation: Return true because "applepenapple" can be segmented as "apple pen apple".
        //Note that you are allowed to reuse a dictionary word.
        //Example 3:
        //Input: s = "catsandog", wordDict = ["cats", "dog", "sand", "and", "cat"]
        //Output: false

        public bool WordBreakDP(string s, IList<string> wordDict)
        {
            bool[] dp = new bool[s.Length + 1];
            dp[0] = true; //since null/empty string is always present in wordDict.
            for (int i = 1; i < dp.Length; i++)
            {
                for (int j = 0; j < i; j++)
                //Consider substrings of all possible lengths starting from the beginning till i.
                {
                    if (dp[j] && wordDict.Contains(s.Substring(j, i - j)))
                    {
                        //For all substrings, we partition the string into two further substrings in all possible ways using the index j.
                        dp[i] = true;
                        break;
                        //first finds leet dp[4]=true; then finds code dp[8]=true which dp[s.Length]
                    }
                }
            }
            return dp[s.Length];
        }

        //Time: O(N^2)- 2 loops to fill dp array
        //Space: O(N) length of dp array

        public bool WordBreakBFS(string s, IList<string> wordDict)
        {
            Queue<string> q = new Queue<string>();
            HashSet<string> visited = new HashSet<string>();
            q.Enqueue(s);
            while (q.Count != 0)
            {
                string temp = q.Dequeue();
                //first temp=leetcode; then temp=code
                if (string.IsNullOrEmpty(temp))
                    return true;
                foreach (var word in wordDict)
                {
                    if (temp.StartsWith(word))
                    {
                        string temp2 = temp.Substring(word.Length);
                        //first removes leet to get temp2=code; then remove code to become temp2=null;
                        if (string.IsNullOrEmpty(temp2))
                            return true;
                        if (!visited.Contains(temp2))
                        {
                            q.Enqueue(temp2);
                            visited.Add(temp2);
                        }
                    }
                }
            }
            return false;
        }
    }
}

//static void Main()
//{
//    string s = "leetcode";

//    IList<string> wordDict = new List<string> { "leet", "code" };

//    var cls = new AR_STR_BFS_wordBreak();
//    bool res = cls.WordBreakBFS(s, wordDict);

//    Console.WriteLine(res);
//    Console.ReadKey();
//}