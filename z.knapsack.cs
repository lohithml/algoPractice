using System;

namespace LohiLibrary
{
    //https://www.geeksforgeeks.org/0-1-knapsack-problem-dp-10/
    //Given weights and values of n items, put these items in a knapsack of capacity W 
    //to get the maximum total value in the knapsack.
    //In other words, given two integer arrays val[0..n - 1] and wt[0..n - 1] 
    //which represent values and weights associated with n items respectively.
    //Also given an integer W which represents knapsack capacity, 
    //find out the maximum value subset of val[] such that sum of the weights of this subset is smaller than or equal to W. 
    //You cannot break an item, either pick the complete item, or don’t pick it (0-1 property).
    class knapsack
    {
        // Driver function 
        public void MainKnapSack()
        {
            int[] val = new int[] { 60, 100, 120 };
            int[] wt = new int[] { 10, 20, 30 };
            int W = 50;
            int n = val.Length;

            Console.WriteLine(knapSackDP(W, wt, val, n));
            //solution 220
        }

        // A utility function that returns maximum of two integers 
        static int max(int a, int b)
        {
            return (a > b) ? a : b;
        }

        // Returns the maximum value that can be put in a knapsack of capacity W 
        static int knapSack(int W, int[] wt, int[] val, int n)
        {

            // Base Case 
            if (n == 0 || W == 0)
                return 0;

            // If weight of the nth item is more than Knapsack capacity W, 
            // then this item cannot be included in the optimal solution 
            if (wt[n - 1] > W)
                return knapSack(W, wt, val, n - 1);

            // Return the maximum of two cases:  
            // (1) nth item included  
            // (2) not included 
            else return max(val[n - 1] + knapSack(W - wt[n - 1], wt, val, n - 1), knapSack(W, wt, val, n - 1));
        }

        // Returns the maximum value that can be put in a knapsack of capacity W 
        static int knapSackDP(int W, int[] wt,
                             int[] val, int n)
        {
            int i, w;
            int[,] K = new int[n + 1, W + 1];

            // Build table K[][] in bottom up manner 
            for (i = 0; i <= n; i++)
            {
                for (w = 0; w <= W; w++)
                {
                    if (i == 0 || w == 0)
                        K[i, w] = 0;
                    else if (wt[i - 1] <= w)
                        K[i, w] = Math.Max(val[i - 1] + K[i - 1, w - wt[i - 1]], K[i - 1, w]);
                    else
                        K[i, w] = K[i - 1, w];
                }
            }

            return K[n, W];
        }
    }
}


        //static void Main()
        //{
        //    int[] val = new int[] { 60, 100, 120 };
        //    int[] wt = new int[] { 10, 20, 30 };
        //    int w = 50;
        //    int n = val.Length;

        //    int optval = getKS(wt, val, w, n);

        //    Console.WriteLine(optval);
        //    Console.ReadKey();
        //}

        //static int getKS(int[] wt, int[] val, int w, int n)
        //{
        //    if (w == 0 || n == 0) return 0;
        //    if (wt[n - 1] > w) return getKS(wt, val, w, n - 1);
        //    else return Math.Max(val[n-1]+getKS(wt, val, w-wt[n-1], n - 1), getKS(wt, val, w, n - 1));        
        //}