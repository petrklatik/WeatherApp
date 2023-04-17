using System.Windows;
using WeatherApp.ViewModel;

namespace WeatherApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Set the DataContext to an instance of MainViewModel
            DataContext = new WeatherViewModel();
        }
    }
}
