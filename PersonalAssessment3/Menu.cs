namespace PersonalAssessment3;

public class Menu
{

    public void ShowMenu()
    {
        Console.WriteLine("TODO: Menu");
    }
    
    public ConsoleKeyInfo GetOption()
    {
        ConsoleKeyInfo key = Console.ReadKey();
        Console.WriteLine();
        return key;
    }

    public string GetConsoleInput()
    {
        return Console.ReadLine();
    }

    public void ShowExitMessage()
    {
        Console.WriteLine("Goodbye!");
    }
}