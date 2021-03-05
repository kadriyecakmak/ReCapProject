using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using System.Text;

namespace Business.Concrete
{
    public class RentalManager:IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            if (rental.RentDate == null)
            {
                _rentalDal.Add(rental);
                return new SuccesResult(Messages.RentalAdded);

            }
            else if (rental.RentDate != null && rental.ReturnDate != null)
            {
                _rentalDal.Add(rental);
                return new SuccesResult(Messages.RentalAdded);
            }
            else
            {
                return new ErrorResult(Messages.RentalFailed);
            }
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccesResult(Messages.RentalDeleted);
        }

        public IResult Delete(int rentalId)
        {
            try
            {
                var rentalBul = _rentalDal.Get(r => r.RentalId == rentalId);
                if (rentalBul != null)
                {
                    _rentalDal.Delete(rentalBul);
                    return new SuccesResult(Messages.RentalDeleted);
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

        public IDataResult<List<Rental>> GetAll()
        {
            if (DateTime.Now.Hour == 21)
            {
                return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }


        public IResult GetRentalICarId(int carId)
        {
            var results = _rentalDal.GetAll(p => p.CarId == carId && p.ReturnDate == null || p.CarId == carId && p.ReturnDate > DateTime.Now);
            if (results.Count == 0)
            {
                return new SuccesResult();
            }
            return new ErrorResult(Messages.RentalCarIdError);
        }

    

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccesResult(Messages.RentalUpdated);
        }
        public IDataResult<List<Rental>> GetRentalsById(int rentalId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
          
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }
    }
}

