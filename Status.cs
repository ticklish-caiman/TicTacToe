class Status
{
    public static class Globals
    {
        public static int ConsoleTextPosition = 4;
        public static int ConsoleBoardPosition = 6;
        public static bool IsGameOver = false;
        public static int RoundsPlayed = 0;
    }

    public byte movesMade = 0;
    public char[] gameStatus = new char[9];

    public bool isXTurn = false;

    public void Init()
    {
        movesMade = 0;
        gameStatus = new char[] { '-', '-', '-', '-', '-', '-', '-', '-', '-' };
    }

    public void Update(char[] status)
    {
        gameStatus = status;
    }

    public void ResetGlobals()
    {
        Globals.ConsoleTextPosition = 5;
        Globals.ConsoleBoardPosition = 6;
        Globals.IsGameOver = false;
        Globals.RoundsPlayed = 0;
    }



}
