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
    public class ColorManager :IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {

            //if (color.ColorName.Length >2) 
           
            _colorDal.Add(color);
            Console.WriteLine(color.ColorId + " numaralı " + color.ColorName + " Renk bilgisi sisteme eklendi");
            return new SuccesResult(Messages.Added);
            //}
            //else if (color.ColorName.Length < 2)
            //{
            //    return new ErrorResult(Messages.ColorNameInvalid);
            //}
            //else
            //{
            //    return new ErrorResult(Messages.Error);
            //}

        }

        public IResult Delete(int colorId)
        {
            try
            {
                var colorBul = _colorDal.Get(k => k.ColorId == colorId);
                if (colorBul != null)
                {
                    _colorDal.Delete(colorBul);
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

        public IDataResult<List<Color>> GetAll()
        {

            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ColorsListed);
        }

        public IDataResult<Color> GetById(int colorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == colorId));
        }

        public IDataResult<List<Color>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(c => c.ColorId == colorId));
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color color)
        {

            IResult result = BusinessRules.Run(ColorControl(color.ColorId));
            if (result != null)
            {
                return result;
            }
            _colorDal.Update(color);
            return new Result(true, Messages.Updated);
        }
        private IResult ColorControl(int colorId)
        {
            var result = _colorDal.Get(c => c.ColorId==colorId);
            if (result == null)
            {
                return new ErrorResult("Girdiğiniz Id'ye ait renk bulunamadı");
            }
            return new SuccesResult();
        }
    }
}
