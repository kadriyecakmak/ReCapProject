using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager:ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            

            
            _customerDal.Add(customer);
            Console.WriteLine(customer.CustomerId + "numaralı" + customer.CompanyName + "müşteri bilgileri sisteme eklendi");
            return new SuccesResult(Messages.CustomerAdded);
       

        }

        public IResult Delete(int customerId)
        {
            try
            {
                var customerBul = _customerDal.Get(m => m.CustomerId == customerId);
                if (customerBul != null)
                {
                    _customerDal.Delete(customerBul);
                    return new SuccesResult(Messages.CustomerDeleted);
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


        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CustomersListed);
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetails());
        }
    
        public IDataResult<List<Customer>> GetById(int customerId)
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(m => m.CustomerId == customerId));
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer customer)
        {

            IResult result = BusinessRules.Run(CustomerControl(customer.CustomerId));
            if (result != null)
            {
                return result;
            }
            _customerDal.Update(customer);
            return new Result(true, Messages.Updated);
        }
        private IResult CustomerControl(int customerId)
        {
            var result = _customerDal.Get(m =>m.CustomerId == customerId);
            if (result == null)
            {
                return new ErrorResult("Girdiğiniz Id'ye ait Müşteri bulunamadı");
            }
            return new SuccesResult();
        }

    }
}
