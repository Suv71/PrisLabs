using System;
using System.Collections.Generic;
using System.Windows;
using DAL.Interfaces;
using Hotel.Commands;
using Model;

namespace Hotel.ViewModels.Rooms
{
    public class AddRoomViewModel : BaseViewModel
    {
        private readonly RoomsTabViewModel _roomTabViewModel;
        private readonly IRoomTypeRepository _roomTypeRepository;

        public Room Room { get; set; }
        public IEnumerable<RoomType> RoomTypeValues { get; set; }
        public IEnumerable<int> CapacityValues { get; set; }
        public Action CloseAction { get; set; }
        public SimpleCommand AddRoomCommand { get; set; }

        public AddRoomViewModel(RoomsTabViewModel roomTabViewModel, IRoomTypeRepository roomTypeRepository)
        {
            _roomTabViewModel = roomTabViewModel;
            _roomTypeRepository = roomTypeRepository;

            Room = new Room
            {
                Number = 1
            };
            RoomTypeValues = _roomTypeRepository.GetAll();
            CapacityValues = new List<int>
            {
                1, 2, 3, 4
            };

            AddRoomCommand = new SimpleCommand(c => AddRoom());
        }

        private void AddRoom()
        {
            var rooms = _roomTabViewModel.Rooms;
            try
            {
                _roomTabViewModel.RoomService.Add(Room);
                rooms.Add(Room);
                CloseAction();
            }
            catch(InvalidOperationException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void UpdateCost()
        {
            var selectedRoomType = _roomTypeRepository.GetById(Room.RoomTypeId);
            Room.Cost = Room.Capacity * selectedRoomType.BaseCost;
            Room.RoomType = selectedRoomType;
            OnPropertyChanged("Room");
        }
    }
}
