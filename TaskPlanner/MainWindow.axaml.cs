using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Interactivity;

namespace TaskPlanner;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        ColumnList.ItemsSource = AppState.Columns;
        //временно
        AppState.Columns.Add(new Column("Автоматический столбец"));
        var column = AppState.Columns[0];
        column.Cards.Add(new TaskCard("Купить молоко", column));
    }

    private void OnAddColumnClick(object sender, RoutedEventArgs e)
    {
        var title = NewTitle.Text;

        AppState.Columns.Add(
            string.IsNullOrWhiteSpace(title)
                ? new Column()
                : new Column(title)
        );

        NewTitle.Text = "";
        App.Notify("Успех", "Столбец создан", NotificationType.Success);
    }

    private async void OnSaveClick(object? sender, RoutedEventArgs e)
    {
        await AppState.SaveAsync();
        App.Notify("Успех", "Файл сохранён", NotificationType.Success);
    }
    
    private async void OnLoadClick(object? sender, RoutedEventArgs e)
    {
        await AppState.LoadAsync();
        App.Notify("Успех", "Файл загружен", NotificationType.Success);
    }
}