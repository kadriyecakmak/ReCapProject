using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
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
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            

            
            _brandDal.Add(brand);
            Console.WriteLine("Sistemden " + brand.BrandId + " numaralı " + brand.BrandName + " marka araç bilgisi eklendi.");
            return new Result(true, Messages.Added);
       
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
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandsListed);
        }
        public IDataResult<List<Brand>>GetById(int brandId)
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(b => b.BrandId == brandId));

        }
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {
           
            IResult result = BusinessRules.Run(BrandControl(brand.BrandId));
            if (result != null)
            {
                return result;
            }
            _brandDal.Update(brand);
            return new Result(true, Messages.Updated);
        }
       private IResult BrandControl(int brandId)
        {
            var result = _brandDal.Get(p=>p.BrandId==brandId);
            if (result==null)
            {
                return new ErrorResult("Girdiğiniz Id'ye ait marka bulunamadı");
            }
            return new SuccesResult();
        }
       

    }
}
