using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary
{
    //amz question jan 2019
    //robot can go right and down
    //it cant go through obstacles
    //path to reach from top left to bottom right

    public class robotingrid
    {
        public void mainR() {
            //int[,] obst = new int[,] { { 0, 0, 0 }, { 0, 0,0}, { 0, 0, 0 } };
            //int result = UniquePathsWithObstacles(obst);

            bool[,] maize = new bool[,] { { true, false, true }, { true, true, true }, { true, false, true }, { true, true, true } };

            Console.WriteLine("Before program run: ");
            for (int i = 0; i < maize.GetLength(0); i++)
            {
                for (int j = 0; j < maize.GetLength(1); j++)
                    Console.Write(maize[i, j] + " ");
                Console.WriteLine();
            }

            Console.WriteLine();

            List<Point> res = getPath(maize);
            //Console.ReadKey();

            Console.WriteLine("After program run: ");
            foreach (var p in res)
                Console.WriteLine(p.r.ToString() + p.c.ToString());
            Console.ReadKey();
        }
        
        List<Point> getPath(bool[,] maze)
        {
            if (maze == null || maze.Length == 0) return null;
            List<Point> path = new List<Point>();
            HashSet<Point> failedPoints = new HashSet<Point>();
            if (getFullPath(maze, maze.GetLength(0) - 1, maze.GetLength(1) - 1, path, failedPoints)) return path;
            //if (getFullPathRecurse(maze, maze.GetLength(0) - 1, maze.GetLength(1) - 1, path)) return path;
            else return null;
        }

        bool getFullPath(bool[,] maze, int r, int c, List<Point> path, HashSet<Point> failedPoints)
        {
            if (c < 0 || r < 0 || !maze[r, c]) return false;
            Point p = new Point(r, c);
            if (failedPoints.Contains(p)) return false;
            bool isAtOrigin = (r == 0) && (c == 0);
            if (isAtOrigin || getFullPath(maze, r, c - 1, path, failedPoints) || getFullPath(maze, r - 1, c, path, failedPoints))
            {
                //add point location to path if exists
                path.Add(p);
                return true;
            }
            //cache the result
            failedPoints.Add(p);
            return false;
        }

        //recursive
        bool getFullPathRecurse(bool[,] maze, int r, int c, List<Point> path)
        {
            if (c < 0 || r < 0 || !maze[r, c]) return false;
            Point p = new Point(r, c);
            bool isAtOrigin = (r == 0) && (c == 0);
            if (isAtOrigin || getFullPathRecurse(maze, r, c - 1, path) || getFullPathRecurse(maze, r - 1, c, path))
            {
                //add point location to path if exists
                path.Add(p);
                return true;
            }
            return false;
        }

        public int UniquePathsWithObstacles(int[,] obstacleGrid)
        {
            var row = obstacleGrid.GetLength(0);
            var column = obstacleGrid.GetLength(1);
            var dp = new int[column];
            dp[0] = 1;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (obstacleGrid[i, j] == 1)
                    {
                        dp[j] = 0;
                    }
                    else
                    {
                        dp[j] += j > 0 ? dp[j - 1] : 0;
                    }
                }
            }
            return dp[column - 1];
        }
    }

    internal class Point
    {
        internal int r;
        internal int c;
        public Point(int x, int y)
        {
            r = x;
            c = y;
        }
    }
}


//class Program
//{
//    static void Main()
//    {
//        //grid r,c
//        //right,down
//        //upper left to bottom right... 0,0 to r,c
//        //off limit
//        //find the path- with matrix coordinates

//        bool[,] input = { { true, false, true }, 
//                           { true, true, true }, 
//                           { true, false, true }, 
//                           { true, true, true } };
//        Console.WriteLine("Question : ");
//        for (int l = 0; l < input.GetLength(0); l++)
//        {
//            for (int m = 0; m < input.GetLength(1); m++)
//            {
//                Console.Write(input[l, m].ToString() + " ");
//            }
//            Console.WriteLine();
//        }
//        List<Pnt> path = findPath(input);
//        Console.WriteLine();
//        Console.WriteLine("Answer : ");
//        foreach (var p in path)
//        {
//            Console.Write(p.r.ToString() + " " + p.c.ToString());
//            Console.WriteLine();
//        }
//        Console.ReadKey();

//output
//0 0
//1 0
//2 0
//3 0
//3 1
//3 2

//    }

//    static List<Pnt> findPath(bool[,] input)
//    {
//        if (input == null || input.GetLength(0) == 0) return null;
//        List<Pnt> res = new List<Pnt>();
//        HashSet<Pnt> fp = new HashSet<Pnt>();
//        if (pathExists (input, input.GetLength(0) - 1, input.GetLength(1) - 1, res, fp)) return res;
//        else return null;
//    }

//    static bool pathExists(bool[,] input, int i, int j, List<Pnt> opt, HashSet<Pnt> f)
//    {
//        if (i < 0 || j < 0 || !input[i, j]) return false;
//        Pnt poi = new Pnt(i, j);
//        if (f.Contains(poi)) return false;
//        bool isOrigin = (i == 0) & (j == 0);
//        if (isOrigin || pathExists(input, i, j - 1, opt, f) || pathExists(input, i - 1, j, opt, f))
//        {
//            opt.Add(poi);
//            return true;
//        }
//        f.Add(poi);
//        return false;
//    }

//}
//class Pnt
//{
//    internal int r, c;
//    internal Pnt(int x, int y)
//    {
//        r = x;
//        c = y;
//    }
//}