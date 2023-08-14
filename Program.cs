bool GameIsOn = true;
while (GameIsOn)
{
    Graphics.PrintWelcome();
    Game game1 = new();
    game1.InitGame();
    Console.SetCursorPosition(21, game1.consoleTextPosition + 2);

    Graphics.DelayWriting("  Play again? (Y/N)", 10);
    string choice = Console.ReadLine().ToUpper();
    if (choice == "N") GameIsOn = false;
    Console.Clear();
}
Console.WriteLine("Have a nice day. Press any key to exit.");
Console.ReadLine();
