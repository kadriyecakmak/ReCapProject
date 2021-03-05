using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId =1, BrandId=1, ColorId=1, ModelYear=2018,DailyPrice=650, Description ="Tofaş"},
                new Car{CarId =2, BrandId=2, ColorId=2, ModelYear=2019,DailyPrice=750, Description ="bmw"},
                new Car{CarId =3, BrandId=3, ColorId=3, ModelYear=2020,DailyPrice=850, Description ="çakmak"},
                new Car{CarId =4, BrandId=4, ColorId=4, ModelYear=2021,DailyPrice=950, Description ="melike"},
                new Car{CarId =5, BrandId=5, ColorId=5, ModelYear=2022,DailyPrice=1050, Description ="doblo"},
                new Car{CarId =6, BrandId=6, ColorId=6, ModelYear=2023,DailyPrice=1150, Description ="nissan"},
                new Car{CarId =7, BrandId=7, ColorId=7, ModelYear=2024,DailyPrice=1250, Description ="keşke arabam olsa"},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car CarToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(CarToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(Car => Car.CarId == carId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car CarToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            CarToUpdate.BrandId = car.BrandId;
            CarToUpdate.ModelYear = car.ModelYear;
            CarToUpdate.ColorId = car.ColorId;
            CarToUpdate.DailyPrice = car.DailyPrice;
            CarToUpdate.Description = car.Description; 


        }
    }
}
