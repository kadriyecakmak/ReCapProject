using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace Console1
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("-----------DAILY CAR RENTAL PRICES-----------");
            Console.WriteLine("---------------------------------------------");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Brand Id = " + car.BrandId + "  |  "
                    + "Color Id = " + car.ColorId + "  |  "
                    + "Model Year = " + car.ModelYear + "  |  "
                    + "Description = " + car.Descriptions + "  --->  "
                    + "Daily Price = " + car.DailyPrice + " TL");
            }
            Console.WriteLine(" ");

            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.WriteLine("------VECIHLE BRAND ID AND VECIHLE BRAND NAME------");
            Console.WriteLine("---------------------------------------------------");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("Brand Id = " + brand.BrandId + "  |  " + "Brand Name = " + brand.BrandName);
            }
            Console.WriteLine(" ");

            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine("------VECIHLE COLOR ID AND VECIHLE COLOR NAME------");
            Console.WriteLine("---------------------------------------------------");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("Color Id = " + color.ColorId + "  |  " + "Color Name = " + color.ColorName);
            }
            Console.WriteLine(" ");
        }
    }
}
