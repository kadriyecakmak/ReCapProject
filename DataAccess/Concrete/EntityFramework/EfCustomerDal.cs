using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapProjectContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from m in context.Customers
                             join k in context.Users
                             on m.CustomerId equals k.UserId
                             select new CustomerDetailDto
                             {
                                 CustomerId=m.CustomerId,
                                 UserId=k.UserId,
                                 CompanyName = m.CompanyName
                             };
                return result.ToList();
            }
        }
    }
}
