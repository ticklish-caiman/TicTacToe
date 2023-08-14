class Graphics
{
    //string element0 = "   A     B     C\n";
    //string element1 = "     |     |    \n";
    //string element2 = "_____|_____|_____\n";

    char[] element0 = { ' ', ' ', ' ', 'A', ' ', ' ', ' ', ' ', ' ', 'B', ' ', ' ', ' ', ' ', ' ', 'C', };
    char[] element1 = { ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ' };
    char[] element2 = { '_', '_', '_', '_', '_', '|', '_', '_', '_', '_', '_', '|', '_', '_', '_', '_', '_' };
    char[] emptyBoard = { '-', '-', '-', '-', '-', '-', '-', '-', '-' };
    public string EmptyBoard()
    {
        return "  " + new string(element0) + "\n   " + new string(element1) + "\n  1" + new string(element1) + "\n   " + new string(element2) + "\n   " + new string(element1) + "\n  2" + new string(element1) + "\n   " + new string(element2) + "\n   " + new string(element1) + "\n  3" + new string(element1) + "\n   " + new string(element1) + "\n";
    }

    public string PrintBoard(char[] gameStatus)
    {
        if (gameStatus.SequenceEqual(emptyBoard))
        {
            return EmptyBoard();
        }
        char[] element1a = new char[element1.Length];
        Array.Copy(element1, element1a, element1.Length);
        char[] element1b = new char[element1.Length];
        Array.Copy(element1, element1b, element1.Length);
        char[] element1c = new char[element1.Length];
        Array.Copy(element1, element1c, element1.Length);
        {
            for (int i = 0; i < gameStatus.Length; i++)
            {
                if (gameStatus[i] != '-')
                {
                    if (i == 0)
                        element1a[2] = gameStatus[i];
                    if (i == 1)
                        element1a[8] = gameStatus[i];
                    if (i == 2)
                        element1a[14] = gameStatus[i];
                    if (i == 3)
                        element1b[2] = gameStatus[i];
                    if (i == 4)
                        element1b[8] = gameStatus[i];
                    if (i == 5)
                        element1b[14] = gameStatus[i];
                    if (i == 6)
                        element1c[2] = gameStatus[i];
                    if (i == 7)
                        element1c[8] = gameStatus[i];
                    if (i == 8)
                        element1c[14] = gameStatus[i];
                }
            }
        }

        string board = "  " + new string(element0) + "\n   " + new string(element1) + "\n  1" + new string(element1a) + "\n   " + new string(element2) + "\n   " + new string(element1) + "\n  2" + new string(element1b) + "\n   " + new string(element2) + "\n   " + new string(element1) + "\n  3" + new string(element1c) + "\n   " + new string(element1) + "\n";
        return board;
    }


    public static void DelayWriting(string text, int delay)
    {
        for (int i = 0; i < text.Length; i++)
        {
            Console.Write(text[i]);
            // TODO: uncomment after debugging!
            //System.Threading.Thread.Sleep(delay);
        }
    }

    public static void DelayRandom(string text, int delay)
    {
        Random rnd = new Random();
        for (int i = 0; i < text.Length; i++)
        {
            Console.Write(text[i]);
            if (rnd.NextDouble() < 0.2)
            {
                // TODO: uncomment after debugging!
                //System.Threading.Thread.Sleep(delay);
            }
        }
    }

    public static void PrintWelcome()
    {
        Console.Write("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■\n");
        DelayWriting("■■■■■■■■■■■■■» ", 1);
        DelayWriting("Welcome to Tic Tac Toe!", 5);
        DelayWriting(" «■■■■■■■■■■■■■■\n", 1);
        DelayWriting("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■\n", 1);
    }

}