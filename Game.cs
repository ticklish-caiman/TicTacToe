class Game
{
    bool isGameOver = false;
    char[] gameStatus = { '-', '-', '-', '-', '-', '-', '-', '-', '-' };
    char choice = 'X';
    char computerChoice = 'O';
    char secondComputerChoice = 'X';
    byte mode = 1;
    public int consoleTextPosition = 6;
    Random rnd = new();
    readonly Graphics graphs = new();
    public void InitGame()
    {
        while (true)
        {
            Graphics.DelayWriting("  Let's begin!\n", 20);


            Graphics.DelayWriting("  O's go first!\n", 25);
            Console.SetCursorPosition(0, 6);
            Graphics.DelayRandom(graphs.EmptyBoard(), 1);
            Console.SetCursorPosition(23, consoleTextPosition++);
            Graphics.DelayWriting("  Choose mode: 1) PvC, 2) CvC\n 2", 20);

            if (mode == 1)
            {
                Console.SetCursorPosition(23, consoleTextPosition++);
                Graphics.DelayWriting(" Play as X or O?  ", 20);
                string playerChoice = Console.ReadLine();
                if (playerChoice == "X" || playerChoice == "x")
                {
                    choice = 'X';
                    computerChoice = 'O';
                    Console.SetCursorPosition(23, consoleTextPosition++);
                    Graphics.DelayWriting(" You will play as X \n", 20);
                    break;
                }
                if (playerChoice == "O" || playerChoice == "o")
                {
                    choice = 'O';
                    Console.SetCursorPosition(23, consoleTextPosition++);
                    Graphics.DelayWriting(" You will play as O\n", 20);
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
                Console.SetCursorPosition(23, consoleTextPosition++);
                Graphics.DelayWriting(" Enjoy the show!  ", 20);
                break;
            }


        }

        StartGame();
    }

    public void StartGame()
    {
        if (mode == 1)
        {
            if (choice == 'O')
            {
                PlayerMove(gameStatus);
            }
            else
            {
                ComputerMove(gameStatus);
            }
        }
        else if (mode == 2)
        {
            ComputerMove(gameStatus);
        }

    }

    public void ComputerMove(char[] gameStatus)
    {
        if (!isGameOver)
        {
            Console.SetCursorPosition(23, consoleTextPosition++);
            Graphics.DelayWriting(" Computer is thinking", 35);
            Graphics.DelayWriting("...", 200);
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
            }
            else
            {
                gameStatus[emptyFields.ElementAt(rnd.Next(0, emptyFields.Count))] = computerChoice;
                Console.SetCursorPosition(0, 6);
                Console.WriteLine(graphs.PrintBoard(gameStatus));
                CheckForWinner(gameStatus);
                if (mode == 1)
                {
                    PlayerMove(gameStatus);
                }
                else SecondComputerMove(gameStatus);
            }


        }

    }

    public void SecondComputerMove(char[] gameStatus)
    {
        if (!isGameOver)
        {
            Console.SetCursorPosition(23, consoleTextPosition++);
            Graphics.DelayWriting(" Computer is thinking", 35);
            Graphics.DelayWriting("...", 200);
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
            }
            else
            {
                gameStatus[emptyFields.ElementAt(rnd.Next(0, emptyFields.Count))] = secondComputerChoice;
                Console.SetCursorPosition(0, 6);
                Console.WriteLine(graphs.PrintBoard(gameStatus));
                CheckForWinner(gameStatus);
                ComputerMove(gameStatus);
            }

        }

    }

    public void PlayerMove(char[] gameStatus)
    {
        if (!isGameOver)
        {
            while (true)
            {
                Console.SetCursorPosition(23, consoleTextPosition++);
                Graphics.DelayWriting(" Your turn! Choose (e.g. A1 or C3):", 25);
                string move = Console.ReadLine();
                // if (move == "C3" || move == "c3" && gameStatus[8] == '-') { gameStatus[8] = choice; break; }
                // note that above statement uses || that ignores all the other statements on the right (NOT ONLY THE THE FIRS ONE!) if the left one is true
                if (gameStatus[0] == '-' && move == "A1" || move == "a1") { gameStatus[0] = choice; break; }
                if (gameStatus[1] == '-' && move == "B1" || move == "b1") { gameStatus[1] = choice; break; }
                if (gameStatus[2] == '-' && move == "C1" || move == "c1") { gameStatus[2] = choice; break; }
                if (gameStatus[3] == '-' && move == "A2" || move == "a2") { gameStatus[3] = choice; break; }
                if (gameStatus[4] == '-' && move == "B2" || move == "b2") { gameStatus[4] = choice; break; }
                if (gameStatus[5] == '-' && move == "C2" || move == "c2") { gameStatus[5] = choice; break; }
                if (gameStatus[6] == '-' && move == "A3" || move == "a3") { gameStatus[6] = choice; break; }
                if (gameStatus[7] == '-' && move == "B3" || move == "b3") { gameStatus[7] = choice; break; }
                if (gameStatus[8] == '-' && move == "C3" || move == "c3") { gameStatus[8] = choice; break; }
                else
                {
                    Console.SetCursorPosition(23, consoleTextPosition++);
                    Console.WriteLine(" Wrong move. Try again");
                }
                // would be nice to do             if (string.Equals(move, "A1", CaseInsensitiveComparer))
                //                                   gameStatus[0] = choice;
                // but dunno how for now
            }
            Console.SetCursorPosition(0, 6);
            Console.WriteLine(graphs.PrintBoard(gameStatus));
            CheckForWinner(gameStatus);
            ComputerMove(gameStatus);
        }

    }

    public void GameOver()
    {
        Console.SetCursorPosition(23, consoleTextPosition += 2);
        Console.WriteLine("  No more moves. Draw.");
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
            isGameOver = true;
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
            isGameOver = true;
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
            isGameOver = true;
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
            isGameOver = true;
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
            isGameOver = true;
        }
        /*   
                - - X
                - - X
                - - X
                           */
        if (gameStatus[2] == gameStatus[5] && gameStatus[5] == gameStatus[8] && gameStatus[2] != '-')
        {
            Console.SetCursorPosition(23, consoleTextPosition += 1);
            Console.WriteLine("  " + gameStatus[3] + " wins!");
            isGameOver = true;
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
            isGameOver = true;
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
            isGameOver = true;
        }
        if (!gameStatus.Contains('-') && !isGameOver)
        {
            GameOver();
        }
    }



}
