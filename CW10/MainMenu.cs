namespace CW10;

public class MainMenu
{
    public static void Menu()
    {
        Console.WriteLine("========== productManagement ==========");
        while (true)
        {
            Console.WriteLine("1.register   2.login");
            switch (Console.ReadLine())
            {
                case "1":
                    break;
                case "2":
                    break;
                default:
                    Console.WriteLine("enter true number");
                    break;
            }
        }
    }
}