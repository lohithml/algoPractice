using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary.Classes.LC.amzOnsite
{
    public class TR_zigzagTree
    {
        //Medium
        //103
        //Given a binary tree, return the zigzag level order traversal of its nodes' values. 
        //(ie, from left to right, then right to left for the next level and alternate between).

        //For example:
        //Given binary tree [3,9,20,null,null,15,7],
        //    3
        //   / \
        //  9  20
        //    /  \
        //   15   7
        //return its zigzag level order traversal as:
        //[
        //  [3],
        //  [20,9],
        //  [15,7]
        //]
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            var result = new List<IList<int>>();
            levelOrder(root, 0, result);
            return result;
        }
        public void levelOrder(TreeNode root, int level, List<IList<int>> result)
        {
            if (root == null)
            {
                return;
            }

            if (level == result.Count)
            {
                result.Add(new List<int>());
            }

            if (level % 2 == 1)
            {
                //add to start
                result[level].Insert(0, root.val);
            }
            else
            {
                //add to end 
                result[level].Add(root.val);
            }

            levelOrder(root.left, level + 1, result);
            levelOrder(root.right, level + 1, result);

        }
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        //Time:O(N) # of elements
        //Space:O(H) height of tree

    }
}




