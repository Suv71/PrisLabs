using Hotel.ViewModels.Orders;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.Views
{
    /// <summary>
    /// Interaction logic for AddOrderWindow.xaml
    /// </summary>
    public partial class AddOrderWindow : Window
    {
        private readonly IServiceScope _scope;

        public AddOrderViewModel ViewModel { get; set; }

        public AddOrderWindow()
        {
            InitializeComponent();

            _scope = AppServices.Instance.ServiceProvider.CreateScope();
            Closed += (sender, e) => _scope.Dispose();

            ViewModel = _scope.ServiceProvider.GetRequiredService<AddOrderViewModel>();
            ViewModel.CloseAction = Close;

            DataContext = ViewModel;
        }

        private void ComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModel.UpdateCost();
        }
    }
}
