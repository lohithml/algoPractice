
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary
{
    public class clsurlify
    {
        
       
        public void mainurlify()
        {
            String str1 = "hello world";

            String res = urlify(str1);
            Console.Write(res);
            Console.ReadKey();
        }

         String urlify(string s1)
        {
            char[] c = s1.ToCharArray();
            int spaceCount = 0, trueLength = 11;
            for (int i = 0; i < trueLength; i++)
            {
                if (c[i] == ' ')
                    spaceCount++;
            }

            int index = trueLength + (spaceCount * 2);
            if (trueLength < c.Length) c[trueLength] = '\0';
            char[] d = new char[index];

            for (int j = trueLength - 1; j >= 0; j--)
            {
                if (c[j] == ' ')
                {
                    d[index - 1] = '0';
                    d[index - 2] = '2';
                    d[index - 3] = '%';
                    index = index - 3;
                }
                else
                {
                    d[index - 1] = c[j];
                    index--;
                }
            }
            string s2 = new string(d);
            return s2;
        }

    }
}