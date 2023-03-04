﻿using Business.Abstract;
using Core.Utilities.Results.Abstract;
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
            throw new NotImplementedException();
        }

        public IResult Delete(User user)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<UserDetailDto>> GetAllUsersDetails()
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> GetUserByUserId(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}