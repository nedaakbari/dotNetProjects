using CW10.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW10.Repository.Interfaces
{
    public interface IProductRepository
    {
        public void Add(Product product);
        public bool Delete(Guid id);
        public Product? GetById(Guid id);
        public List<Product> GetAll();
        public void Update(Product product);
    }
}
