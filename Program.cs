namespace aoc;

class Program
{
    static void Part1()
    {
        StreamReader sr = new StreamReader("input.txt");
        string line = sr.ReadLine();

        List<char[]> engine = new List<char[]>();

        List<int> symbolX = new List<int>();
        List<int> symbolY = new List<int>();

        List<int> numbers = new List<int>();
        List<int> numberX = new List<int>();
        List<int> numberY = new List<int>();

        bool isNumber = false;
        int tmp = 0;
        int sum = 0;

        do
        {
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
                    symbolX.Add(i);
                    symbolY.Add(j);
                }

                if (isNumber)
                {
                    numbers.Add(tmp);
                    numberX.Add(j);
                    numberY.Add(i);
                }
            }
        }

        bool thereIsASymbol = false;
        bool addNumber = false;
        string numberBuild = "";

        for (int i = 0; i < numbers.Count(); i++)
        {
            CheckForASymbol(numberX, numberY, symbolX, symbolY, i, ref thereIsASymbol);
            if (thereIsASymbol)
            {
                // Console.WriteLine("true");
                addNumber = true;
            }

            if (i < numbers.Count() - 1 && numberX[i + 1] == numberX[i] + 1)
            {
                numberBuild = numberBuild + numbers[i].ToString();
            }
            else
            {
                numberBuild = numberBuild + numbers[i].ToString();
                if (addNumber)
                {
                    sum += int.Parse(numberBuild);
                    // Console.WriteLine(numberBuild);
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
        Console.WriteLine(sum);
    }


    


    static void Part2()
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
        int tmp = 0;
        int sum = 0;

        do
        {
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

                if (!isNumber && engine[i][j] == '*')
                {
                    symbolX.Add(i);
                    symbolY.Add(j);
                }

                if (isNumber)
                {
                    numbers.Add(tmp);
                    numberX.Add(j);
                    numberY.Add(i);
                }
            }
        }

        bool thereIsASymbol = false;
        bool addNumber = false;
        string numberBuild = "";

        for (int i = 0; i < numbers.Count(); i++)
        {
            CheckForASymbol(numberX, numberY, symbolX, symbolY, i, ref thereIsASymbol);
            if (thereIsASymbol)
            {
                // Console.WriteLine("true");
                addNumber = true;
            }

            if (i < numbers.Count() - 1 && numberX[i + 1] == numberX[i] + 1)
            {
                numberBuild = numberBuild + numbers[i].ToString();
            }
            else
            {
                numberBuild = numberBuild + numbers[i].ToString();
                if (addNumber)
                {
                    sum += int.Parse(numberBuild);
                    // Console.WriteLine(numberBuild);
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
        Console.WriteLine(sum);
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
                if (numberX[i] - 1 == symbolX[k] && numberY[i] == symbolY[k] || numberX[i] + 1 == symbolX[k] && numberY[i] == symbolY[k])
                {
                    thereIsASymbol = true;
                    break;
                }
            }
        }
    }


    static void Main(string[] args)
    {
        // Part1();
        Part2();

        Console.ReadKey();
    }
}
