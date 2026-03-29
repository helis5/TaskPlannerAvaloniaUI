    using System.Text.Json.Serialization;

    namespace TaskPlanner;

    public class TaskCard : BaseEntity
    {
        public string Title { get; set; }
         // не сохраняем, чтобы избежать цикла
         [JsonIgnore] public Column ParentColumn { get; set; }
        public TaskCard(string title, Column parentColumn)
        {
            Title = title;
            ParentColumn = parentColumn;
        }
    }