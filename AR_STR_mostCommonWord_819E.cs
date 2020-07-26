using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary.Classes.LC.amzOnsite
{
    public class AR_STR_mostCommonWord
    {
        //Easy
        //819
        //Given a paragraph and a list of banned words, return the most frequent word that is not in the list of banned words.  
        //It is guaranteed there is at least one word that isn't banned, and that the answer is unique.
        //Words in the list of banned words are given in lowercase, and free of punctuation.  
        //Words in the paragraph are not case sensitive.  The answer is in lowercase.
        //Example:
        //Input: 
        //paragraph = "Bob hit a ball, the hit BALL flew far after it was hit."
        //banned = ["hit"]
        //Output: "ball"
        //Explanation: 
        //"hit" occurs 3 times, but it is a banned word.
        //"ball" occurs twice (and no other word does), so it is the most frequent non-banned word in the paragraph. 
        //Note that words in the paragraph are not case sensitive,
        //that punctuation is ignored (even if adjacent to words, such as "ball,"), 
        //and that "hit" isn't the answer even though it occurs more because it is banned.
 
        //Note:
        //1 <= paragraph.length <= 1000.
        //0 <= banned.length <= 100.
        //1 <= banned[i].length <= 10.
        //The answer is unique, and written in lowercase (even if its occurrences in paragraph may have uppercase symbols, and even if it is a proper noun.)
        //paragraph only consists of letters, spaces, or the punctuation symbols !?',;.
        //There are no hyphens or hyphenated words.
        //Words only consist of letters, never apostrophes or other punctuation symbols.

        public String mostCommonWords(String paragraph, String[] banned) 
        {
            var banSet = new HashSet<string>(banned);
            var dict = new Dictionary<string, int>();
            var ansFreq = 0;
            var ans = "";
            var sb = new StringBuilder();
            paragraph += ".";

            foreach (char c in paragraph.ToCharArray())
            {
                if (char.IsLetter(c))
                    sb.Append(char.ToLower(c));
                else if (sb.Length > 0)
                {
                    var word = sb.ToString();
                    if (!banSet.Contains(word))
                    {
                        if (!dict.ContainsKey(word))
                            dict.Add(word, 1);
                        else
                            dict[word]++;

                        if (ansFreq < dict[word])
                        {
                            ansFreq = dict[word];
                            ans = word;
                        }
                    }
                    sb = new StringBuilder();
                }
            }
            return ans;
        }

        //Time:O(M+N) M-size of paragraph,N size of banned
        //Space:O(M+N) to store the count and banned set
    }
}