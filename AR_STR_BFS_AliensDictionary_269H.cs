using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary.Classes.LC.amzOnsite
{
    public class AR_STR_BFS_AliensDictionary_269H
    {
        //Hard
        //269. Alien Dictionary
        //There is a new alien language which uses the latin alphabet.However, the order among letters are unknown to you.You receive a list of non-empty words from the dictionary, where words are sorted lexicographically by the rules of this new language.Derive the order of letters in this language.

        //Example 1:
        //Input:
        //[
        //  "wrt",
        //  "wrf",
        //  "er",
        //  "ett",
        //  "rftt"
        //]
        //        Output: "wertf"
        //Example 2:
        //Input:
        //[
        //  "z",
        //  "x"
        //]
        //        Output: "zx"
        //Example 3:
        //Input:
        //[
        //  "z",
        //  "x",
        //  "z"
        //]
        //        Output: "" 
        //Explanation: The order is invalid, so return "".
        //Note:
        //You may assume all letters are in lowercase.
        //If the order is invalid, return an empty string.
        //There may be multiple valid order of letters, return any one of them is fine.

        public string AlienOrder(string[] words)
        {
            // Step 1: Create data structures and find all unique letters.
            var adjList = new Dictionary<char, List<char>>();
            var inDegrees = new Dictionary<char, int>();
            foreach (var word in words)
            {
                foreach (var c in word.ToCharArray())
                {
                    if (!adjList.ContainsKey(c))
                    {
                        adjList[c] = new List<char>();
                        inDegrees[c] = 0;
                    }
                }
            }

            // Step 2: Find all edges.
            for (int i = 0; i < words.Length - 1; i++)
            {
                string word1 = words[i];
                string word2 = words[i + 1];
                // Check that word2 is not a prefix of word1.
                if (word1.Length > word2.Length && word1.StartsWith(word2))
                    return "";
                // Find the first non match and insert the corresponding relation.
                for (int j = 0; j < Math.Min(word1.Length, word2.Length); j++)
                {
                    if (word1[j] != word2[j])
                    {
                        inDegrees[word2[j]]++;
                        adjList[word1[j]].Add(word2[j]);
                        break;
                    }
                }
            }

            // Step 3: Breadth-first search.
            var sb = new StringBuilder();
            var q = new Queue<char>();
            foreach (var item in inDegrees)
            {
                if (item.Value == 0)
                    q.Enqueue(item.Key);
            }

            while (q.Count > 0)
            {
                char cur = q.Dequeue();
                sb.Append(cur);
                foreach (var neibr in adjList[cur])
                {
                    inDegrees[neibr]--;
                    if (inDegrees[neibr] == 0)
                        q.Enqueue(neibr);
                }
            }

            if (sb.Length < inDegrees.Count)
                return "";

            return sb.ToString();
        }

        //Time- O(C) C- total length of all the words in the input list added together. BFS costs O(V+E) V-number of vertices, E-number of edges. There is one vertex for each unique letter- O(U) vertices. There are N-1 pairs of adj words. min(U2,N-1); O(C+U+min(U2,N)); O(C+min(U2,N)); U2<N; C>N===>O(C)
        //Space- O(1) or O(U + min(U2,N)) number of edges worst case is min(U2,N) U-total number of unique letters, N- total number of strings in the inputlist

    }
}