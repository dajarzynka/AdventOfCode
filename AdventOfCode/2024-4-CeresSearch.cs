

using System.Numerics;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    internal class _2024_4_CeresSearch
    {
        internal static int Execute()
        {
            var input = File.ReadAllLines("2024Inputs/2024Problem4.txt");
            var dataSetLength = input.Length;
            var workingDataSet = new string[input.First().Length, input.Length];
            var result = 0;

            for (var i = 0; i < input.First().Length; i++)
            {
                var temp = input[i].Select(c=>c.ToString()).ToArray();

                for (var j = 0; j < temp.Length; j++)
                {
                    workingDataSet[i, j] = temp[j];
                }
            }

            for (var i = 0; i < input.Length; i++)
            {
                for (var j = 0; j < input.First().Length; j++)
                {
                    if (workingDataSet[i,j].Equals("X", StringComparison.OrdinalIgnoreCase))
                    {
                        //right
                        if (j<dataSetLength-3)
                        {
                            result += CheckRight(i, j, workingDataSet);
                        }

                        //left
                        if(j>2)
                        {
                            result += CheckLeft(i, j, workingDataSet);
                        }

                        //down
                        if(i<dataSetLength-3)
                        {
                            result += CheckDown(i, j, workingDataSet);
                        }

                        //up
                        if(i>2)
                        {
                            result += CheckUp(i, j, workingDataSet);
                        }

                        //down + right
                        if(i<dataSetLength-3 && j<dataSetLength-3)
                        {
                            result += CheckDownRight(i, j, workingDataSet);
                        }

                        //down + left
                        if(i<dataSetLength-3 && j>2)
                        {
                            result += CheckDownLeft(i, j, workingDataSet);
                        }

                        //up + left
                        if(i>2 && j>2)
                        {
                            result += CheckUpLeft(i, j, workingDataSet);
                        }

                        //up + right
                        if(i>2 && j<dataSetLength-3)
                        {
                            result += CheckUpRight(i, j, workingDataSet);
                        }
                    }
                }
            }



            //for (var i = 0; i < input.Length; i++)
            //{
            //    for (var j = 0; j < input.First().Length; j++)
            //    {
            //        Console.Write(workingDataSet[i, j]);
            //    }
            //    Console.WriteLine();
            //}

            return result;
           
        }

        private static int CheckRight(int i, int j, string[,] workingDataSet)
        {
            if (!workingDataSet[i, j + 1].Equals("M", StringComparison.OrdinalIgnoreCase))
            {
                return 0;
            }
            if (!workingDataSet[i, j + 2].Equals("A", StringComparison.OrdinalIgnoreCase))
            {
                return 0;
            }
            if (!workingDataSet[i, j + 3].Equals("S", StringComparison.OrdinalIgnoreCase))
            {
                return 0;
            }

            return 1;
        }

        private static int CheckDownRight(int i, int j, string[,] workingDataSet)
        {
            if (!workingDataSet[i + 1, j + 1].Equals("M", StringComparison.OrdinalIgnoreCase))
            {
                return 0;
            }
            if (!workingDataSet[i + 2, j + 2].Equals("A", StringComparison.OrdinalIgnoreCase))
            {
                return 0;
            }
            if (!workingDataSet[i + 3, j + 3].Equals("S", StringComparison.OrdinalIgnoreCase))
            {
                return 0;
            }

            return 1;
        }

        private static int CheckLeft(int i, int j, string[,] workingDataSet)
        {
            if (!workingDataSet[i, j - 1].Equals("M", StringComparison.OrdinalIgnoreCase))
            {
                return 0;
            }
            if (!workingDataSet[i, j - 2].Equals("A", StringComparison.OrdinalIgnoreCase))
            {
                return 0;
            }
            if (!workingDataSet[i, j - 3].Equals("S", StringComparison.OrdinalIgnoreCase))
            {
                return 0;
            }

            return 1;
        }

        private static int CheckDownLeft(int i, int j, string[,] workingDataSet)
        {
            if (!workingDataSet[i + 1, j - 1].Equals("M", StringComparison.OrdinalIgnoreCase))
            {
                return 0;
            }
            if (!workingDataSet[i + 2, j - 2].Equals("A", StringComparison.OrdinalIgnoreCase))
            {
                return 0;
            }
            if (!workingDataSet[i + 3, j - 3].Equals("S", StringComparison.OrdinalIgnoreCase))
            {
                return 0;
            }

            return 1;
        }

        private static int CheckDown(int i, int j, string[,] workingDataSet)
        {
            if (!workingDataSet[i + 1, j].Equals("M", StringComparison.OrdinalIgnoreCase))
            {
                return 0;
            }
            if (!workingDataSet[i + 2, j].Equals("A", StringComparison.OrdinalIgnoreCase))
            {
                return 0;
            }
            if (!workingDataSet[i + 3, j].Equals("S", StringComparison.OrdinalIgnoreCase))
            {
                return 0;
            }

            return 1;
        }

        private static int CheckUp(int i, int j, string[,] workingDataSet)
        {
            if (!workingDataSet[i - 1, j].Equals("M", StringComparison.OrdinalIgnoreCase))
            {
                return 0;
            }
            if (!workingDataSet[i - 2, j].Equals("A", StringComparison.OrdinalIgnoreCase))
            {
                return 0;
            }
            if (!workingDataSet[i - 3, j].Equals("S", StringComparison.OrdinalIgnoreCase))
            {
                return 0;
            }

            return 1;
        }
        private static int CheckUpRight(int i, int j, string[,] workingDataSet)
        {
            if (!workingDataSet[i - 1, j + 1].Equals("M", StringComparison.OrdinalIgnoreCase))
            {
                return 0;
            }
            if (!workingDataSet[i - 2, j + 2].Equals("A", StringComparison.OrdinalIgnoreCase))
            {
                return 0;
            }
            if (!workingDataSet[i - 3, j + 3].Equals("S", StringComparison.OrdinalIgnoreCase))
            {
                return 0;
            }

            return 1;
        }

        private static int CheckUpLeft(int i, int j, string[,] workingDataSet)
        {
            if (!workingDataSet[i - 1, j - 1].Equals("M", StringComparison.OrdinalIgnoreCase))
            {
                return 0;
            }
            if (!workingDataSet[i - 2, j - 2].Equals("A", StringComparison.OrdinalIgnoreCase))
            {
                return 0;
            }
            if (!workingDataSet[i - 3, j - 3].Equals("S", StringComparison.OrdinalIgnoreCase))
            {
                return 0;
            }

            return 1;
        }
    }
}
