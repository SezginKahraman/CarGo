using Core.DataAccess.EntityFramework;
using Core.Entity.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, CarGoContext>, IUserDal
    {
        public UserDetailDto GetUserDetailDto(int id)
        {
            using (CarGoContext carGoContext = new CarGoContext())
            {
                var userDetailDto = from userTable in carGoContext.Set<User>()
                                    join customerTable in carGoContext.Set<Customer>()
                                    on userTable.Id equals customerTable.UserId
                                    join rentalTable in carGoContext.Set<Rental>()
                                    on customerTable.UserId equals rentalTable.CustomerId
                                    where rentalTable.CustomerId == id
                                    let rentals = carGoContext.Set<Rental>().Where(x=>x.CustomerId == id).ToList()
                                    select new UserDetailDto
                                    {
                                         Email = userTable.Email,
                                         FirstName = userTable.FirstName,
                                         LastName = userTable.LastName,
                                         Id = userTable.Id,
                                         Rentals = rentals
                                    };
                return userDetailDto.FirstOrDefault(x=> x.Id == id);
            }
           
        }
        public List<UserDetailDto> GetAllUsersDetails()
        {
            using (CarGoContext carGoContext = new CarGoContext())
            {
                var rentals = from rentalTable in carGoContext.Set<Rental>()
                              select new Rental
                              {
                                  CardId = rentalTable.CardId,
                                  CustomerId = rentalTable.CustomerId,
                                  Id = rentalTable.Id,
                                  RentDate = rentalTable.RentDate,
                                  ReturnDate = rentalTable.ReturnDate
                              };
                var userDetailDto = from userTable in carGoContext.Set<User>()
                                    join customerTable in carGoContext.Set<Customer>()
                                    on userTable.Id equals customerTable.UserId
                                    join rentalTable in carGoContext.Set<Rental>()
                                    on customerTable.UserId equals rentalTable.CustomerId
                                    select new UserDetailDto
                                    {
                                        Email = userTable.Email,
                                        FirstName = userTable.FirstName,
                                        LastName = userTable.LastName,
                                        Id = userTable.Id,
                                        Rentals = rentals.Where(x => x.CustomerId == userTable.Id).ToList()
                                    };
                return userDetailDto.ToList().DistinctBy(x=>x.Id).ToList();
            }
        }
    }
}
