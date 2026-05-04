using System.Drawing;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Tmds.DBus.Protocol;
using Color = Avalonia.Media.Color;

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
                

                SubTaskList.ItemsSource = card.SubTasks;
                StripeBorder.Background = PriorityColors[card.PriorityIndex];
                
                Content.IsEnabled = card.IsEnabled;
            }
            
        };
        
        /*if (DataContext is TaskCard card)
        {
            card.SubTasks.Add(new SubTask("random subtask", card));
            card.SubTasks.Add(new SubTask("Вторая подзадача", card));
        }*/

        //AppState.Columns[0].Cards[0].SubTasks.Add(new SubTask("Случайная задача"));

        
    }

    public void OnMoveToRight(object sender, RoutedEventArgs e)
    {
        if (DataContext is TaskCard card)
        {

            var currentIndex = AppState.Columns.IndexOf(card.ParentColumn);
            var nextIndex = currentIndex + 1;

            if (nextIndex >= AppState.Columns.Count) {
                App.Notify("Ошибка", "Перемещать карточку дальше нельзя", NotificationType.Error);
                return;
            }

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
            
            if (nextIndex < 0)
            {
                App.Notify("Ошибка", "Перемещать карточку дальше нельзя", NotificationType.Error);
                return;
            }

            card.ParentColumn.Cards.Remove(card);
            card.ParentColumn = AppState.Columns[nextIndex]; // обновляем родителя
            AppState.Columns[nextIndex].Cards.Add(card);
        }
    }
    
    private void OnDeleteClick(object sender, RoutedEventArgs e)
    {
        if (DataContext is TaskCard card)
        {
            var currentIndex = AppState.Columns.IndexOf(card.ParentColumn);
            AppState.Columns[currentIndex].Cards.Remove(card);
        }
            
    }
    private void OnNewSubTask(object sender, RoutedEventArgs e)
    {
        if (DataContext is TaskCard card)
        {
            //Желательно переделать в окно редартора задачи
            card.SubTasks.Add(new SubTask("", card));
        }
    }
    private void OnCardDoubleTapped(object sender, RoutedEventArgs e)
    {
        if (DataContext is TaskCard card)
        {
            //Желательно переделать в окно редартора задачи
            //card.SubTasks.Add(new SubTask("random subtask", card));
            /*if (SubTasksBorder.IsEnabled == false) SubTasksBorder.IsEnabled = true;
            else SubTasksBorder.IsEnabled = false;*/

            if (card.IsEnabled == false)
            {
                card.IsEnabled = true;
                Content.IsEnabled = card.IsEnabled;
            }
            else
            {
                card.IsEnabled = false;
                Content.IsEnabled = card.IsEnabled;
            }
            
        }
    }

    private static readonly SolidColorBrush[] PriorityColors =
    [
        new SolidColorBrush(Color.Parse("#4ADE80")),  // зелёный
        new SolidColorBrush(Color.Parse("#FACC15")),  // жёлтый
        new SolidColorBrush(Color.Parse("#F87171")),  // красный
    ];

    private void OnChangePriority(object sender, RoutedEventArgs e)
    {
        if (DataContext is TaskCard card)
        {
            card.PriorityIndex = (card.PriorityIndex + 1) % PriorityColors.Length;
            StripeBorder.Background = PriorityColors[card.PriorityIndex];
        }
    }
    private void TextBox_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter && sender is TextBox textBox)
        {
            e.Handled = true;
            var topLevel = TopLevel.GetTopLevel(textBox);
            topLevel?.FocusManager?.ClearFocus();
        }
    }
    
    
}