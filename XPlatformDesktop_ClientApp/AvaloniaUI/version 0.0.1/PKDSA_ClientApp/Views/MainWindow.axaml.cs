using Avalonia.Controls;
using PKDSA_ClientApp.Helper;

namespace PKDSA_ClientApp.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Closing += OnClosing;
    }

    private void OnClosing(object? sender, WindowClosingEventArgs e)
    {
        if (TORMainOperations.UsingTor == true)
        {
            TORMainOperations.StopTOR();
        }
    }
}
