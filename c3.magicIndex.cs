using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary
{
    public class magicIndex
    {
        public void MainM()
        {
            //find magic index if exists in an array A[i]=i
            
            //              0, 1, 2, 3, 4
            int[] input = { 1, 2, 3, 3 ,8};
            int index;
            //index = magicSlow(input);
            index = magicFast(input);

            Console.WriteLine(index);
            Console.ReadKey();

        }
        //slow procedure
        public int magicSlow(int[] inp)
        {
            for (int i = 0; i < inp.GetLength(0); i++)
                if (inp[i] == i) return i;
            return -1;
        }

        //fast procedure
        //binary search
        //values are distinct
        public int magicFast(int[] array)
        {
            int res = magicFastRec(array, 0, array.GetLength(0)-1);
            return res;
        }

        public int magicFastRec(int[] array, int start, int end)
        {
            //base case
            if (start < end) return -1;
            int mid = (start + end) / 2;
            if (array[mid] == mid) return mid;

            else if (array[mid] > mid) return magicFastRec(array, mid+1, end);
            else if (array[mid] < mid) return magicFastRec(array, start, mid-1);
            else return -1;
        }

        //values are non distinct
        //need to compare mid value and indeces
        //search both left and right sides with math min and max functions
        public int magicFastND(int[] array, int start, int end)
        {
            if (start < end) return -1;
            int mid = (start + end) / 2;
            if (array[mid] == mid) return mid;

            int midVal = array[mid];
            int leftIndex = Math.Min(mid - 1, midVal);
            int left = magicFastND(array, start, leftIndex);
            if (left >= 0) return left;

            int rightIndex = Math.Max(mid + 1, midVal);
            int right = magicFastND(array, rightIndex, end);
            return right;
        }

    }
}
