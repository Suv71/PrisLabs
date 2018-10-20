using System;
using System.Collections.Generic;
using System.Windows;
using DAL.Interfaces;
using Hotel.Commands;
using Model;

namespace Hotel.ViewModels.Rooms
{
    public class EditRoomViewModel : BaseViewModel
    {
        private readonly RoomsTabViewModel _roomTabViewModel;
        private readonly IRoomTypeRepository _roomTypeRepository;

        public Room EditedRoom { get; set; }
        public IEnumerable<RoomType> RoomTypeValues { get; set; }
        public IEnumerable<int> CapacityValues { get; set; }
        public Action CloseAction { get; set; }
        public SimpleCommand UpdateRoomCommand { get; set; }

        public EditRoomViewModel(RoomsTabViewModel roomTabViewModel, IRoomTypeRepository roomTypeRepository)
        {
            _roomTabViewModel = roomTabViewModel;
            _roomTypeRepository = roomTypeRepository;

            RoomTypeValues = _roomTypeRepository.GetAll();
            CapacityValues = new List<int>
            {
                1, 2, 3, 4
            };

            UpdateRoomCommand = new SimpleCommand(c => UpdateRoom());
        }
 
        void UpdateRoom()
        {
            _roomTabViewModel.RoomService.Update(EditedRoom.Id, EditedRoom);
            var index = _roomTabViewModel.Rooms.IndexOf(_roomTabViewModel.SelectedRoom);
            _roomTabViewModel.Rooms[index] = EditedRoom;
            _roomTabViewModel.SelectedRoom = EditedRoom;
            CloseAction();
        }

        public void UpdateCost()
        {
            var selectedRoomType = _roomTypeRepository.GetById(EditedRoom.RoomTypeId);
            EditedRoom.Cost = EditedRoom.Capacity * selectedRoomType.BaseCost;
            EditedRoom.RoomType = selectedRoomType;
            OnPropertyChanged("EditedRoom");
        }
    }
}