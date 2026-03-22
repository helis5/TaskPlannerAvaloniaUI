using System.Collections.ObjectModel;

namespace TaskPlanner;

public static class AppState 
{ 
    public static ObservableCollection<Column> Columns { get; } = new();
}
