using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary
{
    // ==> LC/amz problem: TR_isSubTree
    public class subTree
    {
        public void mainSubtree()
        {
            treeNode tree = new treeNode(6);
            tree.left = new treeNode(3);
            tree.right = new treeNode(2);
            tree.left.right = new treeNode(1);
            tree.left.left = new treeNode(0);

            treeNode tree2 = new treeNode(6);
            tree2.left = new treeNode(4);
            tree2.right = new treeNode(2);
            tree2.left.right = new treeNode(1);
            tree2.left.left = new treeNode(0);

            
            if (subTr(tree,tree2))
            {
                Console.WriteLine("Sub tree returned true");
            }
            else
            {
                Console.WriteLine("Sub tree returned false");
            }
            Console.ReadKey();
        }

        //brute force
        //index of method is not available in c#...so i didn't implement this...
        bool containsTree(treeNode t1, treeNode t2) {
            StringBuilder s1 = new StringBuilder();
            StringBuilder s2 = new StringBuilder();

            getOrderString(t1, s1);
            getOrderString(t2, s2);

            return false;
        }
        
        void getOrderString(treeNode tr1, StringBuilder sb) {
            sb.Append(tr1.value + " ");
            getOrderString(tr1.left, sb);
            getOrderString(tr1.right, sb);
        }

        //optimal
        class treeNode
        {
            public int value;
            public treeNode left, right;
            public treeNode(int item)
            {
                value = item;
                left = right = null;
            }
        }

        bool subTr(treeNode t1, treeNode t2)
        {
            if (t2 == null)
                return true;

            return chkSubtree(t1, t2);
        }

        bool chkSubtree(treeNode r1, treeNode r2)
        {
            if (r1 == null)
                return false;
            else if (r1.value == r2.value && matchTree(r1, r2))
                return true;

            return chkSubtree(r1.left, r2) || chkSubtree(r1.right, r2);
        }

        bool matchTree(treeNode tr1, treeNode tr2)
        {
            if (tr1 == null && tr2 == null)
                return true;
            else if (tr1 == null || tr2 == null)
                return false;
            else if (tr1.value != tr2.value)
                return false;
            else
                return matchTree(tr1.left, tr2.left) && matchTree(tr1.right, tr2.right);
        }


    }
}
