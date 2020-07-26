using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary.Classes.LC.amzOnsite
{
    public class DFS_courseSchedule2_210M
    {
        //Medium
        //210. Course Schedule II
        //There are a total of n courses you have to take, labeled from 0 to n-1.
        //Some courses may have prerequisites, for example to take course 0 you have to first take course 1, which is expressed as a pair: [0,1]
        //Given the total number of courses and a list of prerequisite pairs, return the ordering of courses you should take to finish all courses.
        //There may be multiple correct orders, you just need to return one of them.If it is impossible to finish all courses, return an empty array.
        //Example 1:
        //Input: 2, [[1,0]] 
        //Output: [0,1]
        //        Explanation: There are a total of 2 courses to take.To take course 1 you should have finished
        //             course 0. So the correct course order is [0,1] .
        //Example 2:
        //Input: 4, [[1,0],[2,0],[3,1],[3,2]]
        //Output: [0,1,2,3]
        //        or[0, 2, 1, 3]
        //Explanation: There are a total of 4 courses to take.To take course 3 you should have finished both
        //            courses 1 and 2. Both courses 1 and 2 should be taken after you finished course 0. 
        //             So one correct course order is [0,1,2,3]. Another correct ordering is [0,2,1,3] .
        //Note:
        //The input prerequisites is a graph represented by a list of edges, not adjacency matrices.Read more about how a graph is represented.
        //You may assume that there are no duplicate edges in the input prerequisites.

        LinkedList<int> orderList;
        int[] color;
        List<int>[] adjList;
        bool isCyclic = false;
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            orderList = new LinkedList<int>();
            adjList = new List<int>[numCourses];
            for (int i = 0; i < numCourses; i++)
                adjList[i] = new List<int>();

            foreach (var c in prerequisites)
            {
                var to = c[0];
                var from = c[1];
                adjList[from].Add(to);
            }

            color = new int[numCourses];

            for (int i = 0; i < numCourses; i++)
                if (color[i] == 0)
                    dfs(i);

            if (isCyclic)
                return new int[0];
            else
                return orderList.ToList().ToArray();
        }

        void dfs(int cur)
        {
            color[cur] = 1;
            foreach (var t in adjList[cur])
            {
                if (color[t] == 1)
                {
                    isCyclic = true;
                    return;
                }
                else if (color[t] == 0)
                    dfs(t);
            }
            color[cur] = 2;
            orderList.AddFirst(cur);
        }

        //Time: O(N)
        //Space: O(N)    
    }

}