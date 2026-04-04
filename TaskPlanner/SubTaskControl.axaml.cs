using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace TaskPlanner;

public partial class SubTaskControl : UserControl
{
    public SubTaskControl()
    {
        InitializeComponent();

        DataContextChanged += (_, _) =>
        {
            if (DataContext is SubTask task)
            {
                SubTaskText.Text = task.Title;

                // когда пользователь меняет текст — сохраняем в объект
                SubTaskText.TextChanged += (_, _) => { task.Title = SubTaskText.Text ?? ""; };
            }
        };
    }
    
    private void OnDeleteClick(object sender, RoutedEventArgs e)
    {
        if (DataContext is SubTask subtask)
        {
            //Из родительской карточки удаляем принимаемую подзадачу
            TaskCard PCard = subtask.ParentCard;
            PCard.SubTasks.Remove(subtask);
        }
    }
}