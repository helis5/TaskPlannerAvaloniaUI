using System.Threading.Tasks;
using Avalonia.Controls;
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
    }

    private async void OnSaveClick(object? sender, RoutedEventArgs e)
    {
        await AppState.SaveAsync();
    }
    
    private async void OnLoadClick(object? sender, RoutedEventArgs e)
    {
        await AppState.LoadAsync();
    }
}