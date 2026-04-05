using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Interactivity;

namespace TaskPlanner;

public partial class ColumnControl : UserControl
{
    public ColumnControl()
    {
        InitializeComponent();

        /*
         if (DataContext is Column column)
        Проверка типа: Является ли DataContext объектом типа Column?
        Приведение типа: Если да — сохранить его в переменную column
        // Старый способ
        if (DataContext is Column)
        {
            var column = (Column)DataContext;
            ...
        }
        DataContext и DataContextChanged это просто свойства класса, унаследованные от FrameworkElement
        Для примера можно обратиться к нему просто как this.DataCоntext
        */
        DataContextChanged += (_, _) =>
        {
            if (DataContext is Column column)
            {
                TitleText.Text = column.Name;
                ColumnID.Text = column.Id.ToString();
                
                Tasks.ItemsSource = column.Cards;
                
                TitleText.TextChanged += (_, _) =>
                {
                    column.Name = TitleText.Text ?? "";
                };
            }
        };
    }
    
    private void OnDeleteCardClick(object sender, RoutedEventArgs e)
    {
        if (DataContext is Column column)
            AppState.Columns.Remove(column);
        App.Notify("Успех", "Столбец удалён", NotificationType.Success);
    }
    private void OnAddCardClick(object sender, RoutedEventArgs e)
    {
        if (DataContext is Column column)
            column.Cards.Add(new TaskCard("", column));
    }
}