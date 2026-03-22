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