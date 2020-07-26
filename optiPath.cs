
using System;

namespace LohiLibrary
{
    class optiPath
    {
        static void MainO(string[] args)
        {
            //amz question feb 2019
            //path is represented by node and the distance to that node
            //find the best combination of fwd and rev path to minimize travel distance
            //output node numbers for fwd and rev path

            var fPath = new double[,]
            {
                {1,300},
                {2,210},
                {3,220},
                {4,230}
            };
            var rPath = new double[,]
            {
                {5,800},
                {6,210},
                {7,220}
            };

            OptiPath opt = new OptiPath(fPath, rPath);
            OptiPath opPath = opt.findPath();
            opt.Display();
        }

        private class OptiPath
        {
            double[,] fwdPath;
            double[,] revPath;
            double distfwd, distrev, disttotal, distopt;
            int[] optPath = new int[2];
            double[] optiPath = new double[2];

            public OptiPath(double[,] fPath, double[,] rPath)
            {
                fwdPath = fPath;
                revPath = rPath;
            }

            public OptiPath findPath()
            {

                distopt = 0;

                for (int i = 0; i < fwdPath.GetLength(0); i++)
                {
                    distfwd = fwdPath[i, 1];
                    for (int j = 0; j < revPath.GetLength(0); j++)
                    {
                        distrev = revPath[j, 1];
                        disttotal = distfwd + distrev;
                        if (i == 0)
                        {
                            distopt = disttotal;
                        }
                        else if (disttotal < distopt)
                        {
                            distopt = disttotal;
                            optPath[0] = i;
                            optPath[1] = j;
                            optiPath[0] = fwdPath[i, 0];
                            optiPath[1] = revPath[j, 0];
                        }
                    }
                }
                return null;
            }

            public void Display()
            {
                Console.WriteLine("\nThe optimal distance is : " + distopt);
                Console.WriteLine("\nThe forward path is : " + optiPath[0]);
                Console.WriteLine("\nThe reverse path is : " + optiPath[1]);
                Console.ReadKey();

            }
        }
    }
}