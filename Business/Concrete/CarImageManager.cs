using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        ICarService _carService;
        public CarImageManager(ICarImageDal carImageDal, ICarService carService)
        {
            _carImageDal = carImageDal;
            _carService = carService;
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage, IFormFile file)
        {
            IResult result = BusinessRules.Run(CarControl(carImage.CarId),CarImageCountControl(carImage.CarId));
          
            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = CarImagesFileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccesResult(Messages.CarImageAdded);
        }

     
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

     
        public IResult CarImageIdCheck(int carImageId)
        {
            if(carImageId <= 0)
            {
                return new ErrorResult(Messages.IdError);
            }
            return new SuccesResult();
        }

        public IResult Delete(int carImageId)
        {
            var getCarImage = DatabaseCarImageCheck(carImageId);
            IResult result = BusinessRules.Run(getCarImage);
            if (result != null)
            {
                return result;
            }
            var delete = CarImagesFileHelper.Delete(getCarImage.Data.ImagePath);
            if (delete.Success)
            {
                _carImageDal.Delete(getCarImage.Data);
                return new SuccesResult(Messages.CarImageDeleted);
            }
            return new ErrorResult(Messages.NotCarImageDeleted);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(int carImageId, IFormFile file)
        {
            CarImage carImage = new CarImage();
            var carControl = CarImageControl(carImageId);
            IResult result = BusinessRules.Run(CarImageIdCheck(carImageId), carControl);

            if (result != null)
            {
                return result;
            }
            carImage = carControl.Data;
            var carUpdateFile = CarImagesFileHelper.Update(file, carImage.ImagePath);
            carImage.ImagePath = carUpdateFile;
            _carImageDal.Update(carImage);

            return new SuccesResult(Messages.CarImageUpdated);
        }

        public IDataResult<CarImage>GetById(int carImageId)
        {
            
            return new SuccessDataResult<CarImage>(_carImageDal.Get(i => i.CarImageId == carImageId));
        }

        IDataResult<List<CarImage>>ICarImageService.GetByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarHaveNoImage(carId).Data);
        }
        public IDataResult<CarImage> CarImageControl(int carImageId)
        {
            var carImage = _carImageDal.Get(i => i.CarImageId == carImageId);
            if (carImage != null)
            {
                return new SuccessDataResult<CarImage>(carImage);
            }
            return new ErrorDataResult<CarImage>(Messages.CarNotFound);
        }
        public IDataResult<Car> CarControl(int carId)
        {
            var car = _carService.GetById(carId);
            if (car.Success)
            {
                return new SuccessDataResult<Car>(car.Data);
            }
            return new ErrorDataResult<Car>(Messages.CarNotFound);
        }

        public IResult CarImageCountControl(int carId)
        {
            var car = _carImageDal.GetAll(i => i.CarId == carId);
            if (car.Count() < 5)
            {
                return new SuccesResult();
            }
            return new ErrorResult("5 adet fotoğraf bulundu");
        }
        public IDataResult<CarImage> DatabaseCarImageCheck(int carImageId)
        {
            var result = _carImageDal.Get(i => i.CarImageId == carImageId);
            if (result == null)
            {
                return new ErrorDataResult<CarImage>(Messages.CarImageNotFound);
            }
            return new SuccessDataResult<CarImage>(result);
        }
        public IDataResult<List<CarImage>> CheckIfCarHaveNoImage(int carId)
        {
            string path = @"\Images\default.jpg";
            CarImage empty = new CarImage { CarId=carId,ImagePath=path};
            List<CarImage> list = new List<CarImage>();
                list.Add(empty);
            var result = _carImageDal.GetAll(i => i.CarId == carId);
            if (result.Count!=0)               
                return new SuccessDataResult<List<CarImage>>(result);      
            return new ErrorDataResult<List<CarImage>>(list);
        }
    }

}
