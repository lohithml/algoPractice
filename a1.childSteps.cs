using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;

namespace LohiLibrary
{
    public class childSteps
    {
        //given: child steps 1,2,3
        //total n steps
        //find: count number of ways child can climb the stairs

        public void MainSteps()
        {
            //solution 1
            //int result = countWays(20);

            //solution 2
            int result = countDPways(20);

            //solution 3
            //int result = countGeekWay(20);

            Console.WriteLine(result);
        }
        //recursive
        public int countWays(int n)
        {
            if (n < 1) { return 0; }
            else if (n == 0) { return 1; }
            else { return countWays(n - 1) + countWays(n - 2) + countWays(n - 3); }
        }

        //complexity O(3^n)

        //memoization
        public int countDPways(int n)
        {
            int[] memo = new int[n + 1];
            //fillExt.Fill(memo, -1);
            return countDPway(n, memo);
        }

        public int countDPway(int m, int[] arr)
        {
            if (m < 0) return 0;
            else if (m == 0) return 1;
            //else if (arr[m] > -1) return arr[m];
            else if (arr[m] > 0) return arr[m];
            else
            {
                arr[m] = countDPway(m - 1, arr) + countDPway(m - 2, arr) + countDPway(m - 3, arr);
                return arr[m];
            }
        }

        //dp as in Geek for geeks
        static int countGeekWay(int n)
        {
            int[] mem = new int[n + 1];

            mem[0] = 1;
            mem[1] = 1;
            mem[2] = 2;

            for (int i = 3; i <= n; i++)
                mem[i] = mem[i - 1] + mem[i - 2] + mem[i - 3];

            return mem[n];
            //output 121415 for n=20
        }
    }
    static class fillExt
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

        //static void Main()
        //{
        //    //n steps
        //    //1,2,3
        //    //possible number of ways
        //    int n=10;
        //    int res = countWays(n);
        //    Console.Write(res);
        //    Console.ReadKey();
        //}

        //static int countWays(int s)
        //{
        //    //base case
        //    //-ve
        //    //0

        //    int[] memo=new int[s+1];
        //    for (int i = 0; i < memo.GetLength(0); i++)
        //        memo[i] = -1;

        //    return countDPWays(memo,s);                        
        //}

        //static int countDPWays(int[] mem, int c)
        //{
        //    if (c < 0) return 0;
        //    else if (c == 0) return 1;
        //    else if (mem[c] > -1) return mem[c];
        //    else return countDPWays(mem, c - 1) + countDPWays(mem, c - 2) + countDPWays(mem, c - 3);
        //}