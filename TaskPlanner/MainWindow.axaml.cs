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
        AppState.Columns[0].Cards.Add(new TaskCard("Купить молоко"));
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
}