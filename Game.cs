class Game
{
    readonly Graphics graphs = new();
    readonly Status status = new();
    readonly HumanPlayer player1 = new();
    // TODO: PvP
    readonly HumanPlayer player2 = new();
    readonly ComputerPlayer computer1 = new();
    readonly ComputerPlayer computer2 = new();

    byte mode;

    public int consoleTextPosition = 6;
    // TODO: next game below 
    public int consoleBoardPosiotion = 6;
    Random rnd = new();

    public void InitGame()
    {
        while (true)
        {
            status.Init();
            Graphics.DelayWriting("  Let's begin!\n", 20);
            Graphics.DelayWriting("  O's go first!\n", 25);
            Console.SetCursorPosition(0, 6);
            Graphics.DelayRandom(graphs.EmptyBoard(), 1);
            Console.SetCursorPosition(23, consoleTextPosition++);
            Graphics.DelayWriting("  Choose mode: 1) PvC, 2) CvC ", 20);
            string? modeTmp = Console.ReadLine();
            try
            {
                mode = byte.Parse(modeTmp);
            }
            catch (FormatException)
            {
                Console.SetCursorPosition(23, consoleTextPosition++);
                Console.WriteLine("Wrong value!");
            }

            if (mode == 1)
            {
                Console.SetCursorPosition(23, consoleTextPosition++);
                Graphics.DelayWriting(" What's your name?  ", 20);
                player1.ChangeName(Console.ReadLine());
                Console.SetCursorPosition(23, consoleTextPosition++);
                Graphics.DelayWriting(" Play as X or O?  ", 20);
                string playerChoice = Console.ReadLine();
                if (playerChoice == "X" || playerChoice == "x")
                {
                    player1.currentChoice = 'X';
                    Console.SetCursorPosition(23, consoleTextPosition++);
                    Graphics.DelayWriting(" Great! " + player1.name + " will play as 'X'", 20);
                    break;
                }
                if (playerChoice == "O" || playerChoice == "o")
                {
                    player1.currentChoice = 'O';
                    computer1.currentChoice = 'X';
                    Console.SetCursorPosition(23, consoleTextPosition++);
                    Graphics.DelayWriting(" Great! " + player1.name + " will play as 'O'", 20);
                    break;
                }
                else
                {
                    Console.SetCursorPosition(23, consoleTextPosition++);
                    Graphics.DelayWriting(" Incorrect choice...\n", 15);
                    consoleTextPosition++;
                }
            }
            else if (mode == 2)
            {
                // TODO computers names - might require changes in turn logic
                computer2.currentChoice = 'X';
                Console.SetCursorPosition(23, consoleTextPosition++);
                Graphics.DelayWriting(" Enjoy the show!  ", 20);
                break;
            }
            else
            {
                Console.SetCursorPosition(23, consoleTextPosition++);
                Console.WriteLine("Nonexisting choice!");
            }
        }
        StartGame();
    }

    public void StartGame()
    {
        if (mode == 1)
        {
            if (player1.currentChoice == 'O')
            {
                PlayerMove(status.gameStatus);
            }
            else
            {
                ComputerMove(status.gameStatus, false);
            }
        }
        else if (mode == 2)
        {
            ComputerMove(status.gameStatus, false);
        }

    }

    public void ComputerMove(char[] gameStatus, bool isXTurn)
    {
        if (status.isGameOver)
        {
            status.GameFinished();
            return;
        }

        if (!status.isGameOver)
        {
            Console.SetCursorPosition(23, consoleTextPosition++);
            List<int> emptyFields = new List<int>();
            for (int i = 0; i < gameStatus.Length; i++)
            {
                if (gameStatus[i] == '-')
                {
                    emptyFields.Add(i);
                }
            };
            if (emptyFields.Count == 0)
            {
                GameOver();
                return;
            }
            else
            {
                Graphics.DelayWriting(" Computer is thinking", 5);
                Graphics.DelayWriting("...", 200);
                if (isXTurn)
                {
                    status.gameStatus[emptyFields.ElementAt(rnd.Next(0, emptyFields.Count))] = 'X';
                }
                else
                {
                    status.gameStatus[emptyFields.ElementAt(rnd.Next(0, emptyFields.Count))] = 'O';
                }

                Console.SetCursorPosition(0, 6);
                Console.WriteLine(graphs.PrintBoard(status.gameStatus));
                CheckForWinner(status.gameStatus);
                if (mode == 1)
                {
                    PlayerMove(status.gameStatus);
                }
                else ComputerMove(status.gameStatus, !isXTurn);
            }
        }
    }


    public void PlayerMove(char[] gameStatus)
    {
        if (status.isGameOver)
        {
            status.GameFinished();
            return;
        }

        if (!status.isGameOver)
        {
            while (true)
            {
                Console.SetCursorPosition(23, consoleTextPosition++);
                Graphics.DelayWriting(" Your turn! Choose (e.g. A1 or C3):", 25);
                string? move = Console.ReadLine();
                move = move?.ToUpper();

                if (gameStatus[0] == '-' && move == "A1") { status.gameStatus[0] = player1.currentChoice; break; }
                if (gameStatus[1] == '-' && move == "B1") { status.gameStatus[1] = player1.currentChoice; break; }
                if (gameStatus[2] == '-' && move == "C1") { status.gameStatus[2] = player1.currentChoice; break; }
                if (gameStatus[3] == '-' && move == "A2") { status.gameStatus[3] = player1.currentChoice; break; }
                if (gameStatus[4] == '-' && move == "B2") { status.gameStatus[4] = player1.currentChoice; break; }
                if (gameStatus[5] == '-' && move == "C2") { status.gameStatus[5] = player1.currentChoice; break; }
                if (gameStatus[6] == '-' && move == "A3") { status.gameStatus[6] = player1.currentChoice; break; }
                if (gameStatus[7] == '-' && move == "B3") { status.gameStatus[7] = player1.currentChoice; break; }
                if (gameStatus[8] == '-' && move == "C3") { status.gameStatus[8] = player1.currentChoice; break; }
                else
                {
                    Console.SetCursorPosition(23, consoleTextPosition++);
                    Console.WriteLine(" Wrong move. Try again");
                }
            }
            Console.SetCursorPosition(0, 6);
            Console.WriteLine(graphs.PrintBoard(status.gameStatus));
            CheckForWinner(status.gameStatus);
            ComputerMove(status.gameStatus, player1.currentChoice == 'O');
        }
    }

    public void GameOver()
    {
        Console.SetCursorPosition(23, consoleTextPosition += 2);
        Console.WriteLine("  No more moves. Draw.");
        status.GameFinished();
    }


    public void CheckForWinner(char[] gameStatus)
    {
        /*   
                 X X X
                 - - -
                 - - -
                            */

        if (gameStatus[0] == gameStatus[1] && gameStatus[1] == gameStatus[2] && gameStatus[0] != '-')
        {
            Console.SetCursorPosition(23, consoleTextPosition += 1);
            Console.WriteLine("  " + gameStatus[0] + " wins!");
            status.isGameOver = true;
        }
        /*   
                 - - -
                 X X X
                 - - -
                            */
        if (gameStatus[3] == gameStatus[4] && gameStatus[4] == gameStatus[5] && gameStatus[3] != '-')
        {
            Console.SetCursorPosition(23, consoleTextPosition += 1);
            Console.WriteLine("  " + gameStatus[3] + " wins!");
            status.isGameOver = true;
        }
        /*   
                 - - -
                 - - -
                 X X X
                            */
        if (gameStatus[6] == gameStatus[7] && gameStatus[7] == gameStatus[8] && gameStatus[6] != '-')
        {
            Console.SetCursorPosition(23, consoleTextPosition += 1);
            Console.WriteLine("  " + gameStatus[6] + " wins!");
            status.isGameOver = true;
        }
        /*   
                X - -
                X - -
                X - -
                           */
        if (gameStatus[0] == gameStatus[3] && gameStatus[3] == gameStatus[6] && gameStatus[0] != '-')
        {
            Console.SetCursorPosition(23, consoleTextPosition += 1);
            Console.WriteLine("  " + gameStatus[0] + " wins!");
            status.isGameOver = true;
        }
        /*   
                - X -
                - X -
                - X -
                           */
        if (gameStatus[1] == gameStatus[4] && gameStatus[4] == gameStatus[7] && gameStatus[1] != '-')
        {
            Console.SetCursorPosition(23, consoleTextPosition += 1);
            Console.WriteLine("  " + gameStatus[1] + " wins!");
            status.isGameOver = true;
        }
        /*   
                - - X
                - - X
                - - X
                           */
        if (gameStatus[2] == gameStatus[5] && gameStatus[5] == gameStatus[8] && gameStatus[2] != '-')
        {
            Console.SetCursorPosition(23, consoleTextPosition += 1);
            Console.WriteLine("  " + gameStatus[2] + " wins!");
            status.isGameOver = true;
        }
        /*   
                X - -
                - X -
                - - X
                           */
        if (gameStatus[0] == gameStatus[4] && gameStatus[4] == gameStatus[8] && gameStatus[0] != '-')
        {
            Console.SetCursorPosition(23, consoleTextPosition += 1);
            Console.WriteLine("  " + gameStatus[0] + " wins!");
            status.isGameOver = true;
        }
        /*   
                - - X
                - X -
                X - -
                           */
        if (gameStatus[2] == gameStatus[4] && gameStatus[4] == gameStatus[6] && gameStatus[2] != '-')
        {
            Console.SetCursorPosition(23, consoleTextPosition += 1);
            Console.WriteLine("  " + gameStatus[2] + " wins!");
            status.isGameOver = true;
        }
        if (!gameStatus.Contains('-') && !status.isGameOver)
        {
            GameOver();
        }
    }

}

// if (move == "C3" || move == "c3" && gameStatus[8] == '-') { gameStatus[8] = choice; break; }
// note that above statement uses || that ignores all the other statements on the right (NOT ONLY THE THE FIRST ONE!) if the left one is true
