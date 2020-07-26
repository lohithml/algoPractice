using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary.Classes.LC.amzOnsite
{
    public class AR_STR_numberToWords_273H
    {
        //Hard
    //273
    //Convert a non-negative integer to its english words representation. Given input is guaranteed to be less than 231 - 1.
    //Example 1:
    //Input: 123
    //Output: "One Hundred Twenty Three"
        
    //Example 2:
    //Input: 12345
    //Output: "Twelve Thousand Three Hundred Forty Five"

    //Example 3:
    //Input: 1234567
    //Output: "One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven"

    //Example 4:
    //Input: 1234567891
    //Output: "One Billion Two Hundred Thirty Four Million Five Hundred Sixty Seven Thousand Eight Hundred Ninety One"
        
        private string[] belowTen = new string[] { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
        private string[] belowTwenty = new string[] { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        private string[] belowHundred = new string[] { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
    
        public string NumberToWords(int num) {
            if (num == 0) return "Zero";
            return Helper(num).Trim();
        }
    
        private string Helper(int num) {
            if (num < 10) return belowTen[num];
            if (num < 20) return belowTwenty[num % 10];
            if (num < 100) return belowHundred[num / 10] + " " + belowTen[num % 10];
            if (num < 1000) return Helper(num / 100).Trim() + " Hundred " + Helper(num % 100).Trim();
            if (num < 1000000) return Helper(num / 1000).Trim() + " Thousand "+ Helper(num % 1000).Trim();
            if (num < 1000000000) return Helper(num / 1000000).Trim() + " Million " + Helper(num % 1000000).Trim();
            return Helper(num / 1000000000).Trim()+" Billion " +Helper(num % 1000000000).Trim();
        }

        //Time: O(N)
        //Space: O(1)?? because only string output?
     }
}
