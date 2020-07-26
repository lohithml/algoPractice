using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary
{
    public class parentheses
    {
        //implement algorithm to print all valid combinations of pairs of parentheses
        public void MainParen()
        {
            int n = 3;
            Char[] s = new Char[n * 2];
            List<String> paran = new List<string>();
            addParen(paran, n, n, s, 0);
            foreach (String st in paran)
                Console.WriteLine(st);
            Console.ReadKey();
        }

        static void addParen(List<String> paran, int leftCount, int rightCount, Char[] str, int index)
        {
            if (leftCount < 0 || rightCount < leftCount) return;

            if (leftCount == 0 && rightCount == 0)
            {
                String stri = new String(str);
                paran.Add(stri);
            }
            else
            {
                str[index] = '(';
                addParen(paran, leftCount - 1, rightCount, str, index + 1);

                str[index] = ')';
                addParen(paran, leftCount, rightCount - 1, str, index + 1);
            }
        }
          
    }      
    
}
