
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary
{
    public class isUnique
    {
        //Implement an algorithm to determine if a string has all unique characters
       
        public void mainUnique()
        {
            String inputStr = "aabbd";
            bool res = checkUnique(inputStr);
            Console.Write(res);
            Console.ReadKey();
        }

        bool checkUnique(string s)
        {
            if (s.Length > 128) return false;

            bool[] foundCount = new bool[128];
            for (int i = 0; i < s.Length; i++)
            {
                int v = s[i];
                if (foundCount[v]) return false;
                foundCount[v] = true;
            }
            return true;
        }

    }
}