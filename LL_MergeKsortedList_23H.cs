using LohiLibrary.Classes.LC.amzOnsite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary.Classes.LC.amz
{    
    //Hard
    //23. Merge k Sorted Lists
    //Merge k sorted linked lists and return it as one sorted list.Analyze and describe its complexity.
    //Example:
    //Input:
    //[
    //  1->4->5,
    //  1->3->4,
    //  2->6
    //]
    //Output: 1->1->2->3->4->4->5->6
    public class LL_MergeKsortedList_23H
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            return mergerHelper(lists, 0, lists.Length - 1);
        }

        public ListNode mergerHelper(ListNode[] lists,int L,int R)
        {
            if (L == R) return lists[L];
            if(L<R)
            {
                int M = (L + R) / 2;
                ListNode l1 = mergerHelper(lists, L, M);
                ListNode l2 = mergerHelper(lists,M+1, R);
                return merge2Lists(l1, l2);
            }
            else
                return null;
        }
        public ListNode merge2Lists(ListNode a, ListNode b)
        {
            ListNode tempHead = new ListNode(-1);
            ListNode prev = tempHead;

            while(a!=null && b!=null)
            {
                if(a.val < b.val)
                {
                    prev.next = a;
                    a = a.next;
                }
                else
                {
                    prev.next = b;
                    b = b.next;
                }
                prev = prev.next;
            }

            if (a == null)
                prev.next = b;
            else
                prev.next = a;

            return tempHead.next;
        }
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }

    //Time complexity : O(n + m) for merging 2 lists... O(kN) for merging K lists...
    //Space complexity : O(1) We can merge two sorted linked list in O(1)O(1) space.
}
