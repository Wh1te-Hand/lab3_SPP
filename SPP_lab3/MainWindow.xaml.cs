using WindowHandler;
using System.Windows;
using System.Windows.Input;

namespace SPP_lab3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var viewModel = new WindowView();
            DataContext = viewModel;
            var commandBinding = new CommandBinding();
            commandBinding.Command = ApplicationCommands.Open;
            commandBinding.Executed += viewModel.LoadAssembly;
            menuItem_Open.CommandBindings.Add(commandBinding);
        }
    }
}
