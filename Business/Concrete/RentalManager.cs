using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        //We can not use CarManager directly for the SOLID. But the service of that manager can be injected.
        ICarService _carService;
        public RentalManager(IRentalDal rentalDal, ICarService carService)
        {
            _rentalDal = rentalDal;
            _carService = carService;
        }

        public IResult Add(Rental rental)
        {
            //Lets check the car that wants to be rent is already rent or not.
            var isValid = isCarAvailable(rental).Success;
            if (isValid)
            {
                _rentalDal.Add(rental);
                return new SuccessResult();
            }

            return new ErrorResult();

        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<RentalDetailDto>> GetAllCarsDetails()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetAllRentals()
        {
            var result = _rentalDal.GetAll();
            return new SuccessDataResult<List<Rental>>(result);
        }

        public IDataResult<List<Rental>> GetAllRentalsByRentalDate(DateTime fromDate, DateTime? toDate)
        {
            var result = _rentalDal.GetAll(x =>
            toDate != null ?
            x.RentDate >= fromDate && x.ReturnDate <= toDate :
            x.RentDate >= fromDate && x.ReturnDate == null
            );
            return new SuccessDataResult<List<Rental>>(result);


        }

        public IDataResult<Rental> GetRentalByRentalId(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(x => x.Id == id));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }
        private IResult isCarAvailable(Rental rental)
        {
            var isCarAvailable = _rentalDal.Get(x => x.CardId == rental.CardId)?.ReturnDate == null ? true : false;
            if (isCarAvailable)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
