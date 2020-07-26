using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary
{
    class qinstack
    {
        Stack<int> stackN, stackO;

        public qinstack()
        {
            stackN = new Stack<int>();
            stackO = new Stack<int>();

        }

        public int size()
        {
            return stackN.Count() + stackO.Count();
        }

        public void add(int val)
        {
            stackN.Push(val);
        }

        public void shiftstacks()
        {
            if (stackO.Count != 0)
            {
                while (stackN.Count != 0)
                {
                    stackO.Push(stackN.Pop());
                }
            }
        }

        public int peek()
        {
            shiftstacks();
            return stackO.Peek();
        }


    }
    internal class T
    {
    }
}
