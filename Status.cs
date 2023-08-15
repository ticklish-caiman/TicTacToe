class Status
{
    public static class Globals
    {
        public static int ConsoleTextPosition = 5;
        public static int ConsoleBoardPosition = 6;
        public static bool isGameOver = false;
    }
    public int gamesPlayed = 0;
    public byte movesMade = 0;
    public char[] gameStatus = new char[9];

    public bool isXTurn = false;

    public void Init()
    {
        //gamesPlayed = 0;
        movesMade = 0;
        gameStatus = new char[] { '-', '-', '-', '-', '-', '-', '-', '-', '-' };
    }

    public void Update(char[] status)
    {
        gameStatus = status;
    }

    public void GameFinished()
    {
        gamesPlayed++;
    }

    public void ResetGlobals()
    {
        Globals.ConsoleTextPosition = 5;
        Globals.ConsoleBoardPosition = 6;
        Globals.isGameOver = false;
    }



}
