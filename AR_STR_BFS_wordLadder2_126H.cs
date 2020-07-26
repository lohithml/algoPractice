using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary.Classes.LC.amzOnsite
{
    public class wordLadder2
    {
        //Hard
        //126. Word Ladder II
        //Given two words(beginWord and endWord), and a dictionary's word list, find all shortest transformation sequence(s) from beginWord to endWord, such that:

        //Only one letter can be changed at a time
        //Each transformed word must exist in the word list.Note that beginWord is not a transformed word.
        //Note:
        //Return an empty list if there is no such transformation sequence.
        //All words have the same length.
        //All words contain only lowercase alphabetic characters.
        //You may assume no duplicates in the word list.
        //You may assume beginWord and endWord are non-empty and are not the same.
        //Example 1:
        //Input:
        //beginWord = "hit",
        //endWord = "cog",
        //wordList = ["hot", "dot", "dog", "lot", "log", "cog"]
        //Output:
        //[
        //  ["hit","hot","dot","dog","cog"],
        // ["hit","hot","lot","log","cog"]
        //]

        //Example 2:
        //Input:
        //beginWord = "hit"
        //endWord = "cog"
        //wordList = ["hot","dot","dog","lot","log"]
        //Output: []
        //Explanation: The endWord "cog" is not in wordList, therefore no possible transformation.

        //https://leetcode.com/problems/word-ladder-ii/discuss/375730/C-BFS-Solution-faster-than-94-and-less-than-100-memory
        //explanation with VS image
        //https://leetcode.com/problems/word-ladder-ii/discuss/381058/Referring-to-the-code-posted-by-jianminchen-Explanation-with-Picture

        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
        {
            var map = new Dictionary<string, List<string>>();
            foreach (string s in wordList)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    string key = string.Concat(s.Substring(0, i), '*', s.Substring(i + 1));
                    List<string> list;
                    if (!map.TryGetValue(key, out list))
                    {
                        list = new List<string>();
                        map[key] = list;
                    }
                    list.Add(s);
                }
            }

            var visited = new HashSet<string>();
            var q = new Queue<KeyValuePair<string, int>>();
            q.Enqueue(new KeyValuePair<string, int>(beginWord, 1));

            var paths = new Dictionary<string, IList<IList<string>>>();
            paths[beginWord] = new List<IList<string>>() { new List<string>() { beginWord } };

            while (q.Count > 0)
            {
                var w = q.Dequeue();
                string s = w.Key;
                int level = w.Value + 1; // useful for word ladder problem.. to get length of word ladder
                if (s.Equals(endWord))
                {
                    return paths[endWord];
                }
                else
                {
                    if (visited.Contains(s))
                        continue;
                    visited.Add(s);
                    for (int i = 0; i < s.Length; i++)
                    {
                        string key = string.Concat(s.Substring(0, i), '*', s.Substring(i + 1));
                        if (map.TryGetValue(key, out var list))
                        {
                            foreach (var nw in list)
                            {
                                if (!visited.Contains(nw))
                                {
                                    foreach (var path in paths[s])
                                    {
                                        var tempPath = new List<string>(path);
                                        tempPath.Add(nw);

                                        if (!paths.ContainsKey(nw))
                                            paths[nw] = new List<IList<string>>() { tempPath };
                                        else if (paths[nw][0].Count >= tempPath.Count)
                                            paths[nw].Add(tempPath);
                                    }
                                    q.Enqueue(new KeyValuePair<string, int>(nw, level));
                                }
                            }
                        }
                    }
                }
            }
            return new List<IList<string>>();
        }

        //Time: O(M2*N) m- length of each word, N lenght of list
        //Space: O(M2*N)
    }
}

//static void Main()
//{

//    string beginWord = "hit", endWord = "cog";
//    IList<string> wordDict = new List<string> { "hot", "dot", "dog", "lot", "log", "cog" };

//    var cls = new wordLadder2();
//    IList<IList<String>> res = cls.FindLadders(beginWord, endWord, wordDict);
//    Console.ReadKey();
//}
