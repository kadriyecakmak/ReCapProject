using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapProjectContext>, ICustomerDal
    {
        public List<CustomerDetailDto> customerDetailDtos( )
        {
            using (ReCapProjectContext reCap = new ReCapProjectContext())
            {
                var results = (from m in reCap.Customers//suan burda hata yok ama hatavar diyiyor buyüzden vs yi kapatıp açmam lazım
                           
                               join u in reCap.Users on m.UserId equals u.UserId
                               select new CustomerDetailDto { CustomerId = c.CustomerId, UserFirstName = u.UserFirstName, UserLastName = u.UserLastName, CampanyName = c.CampanyName }).toList();
                return results;
            }
        }
    }
}
