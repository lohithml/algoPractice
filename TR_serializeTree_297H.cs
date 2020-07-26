using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary.Classes.LC.amzOnsite
{
    public class TR_serializeTree_297H
    {
        //Hard
        //297
        //Serialization is the process of converting a data structure or object into a sequence of bits so that it can be stored in a file or memory buffer, or transmitted across a network connection link to be reconstructed later in the same or another computer environment.
        //Design an algorithm to serialize and deserialize a binary tree. There is no restriction on how your serialization/deserialization algorithm should work. 
        //You just need to ensure that a binary tree can be serialized to a string and this string can be deserialized to the original tree structure.

        //Example: 
        //You may serialize the following tree:
        //    1
        //   / \
        //  2   3
        //     / \
        //    4   5
        //as "[1,2,3,null,null,4,5]"

                // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            if (root == null) return "X";
            return root.val + "," + serialize(root.left) + "," + serialize(root.right);

        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            if (data.Length == 0) return null;

            string[] arr = data.Split(',');
            var q = new Queue<String>();
            foreach (var s in arr) q.Enqueue(s);
            return helper(q);
        }
        TreeNode helper(Queue<String> q)
        {
            if (q.Count == 0) return null;
            if (q.Peek() == "X")
            {
                q.Dequeue();
                return null;
            }
            int v;
            var cur = q.Dequeue();
            Int32.TryParse(cur, out v);
            TreeNode r = new TreeNode(v);
            r.left = helper(q);
            r.right = helper(q);
            return r;
        }
        
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        //Time- O(N)
        //Space- O(N)
    }
}


 



 
