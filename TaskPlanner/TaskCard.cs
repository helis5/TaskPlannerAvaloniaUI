namespace TaskPlanner;

public class TaskCard : BaseEntity
{
    public string Title { get; set; }
    public Column ParentColumn { get; set; }
    public TaskCard(string title, Column parentColumn)
    {
        Title = title;
        ParentColumn = parentColumn;
    }
}