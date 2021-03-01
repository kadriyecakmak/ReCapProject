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
        public IResult Add(User users)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(int userId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<User>> GetUsersById(int userId)
        {
            throw new NotImplementedException();
        }

        public IResult Update(User users)
        {
            throw new NotImplementedException();
        }
    }
}
