using Business.Abstract;
using Core.Entity.Concrete;
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
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult();
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult();
        }

        public IDataResult<List<User>> GetAllUsers()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<List<UserDetailDto>> GetAllUsersDetails()
        {
            return new SuccessDataResult<List<UserDetailDto>>(_userDal.GetAllUsersDetails());
        }
        public IDataResult<UserDetailDto> GetUserDetailsById(int id)
        {
            return new SuccessDataResult<UserDetailDto>(_userDal.GetUserDetailDto(id));
        }
        public IDataResult<User> GetUserByUserId(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(x=> x.Id == id));
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult();
        }
    }
}
