using Core.Entity.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Security.JWT.Concrete;
using Entity.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userRegister);

        IDataResult<User> Login(UserForLoginDto userLogin);

        IDataResult<AccessToken> CreateToken(User user);
    }
}
