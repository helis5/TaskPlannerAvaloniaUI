    using System.Collections.ObjectModel;
    using System.Text.Json.Serialization;

    namespace TaskPlanner;

    public class TaskCard : BaseEntity
    {
        public string Title { get; set; }
        public int PriorityIndex { get; set; } = 0;
        
        public ObservableCollection<SubTask> SubTasks { get; set; } = new();
        
         // не сохраняем, чтобы избежать цикла
         [JsonIgnore] public Column ParentColumn { get; set; }
        public TaskCard(string title, Column parentColumn)
        {
            Title = title;
            ParentColumn = parentColumn;
        }
    }