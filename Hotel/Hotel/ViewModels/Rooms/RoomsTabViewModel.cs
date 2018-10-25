using System.Collections.ObjectModel;
using BLL.Interfaces;
using Hotel.Commands;
using Hotel.Views;
using Model;

namespace Hotel.ViewModels.Rooms
{
    public class RoomsTabViewModel : BaseViewModel
    {
        private Room _selectedRoom;

        public ObservableCollection<Room> Rooms { get; set; }

        public IRoomService RoomService { get; }

        public Room SelectedRoom
        {
            get => _selectedRoom;
            set
            {
                _selectedRoom = value;
                OnPropertyChanged("SelectedRoom");
            }
        }

        public SimpleCommand OpenAddRoomWindowCommand { get; set; }

        public SimpleCommand OpenEditRoomWindowCommand { get; set; }

        public SimpleCommand DeleteRoomCommand { get; set; }

        public RoomsTabViewModel(IRoomService roomService, IRoomTypeService roomTypesService)
        {
            RoomService = roomService;
            Rooms = new ObservableCollection<Room>(RoomService.GetAll());
            OpenAddRoomWindowCommand = new SimpleCommand(c => OpenAddRoomWindow());
            OpenEditRoomWindowCommand = new SimpleCommand(c => OpenEditRoomWindow());
            DeleteRoomCommand = new SimpleCommand(c => DeleteRoom());

            foreach (var room in Rooms)
            {
                room.RoomType = roomTypesService.GetById(room.RoomTypeId);
            }
        }

        

        private void OpenAddRoomWindow()
        {
            var addRoomWindow = new AddRoomWindow();
            addRoomWindow.Show();
        }

        private void OpenEditRoomWindow()
        {
            if (SelectedRoom != null)
            {
                var editRoomWindow = new EditRoomWindow();
                editRoomWindow.Show();
            }
        }

        private void DeleteRoom()
        {
            if (SelectedRoom != null)
            {
                RoomService.Delete(SelectedRoom.Id);
                Rooms.Remove(SelectedRoom);
            }
        }
    }
}