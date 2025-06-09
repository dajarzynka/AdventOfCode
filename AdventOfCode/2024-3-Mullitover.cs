

using System.Numerics;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    internal class _2024_3_Mullitover
    {
        internal static BigInteger Execute()
        {
            var input = File.ReadAllText("2024Inputs/2024Problem3.txt");
            BigInteger result = 0;

            //I don't like Regex, but it seems to be the right tool for the job.
            //Don't forget what brought blue screened critical infrastructure in 2024
            //https://youtu.be/JgKbe5tcgZ0?si=-sQNoRoGZiUj1etS
            var matches = Regex.Matches(input, @"mul\(\s*(-?\d+(?:\.\d+)?)\s*,\s*(-?\d+(?:\.\d+)?)\s*\)");

            foreach (Match match in matches)
            {
                var num1 = BigInteger.Parse(match.Groups[1].Value);
                var num2 = BigInteger.Parse(match.Groups[2].Value);

                result += (num1 * num2);
            }

            return result;
        }



        internal static BigInteger ExecutePt2()
        {

            var input = File.ReadAllText("2024Inputs/2024Problem3.txt");

            var splitInput = input.Split(new[] { "do()", "don't()" }, StringSplitOptions.None);

            BigInteger result = 0;
            //I don't like Regex, but it seems to be the right tool for the job.
            //Don't forget what brought blue screened critical infrastructure in 2024
            //https://youtu.be/JgKbe5tcgZ0?si=-sQNoRoGZiUj1etS
            var doDontBlocks = Regex.Matches(input, @"do\(\)|don't\(\)");

            var matches = Regex.Matches(input, @"mul\(\s*(-?\d+(?:\.\d+)?)\s*,\s*(-?\d+(?:\.\d+)?)\s*\)");

            var doBlockIndexes = new List<DoBlockIndexes>();

            bool capture = true;
            int doBlockStartIndex = 0;

            foreach (Match block in doDontBlocks)
            {
                //This can work because we know we start with a capture block
                if (!capture && doBlockStartIndex == 0 && block.Groups[0].ToString().StartsWith("do()"))
                {
                    doBlockStartIndex = block.Index;
                    capture = true;
                }

                if (capture)
                {
                    if (block.Groups[0].ToString().StartsWith("don't()"))
                    {
                        doBlockIndexes.Add(new DoBlockIndexes { startIndex = doBlockStartIndex, 
                                                                endIndex = block.Index });
                        doBlockStartIndex = 0;
                        capture = false;
                    }
                }               
            }

            //Irrelevant. My data set ends with dont blocks
            if(capture)
            {
                doBlockIndexes.Add(new DoBlockIndexes {  startIndex=doBlockStartIndex,
                                                            endIndex=int.MaxValue });                          
            }

            var currentDoGroup = doBlockIndexes.First();
            var nextGroupIndex = 1;

            foreach (Match match in matches)
            {
                if(match.Index > currentDoGroup.endIndex)
                {
                    if(nextGroupIndex < doBlockIndexes.Count)
                    {
                        currentDoGroup = doBlockIndexes[nextGroupIndex];
                        nextGroupIndex++;
                    }
                    else
                    {
                        continue;
                    }
                    
                }

                if(match.Index < currentDoGroup.startIndex)
                {
                    continue;
                }
                

                var num1 = BigInteger.Parse(match.Groups[1].Value);
                var num2 = BigInteger.Parse(match.Groups[2].Value);

                result += (num1 * num2);
            }
            //98930154 too high
            return result;
        }

        internal class DoBlockIndexes()
        {
            internal int startIndex { get; set; }
            internal int endIndex { get; set; }
        }
    }
}
