using BLL.Implementation;
using BLL.Interfaces;
using DAL.Implementation;
using Hotel.Commands;
using Hotel.Views;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private IRoomService _roomService;

        public ObservableCollection<Room> Rooms { get; set; }

        private SimpleCommand _addRoomCommand;
        public SimpleCommand AddRoomCommand => _addRoomCommand ??
                    (_addRoomCommand = new SimpleCommand(
                        obj =>
                        {
                            var addRoomWindow = new AddRoomWindow();
                            addRoomWindow.DataContext = new AddRoomViewModel(this);
                            addRoomWindow.Show();
                        }));

        public MainViewModel()
        {
            _roomService = new RoomService(new LocalRoomRepository(new LocalRoomTypeRepository()));
            Rooms = new ObservableCollection<Room>(_roomService.GetAll());
        }

        private void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
