class Status
{
    public int gamesPlayed;
    public char[] gameStatus = new char[9];
    public bool isGameOver = false;

    public void Init()
    {
        gamesPlayed = 0;
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

}
