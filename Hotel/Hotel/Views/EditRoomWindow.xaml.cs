using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Hotel.ViewModels.Rooms;
using Microsoft.Extensions.DependencyInjection;
using Model;

namespace Hotel.Views
{
    /// <summary>
    /// Interaction logic for EditRoomWindow.xaml
    /// </summary>
    public partial class EditRoomWindow : Window
    {
        private readonly IServiceScope _scope;

        public EditRoomViewModel ViewModel { get; set; }

        public EditRoomWindow()
        {
            InitializeComponent();

            _scope = AppServices.Instance.ServiceProvider.CreateScope();
            Closed += (sender, e) => _scope.Dispose();

            ViewModel = _scope.ServiceProvider.GetRequiredService<EditRoomViewModel>();
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
