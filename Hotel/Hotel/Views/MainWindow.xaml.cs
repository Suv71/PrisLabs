using Hotel.ViewModels;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IServiceScope _scope;

        public MainWindow()
        {
            InitializeComponent();

            _scope = AppServices.Instance.ServiceProvider.CreateScope();
            Closed += (sender, e) => _scope.Dispose();

            DataContext = _scope.ServiceProvider.GetRequiredService<MainViewModel>();
        }
    }
}
