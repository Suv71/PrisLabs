using Hotel.Commands;
using Model;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModels
{
    public class AddRoomViewModel : INotifyPropertyChanged
    {
        private MainViewModel _mainViewModel;

        public Room Room { get; set; }

        public IEnumerable<RoomTypes> RoomTypeValues { get; set; }
        public IEnumerable<int> CapacityValues { get; set; }

        private SimpleCommand _addRoomCommand;
        public SimpleCommand AddRoomCommand => _addRoomCommand ??
                    (_addRoomCommand = new SimpleCommand(
                        obj =>
                        {
                            _mainViewModel.Rooms.Add(Room);
                            
                        }));

        public AddRoomViewModel(MainViewModel mainViewModel)
        {
            Room = new Room();
            _mainViewModel = mainViewModel;
            RoomTypeValues = new List<RoomTypes>()
            {
                RoomTypes.Standard,
                RoomTypes.SemiLuxe,
                RoomTypes.Luxe
            };
            CapacityValues = new List<int>()
            {
                1, 2, 3, 4
            };
        }

        private void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
