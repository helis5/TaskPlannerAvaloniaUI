using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace TaskPlanner;

public partial class TaskCardControl : UserControl
{
    public TaskCardControl()
    {
        InitializeComponent();
        
        DataContextChanged += (_, _) =>
        {
            if (DataContext is TaskCard card)
            {
                TaskCardText.Text = card.Title;

                // когда пользователь меняет текст — сохраняем в объект
                TaskCardText.TextChanged += (_, _) =>
                {
                    card.Title = TaskCardText.Text ?? "";
                };
            }
        };
    }

    public void OnMoveToRight(object sender, RoutedEventArgs e)
    {
        if (DataContext is TaskCard card)
        {
            var currentIndex = AppState.Columns.IndexOf(card.ParentColumn);
            var nextIndex = currentIndex + 1;

            if (nextIndex >= AppState.Columns.Count) return;

            card.ParentColumn.Cards.Remove(card);
            card.ParentColumn = AppState.Columns[nextIndex]; // обновляем родителя
            AppState.Columns[nextIndex].Cards.Add(card);
        }
    }
    
    public void OnMoveToLeft(object sender, RoutedEventArgs e)
    {
        if (DataContext is TaskCard card)
        {
            var currentIndex = AppState.Columns.IndexOf(card.ParentColumn);
            var nextIndex = currentIndex - 1;

            if (nextIndex >= AppState.Columns.Count) return;

            card.ParentColumn.Cards.Remove(card);
            card.ParentColumn = AppState.Columns[nextIndex]; // обновляем родителя
            AppState.Columns[nextIndex].Cards.Add(card);
        }
    }
}