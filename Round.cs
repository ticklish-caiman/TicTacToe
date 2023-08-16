using static Status;


class Round
{
    readonly Random random = new();
    public bool whoseTurn = true; // true = O, false = X
    readonly Graphics graphs = new();
    public Status PlayRound(Status status, Player player1, Player player2, byte mode)
    {
        // ----- Player vs Computer ------
        if (mode == 1)
        {
            while (status.movesMade < 10)
            {
                if (Globals.isGameOver)
                {
                    return status;
                }
                if (player1.currentChoice == 'O' && whoseTurn)
                {
                    PlayerMove(status, player1);
                    Console.SetCursorPosition(0, Globals.ConsoleBoardPosition);
                    Console.WriteLine(graphs.PrintBoard(status.gameStatus));
                    CheckForWinner(status.gameStatus);
                    whoseTurn = !whoseTurn;
                }
                if (player1.currentChoice == 'X' && !whoseTurn)
                {
                    PlayerMove(status, player1);
                    Console.SetCursorPosition(0, Globals.ConsoleBoardPosition);
                    Console.WriteLine(graphs.PrintBoard(status.gameStatus));
                    CheckForWinner(status.gameStatus);
                    whoseTurn = !whoseTurn;
                }
                else
                {
                    ComputerMove(status, player2);
                    Console.SetCursorPosition(0, Globals.ConsoleBoardPosition);
                    Console.WriteLine(graphs.PrintBoard(status.gameStatus));
                    CheckForWinner(status.gameStatus);
                    whoseTurn = !whoseTurn;
                }
            }
            status.GameFinished();

        }
        // ----- Computer vs Computer ------
        else if (mode == 2)
        {
            while (status.movesMade < 10)
            {
                if (Globals.isGameOver)
                {
                    return status;
                }
                ComputerMove(status, player1);
                ComputerMove(status, player2);
                Console.SetCursorPosition(0, Globals.ConsoleBoardPosition);
                Console.WriteLine(graphs.PrintBoard(status.gameStatus));
                CheckForWinner(status.gameStatus);
                whoseTurn = !whoseTurn;
            }
        }
        return status;
    }

    public static void PlayerMove(Status status, Player player)
    {

        if (!Globals.isGameOver)
        {
            while (true)
            {
                Console.SetCursorPosition(23, Globals.ConsoleTextPosition++);
                Graphics.DelayWriting(" Your turn! Choose (e.g. A1 or C3):", 25);
                string? move = Console.ReadLine();
                move = move?.ToUpper();

                if (status.gameStatus[0] == '-' && move == "A1") { status.gameStatus[0] = player.currentChoice; break; }
                if (status.gameStatus[1] == '-' && move == "B1") { status.gameStatus[1] = player.currentChoice; break; }
                if (status.gameStatus[2] == '-' && move == "C1") { status.gameStatus[2] = player.currentChoice; break; }
                if (status.gameStatus[3] == '-' && move == "A2") { status.gameStatus[3] = player.currentChoice; break; }
                if (status.gameStatus[4] == '-' && move == "B2") { status.gameStatus[4] = player.currentChoice; break; }
                if (status.gameStatus[5] == '-' && move == "C2") { status.gameStatus[5] = player.currentChoice; break; }
                if (status.gameStatus[6] == '-' && move == "A3") { status.gameStatus[6] = player.currentChoice; break; }
                if (status.gameStatus[7] == '-' && move == "B3") { status.gameStatus[7] = player.currentChoice; break; }
                if (status.gameStatus[8] == '-' && move == "C3") { status.gameStatus[8] = player.currentChoice; break; }
                else
                {
                    Console.SetCursorPosition(23, Globals.ConsoleTextPosition++);
                    Console.WriteLine(" Wrong move. Try again");
                }
                status.movesMade++;
            }

        }
    }

    public void ComputerMove(Status status, Player player)
    {

        if (!Globals.isGameOver)
        {
            Console.SetCursorPosition(23, Globals.ConsoleTextPosition++);
            List<int> emptyFields = new();
            for (int i = 0; i < status.gameStatus.Length; i++)
            {
                if (status.gameStatus[i] == '-')
                {
                    emptyFields.Add(i);
                }
            };

            Graphics.DelayWriting(" Computer is thinking and have " + player.currentChoice, 5);
            Graphics.DelayWriting("...", 200);

            try
            {
                status.gameStatus[emptyFields.ElementAt(random.Next(0, emptyFields.Count))] = player.currentChoice;
            }
            catch (ArgumentOutOfRangeException)
            {
                CheckForWinner(status.gameStatus);
            }

        }
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
            Console.SetCursorPosition(23, Globals.ConsoleTextPosition++);
            Console.WriteLine("  " + gameStatus[0] + " wins!");
            Globals.isGameOver = true;
            return;
        }
        /*   
                 - - -
                 X X X
                 - - -
                            */
        if (gameStatus[3] == gameStatus[4] && gameStatus[4] == gameStatus[5] && gameStatus[3] != '-')
        {
            Console.SetCursorPosition(23, Globals.ConsoleTextPosition++);
            Console.WriteLine("  " + gameStatus[3] + " wins!");
            Globals.isGameOver = true;
            return;
        }
        /*   
                 - - -
                 - - -
                 X X X
                            */
        if (gameStatus[6] == gameStatus[7] && gameStatus[7] == gameStatus[8] && gameStatus[6] != '-')
        {
            Console.SetCursorPosition(23, Globals.ConsoleTextPosition++);
            Console.WriteLine("  " + gameStatus[6] + " wins!");
            Globals.isGameOver = true;
            return;
        }
        /*   
                X - -
                X - -
                X - -
                           */
        if (gameStatus[0] == gameStatus[3] && gameStatus[3] == gameStatus[6] && gameStatus[0] != '-')
        {
            Console.SetCursorPosition(23, Globals.ConsoleTextPosition++);
            Console.WriteLine("  " + gameStatus[0] + " wins!");
            Globals.isGameOver = true;
            return;
        }
        /*   
                - X -
                - X -
                - X -
                           */
        if (gameStatus[1] == gameStatus[4] && gameStatus[4] == gameStatus[7] && gameStatus[1] != '-')
        {
            Console.SetCursorPosition(23, Globals.ConsoleTextPosition++);
            Console.WriteLine("  " + gameStatus[1] + " wins!");
            Globals.isGameOver = true;
            return;
        }
        /*   
                - - X
                - - X
                - - X
                           */
        if (gameStatus[2] == gameStatus[5] && gameStatus[5] == gameStatus[8] && gameStatus[2] != '-')
        {
            Console.SetCursorPosition(23, Globals.ConsoleTextPosition++);
            Console.WriteLine("  " + gameStatus[2] + " wins!");
            Globals.isGameOver = true;
            return;
        }
        /*   
                X - -
                - X -
                - - X
                           */
        if (gameStatus[0] == gameStatus[4] && gameStatus[4] == gameStatus[8] && gameStatus[0] != '-')
        {
            Console.SetCursorPosition(23, Globals.ConsoleTextPosition++);
            Console.WriteLine("  " + gameStatus[0] + " wins!");
            Globals.isGameOver = true;
            return;
        }
        /*   
                - - X
                - X -
                X - -
                           */
        if (gameStatus[2] == gameStatus[4] && gameStatus[4] == gameStatus[6] && gameStatus[2] != '-')
        {
            Console.SetCursorPosition(23, Globals.ConsoleTextPosition++);
            Console.WriteLine("  " + gameStatus[2] + " wins!");
            Globals.isGameOver = true;
            return;
        }
        if (!gameStatus.Contains('-'))
        {
            GameOver();
        }
    }


    public static void GameOver()
    {
        Console.SetCursorPosition(23, Globals.ConsoleTextPosition++);
        Console.WriteLine("  No more moves. Draw.");
        Globals.isGameOver = true;

    }
}


// if (move == "C3" || move == "c3" && gameStatus[8] == '-') { gameStatus[8] = choice; break; }
// note that above statement uses || that ignores all the other statements on the right (NOT ONLY THE THE FIRST ONE!) if the left one is true
