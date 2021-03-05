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
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User users)
        {
            if (users.FirstName != null && users.LastName != null && users.Email != null && users.Password != null)
            {
                _userDal.Add(users);
                Console.WriteLine(users.UserId + " numaralı " + users.FirstName + " " + users.LastName + " isimli kullanıcı bilgisi sisteme eklendi.");
                return new SuccesResult(Messages.UserAdded);
            }
            else
            {
                return new ErrorResult(Messages.Error);
            }
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

        public IDataResult<List<User>> GetUsersById(int userId)
        {
            throw new NotImplementedException();
        }

        public IResult Update(User users)
        {
            _userDal.Update(users);
            Console.WriteLine("Sistemde yer alan " + users.UserId + " numaralı " + users.FirstName + " " + users.LastName + " Kullanıcı bilgisi güncellendi.");
            return new Result(true, Messages.CustomerUpdated);
        }
    }
}
