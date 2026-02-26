using System.Runtime.CompilerServices;
using System.Text;
using CW10.Logs;
using CW10.Logs.CW10.Logging;
using CW10.Model;
using CW10.Repository;
using CW10.Repository.Interfaces;
using CW10.Service;
using CW10.Service.interfaces;

namespace CW10;

public class UserMenu
{
    private static ILogger _logger = new FileLogger();
    static IUserRepository userRepo = new JsonUserRepository();
    static IPasswordPolicy passwordPolicy = new StrongPasswordPolicy();
    static UserService userService = new UserService(userRepo, passwordPolicy);
    private static IOrderRepository _orderRepository = new JsonOrderRepository();
    private static IProductRepository _productRepository = new JsonProductRepository();
    private static ProductService _productService = new ProductService(_productRepository);
    private static OrderService _orderService = new OrderService(_orderRepository, _productRepository);

    private static void register()
    {
        while (true)
        {
            try
            {
                Console.Write("Enter username:");
                string? name = Console.ReadLine();
                Console.Write("Enter password:");
                string? pass = Console.ReadLine();
                var user = userService.Register(name, pass);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
        }
    }

    private static void Login()
    {
    }

    private static void Login(User user)
    {
        Console.WriteLine("========== welcome" + user.Username + " =========");
        Console.WriteLine("1.order      2.pay       3.show all orders       4.exit");
        switch (Console.ReadLine())
        {
            case "1":
                var allProductDict = new Dictionary<int, Product>();
                var allProducts = _productService.GetAll();
                int i = 0;
                foreach (var product in allProducts)
                {
                    allProductDict.Add(++i, product);
                }

                foreach (var keyValuePair in allProductDict)
                {
                    Product product = keyValuePair.Value;
                    Console.WriteLine($"{keyValuePair.Key} : {product.Name} , {product.Price}");
                }
                
                Console.WriteLine("enter the product");
                while (true)
                {
                    bool isDigit = int.TryParse(Console.ReadLine(), out int choice);
                    if (isDigit && allProductDict.ContainsKey(choice))
                    {
                        Console.Write("how many?");
                        bool isDigitNumber = int.TryParse(Console.ReadLine(),  out int  productnumber);
                        if (!isDigitNumber)
                        {
                            //TODO
                        }
                        var order = _orderService.CreateOrder(user.Id, allProductDict[i],productnumber);
                        _logger.Info("order successfully added");
                        Console.WriteLine("your order added successfully");
                    }
                    else
                    {
                        Console.WriteLine("enter true number");
                    }
                    
                }

                break;
            case "2":
                break;
            case "3":
                var allOrder = _orderService.GetAllOrdersOfUser(user.Id);
                foreach (var order in allOrder)
                {
                    Console.WriteLine(order);
                }

                break;
            case "4":
                MainMenu.Menu();
                break;
            default:
                Console.WriteLine("enter true number");
                break;
        }
    }
}