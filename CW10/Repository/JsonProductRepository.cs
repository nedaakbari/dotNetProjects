using System.Text.Json;
using CW10.Model;
using CW10.Repository.Interfaces;

namespace CW10.Repository
{
    public class JsonProductRepository : IProductRepository //todo explicitly ????
    {
        private readonly string _path = "products.json";
        List<Product> productList;

        public JsonProductRepository()
        {
            productList = Read();
        }

        private List<Product> Read()
        {
            try
            {
                if (!File.Exists(_path))
                {
                    File.WriteAllText(_path, "[]");
                    return new List<Product>();
                }

                var json = File.ReadAllText(_path);

                if (string.IsNullOrWhiteSpace(json))
                    return new List<Product>();

                var data = JsonSerializer.Deserialize<List<Product>>(json);
                return data ?? new List<Product>();
            }
            catch
            {
                Console.WriteLine("Error reading products.json"); //TODO
                return new List<Product>();
            }
        }

        private void Write(List<Product> products)
        {
            var json = JsonSerializer.Serialize(products, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(_path, json);
        }


        public void Add(Product product)
        {
            productList.Add(product);
            Write(productList);
        }

        public bool Delete(Guid id)
        {
            var removeAll = productList.RemoveAll(product => product.Id == id);
            return removeAll > 0;
        }

        public List<Product> GetAll()
        {
            return productList;
        }

        public Product? GetById(Guid id)
        {
            foreach (var product in productList)
            {
                if (product.Id == id)
                {
                    return product;
                }
            }

            return null;
        }

        public void Update(Product product)
        {
            foreach (var item in productList)
            {
                if (item.Id == product.Id)
                {
                    item.Price = product.Price;
                    item.Stock = product.Stock;
                    Write(productList);
                }
            }
        }
    }
}