using Avalonia.Controls;
using Avalonia.Interactivity;
using Stickies.ViewModels;

namespace Stickies.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }
    
    private void MinimizeWindow(object sender, RoutedEventArgs e)
    {
        Hide();
    }
}