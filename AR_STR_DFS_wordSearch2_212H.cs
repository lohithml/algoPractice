using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary.Classes.LC.amzOnsite
{
    public class AR_STR_DFS_wordSearch
    {
        //Hard
        //212
        //Word Search II
        //Given a 2D board and a list of words from the dictionary, find all words in the board.
        //Each word must be constructed from letters of sequentially adjacent cell, 
        //where "adjacent" cells are those horizontally or vertically neighboring. The same letter cell may not be used more than once in a word. 

        //Example:
        //Input: 
        //board = [
        //  ['o','a','a','n'],
        //  ['e','t','a','e'],
        //  ['i','h','k','r'],
        //  ['i','f','l','v']
        //]
        //words = ["oath","pea","eat","rain"]
        //Output: ["eat","oath"] 

        //Note:
        //All inputs are consist of lowercase letters a-z.
        //The values of words are distinct.

        int[] dx = new int[] { 0, 1, 0, -1 };
        int[] dy = new int[] { 1, 0, -1, 0 };

        public List<string> FindWords(char[][] board, string[] words)
        {
            var result = new List<string>();
            var root = this.BuildTrie(words);
            for (int i = 0; i < board.Length; i++)
                for (int j = 0; j < board[0].Length; j++)
                    this.Dfs(board, i, j, root, result);
            return result;
        }

        private void Dfs(char[][] board, int i, int j, TrieNode node, List<string> result)
        {
            if (i < 0 || i >= board.Length || j < 0 || j >= board[0].Length) return;
            char ch = board[i][j];
            if (ch == '.' || node.Next[ch - 'a'] == null) return;
            node = node.Next[ch - 'a'];
            if (node.Word != null)
            {
                result.Add(node.Word);
                node.Word = null;
            }
            board[i][j] = '.';
            for (int ind = 0; ind < 4; ind++) 
                this.Dfs(board, i + this.dx[ind], j + this.dy[ind], node, result);
            board[i][j] = ch;
        }

        private TrieNode BuildTrie(String[] words)
        {
            var root = new TrieNode();
            foreach (var word in words)
            {
                var node = root;
                var charArray = word.ToCharArray();
                foreach (var ch in charArray)
                {
                    int charIndex = ch - 'a';
                    if (node.Next[charIndex] == null) 
                        node.Next[charIndex] = new TrieNode();
                    node = node.Next[charIndex];
                }
                node.Word = word;
            }
            return root;
        }

        public class TrieNode
        {
            public readonly TrieNode[] Next = new TrieNode[26];
            public string Word;
        }

        //Time: O(M*4.3^L-1) M-number of cells, L max length of words
        //Space: O(N) N-total number of letters in dict
    }
}