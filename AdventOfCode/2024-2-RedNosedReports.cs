

namespace AdventOfCode
{
    internal class _2024_2_RedNosedReports
    {
        internal static int Execute()
        {
            var input = File.ReadAllLines("2024Inputs/2024Problem2.txt");
            var count = 0;

            //The levels are either all increasing or all decreasing.
            //Any two adjacent levels differ by at least one and at most three.

            foreach (var line in input)
            {
                var valid = true;

                if (line == null)
                {
                    continue;
                }
                var splitLine = line.Split(' ').Select(Int32.Parse).ToArray();

                //Pre-check ascending vs descending
                if(splitLine[0] > splitLine[1])
                {
                    valid = CheckAscending(splitLine);
                }
                else if (splitLine[0] < splitLine[1])
                {
                    valid = CheckDescending(splitLine);
                }
                else
                {
                    continue;
                }

                if (valid)
                {
                    count++;
                }


            }

            return count;
        }

        

        internal static int ExecutePt2()
        {

            var input = File.ReadAllLines("2024Inputs/2024Problem2.txt");
            var count = 0;


            foreach (var line in input)
            {
                var descendingValid = true;
                var ascendingValid = true;
                var descendingInvalidCounter = 0;
                var ascendingInvalidCounter = 0;

                if (line == null)
                {
                    continue;
                }
                var splitLine = line.Split(' ').Select(Int32.Parse).ToList();


                var skipIndex = 0;

                var valid = CheckAscending(splitLine.ToArray());

                if (!valid)
                {
                    valid = CheckDescending(splitLine.ToArray());
                }

                if (!valid)
                {
                    for (int i = 0; i < splitLine.Count; i++)
                    {

                        List<int> shortenedsplitLine = new List<int>();
                        
                        for(int j= 0;  j < splitLine.Count; j++)
                        {
                            if(j!=i)
                            {
                                shortenedsplitLine.Add(splitLine[j]);
                            }
                        }
                        

                        valid = CheckAscending(shortenedsplitLine.ToArray());

                        if (valid)
                        {
                            break;
                        }
                        else
                        {
                            valid = CheckDescending(shortenedsplitLine.ToArray());
                            if (valid)
                            {
                                break;
                            }
                        }
                    }
                }

                Console.WriteLine(line + " " + valid);

                if (valid)
                {
                    count++;
                }
            }

            return count;
        }

        private static bool CheckDescending(int[] splitLine)
        {
            for (int i = 0; i < splitLine.Length - 1; i++)
            {
                var current = splitLine[i];
                var next = splitLine[i + 1];

                var diff = next - current;
                if (current < next && diff <= 3)
                {
                    continue;
                }
                else
                {
                    return false;
                }

            }

            return true;
        }

        private static bool CheckAscending(int[] splitLine)
        {
            for (int i = 0; i < splitLine.Length - 1; i++)
            {
                var current = splitLine[i];
                var next = splitLine[i + 1];

                var diff = current - next;
                if (current > next && diff <= 3)
                {
                    continue;
                }
                else
                {
                    return false;
                }

            }

            return true;
        }
    }
}
