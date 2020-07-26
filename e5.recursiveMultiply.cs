using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary
{
    public class recursiveMultiply
    {
        //multiply 2 integers without using *
        //you can use addition, subtraction, division

        public void MainRecMul()
        {
            int a, b;
            a = 4;
            b = 5;
            int res = RecMul(a, b);
            Console.Write(res);
        }

        int RecMul(int x, int y)
        {
            if (x == 0 || y == 0) return 0;
            else
            {
                int s, b;
                if (x < y) { s = x; b = y; }
                else { s = y; b = x; }

                return RecMulHelper(s, b);
            }
        }

        int RecMulHelper(int c, int d)
        {
            if (c == 0) return 0;
            else if (c == 1) return d;

            int r = c >> 1; //divide by 2
            int halfPrd = RecMulHelper(r, d);

            if (c % 2 == 0) //even
                return halfPrd + halfPrd;
            else //odd=even+1
                return halfPrd+halfPrd+d;
        }
    }      
    
}


