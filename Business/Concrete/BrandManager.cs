using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            if(brand.BrandName.Length>2)
            {

                _brandDal.Add(brand);
                Console.WriteLine("Sistemden " + brand.BrandId + " numaralı " + brand.BrandName + " marka araç bilgisi eklendi.");
                return new Result(true, Messages.Added);
            }
            else
            {
                return new ErrorResult(Messages.BrandNameInvalid);
            }
        }
        public IResult Delete(int brandId)
        {
            try
            {
                var brandBul = _brandDal.Get(b => b.BrandId == brandId);
                if (brandBul != null)
                {
                    _brandDal.Delete(brandBul);
                    return new SuccesResult(Messages.Deleted);
                }
                else
                {
                    return new ErrorResult(Messages.IdError);
                }
            }
            catch
            {
                return new ErrorResult(Messages.IdError);
            }
        }
        public IDataResult<List<Brand>> GetAll()
        {
            if (DateTime.Now.Hour == 1)
            {
                return new ErrorDataResult<List<Brand>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.Added);
        }
        public IDataResult<List<Brand>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Brand>> (_brandDal.GetAll(b => b.BrandId == brandId));
        }
        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            Console.WriteLine("Sistemde yer alan " + brand.BrandId + " numaralı " + brand.BrandName + " marka araç bilgisi güncellendi.");
            return new Result(true, Messages.Updated);
        }

    }
}
