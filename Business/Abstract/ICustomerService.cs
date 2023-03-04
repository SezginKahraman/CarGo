using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        //CRUD OPERATİONS   
        IResult Add(Customer customer);
        IResult Delete(Customer customer);
        IResult Update(Customer customer);
        IDataResult<Customer> GetCustomerByCustomerId(int id);
        IDataResult<List<Customer>> GetAllCustomers();
        IDataResult<List<CustomerDetailDto>> GetAllCarsDetails();
    }
}
