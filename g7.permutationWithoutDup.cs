using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary
{
    public class permutationWithoutDup
    {
        public void MainPerm()
        {
            string s = "ABC";
            List<String> res = getPerms(s);
            Console.ReadKey();
        }
        private List<String> getPerms(string str)
        {
            List<String> ans = new List<String>();
            getAns("", str, ans);
            return ans;
        }

        private void getAns(String prefix, String reminder, List<String> ans)
        {
            if (reminder.Length == 0) ans.Add(prefix);
            int len = reminder.Length;
            for (int i = 0; i < len; i++)
            {
                String before = reminder.Substring(0, i);
                String after = reminder.Substring(i+1);
                char c = reminder[i];
                getAns(prefix + c, before + after, ans);
            }
        }
        //static void Main()
        //{
        //    int counter = 1;
        //    foreach (var p in Permutate("ABC"))
        //    {
        //        Console.WriteLine(p);
        //    }
        //    Console.ReadKey();
        //}

        //private static IEnumerable<string> Permutate(string source)
        //{
        //    if (source.Length == 1) return new List<string> { source };

        //    var permutations = from c in source
        //                        from p in Permutate(new String(source.Where(x => x != c).ToArray()))
        //                        select c + p;

        //    return permutations;
        //}

          
    }      
    
}
