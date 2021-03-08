using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Delete(int rentalId);
        IResult Update(Rental rental);
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
        IResult GetRentalICarId(int carId);
        IDataResult<List<Rental>> GetRentalsById(int rentalId);
        IDataResult<Rental> GetById(int rentalId);
    }
}
