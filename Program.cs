using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace OverTheHorizon
{
    class Program
    {
        static List<Product> productList = new List<Product>();
        static List<City> cityList = new List<City>();
        static List<Own> ownList = new List<Own>();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Over The Horizon");
            Run();

            var user = new User();

            var r = true; ;
            while(r)
            {

                Console.WriteLine($"1.Status");
                Console.WriteLine($"2.Move");
                Console.WriteLine($"3.Buy");
                Console.WriteLine($"4.Sell");
                Console.WriteLine($"5.Exit");
                switch(Console.ReadLine())
                {
                    case "1":
                        Status(user, ownList);
                        break;
                    case "2":
                        Move(user);
                        break;
                    case "3":
                        Buy(user, ownList, productList);
                        break;
                    case "5":
                        r = false;
                        break;
                }
            }


            Status(user, ownList);
            Move(user);
            Buy(user, ownList, productList);
        }
        static void Run()
        {

            productList = File.ReadAllLines(@"Product.csv").Select(x => {
                var parts = x.Split(',');
                return new Product()
                {
                    Id = Convert.ToInt32(parts[0].Trim()),
                    CityId = Convert.ToInt32(parts[1].Trim()),
                    Name = parts[2].Trim(),
                    Price = Convert.ToInt32(parts[3].Trim()),
                    PriceIndex = (float)Convert.ToDouble(parts[4].Trim()),
                    IsBuy = Convert.ToBoolean(parts[5].Trim()),
                    IsSell = Convert.ToBoolean(parts[6].Trim())
                };
            }).ToList();

            cityList = File.ReadAllLines(@"City.csv").Select(x => {
                var parts = x.Split(',');
                return new City()
                {
                    Id = Convert.ToInt32(parts[0].Trim()),
                    Name = parts[1].Trim(),
                    PriceIndex = (float)Convert.ToDouble(parts[2].Trim()),
                    X = Convert.ToInt32(parts[3].Trim()),
                    Y = Convert.ToInt32(parts[4].Trim()),
                    IsMarket = Convert.ToBoolean(parts[5].Trim())
                };
            }).ToList();



            ownList = File.ReadAllLines(@"Own.csv").Select(x => {
                var parts = x.Split(',');
                return new Own()
                {
                    Id = Convert.ToInt32(parts[0].Trim()),
                    UserId = Convert.ToInt32(parts[1].Trim()),
                    ProductId = Convert.ToInt32(parts[2].Trim()),
                    Name = parts[3].Trim(),
                    Value = Convert.ToInt32(parts[4].Trim())
                };
            }).ToList();
        }

        static void Status(User user, List<Own> own)
        {
            Console.WriteLine($"----------------Status-----------------");
            Console.WriteLine($"ID : {user.Id}, CITY ID : {user.CityId}, MONEY : {user.Money}");
            Console.WriteLine($"---------------------------------------");
            Console.WriteLine($"-----------------OWNS------------------");
            foreach (var o in own.Where(e => e.UserId == user.Id))
            {
                Console.WriteLine($"ID : {o.Id}, CITY ID : {o.Name}, MONEY : {o.Value}");
            }
            Console.WriteLine($"---------------------------------------");
        }
        static User Move(User user)
        {
            Console.WriteLine($"----------------Move-----------------");
            var pos = Console.ReadLine();
            user.CityId = Convert.ToInt32(pos);
            Console.WriteLine($"ID : {user.Id}, CITY ID : {user.CityId}, MONEY : {user.Money}");
            Console.WriteLine($"---------------------------------------");
            return user;
        }

        static List<Own> Buy(User user, List<Own> own, List<Product> product)
        {
            Console.WriteLine($"----------------BUY------------------");
            foreach (var p in product.Where(e => e.CityId == user.CityId))
            {
                Console.WriteLine($"ID : {p.Id}, NAME : {p.Name}, PRICE : {p.Price}");
            }
            Console.Write("What buy?");
            var w = Console.ReadLine();
            Console.Write("How buy?");
            var h = Console.ReadLine();

            var price = product.Where(e => e.CityId == user.CityId && e.Id == Convert.ToInt32(w))
                .Select(e => new { e.Price }).Take(1)
                .GroupBy(e => e.Price)
                .Sum(e => e.Key); 

            user.Money = user.Money - price * Convert.ToInt32(h);

            var maxId = own.Select(e => new { e.Id }).Max().Id;
            var value = own
                .Where(e => e.UserId == user.Id && e.ProductId == Convert.ToInt32(w))
                .OrderByDescending(e => e.Id)
                .Take(1)
                .GroupBy(e => e.Value)
                .Sum(e=>e.Key);

            var o = new Own
            {
                Id = maxId,
                UserId = user.Id,
                ProductId = Convert.ToInt32(w),
                Name = "",
                Value = value + Convert.ToInt32(h)
            };

            ownList.Add(o);

            return own;
        }
    }
}