using System.Windows;
using Hotel.ViewModels.Orders;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.Views
{
    /// <summary>
    /// Interaction logic for EditOrderWindow.xaml
    /// </summary>
    public partial class EditOrderWindow : Window
    {
        private readonly IServiceScope _scope;

        public EditOrderViewModel ViewModel { get; set; }

        public EditOrderWindow()
        {
            InitializeComponent();

            _scope = AppServices.Instance.ServiceProvider.CreateScope();
            Closed += (sender, e) => _scope.Dispose();

            ViewModel = _scope.ServiceProvider.GetRequiredService<EditOrderViewModel>();
            ViewModel.CloseAction = Close;

            DataContext = ViewModel;
        }
    }
}
