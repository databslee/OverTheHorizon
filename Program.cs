using System;
using System.Collections.Generic;

namespace OverTheHorizon
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello The Sea");
            var product = new Product("dd",10);
            var run = new Run();
            var user = new User();
            run.Start(user);
        }
    }

    class User
    {
        public int pos = 1;
        public int money = 1000;
        public int product = 0;
        public Dictionary<string, int> dic = new Dictionary<string, int>();
    }

    class Product
    {
        public Product(string sName, int iPrice)
        {
            name = sName;
            price = iPrice;
        }
        public string name;
        public int price;
    }

    class Run
    {
        public void Start(User user)
        {
            var session = true;
            while (session)
            {
                Console.WriteLine("Command ?");
                var Command = Console.ReadLine();
                switch (Command)
                {
                    case "1": // Status
                        Status(user);
                        break;
                    case "2": // Move
                        Move(user);
                        break;
                    case "3": // Buy
                        Buy(user);
                        break;
                    case "4": // Sell
                        Sell(user);
                        break;
                    case "5": // Exit
                        session = false;
                        break;
                }
            }
        }

        public void Status(User user)
        {
            Console.WriteLine($@"{user.pos} {user.money} {user.product}");
        }

        public void Move(User user)
        {
            Console.WriteLine("Where ?");
            var Command = Console.ReadLine();
            user.pos = Convert.ToInt32(Command);
            Status(user);
        }

        public void Buy(User user)
        {
            Console.WriteLine("How Buy ?");
            var Command = Convert.ToInt32(Console.ReadLine());
            switch (user.pos)
            {
                case 1:
                    user.product = user.product + Command;
                    user.money = user.money - 5 * user.product;
                    break;
                case 2:
                    user.product = user.product + Command;
                    user.money = user.money - 3 * user.product;
                    break;
                case 3:
                    user.product = user.product + Command;
                    user.money = user.money - 1 * user.product;
                    break;
            }
            Status(user);
        }

        public void Sell(User user)
        {
            Console.WriteLine("How Sell ?");
            var Command = Convert.ToInt32(Console.ReadLine());
            switch (user.pos)
            {
                case 1:
                    user.product = user.product - Command;
                    user.money = user.money + 1 * user.product;
                    break;
                case 2:
                    user.product = user.product - Command;
                    user.money = user.money + 3 * user.product;
                    break;
                case 3:
                    user.product = user.product - Command;
                    user.money = user.money + 1 * user.product;
                    break;
            }
            Status(user);
        }
    }
}
