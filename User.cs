using System;
namespace OverTheHorizon
{
    public class User
    {
        public User(int id = 1, int cityId = 1, int money = 3000)
        {
            Id = id;
            CityId = cityId;
            Money = money;
        }

        public int Id { get; set; }
        public int CityId { get; set; }
        public int Money { get; set; }
    }
}
