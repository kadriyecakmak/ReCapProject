using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
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

       [SecuredOperation("admin")]
       [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccesResult( Messages.CarAdded);
        }

        [SecuredOperation("admin")]
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
            if (DateTime.Now.Hour == 19)
            {

                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new Result(true, Messages.CarUpdated);
        }
        private IResult CarControl(int carId)
        {
            var result = _carDal.Get(c => c.CarId == carId);
            if (result == null)
            {
                return new ErrorResult("Girdiğiniz Id'ye ait araç bulunamadı");
            }
            return new SuccesResult();
        }

        public IDataResult<List<CarDto>> GetByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDto>>(_carDal.CarDto(c => c.BrandId == brandId));
        }

        public IDataResult<List<CarDto>> GetByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDto>>(_carDal.CarDto(c => c.ColorId == colorId));
        }
        public List<Car>GetCarsByCarId(int carId)
        {
            return _carDal.GetAll(c => c.CarId == carId);
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
        }

        public IDataResult<List<CarDto>> GetCarDto()
        {
            var result = _carDal.CarDto();
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<CarDto>>("Araç bulunamadı.");
            }
            return new SuccessDataResult<List<CarDto>>(result, Messages.CarListed);
        }
    }
}
