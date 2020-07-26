using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary.Classes.LC.amzOnsite
{
    public class TR_isSubTree
    {
        //Easy
        //572
        //Given two non-empty binary trees s and t, check whether tree t has exactly the same structure and node values with a subtree of s. 
        //A subtree of s is a tree consists of a node in s and all of this node's descendants. 
        //The tree s could also be considered as a subtree of itself.
        //Example 1:
        //Given tree s:

        //     3
        //    / \
        //   4   5
        //  / \
        // 1   2
        //Given tree t:
        //   4 
        //  / \
        // 1   2
        //Return true, because t has the same structure and node values with a subtree of s.

        //Example 2:
        //Given tree s:

        //     3
        //    / \
        //   4   5
        //  / \
        // 1   2
        //    /
        //   0
        //Given tree t:
        //   4
        //  / \
        // 1   2
        //Return false.

        //solution 1:
        public bool IsSubtree(TreeNode s, TreeNode t)
        {
            return s != null && (equals(s, t) || IsSubtree(s.left, t) || IsSubtree(s.right, t));
        }

        public bool equals(TreeNode x, TreeNode y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;
            return x.val == y.val && equals(x.left, y.left) && equals(x.right, y.right);
        }

        //solution 2:
        public bool isSubtree(TreeNode s, TreeNode t) {
            String tree1 = preorder(s, true);
            String tree2 = preorder(t, true);
            return tree1.IndexOf(tree2) >= 0;
        }
        public String preorder(TreeNode t, bool left) {
            if (t == null) {
                if (left)
                    return "lnull";
                else
                    return "rnull";
            }
            return "#"+t.val + " " +preorder(t.left, true)+" " +preorder(t.right, false);
        }

        //Time: O(m^2+n^2+m*n) m-nodes in t,n-nodes in s,O(k) string concatination,O(m*n) indexof
        //Space: O(max(m,n))
        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
    }
}