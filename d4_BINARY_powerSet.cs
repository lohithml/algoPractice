using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary
{
    public class powerSet
    {
        //write a method to return all subsets of a set

        static void MainPwr()
        {
            char[] set= new char[] {'a','b','c'};
            powrSet(set,3);
            Console.ReadKey();
        }

        static void powrSet(char[] inp, int size)
        {
            int maxSize=(int)Math.Pow(2,size);
            for(int c=0;c<maxSize;c++)
            {
                for(int j=0;j<size;j++)
                {
                    if((c & (1<<j))>0)
                        Console.Write(inp[j]);

                }
            Console.WriteLine();
            }
        }
    }      
    
}

//Input: Set[], set_size
//1. Get the size of power set
//    powet_set_size = pow(2, set_size)
//2  Loop for counter from 0 to pow_set_size
//     (a) Loop for i = 0 to set_size
//          (i) If ith bit in counter is set
//               Print ith element from set for this subset
//     (b) Print separator for subsets i.e., newline


//Example:
//Set  = [a,b,c]
//power_set_size = pow(2, 3) = 8
//Run for binary counter = 000 to 111
//Value of Counter            Subset
//    000                    -> Empty set
//    001                    -> a
//    010                    -> b
//    011                    -> ab
//    100                    -> c
//    101                    -> ac
//    110                    -> bc
//    111                    -> abc
