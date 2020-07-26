using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary.Classes.LC.amzOnsite
{
    public class TR_bstIterator_173M
    {
        //Medium
        //173
        //Implement an iterator over a binary search tree(BST). Your iterator will be initialized with the root node of a BST.
        //Calling next() will return the next smallest number in the BST.
        //Note:
        //next() and hasNext() should run in average O(1) time and uses O(h) memory, where h is the height of the tree.
        //You may assume that next() call will always be valid, that is, there will be at least a next smallest number in the BST when next() is called.

         public class TreeNode {
              public int val;
              public TreeNode left;
              public TreeNode right;
              public TreeNode(int x) { val = x; }
          }

        public class BSTIterator
        {
            List<int> nodeSorted;
            int index;

            public BSTIterator(TreeNode root)
            {
                nodeSorted = new List<int>();
                index = -1;
                createNodeArray(root);
            }
            void createNodeArray(TreeNode t)
            {
                if (t == null) return;
                createNodeArray(t.left);
                nodeSorted.Add(t.val);
                createNodeArray(t.right);
            }

            /** @return the next smallest number */
            public int Next()
            {
                return nodeSorted[++index];
            }

            /** @return whether we have a next smallest number */
            public bool HasNext()
            {
                return index + 1 < nodeSorted.Count();
            }
        }

        /**
         * Your BSTIterator object will be instantiated and called as such:
         * BSTIterator obj = new BSTIterator(root);
         * int param_1 = obj.Next();
         * bool param_2 = obj.HasNext();
         */

//Time complexity : O(N)is the time taken by the constructor for the iterator.
//The problem statement only asks us to analyze the complexity of the two functions, 
//however, when implementing a class, it's important to also note the time it takes to initialize a new object of the class and in this case it would be linear in terms of the number of nodes in the BST. In addition to the space occupied by the new array we initialized, the recursion stack for the inorder traversal also occupies space but that is limited to O(h)O(h) where hh is the height of the tree.
//next() would take O(1)
//hasNext() would take O(1)
//Space complexity : O(N) since we create a new array to contain all the nodes of the BST.
 //This doesn't comply with the requirement specified in the problem statement that the maximum space complexity of either of the functions should be O(h) where h is the height of the tree and for a well balanced BST, the height is usually logN. 
 //So, we get great time complexities but we had to compromise on the space. Note that the new array is used for both the function calls and hence the space complexity for both the calls is O(N).
    }
}


 



 
