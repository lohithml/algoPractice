using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary.Classes.LC.amzOnsite
{
    public class partitionLabel
    { 
        //Medium
        //763
        //Partition Labels
        //A string S of lowercase letters is given. We want to partition this string into as many parts as possible so that each letter appears in at most one part, 
        //and return a list of integers representing the size of these parts.
        //Example 1:
        //Input: S = "ababcbacadefegdehijhklij"
        //Output: [9,7,8]
        //Explanation:
        //The partition is "ababcbaca", "defegde", "hijhklij".
        //This is a partition so that each letter appears in at most one part.
        //A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits S into less parts.
        //Note:
        //S will have length in range [1, 500].
        //S will consist of lowercase letters ('a' to 'z') only.

        public List<int> listLabel(string s)
        {
            List<int> res= new List<int>();
            int[] last= new int[26];
            for (int k=0; k<s.Length;k++)
                last[s[k]-'a']=k;              //char -char = integer ... index of last occurance of the char

            int j=0,anchor=0;
            for (int i = 0; i < s.Length; i++)
            { 
                j=Math.Max(j,last[s[i]-'a']);           //j= end of current partition
                if(i==j)
                {
                    res.Add(i - anchor + 1);
                    anchor = i + 1;                     //anchor= start of partition
                }
            }      
            return res;
        }
        public IList<int> PartitionLabels2(string s)
        {
            //Time:O(N)
            //Space:O(1)

            var res = new List<int>();
            var letters = new int[26];
            for (int i = 0; i < s.Length; i++)
                letters[s[i] - 'a'] = i;

            int last = 0;
            int start = 0;
            for (int i = 0; i < s.Length; i++)
            {
                last = Math.Max(last, letters[s[i] - 'a']);
                if (last == i)
                {
                    res.Add(last - start + 1);
                    start = last + 1;
                }
            }
            return res;
        }


        //Time:O(N) 2 pass
        //Space:O(1)
    }
}