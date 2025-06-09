

namespace AdventOfCode
{
    internal class _2024_1_HistorianHysteria
    {
        internal static int Execute()
        {
            var input = File.ReadAllLines("2024Inputs/2024Problem1.txt");

            var list1 = new List<int>();
            var list2 = new List<int>();

            foreach (var line in input)
            {
                if(line == null)
                {
                    continue;
                }
                var splitLine = line.Split(' ');
                list1.Add(Int32.Parse(splitLine[0]));
                list2.Add(Int32.Parse(splitLine[3]));
            }

            list1.Sort();
            list2.Sort();

            int sum = 0;

            for (int i = 0; i<list1.Count; i++)
            {
                var temp = list1[i]-list2[i];
                sum += Math.Abs(temp);
            }


            return sum;
        }

        internal static int ExecutePt2()
        {

            var input = File.ReadAllLines("2024Inputs/2024Problem1.txt");

            var list1 = new List<int>();
            //Key is number "value" value is count
            var dict = new Dictionary<int, int>();

            foreach (var line in input)
            {
                if (line == null)
                {
                    continue;
                }
                var splitLine = line.Split(' ');
                list1.Add(Int32.Parse(splitLine[0]));

                dict.TryGetValue(Int32.Parse(splitLine[3]), out int value);

                if (value == 0)
                {
                    dict.Add(Int32.Parse(splitLine[3]), 1);
                }
                else
                {
                    dict[Int32.Parse(splitLine[3])]++;
                }
            }

            int sum = 0;


            for (int i = 0; i < list1.Count; i++)
            {
                var key = list1[i];

                if (dict.ContainsKey(key))
                {
                    sum += (key * dict[key]);
                }
            }

            return sum;
        }
    }
}
