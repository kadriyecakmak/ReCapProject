using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User users);
        IResult Delete(int userId);
        IResult Update(User users);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int userId);
        List<OperationClaim> GetClaims(User user);
        
        User GetByMail(string email);
    }
}
