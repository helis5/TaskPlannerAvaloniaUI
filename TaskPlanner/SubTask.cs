using System.Text.Json.Serialization;

namespace TaskPlanner;

public class SubTask : BaseEntity
{
    public string Title { get; set; }
    [JsonIgnore] public TaskCard ParentCard { get; set; }
    public SubTask(string title, TaskCard parentCard)
    {
        Title = title;
        ParentCard = parentCard;
    }
}