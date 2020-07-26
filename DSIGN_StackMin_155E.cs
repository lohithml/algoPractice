using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary.Classes.LC.amzOnsite
{
    public class minStack
    {
        //Easy
        //155. Min Stack
        //Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.

        //push(x) -- Push element x onto stack.
        //pop() -- Removes the element on top of the stack.
        //top() -- Get the top element.
        //getMin() -- Retrieve the minimum element in the stack.


        //Example:

        //MinStack minStack = new MinStack();
        //        minStack.push(-2);
        //minStack.push(0);
        //minStack.push(-3);
        //minStack.getMin();   --> Returns -3.
        //minStack.pop();
        //minStack.top();      --> Returns 0.
        //minStack.getMin();   --> Returns -2.

        public class MinStack
        {

            Stack<int> st;
            Stack<int> minSt ;

            /** initialize your data structure here. */
            public MinStack()
            {
                st = new Stack<int>();
                minSt = new Stack<int>();
            }

            public void Push(int x)
            {
                st.Push(x);
                if (minSt.Count == 0 || x <= minSt.Peek())
                    minSt.Push(x);
            }

            public void Pop()
            {
                if (st.Peek() == minSt.Peek())
                    minSt.Pop();
                st.Pop();
            }

            public int Top()
            {
                return st.Peek();
            }

            public int GetMin()
            {
                return minSt.Peek();
            }

            //Time : O(1)
            //Space: O(N)..push operations O(2*N)

        }

        /**
         * Your MinStack object will be instantiated and called as such:
         * MinStack obj = new MinStack();
         * obj.Push(x);
         * obj.Pop();
         * int param_3 = obj.Top();
         * int param_4 = obj.GetMin();
         */

    }
}

