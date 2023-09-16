using System.Windows;
using WpfApp1.ViewModels;

namespace WpfApp1.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        // You can add the ViewModel here or in the code behind of the App.xaml
        var VM = new WorkOrderViewModel();
        DataContext = VM;
    }
}