using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary
{
    public class permutationWithDup
    {
        public void MainPermDup()
        {
            string s = "AABC";
            List<String> res = getPermsDup(s);
            foreach (String st in res)
                Console.WriteLine(st);
            Console.ReadKey();
        }

        static List<String> getPermsDup(String str)
        {
            List<String> ans = new List<String>();
            Dictionary<Char, Int32> freqDict = new Dictionary<Char, Int32>();
            freqDict = getFreCount(str);
            getAnsDup(freqDict, "", str.Length, ans);
            return ans;
        }

        static Dictionary<Char, Int32> getFreCount(String s)
        {
            Dictionary<Char, Int32> tempDict = new Dictionary<Char, Int32>();
            foreach (Char c in s.ToCharArray())
            {
                if (!tempDict.ContainsKey(c))
                {
                    tempDict.Add(c, 0);
                }
                tempDict[c] = tempDict[c] + 1;
            }
            return tempDict;
        }

        static void getAnsDup(Dictionary<Char, Int32> freqD, String prefix, Int32 reminder, List<String> ans)
        {
            if (reminder == 0)
            {
                ans.Add(prefix);
                return;
            }

            for (int a = 0; a < freqD.Count; a++)
            {
                Char c = freqD.Keys.ElementAt(a);
                int count = freqD[c];
                if (count > 0)
                {
                    freqD[c] = count - 1;
                    getAnsDup(freqD, prefix + c, reminder - 1, ans);
                    freqD[c] = count;
                }
            }
        }
          
    }      
    
}
