using Core.Entity.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT.Abstract;
using Core.Utilities.Security.JWT.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : IJwtHelper
    {
        IConfiguration _configuration { get; }

        TokenOptions _accessToken;

        private DateTime _expirationTime;

        public JwtHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            //To use Get method for the IConfiguration, install configuration.Binder from NuGet
            _accessToken = _configuration.GetSection("TokenOptions").Get<TokenOptions>();

            _expirationTime = DateTime.UtcNow.AddMinutes(_accessToken.AccessTokenExpiration);

        }
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            //The reason to create security key is to make a SigningCredentials class.
            //That class has the info for the Algorithm that will be used for to hashing header and payload parts of the JWT token and the securitykey that will be used for that algorithm.
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_accessToken.SecurityKey);

            // create the signingCredetianl for the jwt token which represents the algorithm and securityKey.
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            
            var jwtToken = CreateToken(_accessToken, user, operationClaims, signingCredentials);

            var jwtHandler = new JwtSecurityTokenHandler();

            string token = jwtHandler.WriteToken(jwtToken);

            return new AccessToken()
            {
                Token = token,
                Expiration = _expirationTime,
            };
        }
        private JwtSecurityToken CreateToken(TokenOptions tokenOptions, User user, List<OperationClaim> operationClaims, SigningCredentials signingCredentials)
        {
            return new JwtSecurityToken(
                signingCredentials : signingCredentials,
                issuer : tokenOptions.Issuer,
                audience : tokenOptions.Audience,
                claims : SetClaims(user, operationClaims),
                notBefore : DateTime.UtcNow,
                expires : _expirationTime
                );
        }
        //Every operation claim is added as ClaimRole to the list with the properties of the user.
        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            //Identifier of the user.
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));   

            //Email of the user added as ClaimEmail.
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            
            //Name of user.
            claims.Add(new Claim(JwtRegisteredClaimNames.Name, $"{user.FirstName} + {user.LastName}"));

            //All the roles of the user is added.
            operationClaims.ForEach(x=> claims.Add(new Claim(ClaimTypes.Role, x.Name)));

            //Or you can just simply use the extension
            //claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());
            
            //string[] test = { "a", "b", "c" };
            //test.myAddingTest();

            return claims;
        }

    }
}
