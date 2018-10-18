using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Hotel.ViewModels.Rooms;

namespace Hotel.Views
{
    /// <summary>
    /// Interaction logic for EditRoomWindow.xaml
    /// </summary>
    public partial class EditRoomWindow : Window
    {
        public EditRoomWindow()
        {
            InitializeComponent();
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
            if (DataContext is EditRoomViewModel viewModel) viewModel.UpdateCost();
        }
    }
}
