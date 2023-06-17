namespace PersonalAssessment3;

public class Program
{
    public static void Main(string[] argv)
    {
        Tests();
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

    public static void Tests()
    {
        Agent employee = new Agent(0, "Employee", SeniorityLevel.LevelA);
        Agent employee2 = new Agent(1, "Employee1", SeniorityLevel.LevelA);
        Agent employee3 = new Agent(2, "Employee2", SeniorityLevel.LevelB);
        Agent employee4 = new Agent(3, "Employee3", SeniorityLevel.LevelB);
        Agent employee5 = new Agent(4, "Employee4", SeniorityLevel.LevelC);

        Call call = new Call();
        Call call1 = new Call();
        Call call2 = new Call();
        Call call3 = new Call();
        Call call4 = new Call();

        CallsQueue standardQueue = new CallsQueue("MyQueue");
        CallsQueue highPriorityQueue = new HighPriorityCallsQueue("MyHighPriorityQueue");
        standardQueue.AddReceiver(employee);
        standardQueue.AddReceiver(employee3);
        standardQueue.AddReceiver(employee5);
        highPriorityQueue.AddReceiver(employee2);
        
        standardQueue.AddCall(call);
        standardQueue.AddCall(call1);
        standardQueue.AddCall(call2);
        
        highPriorityQueue.AddCall(call3);
        highPriorityQueue.AddCall(call4);
        Console.WriteLine($"Standard queue count: {standardQueue.CallsCount()}");
        Console.WriteLine($"High Priority Queue count: {highPriorityQueue.CallsCount()}");

        standardQueue.AnswerCall();
        standardQueue.AnswerCall();
        highPriorityQueue.AnswerCall(call4);
        
        Console.WriteLine($"Standard queue count after answering two calls: {standardQueue.CallsCount()}");
        Console.WriteLine($"High Priority Queue count after answering one call: {highPriorityQueue.CallsCount()}");
        
        highPriorityQueue.AddReceiver(employee4);
    }
}