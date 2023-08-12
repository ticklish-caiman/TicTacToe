bool GameIsOn = true;
while (GameIsOn)
{
    Console.Write("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■\n");
    Graphics.DelayWriting("■■■■■■■■■■■■■» ", 1);
    Graphics.DelayWriting("Welcome to Tic Tac Toe!", 5);
    Graphics.DelayWriting(" «■■■■■■■■■■■■■■\n", 1);
    Graphics.DelayWriting("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■\n", 1);
    Game game1 = new();
    game1.InitGame();
    Console.SetCursorPosition(21, game1.consoleTextPosition + 2);
    Graphics.DelayWriting("  Play again? (Y/N)", 10);
    string choice = Console.ReadLine();
    if (choice == "N" || choice == "n") GameIsOn = false;
    Console.Clear();
}
Console.WriteLine("Have a nice day. Press any key to exit.");
Console.ReadLine();
