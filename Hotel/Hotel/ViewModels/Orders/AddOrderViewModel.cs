﻿using Hotel.Commands;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using BLL.Interfaces;

namespace Hotel.ViewModels.Orders
{
    public class AddOrderViewModel : BaseViewModel
    {
        private readonly OrdersTabViewModel _ordersTabViewModel;
        private readonly IRoomService _roomService;
        private readonly IPersonService _personService;

        public Order Order { get; set; }
        public double Cost { get; set; }
        public IEnumerable<Room> Rooms { get; set; }
        public IEnumerable<Person> Persons { get; set; }
        public Action CloseAction { get; set; }
        public SimpleCommand AddOrderCommand { get; set; }

        public AddOrderViewModel(OrdersTabViewModel ordersTabViewModel, IRoomService roomService, IPersonService personService)
        {
            _ordersTabViewModel = ordersTabViewModel;
            _roomService = roomService;
            _personService = personService;

            Cost = 0;

            Rooms = _roomService.GetAll();
            Persons = _personService.GetAll();

            Order = new Order
            {
                Id = Guid.NewGuid(),
                IsActive = false,
                RoomId = Rooms.First().Id,
                Room = Rooms.First(),
                ArrivedDate = DateTime.Now,
                LeavedDate = DateTime.Now
            };

            AddOrderCommand = new SimpleCommand(c => AddOrder());
        }

        private void AddOrder()
        {
            try
            {
                _ordersTabViewModel.OrderService.Add(Order);
                Order.Room = _roomService.GetById(Order.RoomId);
                Order.Person = _personService.GetById(Order.PersonId);
                _ordersTabViewModel.Orders.Add(Order);
                
                CloseAction();
            }
            catch (InvalidOperationException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void UpdateCost()
        {
            if (Order.LeavedDate > Order.ArrivedDate && Order.ArrivedDate != Order.LeavedDate)
            {
                var selectedRoom = _roomService.GetById(Order.RoomId);
                Cost = selectedRoom.Cost * (Order.LeavedDate - Order.ArrivedDate).TotalDays;
                OnPropertyChanged("Cost");
            } 
        }
    }
}
