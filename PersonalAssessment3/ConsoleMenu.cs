namespace PersonalAssessment3;

public class ConsoleMenu
{

    public void ShowGeneralMenu()
    {
        Console.WriteLine("e, e - Exit" +
                          "\nt, T - Tests" +
                          "\nc, C - Calls" +
                          "\na, A - Agents" +
                          "\nq, Q - Queues");
    }

    public void ShowCallsMenu()
    {
        Console.WriteLine("TODO");
    }

    public void ShowQueuesMenu()
    {
        Console.WriteLine("TODO");
    }

    public void ShowAgentsMenu()
    {
        Console.WriteLine("TODO");
    }
    
    public MenuOption GetOption()
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        Console.WriteLine();
        switch (keyInfo.Key)
        {
            case ConsoleKey.E:
                return MenuOption.Exit;
            case ConsoleKey.T:
                return MenuOption.Tests;
            default:
                return MenuOption.NoOptionChosen;
        }
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