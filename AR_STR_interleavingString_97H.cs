using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary.Classes.LC.amzOnsite
{
    public class AR_STR_interleavingString_97H
    {
        //Hard
        //97. Interleaving String
        //Given s1, s2, s3, find whether s3 is formed by the interleaving of s1 and s2.
        //Example 1:
        //Input: s1 = "aabcc", s2 = "dbbca", s3 = "aadbbcbcac"
        //Output: true
        //Example 2:
        //Input: s1 = "aabcc", s2 = "dbbca", s3 = "aadbbbaccc"
        //Output: false

        Dictionary<(string s1, string s2, string s3), bool> dict = new Dictionary<(string s1, string s2, string s3), bool>();
        public bool IsInterleave(string s1, string s2, string s3)
        {

            if (s3.Length != s1.Length + s2.Length) return false;

            if (s3.Length == 0) return true;

            if (dict.ContainsKey((s1, s2, s3))) return dict[(s1, s2, s3)];

            dict[(s1, s2, s3)] = (s1.Length > 0 && s1[0] == s3[0] && IsInterleave(s1.Substring(1), s2, s3.Substring(1))) ||
                                 (s2.Length > 0 && s2[0] == s3[0] && IsInterleave(s1, s2.Substring(1), s3.Substring(1)));

            return dict[(s1, s2, s3)];
        }

        //Time: O(2^{m+n}). m is the length of s1 and n is the length of s2.
        //Sapce:O(m+n) The size of stack for recursive calls can go upto m+n.
    }
}