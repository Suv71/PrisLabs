using BLL.Implementation;
using BLL.Interfaces;
using DAL.Implementation;
using Hotel.Commands;
using Hotel.Views;
using Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Hotel.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private IRoomService _roomService;

        public ObservableCollection<Room> Rooms { get; set; }

        public Room SelectedRoom { get; set; }

        public SimpleCommand OpenAddRoomWindowCommand { get; set; }

        public SimpleCommand DeleteRoomCommand { get; set; }

        public MainViewModel()
        {
            var roomTypeRepository = new LocalRoomTypeRepository();
            _roomService = new RoomService(new LocalRoomRepository(roomTypeRepository));
            Rooms = new ObservableCollection<Room>(_roomService.GetAll());
            OpenAddRoomWindowCommand = new SimpleCommand(c => OpenAddRoomWindow());
            DeleteRoomCommand = new SimpleCommand(c => DeleteRoom());

            foreach (var room in Rooms)
            {
                room.RoomType = roomTypeRepository.GetById(room.RoomTypeId);
            }
        }

        private void OpenAddRoomWindow()
        {
            var addRoomWindow = new AddRoomWindow();
            addRoomWindow.DataContext = new AddRoomViewModel(this, new LocalRoomTypeRepository())
            {
                CloseAction = addRoomWindow.Close
            };
            addRoomWindow.Show();
        }

        private void DeleteRoom()
        {
            if (SelectedRoom != null)
            {
                Rooms.Remove(SelectedRoom);
            }
        }

        private void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
