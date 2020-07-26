using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary
{
    public class towersHoanoi
    {
        //move disks from one to another


        public void Maintoh()
        {
            int n = 4;

            //toh(n, 'A', 'C', 'B');
            Stack<int> f = new Stack<int>();
            Stack<int> t = new Stack<int>();
            Stack<int> i = new Stack<int>();
            Move(n, f, t, i);
            Console.ReadKey();
        }

        void toh(int x, char s,char d, char a)
        {
            if (x == 1)
            {
                Console.WriteLine("Move disc {0} from rod {1} to rod {2}", x, s, d);
                return;
            }
            toh(x - 1, s, a, d);
            Console.WriteLine("Move disc {0} from rod {1} to rod {2}", x, s, d);
            toh(x - 1, a, d, s);
            
        }


        void Move(int discs, Stack<int> fromPeg, Stack<int> toPeg, Stack<int> otherPeg)
        {
            if(discs<=0) return;

            if (discs == 1)
            {
                toPeg.Push(discs);
                return;
            }

            Move(discs - 1, fromPeg, otherPeg, toPeg);

            toPeg.Push(discs);

            Move(discs - 1, otherPeg, toPeg, fromPeg);
        }

    }      
    
}

 //Move disk 1 from rod A to rod B
 //Move disk 2 from rod A to rod C
 //Move disk 1 from rod B to rod C
 //Move disk 3 from rod A to rod B
 //Move disk 1 from rod C to rod A
 //Move disk 2 from rod C to rod B
 //Move disk 1 from rod A to rod B
 //Move disk 4 from rod A to rod C
 //Move disk 1 from rod B to rod C
 //Move disk 2 from rod B to rod A
 //Move disk 1 from rod C to rod A
 //Move disk 3 from rod B to rod C
 //Move disk 1 from rod A to rod B
 //Move disk 2 from rod A to rod C
 //Move disk 1 from rod B to rod C


