namespace PersonalAssessment3;

public class Program
{
    public static void Main(string[] argv)
    {
        Menu menu = new Menu();
        menu.ShowMenu();
        ConsoleKeyInfo option = menu.GetOption();
        while (option.Key != ConsoleKey.Q)
        {
            menu.ShowMenu();
            option = menu.GetOption();
        }
        
        menu.ShowExitMessage();
    }
}