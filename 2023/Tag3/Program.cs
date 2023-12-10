namespace aoc;
using System.Text.RegularExpressions;

class Program
{
    static void Part1()
    {
        StreamReader sr = new StreamReader("sample.txt");
        string line = sr.ReadLine();

        List<char[]> engine = new List<char[]>();

        List<int> symbolX = new List<int>();
        List<int> symbolY = new List<int>();

        List<int> numbers = new List<int>();
        List<int> numberX = new List<int>();
        List<int> numberY = new List<int>();

        bool isNumber = false;
        string pattern = @"(\d+)";
        int tmp = 0;
        int number = 0;
        int sum = 0;

        do
        {
            // MatchCollection matches = Regex.Matches(line, pattern);
            // for (int i = 0; i < matches.Count(); i++)
            // {
            //     alleZahlen += int.Parse(matches[i].Value);
            // }

            engine.Add(line.ToCharArray());
            line = sr.ReadLine();
        }
        while (line != null);



        // gets the coordinates for the numbers and symbols
        for (int i = 0; i < engine.Count; i++)
        {
            for (int j = 0; j < engine[i].Count(); j++)
            {
                isNumber = int.TryParse(engine[i][j].ToString(), out tmp);

                if (!isNumber && engine[i][j] != '.')
                {
                    symbolX.Add(j);
                    symbolY.Add(i);
                }

                if (isNumber)
                {
                    numbers.Add(tmp);
                    numberX.Add(j);
                    numberY.Add(i);
                }
            }
        }

        // for (int i = 0; i < numbers.Count; i++)
        // {
        //     Console.WriteLine($"{numbers[i]}: {numberX[i]}  {numberY[i]}");
        // }


        bool thereIsASymbol = false;
        bool addNumber = false;
        string numberBuild = "";


        for (int i = 0; i < numbers.Count() - 1; i++)
        {

            CheckForASymbol(numberX, numberY, symbolX, symbolY, i, ref thereIsASymbol);
            if (thereIsASymbol)
            {
                addNumber = true;
            }


            if (numberX[i + 1] == numberX[i] + 1)
            {
                numberBuild = numberBuild + numbers[i].ToString();
            }
            else
            {
                if (addNumber)
                {
                    sum += int.Parse(numberBuild);
                    numberBuild = "";
                    addNumber = false;
                }
                else
                {
                    numberBuild = "";
                    addNumber = false;
                }
            }


        }


        static void CheckForASymbol(List<int> numberX, List<int> numberY, List<int> symbolY, List<int> symbolX, int i, ref bool thereIsASymbol)
        {
            thereIsASymbol = false;
            for (int j = -1; j <= 1; j++)
            {
                for (int k = 0; k < symbolX.Count(); k++)
                {
                    if (numberY[i] - 1 == symbolY[k] && numberX[i] + j == symbolX[k] || numberY[i] + 1 == symbolY[k] && numberX[i] + j == symbolX[k])
                    {
                        thereIsASymbol = true;
                        break;
                    }
                    if (numberX[i] - 1 == symbolX[k] || numberX[i] + 1 == symbolX[k])
                    {
                        thereIsASymbol = true;
                    }
                }

            }

        }



        // // for every line
        // int row;
        // for (row = 0; row < engine.Count; row++)
        // {
        //     line = engine[row].ToString();
        //     MatchCollection matches = Regex.Matches(line, pattern);

        //     // for every number
        //     int number;
        //     for (number = 0; number < matches.Count(); number++)
        //     {
        //         // for every digit
        //         for (int k = 0; k < matches[j].Length; k++)
        //         {

        //         }
        //     }


        // }



        Console.WriteLine(sum);


        // static void CheckForASymbol()
        // {
        //     for (int x = numberX[number] - 1; i <= numberX + 1; i++)
        //     {
        //         if (i >= 0 && i <= engine[1].Counnt - 2 && row - 1 >= 0)
        //         {
        //             engine[row - 1][i]
        //         }
        //     }
        // }




        // for (int i = 0; i < symbolX.Count(); i++)
        // {
        //     for (int j = symbolX[i] - 1; j <= symbolX[i] + 1; j++)
        //     {
        //         do
        //         {
        //             istZahl = int.TryParse(engine[symbolY[i]-1][j].ToString(), out tmp);
        //         } while (istZahl);


        //         Console.WriteLine(tmp);
        //     }
        // }



        // for (int i = 0; i < symbolX.Count(); i++)
        // {
        //     Console.Write(symbolX[i]);
        //     Console.WriteLine(symbolY[i]);
        // }

    }
    static void Main(string[] args)
    {
        Part1();
        Console.ReadKey();
    }
}
