namespace Tag2;
using System.Text.RegularExpressions;


class Program
{
    static void Part1()
    {
        StreamReader sr = new StreamReader("input.txt");
        string line = sr.ReadLine();

        string pattern = @"(\d+)";
        int maxRedCubes = 12;
        int maxGreenCubes = 13;
        int maxBlueCubes = 14;

        int gameId = 0;
        int sumIds = 0;
        do
        {
            List<int> red = new List<int>();
            List<int> green = new List<int>();
            List<int> blue = new List<int>();

            ExtractInformations(line, pattern, ref gameId, ref red, ref green, ref blue);

            if (red.Max() <= maxRedCubes && green.Max() <= maxGreenCubes && blue.Max() <= maxBlueCubes)
            {
                sumIds += gameId;
            }

            line = sr.ReadLine();
        }
        while (line != null);

        Console.WriteLine($"Solution Part 1: {sumIds}");
    }

    static void Part2()
    {
        StreamReader sr = new StreamReader("input.txt");
        string line = sr.ReadLine();
        
        string pattern = @"(\d+)";
        int gameId = 0;
        int sumPower = 0;

        do
        {
            List<int> red = new List<int>();
            List<int> green = new List<int>();
            List<int> blue = new List<int>();

            ExtractInformations(line, pattern, ref gameId, ref red, ref green, ref blue);

            sumPower += red.Max() * green.Max() * blue.Max();

            line = sr.ReadLine();
        }
        while (line != null);

        Console.WriteLine($"Solution Part 2: {sumPower}");
    }

    static void ExtractInformations(string line, string pattern, ref int gameId, ref List<int> red, ref List<int> green, ref List<int> blue)
    {
        MatchCollection matches = Regex.Matches(line, pattern);

        gameId = int.Parse(matches[0].Value);
        line = line.Substring(8);

        string[] rounds = line.Split(';');

        foreach (string round in rounds)
        {
            string[] cubes = round.Split(",");
            foreach (string cubeInformations in cubes)
            {
                string information = cubeInformations;
                if (information.First() == ' ')
                {
                    information = information.Substring(1);
                }
                string[] informations = information.Split(" ");
                switch (informations[1])
                {
                    case "red":
                        red.Add(int.Parse(informations[0]));
                        break;
                    case "green":
                        green.Add(int.Parse(informations[0]));
                        break;
                    case "blue":
                        blue.Add(int.Parse(informations[0]));
                        break;
                }
            }
        }
    }

    static void Main(string[] args)
    {
        Part1();
        Part2();
        Console.ReadKey();
    }
}
