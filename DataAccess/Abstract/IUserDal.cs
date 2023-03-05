using Core.DataAccess.Abstract;
using Core.Entity.Concrete;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<UserDetailDto> GetAllUsersDetails();
        UserDetailDto GetUserDetailDto(int id);
    }
}
