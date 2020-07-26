using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary.Classes.LC.amzOnsite
{
    public class LL_REC_Merge2sortedList
    {
        //Easy
        //21
        //Merge two sorted linked lists and return it as a new list. 
        //The new list should be made by splicing together the nodes of the first two lists.

        //Example:
        //Input: 1->2->4, 1->3->4
        //Output: 1->1->2->3->4->4
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null)
            {
                return l2;
            }
            else if (l2 == null)
            {
                return l1;
            }
            else if (l1.val < l2.val)
            {
                l1.next = MergeTwoLists(l1.next, l2);
                return l1;
            }
            else
            {
                l2.next = MergeTwoLists(l1, l2.next);
                return l2;
            }

        }

        //Time: O(M+N) sum of size of 2 lists
        //SPace O(M+N)
        //The first call to mergeTwoLists does not return until the ends of both l1 and l2 have been reached, so n + m stack frames consume O(n + m) space.

        public ListNode MergeTwoListsIterative(ListNode l1, ListNode l2)
        {
            ListNode prehead = new ListNode(-1);

            ListNode prev = prehead;
            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    prev.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    prev.next = l2;
                    l2 = l2.next;
                }
                prev = prev.next;
            }

            // exactly one of l1 and l2 can be non-null at this point, so connect
            // the non-null list to the end of the merged list.
            prev.next = l1 == null ? l2 : l1;

            return prehead.next;
        }

        //Time complexity : O(n + m)
        //Because exactly one of l1 and l2 is incremented on each loop iteration, the while loop runs for a number of iterations equal to the sum of the lengths of the two lists.All other work is constant, so the overall complexity is linear.
        //Space complexity : O(1)
        //The iterative approach only allocates a few pointers, so it has a constant overall memory footprint.
    }
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
  }
}
