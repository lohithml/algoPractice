using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary.Classes.LC.amzOnsite
{
    public class DFS_criticalConnections_1192H
    {
        //https://www.youtube.com/watch?v=2kREIkF9UAs&t=883s

        //Hard
        //1192
        //Critical Connections in a Network

        //There are n servers numbered from 0 to n-1 connected by undirected server-to-server connections 
        //forming a network where connections[i] = [a, b] represents a connection between servers a and b. 
        //Any server can reach any other server directly or indirectly through the network.

        //A critical connection is a connection that, if removed, will make some server unable to reach some other server.
        //Return all critical connections in the network in any order.

        //Example 1:
        //Input: n = 4, connections = [[0,1],[1,2],[2,0],[1,3]]
        //Output: [[1,3]]
        //Explanation: [[3,1]] is also accepted. 

        //Constraints:
        //1 <= n <= 10^5
        //n-1 <= connections.length <= 10^5
        //connections[i][0] != connections[i][1]
        //There are no repeated connections.

        private int id;
        private int[] visited;
        private int[] low;
        private Dictionary<int, IList<int>> adjacencyList;
        private IList<IList<int>> ans;
        
        public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections)
        {
            //prepare adjacency list
            this.adjacencyList = new Dictionary<int, IList<int>>();
            foreach (var conn in connections)
            {
                int u = conn[0];
                int v = conn[1];

                if (!adjacencyList.ContainsKey(u))
                    adjacencyList.Add(u, new List<int>());

                if (!adjacencyList.ContainsKey(v))
                    adjacencyList.Add(v, new List<int>());

                adjacencyList[u].Add(v);
                adjacencyList[v].Add(u);
            }

            this.id = 0;
            this.visited = new int[n];
            this.low = new int[n];
            this.ans = new List<IList<int>>();            

            //mark nodes as unvisited
            for (int i = 0; i < n; i++)
                visited[i] = -1;

            //start with unvisited
            for (int i = 0; i < n; i++)
            {
                if (visited[i] == -1)
                    DFS(i, -1);
            }

            //to get link numbers in output list
            //var ans2 = new List<int>();
            //int c = 0;
            //foreach (var lnk in ans)
            //{
            //    int i = lnk[0];
            //    int j = lnk[1];
            //    foreach (var con in connections)
            //    {
            //        if (i == con[0] && j == con[1])
            //            ans2.Add(c);
            //        c++;
            //    }
            //}

            return ans;
        }

        void DFS(int at, int prev)
        {
            visited[at] = id;
            low[at] = id;
            id++;

            foreach (int to in adjacencyList[at])
            {
                //ignore the node we came from
                if (to == prev)
                    continue;

                if (visited[to] == -1)
                {
                    //visit
                    DFS(to, at);

                    if (visited[at] < low[to])
                    {
                        ans.Add(new List<int>() { at, to });
                    }
                }

                //update low-link value
                low[at] = Math.Min(low[at], low[to]);
            }
        }
    
        //Time: O(E+V)    
    }


}