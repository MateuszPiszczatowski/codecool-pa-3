namespace PersonalAssessment3;

public class Call
{
    public DateTime CallTime { get; private set; }
    public Agent Receiver { get; private set; }
    
    public Call()
    {
        CallTime = DateTime.Now;
    }

    public void setReceiver(Agent newReceiver)
    {
        Receiver = newReceiver;
    }
}