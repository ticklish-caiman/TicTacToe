class Player
{
    public string name = "Player";
    public int score = 0;
    public char currentChoice = 'O';

    public void ChangeName(string newName)
    {
        if (newName == "")
        {
            name = "Nameless";
        }
        else name = newName;
    }

}