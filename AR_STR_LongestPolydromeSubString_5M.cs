using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary.Classes.LC.amzOnsite
{
    public class AR_STR_LongestPolydromeSubString_5M
    {
    //Medium
    //5
    //Given a string s, find the longest palindromic substring in s. 
    //You may assume that the maximum length of s is 1000.

//Example 1:
//Input: "babad"
//Output: "bab"
//Note: "aba" is also a valid answer.

//Example 2:
//Input: "cbbd"
//Output: "bb"

        public string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s)) return String.Empty;
            var res = string.Empty;
            var reslen = 0;

            for (int i = 0; i < s.Length; i++)
            {
                var p1 = expandAroundCenter(s, i, i);
                if (p1.Length > reslen)
                {
                    reslen = p1.Length;
                    res = p1;
                }

                var p2 = expandAroundCenter(s, i, i + 1);
                if (p2.Length > reslen)
                {
                    reslen = p2.Length;
                    res = p2;
                }
            }

            return res;
        }

        private string expandAroundCenter(string s, int i, int j)
        {
            while (i >= 0 && j < s.Length && s[i] == s[j])
            {
                i--; //to check the char before
                j++; //to check the char after
            }

            return s.Substring(i + 1, j - i - 1);
        }

        //Time-O(N2).. checkPalindrome O(N)
        //Space-O(1)

    }
}