using DataAccess.Abstract;
using Entities.Concrete;
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
                new Car{Id =1, BrandId=123, ColorId=12345, ModelYear=2018,DailyPrice=650, Descriptions ="Tofaş"},
                new Car{Id =2, BrandId=234, ColorId=23456, ModelYear=2019,DailyPrice=750, Descriptions ="bmw"},
                new Car{Id =3, BrandId=345, ColorId=34567, ModelYear=2020,DailyPrice=850, Descriptions ="çakmak"},
                new Car{Id =4, BrandId=456, ColorId=45678, ModelYear=2021,DailyPrice=950, Descriptions ="melike"},
                new Car{Id =5, BrandId=567, ColorId=56789, ModelYear=2022,DailyPrice=1050, Descriptions ="doblo"},
                new Car{Id =6, BrandId=678, ColorId=67891, ModelYear=2023,DailyPrice=1150, Descriptions ="nissan"},
                new Car{Id =7, BrandId=789, ColorId=78912, ModelYear=2024,DailyPrice=1250, Descriptions ="keşke arabam olsa"},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car CarToDelete = _cars.SingleOrDefault(Car=>Car.Id ==Car.Id);
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

        public List<Car> GetById(int id)
        {
            return _cars.Where(Car => Car.Id == id).ToList();
        }
        public void Update(Car car)
        {
            Car CarToUpdate = _cars.SingleOrDefault(Car => Car.Id == car.Id);
            CarToUpdate.BrandId = car.BrandId;
            CarToUpdate.ModelYear = car.ModelYear;
            CarToUpdate.ColorId = car.ColorId;
            CarToUpdate.DailyPrice = car.DailyPrice;
            CarToUpdate.Descriptions = car.Descriptions; 


        }
    }
}
