using System;
using System.Collections.Generic;
using BLL.Interfaces;
using Hotel.Commands;
using Model;

namespace Hotel.ViewModels.Rooms
{
    public class EditRoomViewModel : BaseViewModel
    {
        private readonly RoomsTabViewModel _roomTabViewModel;
        private readonly IRoomTypeService _roomTypeService;

        public Room EditedRoom { get; set; }
        public IEnumerable<RoomType> RoomTypeValues { get; set; }
        public IEnumerable<int> CapacityValues { get; set; }
        public Action CloseAction { get; set; }
        public SimpleCommand UpdateRoomCommand { get; set; }

        public EditRoomViewModel(RoomsTabViewModel roomTabViewModel, IRoomTypeService roomTypeService)
        {
            _roomTabViewModel = roomTabViewModel;
            _roomTypeService = roomTypeService;

            RoomTypeValues = roomTypeService.GetAll();
            CapacityValues = new List<int>
            {
                1, 2, 3, 4
            };
            EditedRoom = new Room
            {
                Id = _roomTabViewModel.SelectedRoom.Id,
                Capacity = _roomTabViewModel.SelectedRoom.Capacity,
                Cost = _roomTabViewModel.SelectedRoom.Cost,
                Number = _roomTabViewModel.SelectedRoom.Number,
                RoomTypeId = _roomTabViewModel.SelectedRoom.RoomTypeId,
                RoomType = _roomTabViewModel.SelectedRoom.RoomType
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
            var selectedRoomType = _roomTypeService.GetById(EditedRoom.RoomTypeId);
            EditedRoom.Cost = EditedRoom.Capacity * selectedRoomType.BaseCost;
            EditedRoom.RoomType = selectedRoomType;
            OnPropertyChanged("EditedRoom");
        }
    }
}