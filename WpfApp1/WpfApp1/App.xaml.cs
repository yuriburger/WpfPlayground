using System.Windows;

namespace WpfApp1;

/*
Model: The Model represents the underlying data and business logic of the application.
It encapsulates the data and operations that are necessary to manipulate that data.
Models are typically responsible for data retrieval from databases or external sources,
data manipulation, and validation.

View: The View is responsible for presenting the data to the user and capturing user interactions.
It represents the user interface and includes elements like buttons, text fields, and other visual elements.
In MVVM, the View should be as passive as possible, meaning it should focus on displaying data and forwarding user input to the ViewModel.

ViewModel: The ViewModel acts as an intermediary between the Model and the View.
It contains the presentation logic that transforms data from the Model into a format that can be easily displayed in the View.
The ViewModel also exposes properties and commands that the View binds to.
It allows the View to observe and interact with the data and operations provided by the Model without needing direct knowledge of the Model itself.
*/

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        // You can add the ViewModel here or in the code behind of the view

        /*base.OnStartup(e);
        var window = new MainWindow();
        var VM = new WorkOrderViewModel();
        window.DataContext = VM;
        window.Show();*/
    }
}