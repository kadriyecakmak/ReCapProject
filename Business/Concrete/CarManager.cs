using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        
        public IResult Add(Car car)
        {
            if (car.Description.Length > 2 && car.DailyPrice != 0) 
            
            {
                _carDal.Add(car);
                Console.WriteLine(car.CarId + " numaralı " + car.Description + " araç bilgisi sisteme eklendi");
                return new SuccesResult( Messages.Added); 
            }
            else if (car.DailyPrice == 0)
            {
                return new ErrorResult(Messages.DailyPriceInvalid);
            }
            else if (car.CarName.Length < 2)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            else
            {
                return new ErrorResult(Messages.Error);
            }

        }

        public IResult Delete(int carId)
        {
            try
            {
                var carBul = _carDal.Get(c => c.CarId == carId);
                if (carBul != null)
                {
                    _carDal.Delete(carBul);
                    return new SuccesResult(Messages.Deleted);
                }
                else
                {
                    return new ErrorResult(Messages.IdError);
                }
            }
            catch
            {
                return new ErrorResult(Messages.Error);
            }
        }

        public IDataResult<List<Car>> GetAll()
        {
            if(DateTime.Now.Hour== 1)
            {
                
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            
            Console.WriteLine("Sistemde yer alan " + car.CarId + " numaralı " + car.Description + " model araç bilgisi güncellendi.");
            return new Result(true, Messages.Updated);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int carId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == carId));
        }
        public List<Car>GetCarsByCarId(int carId)
        {
            return _carDal.GetAll(c => c.CarId == carId);
        }
    }
}
