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
        public static void Main(string[] args)
        {
            bool Durum = true;
            while (Durum == true)

            {
                Console.Write("İşlem Seçiniz --> Ekleme {A} - Silme {D} - Güncelleme {U} - Listeleme {L} = ");
                string islem = Console.ReadLine();
                if (islem == "A")
                {
                    Console.Write("Eklemek istediğiniz nedir? --> Yeni Araç {C} - Marka {B} - Renk {K} - Müşteri  {M} -Kullanıcı{U} - Kiralama {R} = ");
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
                    else if (islemA == "R")
                    {
                        RentalAdd();
                    }
                    else if (islemA == "U")
                    {
                        UserAdd();
                    }
                    else
                    {
                        Console.WriteLine("Hatalı işlem seçtiniz.");
                    }
                }
                else if (islem == "D")
                {
                    Console.Write("Silmek istediğiniz nedir? --> Araç {C} - Marka {B} - Renk {K} - Müşteri {M} - Kullanıcı {U} - Kira İptal{R} = ");
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
                    else if (islemD == "U")
                    {
                        UserDelete();
                    }
                    else if (islemD == "R")
                    {
                        RentalDelete();
                    }

                    else
                    {
                        Console.WriteLine("Hatalı bir işlem seçtiniz");

                    }

                }
                else if (islem == "U")
                {
                    Console.Write("Güncellemek istediğiniz nedir? --> Araç {C} - Marka {B} - Renk {K} - Kullanıcı {U} - Müşteri {M} = ");
                    string islemU = Console.ReadLine();
                    if (islemU == "C")
                    {
                        CarManager carManager = new CarManager(new EfCarDal());
                        CarUpdate(carManager);
                    }
                    else if (islemU == "B")
                    {
                        BrandManager brandManager = new BrandManager(new EfBrandDal());
                        BrandUpdate(brandManager);
                    }
                    else if (islemU == "K")
                    {
                        ColorManager colorManager = new ColorManager(new EfColorDal());
                        ColorUpdate(colorManager);
                    }
                    else if (islemU == "U")
                    {
                        UserManager userManager = new UserManager(new EfUserDal());
                        UserUpdate(userManager);
                    }
                    else if (islemU == "M")
                    {
                        CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
                        CustomerUpdate(customerManager);
                    }
                    else
                    {
                        Console.WriteLine("Hatalı bir işlem seçtiniz.");
                    }

                }
                else if (islem == "L")
                {
                    Console.Write("Listelemek istediğiniz nedir? --> Araç {C} - Marka {B} - Renk {K} - Kullanıcı {U} - Müşteri {M} - Kiralı araçlar {R} = ");
                    string islemL = Console.ReadLine();
                    if (islemL == "C")
                    {
                        CarList();
                    }
                    else if (islemL == "B")
                    {
                        BrandList();
                    }
                    else if (islemL == "K")
                    {
                        ColorList();
                    }
                    else if (islemL == "U")
                    {
                        UserList();
                    }
                    else if (islemL == "M")
                    {
                        CustomerList();
                    }
                    else if (islemL == "R")
                    {
                        RentalList();
                    }
                    else
                    {
                        Console.WriteLine("Hatalı bir işlem seçtiniz.");
                    }
                }
                else
                {
                    Console.WriteLine("Hatalı bir işlem seçtiniz.");
                }
            }
        }

        public static void CustomerList()
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

        public static void RentalList()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetAll();
            Console.WriteLine("-------KİRALANMIŞ ARAÇ BİLGİSİ LİSTESİ----");
            Console.WriteLine("----------------------");
            if (result.Success == true)
            {
                foreach (var rental in result.Data)
                {
                    Console.WriteLine("Model bilgisi" + rental.CarId + " | "
                        + "Kullanıcı No = " + rental.UserId + " | "
                        + "Başlangıç Tarihi = " + rental.RentDate + "---->"
                        + "Bitiş Tarihi =" + rental.RentDate);
                }
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        public static void ColorList()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine("------ARAÇ RENK BİLGİ LİSTESİ------");
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

        public static void BrandList()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetAll();
            Console.WriteLine("------ARAÇ MARKA BİLGİSİ LİSTESİ------");
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

        public static void CarList()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("-----------GÜNLÜK ÜCRET KİRA BİLGİSİ LİSTESİ-----------");
            Console.WriteLine("---------------------------------------------");
            var result = carManager.GetAll();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Marka No = " + car.BrandId + "  |  "
                        + "Color Id = " + car.ColorId + "  |  "
                        + "Model Year = " + car.ModelYear + "  |  "
                        + "Description = " + car.Description + "  --->  "
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

        public static void UserList()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.GetAll();
            Console.WriteLine("-----------KULLANICI BİLGİSİ LİSTESİ-----------");
            Console.WriteLine("---------------------------------------------");
            if (result.Success == true)
            {
                foreach (var user in result.Data)
                {
                    Console.WriteLine("Adı = " + user.FirstName + "  |  "
                        + "Soyadı = " + user.LastName + "  |  "
                        + "Email Adresi = " + user.Email);
                }
                Console.WriteLine(Messages.UserListed);
            }
            else
            {
                Console.WriteLine(result.Message);
            }

      

       

      

       
        }


        public static void AddCar()
        {
            Car _car = new Car();
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("------------ARAÇ EKLEME İŞLEMİ--------------");
            Console.Write("Marka No = ");
            _car.BrandId = int.Parse(Console.ReadLine());
            Console.Write("Renk No = ");
            _car.ColorId = int.Parse(Console.ReadLine());
            Console.Write("Model Yılı = ");
            _car.ModelYear = int.Parse(Console.ReadLine());
            Console.Write("Gümlük ücreti = ");
            _car.DailyPrice = int.Parse(Console.ReadLine());
            Console.Write("Açıklaması = ");
            _car.Description = Console.ReadLine();
            Console.WriteLine("Model Bilgisi =");
            _car.CarName = Console.ReadLine();
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

        public static void AddBrand()
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

        public static void AddColor()
        {

            Color _color = new Color();
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine("------RENK EKLEME İŞLEMİ-------");
            Console.Write("Renk Adı =");
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

        public static void RentalAdd()
        {
            Rental _rental = new Rental();
            UserManager userManager = new UserManager(new EfUserDal());
            CarManager carManager = new CarManager(new EfCarDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Console.WriteLine("Kullanıcı seçiniz (ıd olarak giriniz) = ");
            foreach (var item in userManager.GetAll().Data)
            {
                Console.WriteLine("Id =" + item.UserId + "First name =" + item.FirstName);

            }
            Console.WriteLine("Kullanıcı seçiniz(Id olarak giriniz) =");
            _rental.UserId = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Araç seçiniz =");
            foreach (var item in carManager.GetAll().Data)
            {
                Console.WriteLine("Araç No =" + item.CarId + " | "
                    + "Marka No =" + item.BrandId + " | "
                    + "Renk No =" + item.ColorId + " | "
                    + "Model Bilgisi =" + item.CarName + " |"
                    + "Model Yılı =" + item.ModelYear + " | "
                    + "Araç Açıklaması =" + item.Description + " ----> "
                    + "Günlük Ücret =" + item.DailyPrice + "₺");
            }
            Console.WriteLine("Araç Seçiniz (Id olararak giriniz) =");
            _rental.CarId = int.Parse(Console.ReadLine());
            var carControl = rentalManager.GetRentalICarId(_rental.CarId);
            if (carControl.Success)
            {
                Console.Clear();
                Console.WriteLine("Kiralama süresinin başlangıcı (g/a/y) =");
                _rental.RentDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Kiralama süresinin bitişi (g/a/y) =");
                _rental.ReturnDate = DateTime.Parse(Console.ReadLine());
                var result = rentalManager.Add(_rental);
                if (result.Success)
                {
                    Console.WriteLine(result.Message);
                }
                else
                {
                    Console.WriteLine(result.Message);
                }
            }
            else
            {
                Console.WriteLine(carControl.Message);
            }
        }

        public static void AddCustomer()
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

        public static void UserAdd()
        {
            User _user = new User();
            UserManager userManager = new UserManager(new EfUserDal());
            Console.WriteLine("-------------KULLANICI EKLEME İŞLEMİ--------------");
            Console.Write("Adı = ");
            _user.FirstName = Console.ReadLine();
            Console.Write("Soyadı = ");
            _user.LastName = Console.ReadLine();
            Console.Write("Email adresi = ");
            _user.Email = Console.ReadLine();
            Console.Write("Parola = ");
            _user.Password = int.Parse(Console.ReadLine());
            var result = userManager.Add(_user);
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }


        public static void DeleteCar()
        {
            Car _car = new Car();
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("-------------ARAÇ SİLME İŞLEMİ-------------");
            Console.Write("Araç No = ");
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
        }

        public static void DeleteColor()
        {
            Color _color = new Color();
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine("-------------RENK SİLME İŞLEMİ--------------");
            Console.Write("Renk No = ");
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

        public static void DeleteBrand()
        {
            Brand _brand = new Brand();
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.WriteLine("-------------Marka Silme işlemi--------------");
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

        public static void DeleteCustomer()
        {
            Customer _customer = new Customer();
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Console.WriteLine("-------------MÜŞTERİ SİLME İŞLEMİ--------------");
            Console.Write("Müşteri No = ");
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

        public static void RentalDelete()
        {
            Rental _rental = new Rental();
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Console.WriteLine("----- ARAÇ KİRALAMA İPTAL İŞLEMİ----");
            RentalList();
            Console.WriteLine("Kiralama No =");
            int rentalId = int.Parse(Console.ReadLine());
            var result = rentalManager.Delete(rentalId);
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        public static void UserDelete()
        {
            User _userr = new User();
            UserManager userManager = new UserManager(new EfUserDal());
            Console.WriteLine("-------------KULLANICI SİLME İŞLEMİ--------------");
            Console.Write("Kullanıcı No = ");
            int userId = int.Parse(Console.ReadLine());
            var result = userManager.Delete(userId);
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }


        public static void BrandUpdate(BrandManager brandManager)
        {
            Console.WriteLine("----------MARKA GÜNCELLEM İŞLEMİ----");
            brandManager.Update(new Brand { BrandId = 3002, BrandName = "Alfa romeo" });
            Console.WriteLine(Messages.Updated);
        }

        public static void CarUpdate(CarManager carManager)
        {
            Console.WriteLine("------------GÜNCELLEME İŞLEMİ---------");
            carManager.Update(new Car
            {
                CarId = 3,
                BrandId = 3,
                ColorId = 5,
                CarName = "ALFA ROMEO GIULIA",
                ModelYear = 2020,
                DailyPrice = 850,
                Description = "Sigortası Yapıldı"
            });
            Console.WriteLine(Messages.Updated);
        }

        public static void ColorUpdate(ColorManager colorManager)
        {
            Console.WriteLine("------RENK GÜNCELLEME İŞLEMİ---------");
            colorManager.Update(new Color
            {
                ColorId = 1,
                ColorName = "Yeşil"
            });
            Console.WriteLine(Messages.Updated);
        }

        public static void CustomerUpdate(CustomerManager customerManager)
        {
            Console.WriteLine("------MÜŞTERİ BİLGİSİ GÜNCELLEME İŞLEMİ");
            customerManager.Update(new Customer
            {
                UserId = 3,
                CompanyName = "Çakmak A.Ş"
            });
            Console.WriteLine(Messages.Updated);
        }

        public static void UserUpdate(UserManager userManager)
        {
            Console.WriteLine("------------KULLANICI BİLGİSİ GÜNCELLEME İŞLEMİ---------");
            userManager.Update(new User { UserId = 1002, FirstName = "Umut", LastName = "Beldek", Email = "umutkayra@gmail.com", Password = 123456 });
            Console.WriteLine(Messages.Updated);
        }


    } }
    
