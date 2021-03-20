using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<CarDto>> GetCarDto();
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int carId);
        IDataResult<List<CarDto>> GetByBrandId(int brandId);
        IDataResult<List<CarDto>> GetByColorId(int colorId);
        IDataResult<List<CarDetailDto>>GetCarDetails();
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(int carId);


    }
}
