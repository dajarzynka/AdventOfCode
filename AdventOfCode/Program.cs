// See https://aka.ms/new-console-template for more information
using AdventOfCode;
using System.Numerics;

Console.WriteLine("Advent of code fun!");
Console.WriteLine("Which problem would you like to run?");
Console.WriteLine("1. Historian Hysteria");
Console.WriteLine("2. Red Nosed Reports");
Console.WriteLine("3. Mull It Over");
Console.WriteLine("4. Ceres Search");
var keyInput = Console.ReadLine();

BigInteger result;
switch (keyInput)
{
    case "1":
        result = _2024_1_HistorianHysteria.Execute();
        Console.WriteLine("Part 1: " + result);
        result = _2024_1_HistorianHysteria.ExecutePt2();
        Console.WriteLine("Part 2: " + result);
        break;
    case "2":
        result = _2024_2_RedNosedReports.Execute();
        Console.WriteLine("Part 1: " + result);
        result = _2024_2_RedNosedReports.ExecutePt2();
        Console.WriteLine("Part 2: " + result);
        break;
    case "3":
        result = _2024_3_Mullitover.Execute();
        Console.WriteLine("Part 1: " + result);
        result = _2024_3_Mullitover.ExecutePt2();
        Console.WriteLine("Part 2: " + result);
        break;
    case "4":
        result = _2024_4_CeresSearch.Execute();
        Console.WriteLine("Part 1: " + result);
        result = _2024_4_CeresSearch.ExecutePt2();
        Console.WriteLine("Part 2: " + result);
        break;
    default:
        result = 0;
        break;
}

Console.WriteLine(result);
