class ComputerPlayer : Player
{
    private string[] names = new string[] { "Adam", "John", "Mike", "Paul", "Chris", "Eva", "Merry", "Judy", "Samantha", "Ada" };

    public void PickAName()
    {
        name = names[new Random().Next(0, names.Length)];
    }

}

