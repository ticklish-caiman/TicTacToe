class Computer
{
    private string[] names = new string[] { "Adam", "John", "Mike", "Paul", "Chris", "Eva", "Merry", "Judy", "Samantha", "Ada" };
    public string? name;
    public int score = 0;
    public char currentChoice = 'O';

    public void PickAName()
    {
        name = names[new Random().Next(0, names.Length)];
    }

}

