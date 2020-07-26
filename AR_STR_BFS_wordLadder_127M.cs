using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary.Classes.LC.amzOnsite
{
    public class wordLadder
    {
        //Medium
        //127
        //Word Ladder
        //Given two words (beginWord and endWord), and a dictionary's word list, 
        //find the length of shortest transformation sequence from beginWord to endWord, such that:
        //Only one letter can be changed at a time.
        //Each transformed word must exist in the word list. Note that beginWord is not a transformed word.
        //Note:
        //Return 0 if there is no such transformation sequence.
        //All words have the same length.
        //All words contain only lowercase alphabetic characters.
        //You may assume no duplicates in the word list.
        //You may assume beginWord and endWord are non-empty and are not the same.
        //Example 1:
        //Input:
        //beginWord = "hit",
        //endWord = "cog",
        //wordList = ["hot","dot","dog","lot","log","cog"]
        //Output: 5
        //Explanation: As one shortest transformation is "hit" -> "hot" -> "dot" -> "dog" -> "cog",
        //return its length 5.
        //Example 2:
        //Input:
        //beginWord = "hit"
        //endWord = "cog"
        //wordList = ["hot","dot","dog","lot","log"]
        //Output: 0
        //Explanation: The endWord "cog" is not in wordList, therefore no possible transformation.

        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
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
            while (q.Count > 0)
            {
                var w = q.Dequeue();
                string s = w.Key;
                int level = w.Value + 1;
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
                                if (nw == endWord)
                                    return level;

                                //visited.Add(nw);
                                q.Enqueue(new KeyValuePair<string, int>(nw, level));
                            }
                        }
                    }
                }
            }

            return 0;
        }

        //Time: O(M2*N) m- length of each word, N lenght of list
        //Space: O(M2*N)

    }
}