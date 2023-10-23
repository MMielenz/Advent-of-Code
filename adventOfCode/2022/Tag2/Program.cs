namespace Tag2;

using System.IO;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Part1()
    {
        string[] inputValue = { "X", "Y", "Z" };

        string line;

        string opponentsMove = "";
        string yourMove = "";
        int yourMovesValue = 0;

        int GameOutcomeScore = 0;
        int endscore = 0;


        StreamReader sr = new StreamReader("input.txt");


        line = sr.ReadLine();

        while (line != null)
        {
            opponentsMove = line.Substring(0, 1);
            yourMove = line.Substring(2);

            GiveYourInputValue(yourMove, inputValue, ref yourMovesValue);
            CheckingWhoWins(yourMovesValue, opponentsMove, ref GameOutcomeScore);

            GameOutcomeScore = GameOutcomeScore + yourMovesValue;

            endscore = endscore + GameOutcomeScore;

            line = sr.ReadLine();
        }

        Console.WriteLine($"Total score of Part 1: {endscore}");
    }


    static void Part2()
    {
        string line;

        string[] inputValue = { "X", "Y", "Z" };

        string opponentsMove;
        string yourMove = "";

        int yourMovesValue = 0;

        string GameOutcome = "";
        int GameOutcomeScore = 0;
        int endscore = 0;


        StreamReader sr = new StreamReader("input.txt");


        line = sr.ReadLine();


        while (line != null)
        {
            opponentsMove = line.Substring(0, 1);
            GameOutcome = line.Substring(2);

            WhatToPick(GameOutcome, opponentsMove, ref yourMove);
            GiveYourInputValue(yourMove, inputValue, ref yourMovesValue);

            CheckingWhoWins(yourMovesValue, opponentsMove, ref GameOutcomeScore);

            GameOutcomeScore = GameOutcomeScore + yourMovesValue;

            endscore = endscore + GameOutcomeScore;

            line = sr.ReadLine();
        }

        Console.WriteLine($"Total score of Part 2: {endscore}");
    }


    static void Main(string[] args)
    {
        Part1();
        Part2();
        Console.ReadKey();
    }



    static void GiveYourInputValue(string yourMove, string[] inputValue, ref int yourMovesValue)
    {
        int x = 0;
        bool finished = false;

        do
        {
            if (yourMove == inputValue[x])
            {
                yourMovesValue = x + 1;
                finished = true;
            }
            x++;
        }
        while (!finished);
    }


    static void CheckingWhoWins(int yourMovesValue, string opponentsMove, ref int GameOutcome)
    {
        switch (yourMovesValue)
        {
            case 1:
                if (opponentsMove == "A")   // A = Rock
                {
                    GameOutcome = 3;
                }
                if (opponentsMove == "B")   // B = Paper
                {
                    GameOutcome = 0;
                }
                if (opponentsMove == "C")   // C = Scissors
                {
                    GameOutcome = 6;
                }
                break;
            case 2:
                if (opponentsMove == "A")
                {
                    GameOutcome = 6;
                }
                if (opponentsMove == "B")
                {
                    GameOutcome = 3;
                }
                if (opponentsMove == "C")
                {
                    GameOutcome = 0;
                }
                break;
            case 3:
                if (opponentsMove == "A")
                {
                    GameOutcome = 0;
                }
                if (opponentsMove == "B")
                {
                    GameOutcome = 6;
                }
                if (opponentsMove == "C")
                {
                    GameOutcome = 3;
                }
                break;
        }
    }


    static void WhatToPick(string GameOutcome, string opponentsMove, ref string yourMove)
    {
        switch (GameOutcome)
        {
            // "X" means you need to lose
            case "X":
                switch (opponentsMove)
                {
                    case "A":
                        yourMove = "Z";
                        break;
                    case "B":
                        yourMove = "X";
                        break;
                    case "C":
                        yourMove = "Y";
                        break;
                }
                break;
            // "Y" means you need a draw
            case "Y":
                switch (opponentsMove)
                {
                    case "A":
                        yourMove = "X";
                        break;
                    case "B":
                        yourMove = "Y";
                        break;
                    case "C":
                        yourMove = "Z";
                        break;
                }
                break;
            // "Z" you need to win
            case "Z":
                switch (opponentsMove)
                {
                    case "A":
                        yourMove = "Y";
                        break;
                    case "B":
                        yourMove = "Z";
                        break;
                    case "C":
                        yourMove = "X";
                        break;
                }
                break;
        }
    }
}
