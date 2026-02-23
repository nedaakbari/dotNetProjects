using CW10.Model;
using CW10.Repository.Interfaces;

namespace CW10.Service
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product Create(string name, decimal price, int stock)
        {
            var product = new Product(name, price, stock);
            _productRepository.Add(product);
            return product;
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public void SetStock(Guid id, int stock)
        {
            var product = FindById(id);
            product.SetStock(stock);
            _productRepository.Update(product);
        }

        public void Update(Guid id, string name, decimal price, int stock)
        {
            var foundProduct = FindById(id);
            foundProduct.Name = name;
            foundProduct.Price = price;
            foundProduct.SetStock(stock);
            _productRepository.Update(foundProduct);
        }

        public void Delete(Guid id)
        {
            _productRepository.Delete(id);
        }

        private Product FindById(Guid id)
        {
            return _productRepository.GetById(id) ??
                   throw new KeyNotFoundException($"product with id: {id.ToString()} not found");
        }
    }
}