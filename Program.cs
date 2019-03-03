using System;
using System.Collections.Generic;

namespace OverTheHorizon
{
    class Program
    {
        static Position One_Apple;
        static Position Two_Apple;
        static Position Three_Apple;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Over The Horizon");

            SetProduct();
            var run = new Run();
            var user = new User();

            var User_Product = new Dictionary<string, int>();
            User_Product.Add("사과", 0);
            User_Product.Add("바나나", 0);
            User_Product.Add("복숭아", 0);

            user.productDic = User_Product;
            run.Start(user);
        }

        static void SetProduct()
        {
            var One_Product = new Dictionary<string, int>();
            One_Product.Add("사과", 10);
            One_Product.Add("바나나", 20);
            One_Product.Add("복숭아", 30);

            var Two_Product = new Dictionary<string, int>();
            Two_Product.Add("사과", 15);
            Two_Product.Add("바나나", 30);
            Two_Product.Add("복숭아", 10);

            var Three_Product = new Dictionary<string, int>();
            Three_Product.Add("사과", 25);
            Three_Product.Add("바나나", 10);
            Three_Product.Add("복숭아", 20);


            One_Apple = new Position(1, One_Product);
            Two_Apple = new Position(2, Two_Product);
            Three_Apple = new Position(3, Three_Product);
        }
    }

    class Position
    {
        public Position(int iPos, Dictionary<string, int> dProductDic)
        {
            iPos = pos;
            dProductDic = productDic;
        }
        public int pos;
        public Dictionary<string, int> productDic = new Dictionary<string, int>();
    }

    class User
    {
        public int pos = 1;
        public int money = 1000;
        public int product = 0;
        public Dictionary<string, int> productDic = new Dictionary<string, int>();
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
            Console.WriteLine($@"위치 : {user.pos} 돈 : {user.money} 상품 : {user.product}");
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
