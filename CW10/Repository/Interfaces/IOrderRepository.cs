using CW10.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW10.Repository.Interfaces
{
    public interface IOrderRepository
    {
        public void Add(Order order);
        public List<Order> GetAll();
        public Order? GetById(Guid id);
        public List<Order> GetByUserId(Guid userId);
        public void Update(Order order);
        public bool Delete(Guid id);
    }
}