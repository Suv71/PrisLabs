using System.Collections.ObjectModel;
using BLL.Implementation;
using BLL.Interfaces;
using DAL.Interfaces;
using Hotel.Commands;
using Hotel.Views;
using Model;

namespace Hotel.ViewModels.Rooms
{
    public class RoomsTabViewModel : BaseViewModel
    {
        private readonly IRoomTypeRepository _roomTypesRepository;
        private Room _selectedRoom;

        public IRoomService RoomService;

        public ObservableCollection<Room> Rooms { get; set; }

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

        public RoomsTabViewModel(IRoomRepository roomsRepository, IRoomTypeRepository roomTypesRepository)
        {
            _roomTypesRepository = roomTypesRepository;
            RoomService = new RoomService(roomsRepository);
            Rooms = new ObservableCollection<Room>(RoomService.GetAll());
            OpenAddRoomWindowCommand = new SimpleCommand(c => OpenAddRoomWindow());
            OpenEditRoomWindowCommand = new SimpleCommand(c => OpenEditRoomWindow());
            DeleteRoomCommand = new SimpleCommand(c => DeleteRoom());

            foreach (var room in Rooms)
            {
                room.RoomType = roomTypesRepository.GetById(room.RoomTypeId);
            }
        }

        

        private void OpenAddRoomWindow()
        {
            var addRoomWindow = new AddRoomWindow();
            addRoomWindow.DataContext = new AddRoomViewModel(this, _roomTypesRepository)
            {
                CloseAction = addRoomWindow.Close
            };
            addRoomWindow.Show();
        }

        private void OpenEditRoomWindow()
        {
            if (SelectedRoom != null)
            {
                var editRoomWindow = new EditRoomWindow();
                editRoomWindow.DataContext = new EditRoomViewModel(this, _roomTypesRepository)
                {
                    EditedRoom = new Room
                    {
                        Id = SelectedRoom.Id,
                        Capacity = SelectedRoom.Capacity,
                        Cost = SelectedRoom.Cost,
                        Number = SelectedRoom.Number,
                        RoomTypeId = SelectedRoom.RoomTypeId,
                        RoomType = SelectedRoom.RoomType
                    },
                    CloseAction = editRoomWindow.Close
                };
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