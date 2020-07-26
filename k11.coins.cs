using System;

namespace LohiLibrary
{
    public class coins
    {
        public void MainCoins()
        {
            //coins 
            //amount
            //denominations

            int[] denom = new int[] { 25, 10, 5, 1 };
            int amount = 50;

            int[,] memo = new int[amount + 1, denom.Length];
            int way = getWays(amount, denom, 0, memo);

            Console.Write(way);
            Console.ReadKey();
        }

        //static int makechange(int n, int[] deno)
        //{

        //    int[,] memo = new int[n+1,deno.Length];
        //    int ways = getWays(n, deno,0,memo);
        //    return ways;
        //}

        int getWays(int total, int[] deno, int i, int[,] mem)
        {

            if (mem[total, i] > 0) return mem[total, i];

            int coin = deno[i];

            if (i == deno.Length - 1)   //one denomination left - possible or not
            {
                int reminder = total % coin;
                if (reminder == 0) return 1;
                else return 0;
            }
            int combiWays = 0;
            for (int c = 0; c < total; c += coin)
            {
                combiWays += getWays(total - c, deno, i + 1, mem);
            }
            mem[total, i] = combiWays;

            return combiWays;
        }
    }
}