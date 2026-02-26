using CW10.Model;
using CW10.Repository.Interfaces;
using System.Text.Json;

namespace CW10.Repository
{
    public class JsonOrderRepository : IOrderRepository
    {
        private readonly string _path = "orders.json";

        List<Order> orderList = new();

        private List<Order> Read()
        {
            try
            {
                if (!File.Exists(_path))
                {
                    File.WriteAllText(_path, "[]");
                    return new List<Order>();
                }

                var json = File.ReadAllText(_path);

                if (string.IsNullOrWhiteSpace(json))
                    return new List<Order>();

                var data = JsonSerializer.Deserialize<List<Order>>(json);
                return data ?? new List<Order>();
            }
            catch
            {
                Console.WriteLine($"Error reading {_path}"); //TODO
                return new List<Order>();
            }
        }

        private void Write(List<Order> orders)
        {
            var json = JsonSerializer.Serialize(orders, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(_path, json);
        }


        public void Add(Order order)
        {
            orderList.Add(order);
            Write(orderList);
        }

        public Order? GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetByUserId(Guid id)
        {
            List<Order> orders = new();
            foreach (var order in orderList)
            {
                if (order.UserId == id)
                {
                    orders.Add(order);
                }
            }

            return orders;
        }

        public bool Delete(Guid id)
        {
            var removeAll = orderList.RemoveAll(order => order.Id == id);
            return removeAll > 0;
        }


        public List<Order> GetAll()
        {
            return new List<Order>(orderList);
        }


        public void Update(Order order)
        {
        }
    }
}