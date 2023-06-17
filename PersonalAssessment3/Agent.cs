namespace PersonalAssessment3;

public class Agent : Employee
{
    public SeniorityLevel SeniorityLevel { get; private set; }
    public Agent(int id, string name, SeniorityLevel seniorityLevel) : base(id, name)
    {
        SeniorityLevel = seniorityLevel;
    }
}