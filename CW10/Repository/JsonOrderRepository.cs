/*
using CW10.Model;
using CW10.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CW10.Repository
{
    internal class JsonOrderRepository : IOrderRepository
    {
        List<Order> orderList = new List<Order>();

        private readonly string _filePath = "Data/orders.json";

        //public JsonOrderRepository()
        //{
        //    FileExist();
        //}


        private void FileExist()
        {
            Directory.CreateDirectory("Data");
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "[]");
            }
        }

        private void WriteAll(List<Order> orders)
        {
            File.WriteAllText(_filePath, JsonSerializer.Serialize(orders));
        }

        public void Add(Order order)
        {
            orderList.Add(order);
            //try
            //{
            //    var orders = GetAll();
            //    orders.Add(order);
            //    WriteAll(orders);

            //}
            //catch (Exception ex)
            //{
            //}

        }

        public bool Remove(Guid id)
        {
            //var orderList = GetAll();
            //foreach (var order in orderList)
            //{
            //    if (order.Id == id)
            //    {
            //        orderList.Remove(order);
            //        WriteAll(orderList);
            //        return true;
            //    }
            //}
            return false;
        }

        public List<Order> GetAll()
        {
            return orderList;
            //return JsonSerializer.Deserialize<List<Order>>(File.ReadAllText(_filePath));
        }

        public Order? GetById(Guid id)
        {
            //var orderList = GetAll();
            //foreach (var order in orderList)
            //{
            //    if (order.Id == id)
            //    {
            //        return order;
            //    }
            //}
            return null;
        }


        public void Update(Order order)
        {
            //var orderList = GetAll();
            //foreach (var item in orderList)
            //{
            //    if (item.Id == order.Id)
            //    {
            //        //TODO
            //        WriteAll(orderList);
            //    }
            //}
        }

        public void Update(Guid id, string password)
        {
            //var userList = JsonSerializer.Deserialize<List<User>>(File.ReadAllText(_filePath));
            //foreach (var item in userList)
            //{
            //    if (item.Id == id)
            //    {
            //        item.Password = password;

            //        File.WriteAllText(_filePath, JsonSerializer.Serialize(userList));
            //    }
            //}
        }

    }
}
*/




