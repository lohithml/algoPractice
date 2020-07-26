using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary
{
    
    //calculate min cost in an array to cover all items

    class tsp
    {
        // Function to calculate minimum cost 
        static int minimum_cost(int[] a, int n)
        {

            int mn = int.MaxValue;
            int sum = 0;

            for (int i = 0; i < n; i++)
            {

                // To find the minimum element 
                mn = Math.Min(a[i], mn);

                // sum of all the elements 
                sum += a[i];
            }

            return mn * (sum - mn);
        }

        // Driver code 
        public static void Maint()
        {
            int[] a = { 4, 3, 2, 5 };
            int n = a.Length;

            Console.WriteLine(minimum_cost(a, n));
            Console.ReadKey();
        }

    }
}
