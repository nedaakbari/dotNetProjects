using CW10.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW10.Repository.Interfaces
{
    internal interface IOrderRepository
    {
        void Add(Order order);
        List<Order> GetAll();
        Order? GetById(Guid id);
        List<Order> GetByUserId(Guid userId);
        void Update(Order order);
        void Delete(Guid id);
    }
}
