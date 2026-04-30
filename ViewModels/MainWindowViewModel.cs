using System;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.Input;
using Stickies.Views;

namespace Stickies.ViewModels;

public class MainWindowViewModel : ViewModelBase
{    
// === CONSTRUCTOR ===
    public MainWindowViewModel()
    {
        CreateNewStickieCommand = new RelayCommand(CreateNewStickie);
        LoginCommand = new RelayCommand(LoginToNextcloud);
        
        InitializeTrayIcon();
    }
// === CONSTRUCTOR ===

//-----------------------------------------------------------------------------------------------------------

// === FIELDS & PROPERTIES === 

    private static TrayIcon? _trayIcon;
    public ICommand CreateNewStickieCommand { get; }
    public ICommand LoginCommand { get; }
// === FIELDS & PROPERTIES ===
    
//-----------------------------------------------------------------------------------------------------------    

// === METHODS ===
    private void InitializeTrayIcon()
    {
        if (_trayIcon != null)
        {
            return;
        }
        
        var menu = new NativeMenu();

        var newStickieItem = new NativeMenuItem("New Stickie");
        newStickieItem.Click += (_, _) => CreateNewStickie();

        var openItem = new NativeMenuItem("Open");
        openItem.Click += (_, _) => ShowWindow();
        
        var exitItem = new NativeMenuItem("Exit");
        exitItem.Click += (_, _) =>
        {
            Console.WriteLine("exit the application!");
            Environment.Exit(0);
        };
        
        menu.Items.Add(newStickieItem);
        menu.Items.Add(new NativeMenuItemSeparator());
        menu.Items.Add(openItem);
        menu.Items.Add(exitItem);

        _trayIcon = new TrayIcon()
        {
            Icon = new WindowIcon("Assets/avalonia-logo.ico"),
            ToolTipText = "Stickies",
            Menu = menu
        };
    }

    private static void ShowWindow()
    {
        if (Application.Current?.ApplicationLifetime is not IClassicDesktopStyleApplicationLifetime desktop)
        {
            return;
        }

        if (desktop.MainWindow is MainWindow mainWindow)
        {
            mainWindow.Show();
            mainWindow.WindowState = WindowState.Normal;
        }
    }

    private static void LoginToNextcloud()
    {
        Console.WriteLine("login to nextcloud");
    }

    private static void CreateNewStickie()
    {
        Console.WriteLine("new stickie created");

        var newStickie = new Stickie();
        
        newStickie.Show();
    }
// === METHODS ===
}