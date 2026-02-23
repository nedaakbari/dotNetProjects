using CW10.Repository;
using CW10.Repository.Interfaces;
using CW10.Service;
using CW10.Service.interfaces;

namespace CW10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUserRepository userRepo = new JsonUserRepository();
            IPasswordPolicy passwordPolicy = new StrongPasswordPolicy();
            UserService userService = new UserService(userRepo, passwordPolicy);

            var user = userService.Register("nedaa", "ned@Akbari123");
            var users = userService.GetAll();
            userService.Delete(user.Id);
            var user2 = userService.GetAll();

            /*
            IProductRepository productRepo = new JsonProductRepository(...);
            IOrderRepository orderRepo = new JsonOrderRepository(...) ;*/

            //     var userService = new UserService(userRepo);
            //     var productService = new ProductService(productRepo);
            //     var orderService = new OrderService(orderRepo, productRepo);
            // }
        }
    }
}