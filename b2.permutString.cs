
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary
{
    public class permutString
    {
        //Given two strings, write a method to decide if one is a permutation of the other.
       
        public void mainPermStr()
        {
            String str1 = "abg", str2 = "gba";

            bool res = checkPermut(str1, str2);
            Console.Write(res);
            Console.ReadKey();
        }

        static bool checkPermut(string s1, string s2)
        {
            if (s1.Length != s2.Length) return false;

            //count of each character
            int[] letterCount = new int[128];
            char[] charArr = s1.ToCharArray();
            foreach (char c in charArr)
                letterCount[c]++;

            int b;
            for (int j = 0; j < s2.Length; j++)
            {
                b = s2[j];
                letterCount[b]--;
                if (letterCount[b] < 0)
                    return false;
            }

            return true;
        }

    }
}