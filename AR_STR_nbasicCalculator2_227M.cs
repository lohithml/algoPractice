using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary.Classes.LC.amzOnsite
{
    public class AR_STR_nbasicCalculator2_227M
    {
        //Medium
        //227.Basic Calculator II
        //Implement a basic calculator to evaluate a simple expression string.

        //The expression string contains only non-negative integers, +, -, *, / operators and empty spaces.The integer division should truncate toward zero.

        //Example 1:

        //Input: "3+2*2"
        //Output: 7
        //Example 2:

        //Input: " 3/2 "
        //Output: 1
        //Example 3:

        //Input: " 3+5 / 2 "
        //Output: 5
        //Note:

        //You may assume that the given expression is always valid.
        //Do not use the eval built-in library function.   

        public int Calculate_WithStack(string s)
        {
            if (s == null || (s.Length == 0)) return 0;
            int len = s.Length;
            Stack<int> stack = new Stack<int>();

            int num = 0;
            char sign = '+';

            for (int i = 0; i < len; i++)
            {
                if (Char.IsDigit(s[i]))
                {
                    num = num * 10 + s[i] - '0';
                }
                if ((!Char.IsDigit(s[i]) && s[i] != ' ') || i == len - 1)
                {
                    if (sign == '-')
                    {
                        stack.Push(-num);
                    }
                    if (sign == '+')
                    {
                        stack.Push(num);
                    }
                    if (sign == '*')
                    {
                        stack.Push(stack.Pop() * num);
                    }
                    if (sign == '/')
                    {
                        stack.Push(stack.Pop() / num);
                    }
                    sign = s[i];
                    num = 0;
                }
            }

            int re = 0;
            foreach (int i in stack)
            {
                re += i;
            }
            return re;
        }

        //Time: O(N)
        //Space: O(N) because of stack

        public int Calculate_withoutStack(string s)
        {
            //without stack

            s = s.Trim();
            if (s == null || (s.Length == 0)) return 0;

            int len = s.Length;

            int num = 0;
            char sign = '+';
            int re = 0;
            int prenum = 0;

            for (int i = 0; i < len; i++)
            {
                if (Char.IsDigit(s[i]))
                {
                    num = num * 10 + s[i] - '0';
                }
                if ((!Char.IsDigit(s[i]) && s[i] != ' ') || i == len - 1)
                {
                    if (sign == '-')
                    {
                        //stack.Push(-num);
                        re += prenum;
                        prenum = -num;
                    }
                    if (sign == '+')
                    {
                        //stack.Push(num);
                        re += prenum;
                        prenum = num;
                    }
                    if (sign == '*')
                    {
                        //stack.Push(stack.Pop()*num);
                        prenum = prenum * num;
                    }
                    if (sign == '/' && num != 0)
                    {
                        //stack.Push(stack.Pop()/num);
                        prenum = prenum / num;
                    }
                    sign = s[i];
                    num = 0;
                }
            }
            //int re = 0;
            // foreach(int i in stack){
            //    re += i;
            // }
            re += prenum;
            return re;
        }

        //Time: O(N)
        //Space: O(1)

    }
}
