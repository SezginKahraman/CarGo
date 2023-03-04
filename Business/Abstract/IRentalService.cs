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
    public interface IRentalService
    {
        //CRUD OPERATİONS   
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
        IDataResult<Rental> GetRentalByRentalId(int id);
        IDataResult<List<Rental>> GetAllRentals();
        IDataResult<List<Rental>> GetAllRentalsByRentalDate(DateTime fromDate, DateTime? toDate = null);
        IDataResult<List<RentalDetailDto>> GetAllCarsDetails();
    }
}
