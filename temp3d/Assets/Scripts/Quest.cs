public class Quest
{
    public ITask[] tasks { get; }

    public Quest(params ITask[] tasks)
    {
        this.tasks = tasks;
    }
}


