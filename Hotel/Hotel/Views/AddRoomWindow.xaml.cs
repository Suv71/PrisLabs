using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Hotel.ViewModels.Rooms;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.Views
{
    /// <summary>
    /// Interaction logic for AddRoomWindow.xaml
    /// </summary>
    public partial class AddRoomWindow : Window
    {
        private readonly IServiceScope _scope;

        public AddRoomViewModel ViewModel { get; set; }

        public AddRoomWindow()
        {
            InitializeComponent();

            _scope = AppServices.Instance.ServiceProvider.CreateScope();
            Closed += (sender, e) => _scope.Dispose();

            ViewModel = _scope.ServiceProvider.GetRequiredService<AddRoomViewModel>();
            ViewModel.CloseAction = Close;

            DataContext = ViewModel;
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsValid(((TextBox)sender).Text + e.Text);
        }

        public static bool IsValid(string str)
        {
            return int.TryParse(str, out var i) && i >= 1 && i <= 500;
        }

        private void ComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModel.UpdateCost();
        }
    }
}
