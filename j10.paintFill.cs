using System;

namespace LohiLibrary
{
    // C# program to implement
    // flood fill algorithm
    class paintFill
    {
        // Dimentions of paint screen
        static int M = 8;
        static int N = 8;

        // A recursive function to replace
        // previous color ‘prevC’ at ‘(x, y)’
        // and all surrounding pixels of (x, y)
        // with new color ‘newC’ and
        static void floodFillUtil(int[,] screen, int x, int y, int prevC, int newC)
        {
            // Base cases
            if (x < 0 || x >= M || y < 0 || y >= N)
                return;
            if (screen[x, y] != prevC)
                return;

            // Replace the color at (x, y)
            screen[x, y] = newC;

            // Recur for north, east, south and west
            floodFillUtil(screen, x + 1, y, prevC, newC);
            floodFillUtil(screen, x-1, y, prevC, newC);
            floodFillUtil(screen, x, y + 1, prevC, newC);
            floodFillUtil(screen, x, y - 1, prevC, newC);
        }

        // It mainly finds the previous color
        // on (x, y) and calls floodFillUtil()
        static void floodFill(int[,] screen, int x, int y, int newC)
        {
            int prevC = screen[x, y];
            floodFillUtil(screen, x, y, prevC, newC);
        }

        // Driver code
        public void MainFF()
        {
            int[,] screen = {
                                {1, 1, 1, 1, 1, 1, 1, 1},
                                {1, 1, 1, 1, 1, 1, 0, 0},
                                {1, 0, 0, 1, 1, 0, 1, 1},
                                {1, 2, 2, 2, 2, 0, 1, 0},
                                {1, 1, 1, 2, 2, 0, 1, 0},
                                {1, 1, 1, 2, 2, 2, 2, 0},
                                {1, 1, 1, 1, 1, 2, 1, 1},
                                {1, 1, 1, 1, 1, 2, 2, 1}
                            };
            int x = 0, y = 0, newC = 3;
            floodFill(screen, x, y, newC);

            Console.WriteLine("After floodFill: ");
            for (int i = 0; i < M; i++) {
                for (int j = 0; j < N; j++)
                    Console.Write(screen[i, j] + " ");
                    Console.WriteLine();
            }
        }
    }
}

        //static void Main()
        //{
        //    int[,] screen = {
        //                        {1, 1, 1, 1, 1, 1, 1, 1},
        //                        {1, 1, 1, 1, 1, 1, 0, 0},
        //                        {1, 0, 0, 1, 1, 0, 1, 1},
        //                        {1, 2, 2, 2, 2, 0, 1, 0},
        //                        {1, 1, 1, 2, 2, 0, 1, 0},
        //                        {1, 1, 1, 2, 2, 2, 2, 0},
        //                        {1, 1, 1, 1, 1, 2, 1, 1},
        //                        {1, 1, 1, 1, 1, 2, 2, 1}
        //                    };

        //    int x, y, c;
        //    x = 0;
        //    y = 0;
        //    c = 3;
        //    int pre = screen[x, y];
        //    floodfill(screen, x, y, pre, c);

        //    for (int g = 0; g < screen.GetLength(0); g++)
        //        for (int h = 0; h < screen.GetLength(1); h++)
        //            Console.Write(screen[g, h]+ " ");
        //            Console.WriteLine();

        //}

        //static void floodfill(int[,] scr, int i, int j, int k, int l)
        //{            
        //    if (i<0||j<0||i>=scr.GetLength(0)||j>=scr.GetLength(1)||scr[i, j]!=k) return;

        //    scr[i, j] = l;

        //    floodfill(scr, i, j + 1, k, l);
        //    floodfill(scr, i, j - 1, k, l);
        //    floodfill(scr, i-1, j, k, l);
        //    floodfill(scr, i + 1, j, k, l);
        //}