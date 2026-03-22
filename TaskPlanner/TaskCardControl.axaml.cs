using Avalonia;
using Avalonia.Controls;
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
                // замени CardTitle на x:Name твоего элемента в TaskCardControl.axaml
                TaskCardText.Text = card.Title;
            }
        };
    }
}