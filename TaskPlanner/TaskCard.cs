namespace TaskPlanner;

public class TaskCard : BaseEntity
{
    public string Title { get; }

    public TaskCard(string title)
    {
        Title = title;
    }
}