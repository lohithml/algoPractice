using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary.Classes.LC.amzOnsite
{
    public class AR_STR_ReorderLog_937E
    {
//Easy
//937
//You have an array of logs.  Each log is a space delimited string of words.
//For each log, the first word in each log is an alphanumeric identifier.  Then, either:
//Each word after the identifier will consist only of lowercase letters, or;
//Each word after the identifier will consist only of digits.
//We will call these two varieties of logs letter-logs and digit-logs.  It is guaranteed that each log has at least one word after its identifier.
//Reorder the logs so that all of the letter-logs come before any digit-log.  The letter-logs are ordered lexicographically ignoring identifier, with the identifier used in case of ties.  The digit-logs should be put in their original order.
//Return the final order of the logs.
        
//Example 1:
//Input: logs = ["dig1 8 1 5 1","let1 art can","dig2 3 6","let2 own kit dig","let3 art zero"]
//Output: ["let1 art can","let3 art zero","let2 own kit dig","dig1 8 1 5 1","dig2 3 6"] 

//Constraints:
//0 <= logs.length <= 100
//3 <= logs[i].length <= 100
//logs[i] is guaranteed to have an identifier, and a word after the identifier.

    public String[] reorderLogFiles(String[] logs) 
    {
        var degitLog = new List<string>();
        var letterLog = new List<string>();

        foreach (var log in logs)
        {
            if (char.IsDigit(log[log.IndexOf(' ') + 1]))
                degitLog.Add(log);
            else
                letterLog.Add(log);
        }

        letterLog.Sort((a, b) => {
            int indA = a.IndexOf(' ');
            int indB = b.IndexOf(' ');
            string strA = a.Substring(indA + 1); //removes upto this position
            string strB = b.Substring(indB + 1);
            int compare = strA.CompareTo(strB);
            if (compare != 0) return compare;
            return a.Substring(0, indA).CompareTo(b.Substring(0, indB)); //gets substring from - to position
        });

        letterLog.AddRange(degitLog);
        return letterLog.ToArray();
    }
  
    //Time: O(N2) sort is an operation at the worst case.
    //Space: O(N) N is total content of logs
    }
}