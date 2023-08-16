using static Status;

class Game
{
    readonly Graphics graphs = new();
    Round round = new();
    HumanPlayer humanPlayer1 = new();
    ComputerPlayer computerPlayer1 = new();
    HumanPlayer humanPlayer2 = new();
    ComputerPlayer computerPlayer2 = new();


    byte mode;
    bool anotherRound = true;
    bool firstRound = true;

    Random random = new();

    public void InitGame(Status status)
    {
        Console.SetCursorPosition(23, Globals.ConsoleTextPosition++);
        Graphics.DelayWriting("Let's begin!\n", 20);
        while (anotherRound)
        {
            status.Init();
            Console.SetCursorPosition(23, Globals.ConsoleTextPosition++);
            if (random.NextDouble() >= 0.5)
            {
                Graphics.DelayWriting("O's go first!\n", 25);
            }
            else
            {
                Graphics.DelayWriting("X's go first!\n", 25);
                round.whoseTurn = false;
            }

            Console.SetCursorPosition(0, Globals.ConsoleBoardPosition);
            Graphics.DelayRandom(graphs.EmptyBoard(), 1);
            if (firstRound)
            {
                Console.SetCursorPosition(23, Globals.ConsoleTextPosition++);
                Graphics.DelayWriting("Choose mode: 1) PvC, 2) CvC 3) PvP ", 20);
                Console.SetCursorPosition(23, Globals.ConsoleTextPosition++);
                Graphics.DelayWriting("1) Player vs Computer, 2) Computer vs Computer 3) Player vs Player ", 20);
                string? modeTmp = Console.ReadLine();
                try
                {
                    mode = byte.Parse(modeTmp);
                }
                catch (FormatException)
                {
                    Console.SetCursorPosition(23, Globals.ConsoleTextPosition++);
                    Console.WriteLine("Wrong value!");
                }

                if (mode == 1)
                {
                    Console.SetCursorPosition(23, Globals.ConsoleTextPosition++);
                    Graphics.DelayWriting(" What's your name?  ", 20);
                    humanPlayer1.ChangeName(Console.ReadLine());
                    Console.SetCursorPosition(23, Globals.ConsoleTextPosition++);
                    Graphics.DelayWriting(" Play as X or O?  ", 20);
                    string playerChoice = Console.ReadLine();
                    playerChoice = playerChoice.ToUpper();
                    if (playerChoice == "X")
                    {
                        humanPlayer1.currentChoice = 'X';
                        computerPlayer1.currentChoice = 'O';
                        Console.SetCursorPosition(23, Globals.ConsoleTextPosition++);
                        Graphics.DelayWriting(" Great! " + humanPlayer1.name + " will play as " + humanPlayer1.currentChoice, 20);
                        Graphics.DelayWriting(" | " + computerPlayer1.name + " will play as " + computerPlayer1.currentChoice, 20);
                        round.PlayRound(status, humanPlayer1, computerPlayer1, mode);
                    }
                    if (playerChoice == "O")
                    {
                        humanPlayer1.currentChoice = 'O';
                        computerPlayer1.currentChoice = 'X';
                        Console.SetCursorPosition(23, Globals.ConsoleTextPosition++);
                        Graphics.DelayWriting(" Great! " + humanPlayer1.name + " will play as " + humanPlayer1.currentChoice, 20);
                        Graphics.DelayWriting(" | " + computerPlayer1.name + " will play as " + computerPlayer1.currentChoice, 20);
                        round.PlayRound(status, humanPlayer1, computerPlayer1, mode);
                    }
                    else if (!Globals.IsGameOver)
                    {
                        Console.SetCursorPosition(23, Globals.ConsoleTextPosition++);
                        Graphics.DelayWriting(" Incorrect choice...\n", 15);
                        Globals.ConsoleTextPosition++;
                    }
                }
                else if (mode == 2)
                {
                    computerPlayer1.currentChoice = 'X';
                    computerPlayer2.currentChoice = 'O';
                    computerPlayer1.PickAName();
                    computerPlayer2.PickAName();
                    Console.SetCursorPosition(23, Globals.ConsoleTextPosition++);
                    Graphics.DelayWriting(computerPlayer1.name + " will play as " + computerPlayer1.currentChoice, 20);
                    Console.SetCursorPosition(23, Globals.ConsoleTextPosition++);
                    Graphics.DelayWriting(computerPlayer2.name + " will play as " + computerPlayer2.currentChoice, 20);
                    Console.SetCursorPosition(23, Globals.ConsoleTextPosition++);
                    Graphics.DelayWriting(" Enjoy the show!  ", 20);
                    round.PlayRound(status, computerPlayer1, computerPlayer2, mode);
                }


                else if (mode == 3)
                {
                    Console.SetCursorPosition(23, Globals.ConsoleTextPosition++);
                    Graphics.DelayWriting(" What's first player name?  ", 20);
                    humanPlayer1.ChangeName(Console.ReadLine());
                    Console.SetCursorPosition(23, Globals.ConsoleTextPosition++);
                    Graphics.DelayWriting(" What's second player name?  ", 20);
                    humanPlayer2.ChangeName(Console.ReadLine());
                    Console.SetCursorPosition(23, Globals.ConsoleTextPosition++);
                    Graphics.DelayWriting(" First player will as X or O?  ", 20);
                    string playerChoice = Console.ReadLine();
                    playerChoice = playerChoice.ToUpper();
                    if (playerChoice == "X")
                    {
                        humanPlayer1.currentChoice = 'X';
                        humanPlayer2.currentChoice = 'O';
                        Console.SetCursorPosition(23, Globals.ConsoleTextPosition++);
                        Graphics.DelayWriting(" Great! " + humanPlayer1.name + " will play as " + humanPlayer1.currentChoice, 20);
                        Graphics.DelayWriting(" | Computer " + humanPlayer2.name + " will play as " + humanPlayer2.currentChoice, 20);
                        round.PlayRound(status, humanPlayer1, humanPlayer2, mode);
                    }
                    if (playerChoice == "O")
                    {
                        humanPlayer1.currentChoice = 'O';
                        humanPlayer2.currentChoice = 'X';
                        Console.SetCursorPosition(23, Globals.ConsoleTextPosition++);
                        Graphics.DelayWriting(" Great! " + humanPlayer1.name + " will play as " + humanPlayer1.currentChoice, 20);
                        Graphics.DelayWriting(" | Computer " + humanPlayer2.name + " will play as " + humanPlayer2.currentChoice, 20);
                        round.PlayRound(status, humanPlayer1, humanPlayer2, mode);
                    }
                    else if (!Globals.IsGameOver)
                    {
                        Console.SetCursorPosition(23, Globals.ConsoleTextPosition++);
                        Graphics.DelayWriting(" Incorrect choice...\n", 15);
                        Globals.ConsoleTextPosition++;
                    }
                }
                else
                {
                    Console.SetCursorPosition(23, Globals.ConsoleTextPosition++);
                    Console.WriteLine("Nonexisting choice!");
                    break;
                }
            }
            else
            {
                if (mode == 1)
                {
                    round.PlayRound(status, humanPlayer1, computerPlayer1, mode);
                }
                if (mode == 2)
                {
                    round.PlayRound(status, computerPlayer1, computerPlayer2, mode);
                }
                if (mode == 3)
                {
                    round.PlayRound(status, humanPlayer1, humanPlayer2, mode);
                }
            }
            Console.SetCursorPosition(23, Globals.ConsoleTextPosition++);
            Console.WriteLine("Play another round? (Y/N)");
            string choice = Console.ReadLine();
            choice = choice.ToUpper();
            if (choice == "N")
            {
                anotherRound = false;
            }
            firstRound = false;
            Globals.IsGameOver = false;
            Globals.ConsoleBoardPosition += Globals.ConsoleTextPosition / Globals.RoundsPlayed;
            Globals.ConsoleTextPosition = Globals.ConsoleBoardPosition;
        }

    }
}

