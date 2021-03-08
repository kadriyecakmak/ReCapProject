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
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User users)
        {
           
           
            _userDal.Add(users);
            Console.WriteLine(users.UserId + " numaralı " + users.FirstName + " " + users.LastName + " isimli kullanıcı bilgisi sisteme eklendi.");
            return new SuccesResult(Messages.UserAdded);
          
        }

        public IResult Delete(int userId)
        {
            try
            {
                var userBul = _userDal.Get(u => u.UserId == userId);
                if (userBul != null)
                {
                    _userDal.Delete(userBul);
                    return new SuccesResult(Messages.UserDeleted);
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

        public IDataResult<List<User>> GetAll()
        {
            var result = _userDal.GetAll();
            return new SuccessDataResult<List<User>>(result);
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.UserId == userId));
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User user)
        {

            IResult result = BusinessRules.Run(UserControl(user.UserId));
            if (result != null)
            {
                return result;
            }
            _userDal.Update(user);
            return new Result(true, Messages.Updated);
        }
        private IResult UserControl(int userId)
        {
            var result = _userDal.Get(u => u.UserId == userId);
            if (result == null)
            {
                return new ErrorResult("Girdiğiniz Id'ye ait kullanıcı bulunamadı :(");
            }
            return new SuccesResult();
        }
    }
}
