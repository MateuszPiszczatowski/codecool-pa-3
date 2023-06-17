namespace PersonalAssessment3;

public class HighPriorityCallsQueue : CallsQueue
{

    public HighPriorityCallsQueue(string name) : base(name) { }

    public override void AddReceiver(Agent newReceiver)
    {
        if (newReceiver is not null)
        {
            if (newReceiver.SeniorityLevel == SeniorityLevel.LevelA)
            {
                ReceiversList.Add(newReceiver);
                return;
            }
            throw new ArgumentException("Receiver in high priority Queue must be of Level A!");
        }
        throw new ArgumentException("Cannot add null as a receiver!");
    }
}