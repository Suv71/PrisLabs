using Hotel.Commands;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using DAL.Interfaces;

namespace Hotel.ViewModels
{
    public class AddRoomViewModel : INotifyPropertyChanged
    {
        private readonly MainViewModel _mainViewModel;
        private readonly IRoomTypeRepository _roomTypeRepository;

        public Room Room { get; set; }
        public IEnumerable<RoomType> RoomTypeValues { get; set; }
        public IEnumerable<int> CapacityValues { get; set; }
        public Action CloseAction { get; set; }
        public SimpleCommand AddRoomCommand { get; set; }

        public AddRoomViewModel(MainViewModel mainViewModel, IRoomTypeRepository roomTypeRepository)
        {
            _mainViewModel = mainViewModel;
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
            var rooms = _mainViewModel.Rooms;
            if (rooms.All(r => r.Number != Room.Number))
            {
                Room.RoomType = _roomTypeRepository.GetById(Room.RoomTypeId);
                rooms.Add(Room);
            }
            else
            {
                MessageBox.Show("Комната с таким номером уже существует!");
                return;
            }
            CloseAction();
        }

        public void UpdateCost()
        {
            var selectedRoomType = _roomTypeRepository.GetById(Room.RoomTypeId);
            Room.Cost = Room.Capacity * selectedRoomType.BaseCost;
            OnPropertyChanged("Room");
        }

        private void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
