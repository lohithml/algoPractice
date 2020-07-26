using System;

//2 arrays of integers
//pair of values-one from each array with the smallest difference
//return the difference

class Solution
{
    static void mainSmall()
    {
        
        int[] arrayA={1,2,18,15};
        int[] arrayB={4,22,19,223,127,235};
        
        int res=getSmallestDiff(arrayA,arrayB);
        Console.WriteLine(res);
        
    }
    
    public static int getSmallestDiff(int[] arrA,int[] arrB)
    {
            
        if(arrA.Length==0 || arrB.Length==0) return -1;
                
        Array.Sort(arrA);
        Array.Sort(arrB);
        
        int indA=0;
        int indB=0;
        
        int smallDiff=int.MaxValue;
        
        while(indA<arrA.Length && indB<arrB.Length)
        {  
            int diff=Math.Abs(arrA[indA]-arrB[indB]);
            smallDiff=Math.Min(diff,smallDiff);
            
            if(arrA[indA]<arrB[indB])
                indA++;
            else
                indB++;
        }
        return smallDiff;
    }
}