namespace PersonalAssessment3;

public class CallsQueue
{
    public string Name { get; private set; }
    public List<Agent> ReceiversList { get; private set; }
    public List<Call> WaitingCallsList { get; private set; }

    public CallsQueue(string name)
    {
        Name = name;
        ReceiversList = new List<Agent>();
        WaitingCallsList = new List<Call>();
    }

    public void AddCall(Call newCall)
    {
        if (newCall is not null)
        {
            WaitingCallsList.Add(newCall);
            newCall.setQueue(this);
            return;
        }
        throw new ArgumentException("Cannot add null as a call!");
    }
    
    public virtual void AddReceiver(Agent newReceiver)
    {
        if (newReceiver is not null)
        {
            ReceiversList.Add(newReceiver);
            newReceiver.setQueue(this);
            return;
        }
        throw new ArgumentException("Cannot add null as a receiver!");
    }

    public void AnswerCall()
    {
        Call answeredCall;
        Agent receiver;
        try
        {
            answeredCall = WaitingCallsList.First();
        }
        catch (InvalidOperationException e)
        {
            throw new InvalidOperationException("No Call is waiting!");
        }
        try
        {
            receiver = ReceiversList.First();
        }
        catch (InvalidOperationException e)
        {
            throw new InvalidOperationException("There is no Agent to answer right now.");
        }
        AnswerCall(receiver, answeredCall);
    }
    
    public void AnswerCall(Agent receiver)
    {
        Call answeredCall;
        try
        {
            answeredCall = WaitingCallsList.First();
        }
        catch (InvalidOperationException e)
        {
            throw new InvalidOperationException("No Call is waiting!");
        }
        AnswerCall(receiver, answeredCall);
    }
    
    public void AnswerCall(Call call)
    {
        Agent receiver;
        try
        {
            receiver = ReceiversList.First();
        }
        catch (InvalidOperationException e)
        {
            throw new InvalidOperationException("There is no Agent to answer right now.");
        }
        AnswerCall(receiver, call);
    }
    
    public void AnswerCall(Agent receiver, Call call)
    {
        if (receiver is not null && call is not null)
        {
            if (ReceiversList.Contains(receiver) && WaitingCallsList.Contains(call))
            {
                ReceiversList.Remove(receiver);
                WaitingCallsList.Remove(call);
                receiver.setQueue(null);
                call.setQueue(null);
                call.setReceiver(receiver);
                return;
            }
            throw new ArgumentException("Call and receiver should belong to the queue!");
        }
        throw new ArgumentException("Neither receiver nor call can be null!");
    }

    public int CallsCount()
    {
        return WaitingCallsList.Count;
    }

    public Call GetOldestCall()
    {
        return WaitingCallsList.OrderBy(call => call.CallTime).First();
    }
}