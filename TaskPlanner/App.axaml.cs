using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Notifications;
using Avalonia.Markup.Xaml;

namespace TaskPlanner;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }
    //НОВОЕ
    public static WindowNotificationManager? Notifications { get; private set; }
    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow();
            
            //НОВОЕ
            //Уведомления
            Notifications = new WindowNotificationManager(desktop.MainWindow)
            {
                Position = NotificationPosition.TopRight,
                MaxItems = 3
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
    
    // Статический метод для удобного вызова
    public static void Notify(string title, string message, NotificationType type = NotificationType.Information)
    {
        Notifications?.Show(new Notification(title, message, type));
    }
}