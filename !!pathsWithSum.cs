using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary
{
    class pathsWithSum
    {
        public void mainPathsWithSum()
        {
            treeNode tree = new treeNode(6);
            tree.left = new treeNode(3);
            tree.right = new treeNode(2);
            tree.left.right = new treeNode(1);
            tree.left.left = new treeNode(0);

            int totalNumPaths = countPaths(tree, 10);

            Console.WriteLine(totalNumPaths.ToString());
            Console.ReadKey();

        }
        int countPaths(treeNode t1,int targetSum)
        {
            if (t1 == null) return 0;

            int pathfromroot = countPathsFrmRoot(t1, targetSum, 0);
            int pathsonleft = countPaths(t1.left, targetSum);
            int pathsonright = countPaths(t1.right, targetSum);

            return pathfromroot+pathsonleft+pathsonright;
        }

        int countPathsFrmRoot(treeNode tc,int targetSum, int currentSum)
        {
            if (tc == null) return 0;

            currentSum = tc.value;

            int totalPaths = 0;
            if (currentSum == targetSum) totalPaths++;

            totalPaths += countPathsFrmRoot(tc.left, targetSum, currentSum);
            totalPaths += countPathsFrmRoot(tc.right, targetSum, currentSum);
            return totalPaths;            
        }

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
    }
}
