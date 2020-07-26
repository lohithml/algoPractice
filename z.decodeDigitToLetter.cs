using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary
{
    class decodeDigitToLetter
    {
        //a=1,b=2....z=26
        //how many ways to decode the message back to original message
        //input: string
        //12 = ab or l
        //1234 : (1 + 234) + (2+34) + ( 3+4) like fibannoci series recursive
        
        //helper
        public int numofways(string data, int n)
        {
            if (n == 0) return 1;
            int s = data.Length - n;
            char[] ch = data.ToCharArray();
            if (data[s] == '0') return 0;

            int x = 0;
            Int32.TryParse(data.Substring(0, 2), out x);            

            int result = numofways(data, n - 1);

            if (n >= 2 || x <= 26) result += numofways(data, n - 2);

            return result;
        }

        //driver
        public void MainDecode()
        {
        
            string data = "2734";
            
            Console.WriteLine(numofways(data,data.Length));
        }
        //COMPLEXITY O(2^N)

        //IMPROVE TO O(N) USING DYNAMIC PROGRAMMING

        public int numofwaysDP(string data, int n,int[] memo)
        {
            if (n == 0) return 1;
            int s = data.Length - n;
            char[] ch = data.ToCharArray();
            if (ch[s] == '0') return 0;
            if (memo[n]!= -1) return memo[n];
            int x = 0;
            Int32.TryParse(data.Substring(0, 2), out x);

            int result = numofwaysDP(data, n - 1,memo);

            if (n >= 2 || x <= 26) result += numofwaysDP(data, n - 2,memo);

            memo[n] = result;

            return result;
        }

        //driver
        public void MainDecodeDP()
        {
            string data = "2734";
            int[] memo = new int[data.Length + 1];
            fillExte.Fill(memo, -1);
            Console.WriteLine(numofwaysDP(data, data.Length,memo));
        }
    }
    static class fillExte
    {
        public static void Fill<T>(this T[] originalArray, T val)
        {
            for (int i = 0; i < originalArray.Length; i++)
            {
                originalArray[i] = val;
            }
        }
    }
}
