class HumanPlayer : Player
{
    public void ChangeName(string newName)
    {
        if (newName == "")
        {
            name = "Nameless";
        }
        else name = newName;
    }

}