namespace Tag3;

using System.Diagnostics.Contracts;
using System.IO;

public class Program
{
    static void Part1()
    {
        char[] value = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        string line;
        char commonLetter = 'a';
        int letterValue = 0;
        int sum = 0;

        //Pass the file path and file name to the StreamReader constructor
        StreamReader sr = new StreamReader("input.txt");
        // Read the first line of text
        line = sr.ReadLine();

        //Continue to read until you reach end of file
        while (line != null)
        {
            GettingCommonLetter(line, ref commonLetter);
            GiveValue(commonLetter, value, ref letterValue);
            sum = sum + letterValue;

            //Read the next line
            line = sr.ReadLine();
        }

        Console.WriteLine($"Part 1: {sum}");
    }


    static void Part2()
    {
        char[] value = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        string line1;
        string line2;
        string line3;
        char commonLetter = 'a';
        int letterValue = 0;
        int sum = 0;

        StreamReader sr = new StreamReader("input.txt");
        line1 = sr.ReadLine();
        line2 = sr.ReadLine();
        line3 = sr.ReadLine();

        while (line1 != null)
        {
            foreach (char c in line1)
            {
                foreach (char d in line2)
                {
                    foreach (char e in line3)
                    {
                        if (c == d && c == e)
                        {
                            commonLetter = c;
                        }
                    }
                }
            }
            GiveValue(commonLetter, value, ref letterValue);

            line1 = sr.ReadLine();
            line2 = sr.ReadLine();
            line3 = sr.ReadLine();

            sum = sum + letterValue;
        }
        Console.WriteLine($"Part 2: {sum});
    }



    static void Main(string[] args)
    {
        Part1();
        Part2();
        Console.ReadKey();
    }



    static void GettingCommonLetter(string line, ref char commonLetter)
    {
        int stringHalf = line.Length / 2;

        string firstCompartment = line.Substring(0, stringHalf);
        string secondCompartment = line.Substring(stringHalf);

        commonLetter = 'a';

        foreach (char c in firstCompartment)
        {
            foreach (char d in secondCompartment)
            {
                if (c == d)
                {
                    commonLetter = c;
                }
            }
        }
    }


    static void GiveValue(char commonLetter, char[] value, ref int letterValue)
    {
        int i = 0;
        bool finished = false;
        do
        {
            if (commonLetter == value[i])
            {
                letterValue = i + 1;
                finished = true;
            }
            i++;
        }
        while (!finished);
    }
}
