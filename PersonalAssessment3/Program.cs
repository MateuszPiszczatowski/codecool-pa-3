namespace PersonalAssessment3;

public static class Program
{
    public static void Main(string[] argv)
    {
        List<Agent> agents = new List<Agent>();
        List<Call> calls = new List<Call>();
        List<CallsQueue> queues = new List<CallsQueue>();
        ConsoleMenu consoleMenu = new ConsoleMenu();
        consoleMenu.ShowGeneralMenu();
        MenuOption option = consoleMenu.GetOption();
        while (option != MenuOption.Exit)
        {
            HandleOption(option, consoleMenu);
            consoleMenu.ShowGeneralMenu();
            option = consoleMenu.GetOption();
        }
        consoleMenu.ShowExitMessage();
    }

    public static void HandleOption(MenuOption option, ConsoleMenu menu)
    {
        switch (option)
        {
            case MenuOption.Tests:
                Tests();
                break;
            case MenuOption.NoOptionChosen:
                Console.WriteLine("\nInvalid option!\n");
                break;
            case MenuOption.EnterAgents:
                break;
            case MenuOption.EnterCalls:
                break;
            case MenuOption.EnterQueues:
                break;
        }
    }

    public static CallsQueue GetQueueWithOldestCall(List<CallsQueue> queues)
    {
        if (queues is not null)
        {
            if (queues.Any())
            {
                return queues.OrderBy(queue => queue.GetOldestCall().CallTime).First();                
            }

            throw new ArgumentException("Queues list is empty!");
        }
        throw new ArgumentException("Queues list is a null reference");
    }
    
    public static List<CallsQueue> GetQueuesWithMostWaitingCalls(List<CallsQueue> queues)
    {
        if (queues is not null)
        {
            if (queues.Any())
            {
                 int mostWaitingCallsCount = queues.OrderByDescending(queue => queue.CallsCount()).First().CallsCount();
                 return queues.Where(queue => queue.CallsCount() == mostWaitingCallsCount).ToList();
            }
            throw new ArgumentException("Queues list is empty!");
        }
        throw new ArgumentException("Queues list is a null reference");
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
        List<CallsQueue> queues = new List<CallsQueue>();
        queues.Add(standardQueue);
        queues.Add(highPriorityQueue);
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
        Console.WriteLine($"Queue with oldest call is: {GetQueueWithOldestCall(queues).Name}\nThe oldest call has been made: {GetQueueWithOldestCall(queues).GetOldestCall().CallTime}\nIt's equality to firstly created call is: {GetQueueWithOldestCall(queues).GetOldestCall()==call}");
        Console.WriteLine($"Queues with most waiting calls ({GetQueuesWithMostWaitingCalls(queues).First().CallsCount()}):");
        foreach (var queue in GetQueuesWithMostWaitingCalls(queues))
        {
            Console.WriteLine($"\t- {queue.Name}");
        }
        highPriorityQueue.AddCall(new Call());
        Console.WriteLine($"Queues with most waiting calls after adding one to high priority ({GetQueuesWithMostWaitingCalls(queues).First().CallsCount()}):");
        foreach (var queue in GetQueuesWithMostWaitingCalls(queues))
        {
            Console.WriteLine($"\t- {queue.Name}");
        }
        
        standardQueue.AnswerCall();
        standardQueue.AnswerCall();
        highPriorityQueue.AnswerCall(call3);
        
        Console.WriteLine($"Standard queue count after answering two calls: {standardQueue.CallsCount()}");
        Console.WriteLine($"High Priority Queue count after answering one call: {highPriorityQueue.CallsCount()}");
        Console.Write("Exception when invalid employee added to highPriorityQueue: ");
        try
        {
            highPriorityQueue.AddReceiver(employee4);
            Console.WriteLine("No");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Yes");
        }
    }
}