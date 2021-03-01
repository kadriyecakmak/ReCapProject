using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace Console1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool Durum = true;
            while (Durum == true)
            {
                Console.Write("İşlem Seçiniz --> Ekleme {A} - Silme {D} - Güncelleme {U} - Listeleme {L}  - Araba kiralama {R}= ");
                string islem = Console.ReadLine();
                if (islem == "A")
                {
                    Console.Write("Eklemek istediğiniz nedir? --> Yeni Araç {C} - Marka {B} - Renk {K} - Müşteri ekleme {M} = ");
                    string islemA = Console.ReadLine();
                    if (islemA == "C")
                    {
                        AddCar();
                    }
                    else if (islemA == "B")
                    {
                        AddBrand();

                    }
                    else if (islemA == "K")
                    {
                        AddColor();
                    }
                    else if (islemA == "M")
                    {
                        AddCustomer();
                    }
                    else
                    {
                        Console.WriteLine("Hatalı işlem seçtiniz.");
                    }
                }
                else if (islem == "D")
                {
                    Console.Write("Silmek istediğiniz nedir? --> Araç {C} - Marka {B} - Renk {K} - Müşteri {M} = ");
                    string islemD = Console.ReadLine();
                    if (islemD == "C")
                    {
                        DeleteCar();
                    }
                    else if (islemD == "B")
                    {
                        DeleteBrand();

                    }
                    else if (islemD == "K")
                    {
                        DeleteColor();
                    }
                    else if (islemD == "M")
                    {
                        DeleteCustomer();
                    }
                   
                    else
                    {
                        Console.WriteLine("Hatalı bir işlem seçtiniz");

                    }

                }
                else if (islem == "U")
                {
                    CarManager carManager = new CarManager(new EfCarDal());
                    BrandManager brandManager = new BrandManager(new EfBrandDal());
                    ColorManager colorManager = new ColorManager(new EfColorDal());
                    UpdateTest(carManager, brandManager, colorManager);
                }
                else if (islem == "L")
                {
                    Console.Write("Listelemek istediğiniz nedir? --> Araç {C} - Marka {B} - Renk {K} - Müşteri {M} = ");
                    string islemL = Console.ReadLine();
                    if (islemL == "C")
                    {
                        CarTest();
                    }
                    else if (islemL == "B")
                    {
                        BrandTest();

                    }
                    else if (islemL == "K")
                    {
                        ColorTest();
                    }
                    else if (islemL == "M")
                    {
                        CustomerTest();
                    }
                    else
                    {
                        Console.WriteLine("Hatalı bir işlem seçtiniz");

                    }

                }
                else if (islem == "R")
                {
                    RentACar();
                }
                else
                {
                    Console.WriteLine("Hatalı bir işlem seçtiniz.");
                }
            }
        }

        private static void RentACar()
        {
            Rental _rental = new Rental();
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Console.WriteLine("Araba kiralama işlemi");
            Console.WriteLine("----------------------");
            Console.WriteLine("Rental date =");
            _rental.RentDate = DateTime.Parse(Console.ReadLine());
            var result = rentalManager.Add(_rental);
            if(result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
          


        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("-----------DAILY CAR RENTAL PRICES-----------");
            Console.WriteLine("---------------------------------------------");
            var result = carManager.GetAll();
            if (result.Success == true)
            {
                    foreach (var car in result.Data) //Bu satırların şeklini sen düzeltirsin şimdi ben tek tek uğraşmayım tmm
                    {
                        Console.WriteLine("Brand Id = " + car.BrandId + "  |  "
                            + "Color Id = " + car.ColorId + "  |  "
                            + "Model Year = " + car.ModelYear + "  |  "
                            + "Description = " + car.Descriptions + "  --->  "
                            + "Daily Price = " + car.DailyPrice + " TL");
                    }
                    Console.WriteLine(Messages.CarsListed);
            }
            else
            {
                
             Console.WriteLine(result.Message);
            }
                Console.WriteLine(" ");
            }
        private static void BrandTest()
            {
                BrandManager brandManager = new BrandManager(new EfBrandDal());
                var result = brandManager.GetAll();
                Console.WriteLine("------VECIHLE BRAND ID AND VECIHLE BRAND NAME------");
                Console.WriteLine("---------------------------------------------------");
                if (result.Success == true)
                {
                    foreach (var brand in result.Data)
                    {
                        Console.WriteLine("Brand Id = " + brand.BrandId + "  |  " + "Brand Name = " + brand.BrandName);
                    }
                    Console.WriteLine(Messages.BrandsListed);
                }
                else
                {
                    Console.WriteLine(result.Message);
                }
                Console.WriteLine(" ");
            }
        private static void ColorTest()
            {
                ColorManager colorManager = new ColorManager(new EfColorDal());
                Console.WriteLine("------VECIHLE COLOR ID AND VECIHLE COLOR NAME------");
                Console.WriteLine("---------------------------------------------------");
                var result = colorManager.GetAll();
                if (result.Success == true)
                {
                    foreach (var color in result.Data)
                    {
                        Console.WriteLine("Color Id = " + color.ColorId + "  |  " + "Color Name = " + color.ColorName);
                    }
                    Console.WriteLine(Messages.ColorsListed);
                }
                else
                {
                    Console.WriteLine(result.Message);
                }
                Console.WriteLine(" ");
            }
        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.GetAll();
            Console.WriteLine("------MÜŞTERİ BİLGİ LİSTESİ------");
            Console.WriteLine("---------------------------------------------------");
            if (result.Success == true)
            {
                foreach (var customer in result.Data)
                {
                    Console.WriteLine("Müşteri No = " + customer.UserId + "  |  " + "Şirket Adı = " + customer.CompanyName);
                }
                Console.WriteLine(Messages.CustomersListed);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            Console.WriteLine(" ");
        }
        private static void AddCar()
            {
                Car _car = new Car();
                CarManager carManager = new CarManager(new EfCarDal());
                Console.WriteLine("-------------INSERTION OPERATOR TEST--------------");
                Console.Write("Brand Id = ");
                _car.BrandId = int.Parse(Console.ReadLine());
                Console.Write("Color Id = ");
                _car.ColorId = int.Parse(Console.ReadLine());
                Console.Write("Model Year = ");
                _car.ModelYear = int.Parse(Console.ReadLine());
                Console.Write("DailyPrice = ");
                _car.DailyPrice = int.Parse(Console.ReadLine());
                Console.Write("Descriptions = ");
                _car.Descriptions = Console.ReadLine();
                AddBrand();
                AddColor();
                var result = carManager.Add(_car);
                if (result.Success == true)
                {
                    Console.WriteLine(result.Message);
                }
                else
                {
                    Console.WriteLine(result.Message);
                }
            }
            private static void AddBrand()
            {
                Brand _brand = new Brand();
                BrandManager brandManager = new BrandManager(new EfBrandDal());
                Console.WriteLine("Marka ekleme işlemi testi");
                Console.Write("Marka Adı =");
                _brand.BrandName = Console.ReadLine();
                var result = brandManager.Add(_brand);
                if (result.Success == true)
                {
                    Console.WriteLine(result.Message);
                }
                else
                {
                    Console.WriteLine(result.Message);
                }


            }
            private static void AddColor()
            {

                Color _color = new Color();
                ColorManager colorManager = new ColorManager(new EfColorDal());
                Console.WriteLine("Renk ekleme işlemi Tsti");
                Console.Write("color Adı =");
                _color.ColorName = Console.ReadLine();
                var result = colorManager.Add(_color);
                if (result.Success == true)
                {
                    Console.WriteLine(result.Message);
                }
                else
                {
                    Console.WriteLine(result.Message);
                }

            }

            private static void DeleteCar()
            {
                Car _car = new Car();
                CarManager carManager = new CarManager(new EfCarDal());
                Console.WriteLine("-------------DELETION OPERATOR TEST--------------");
                Console.Write("Car Id = ");
                int carId = int.Parse(Console.ReadLine());
                var result = carManager.Delete(carId);
                if (result.Success == true)
                {
                    Console.WriteLine(result.Message);
                }
                else
                {
                    Console.WriteLine(result.Message);
                }
                Console.ReadKey();
            }

            private static void DeleteColor()
            {
                Color _color = new Color();
                ColorManager colorManager = new ColorManager(new EfColorDal());
                Console.WriteLine("-------------DELETION OPERATOR TEST--------------");
                Console.Write("Color Id = ");
                int colorId = int.Parse(Console.ReadLine());
                var result = colorManager.Delete(colorId);
                if (result.Success == true)
                {
                    Console.WriteLine(result.Message);
                }
                else
                {
                    Console.WriteLine(result.Message);
                }
            }
            private static void DeleteBrand()
            {
                Brand _brand = new Brand();
                BrandManager brandManager = new BrandManager(new EfBrandDal());
                Console.WriteLine("-------------DELETION OPERATOR TEST--------------");
                Console.Write("Brand Id = ");
                int brandId = int.Parse(Console.ReadLine());
                var result = brandManager.Delete(brandId);
                if (result.Success == true)
                {
                    Console.WriteLine(result.Message);
                }
                else
                {
                    Console.WriteLine(result.Message);
                }
                Console.ReadKey();
            }
            private static void UpdateTest(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
            {
                Console.WriteLine("------------UPDATION OPERATOR TEST---------");
                carManager.Update(new Car { Id = 4003, BrandId = 2, ColorId = 2, ModelYear = 2016, DailyPrice = 350, Descriptions = "Ford focus" });
                brandManager.Update(new Brand { BrandId = 1003, BrandName = "Ford" });
                colorManager.Update(new Color { ColorId = 1003, ColorName = "Pink" });
            }
            private static void AddCustomer()
            {
                Customer _customer = new Customer();
                CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
                Console.WriteLine("-------------Yeni Müşteri Ekleme İşlemi-------------");
                Console.Write("Şirket Adı = ");
                _customer.CompanyName = Console.ReadLine();
                var result = customerManager.Add(_customer);
                if (result.Success == true)
                {
                    Console.WriteLine(result.Message);
                }
                else
                {
                    Console.WriteLine(result.Message);
                }
            }
            private static void DeleteCustomer()
            {
                Customer _customer = new Customer();
                CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
                Console.WriteLine("-------------Müşteri Silme işlemi--------------");
                Console.Write("Customer Id = ");
                int customerId = int.Parse(Console.ReadLine());
                var result = customerManager.Delete(customerId);
                if (result.Success == true)
                {
                    Console.WriteLine(result.Message);
                }
                else
                {
                    Console.WriteLine(result.Message);
                }
            }
        }
    }
