using Business.Abstract;
using Core.Entity.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT.Abstract;
using Core.Utilities.Security.JWT.Concrete;
using Entity.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        IJwtHelper _jwtHelper;
        public AuthManager(IUserService userService, IJwtHelper jwtHelper)
        {
            _userService = userService;
            _jwtHelper = jwtHelper;
        }

        public IDataResult<AccessToken> CreateToken(User user)
        {
            var claims = new List<OperationClaim> (){ new OperationClaim() {  Id = 1, Name = "admin"} };
            var jwtToken = _jwtHelper.CreateToken(user, claims);

            return new SuccessDataResult<AccessToken>(jwtToken);
        }

        public IDataResult<User> Login(UserForLoginDto userLogin)
        {
            // Check if the user exists
            var isUserExists = _userService.GetAllUsers().Data.Find(x=>x.Email == userLogin.Email);

            if (isUserExists == null)
            {
                return new ErrorDataResult<User>("there is no user with this email");
            }

            // Check if the password is correct by comparing their hashes.
            var checkPassword = HashingHelper.VerifyPasswordHash(userLogin.Password, isUserExists.PasswordHash, isUserExists.PasswordSalt);

            if (!checkPassword)
            {
                return new ErrorDataResult<User>(isUserExists,"invalid password");
            }
            return new SuccessDataResult<User>(isUserExists);
        }

        public IDataResult<User> Register(UserForRegisterDto userRegister)
        {
            // Check if the user exists
            var isUserExists = _userService.GetAllUsers().Data.Find(x => x.Email == userRegister.Email);

            // If there is a user with that email, return error.
            if(isUserExists != null)
            {
                return new ErrorDataResult<User>("There is a user already registered with this email");
            }
            // Create password hash.
            HashingHelper.CreatePasswordHash(userRegister.Password, out byte[] passwordhash, out byte[] passwordsalt);

            var user = new User()
            {
                Email = userRegister.Email,
                FirstName = userRegister.FirstName,
                LastName = userRegister.LastName,
                PasswordHash = passwordhash,
                PasswordSalt = passwordsalt,
                Status = true
            };

            var addedUser = _userService.Add(user);
            return new SuccessDataResult<User>(user);
        }
    }
}
