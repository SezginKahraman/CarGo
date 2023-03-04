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
    public interface IUserService
    {
        //CRUD OPERATİONS   
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
        IDataResult<User> GetUserByUserId(int id);
        IDataResult<List<User>> GetAllUsers();
        IDataResult<List<UserDetailDto>> GetAllUsersDetails();
    }
}
