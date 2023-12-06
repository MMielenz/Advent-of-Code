namespace tmp;

class Program
{
    static void Part1()
    {
        string line;
        StreamReader sr = new StreamReader("input.txt");
        line = sr.ReadLine();

        int loesung = 0;
        do
        {
            bool istZahl = false;
            int ersteZahl = 0;
            int zweiteZahl = 0;

            foreach (char c in line)
            {
                istZahl = int.TryParse(c.ToString(), out ersteZahl);
                if (istZahl)
                {
                    break;
                }
            }

            char[] inChars = line.ToCharArray();
            for (int i = inChars.Length - 1; i >= 0; i--)
            {
                istZahl = int.TryParse(inChars[i].ToString(), out zweiteZahl);
                if (istZahl)
                {
                    break;
                }
            }

            string gesamteZahlString = ersteZahl.ToString() + zweiteZahl.ToString();
            int gesamteZahl = int.Parse(gesamteZahlString);
            line = sr.ReadLine();

            loesung += gesamteZahl;
        }
        while (line != null);

        Console.WriteLine(loesung);
    }

    static void Part2()
    {
        string line;
        StreamReader sr = new StreamReader("input.txt");
        line = sr.ReadLine();

        string[] possibleNumbers = { "one",
                                     "two",
                                     "three",
                                     "four",
                                     "five",
                                     "six",
                                     "seven",
                                     "eight",
                                     "nine" };
        bool istZahl = false;
        char[] inChars = line.ToCharArray();
        int ersteZahl = 0;
        int zweiteZahl = 0;

        int loesung = 0;

        do
        {
            int ersterIndex = int.MaxValue;
            int ersteValue = 0;
            int letzterIndex = -1;
            int letzteValue = 0;
            for (int i = 0; i < possibleNumbers.Length; i++)
            {
                int zahlauftreten = line.IndexOf(possibleNumbers[i]);
                if (zahlauftreten < ersterIndex && zahlauftreten != -1)
                {
                    ersterIndex = zahlauftreten;
                    ersteValue = i + 1;
                }

                zahlauftreten = line.LastIndexOf(possibleNumbers[i]);
                if (zahlauftreten > letzterIndex && zahlauftreten != -1)
                {
                    letzterIndex = zahlauftreten;
                    letzteValue = i + 1;
                }
            }

            inChars = line.ToCharArray();
            int indexOfFirstNumber = 0;
            foreach (char c in inChars)
            {
                istZahl = int.TryParse(c.ToString(), out ersteZahl);
                if (istZahl)
                {
                    break;
                }
                indexOfFirstNumber++;
            }

            int indexOfLastNumber = 0;
            for (int i = inChars.Length - 1; i >= 0; i--)
            {
                indexOfLastNumber = i;
                istZahl = int.TryParse(inChars[i].ToString(), out zweiteZahl);
                if (istZahl)
                {
                    break;
                }
            }

            if (ersterIndex < indexOfFirstNumber && ersterIndex != -1)
            {
                ersteZahl = ersteValue;
            }


            if (letzterIndex > indexOfLastNumber && letzterIndex != -1)
            {
                zweiteZahl = letzteValue;
            }

            string gesamteZahlString = ersteZahl.ToString() + zweiteZahl.ToString();
            int gesamteZahl = int.Parse(gesamteZahlString);
            loesung += gesamteZahl;


            line = sr.ReadLine();
        }
        while (line != null);

        Console.WriteLine(loesung);
    }

    static void Main(string[] args)
    {
        Part1();
        Part2();
        Console.ReadKey();
    }
}
