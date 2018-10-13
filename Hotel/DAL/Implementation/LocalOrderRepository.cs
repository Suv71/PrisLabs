using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementation
{
    public class LocalOrderRepository : IOrderRepository
    {
        private IEnumerable<Order> _orders;

        public LocalOrderRepository()
        {
            _orders = new List<Order>();
        }

        public IEnumerable<Order> GetAll()
        {
            return _orders;
        }
    }
}
