using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary
{
    public class validateBST
    {
        //binary search tree
        //left <= node < right

        public void mainBst()
        {
            BinTree tree = new BinTree();
            tree.root = new Node(4);
            tree.root.left = new Node(2);
            tree.root.right = new Node(5);
            tree.root.left.left = new Node(1);
            tree.root.left.right = new Node(3);
            if (tree.isBST)
            {
                Console.WriteLine("Tree is BST");
            }
            else
            {
                Console.WriteLine("Tree is not BST");
            }
            Console.ReadKey();
        }
        public class Node
        {
            public int data;
            public Node left, right;
            public Node(int item)
            {
                data = item;
                left = right = null;
            }
        }
        public class BinTree
        {
            public Node root;
            public bool isBST
            {
                get
                {
                    return bstCheck(root, int.MinValue, int.MaxValue);
                }
            }
            public bool bstCheck(Node root, int min, int max)
            {
                if (root == null) return true;
                if (root.data < min || root.data > max)
                    return false;
                return bstCheck(root.left, min, root.data) && bstCheck(root.right,root.data,max);
            }
        }
    }
}
