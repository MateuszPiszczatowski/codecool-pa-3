namespace PersonalAssessment3;

public class Menu
{

    public void ShowMenu()
    {
        Console.WriteLine("TODO: Menu");
        GetOption();
    }
    
    public ConsoleKeyInfo GetOption()
    {
        return Console.ReadKey();
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