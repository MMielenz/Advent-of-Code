namespace Tag4;

using System.IO;

class Program
{
    static void Part1()
    {
        string line;
        int pair1start;
        int pair1end;
        int pair2start;
        int pair2end;

        int countOfDoubleSectors = 0;

        StreamReader sr = new StreamReader("input.txt");

        line = sr.ReadLine();

        while (line != null)
        {
            string[] pairs = line.Split(',');
            string[] pair1 = pairs[0].Split('-');
            string[] pair2 = pairs[1].Split('-');

            pair1start = int.Parse(pair1[0]);
            pair1end = int.Parse(pair1[1]);
            pair2start = int.Parse(pair2[0]);
            pair2end = int.Parse(pair2[1]);

            if (pair1start <= pair2start && pair1end >= pair2end || pair1start >= pair2start && pair1end <= pair2end)
            {
                countOfDoubleSectors++;
            }
            
            line = sr.ReadLine();
        }
        Console.WriteLine($"Part 1: {countOfDoubleSectors}");
    }


    static void Part2()
    {
        string line;
        int pair1start;
        int pair1end;
        int pair2start;
        int pair2end;

        int countOfOverlapingSectors = 0;

        StreamReader sr = new StreamReader("input.txt");

        line = sr.ReadLine();

        while (line != null)
        {
            string[] pairs = line.Split(',');
            string[] pair1 = pairs[0].Split('-');
            string[] pair2 = pairs[1].Split('-');

            pair1start = int.Parse(pair1[0]);
            pair1end = int.Parse(pair1[1]);
            pair2start = int.Parse(pair2[0]);
            pair2end = int.Parse(pair2[1]);

            if (pair1start >= pair2start && pair1start <= pair2end || pair2start >= pair1start && pair2start <= pair1end)
            {
                countOfOverlapingSectors++;
            }
            
            line = sr.ReadLine();
        }
        Console.WriteLine($"Part 2: {countOfOverlapingSectors}");
    }


    static void Main(string[] args)
    {
        Part1();
        Part2();
        Console.ReadKey();
    }
}
