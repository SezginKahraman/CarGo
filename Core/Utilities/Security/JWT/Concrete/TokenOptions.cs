using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT.Concrete
{
    public class TokenOptions
    {
        /// <summary>
        ///     This class represents the TokenOptions value in the appsetting.json.
        ///     This TokenOptions value from json file will converted via the IConfiguration.GetSection("").Get<T> method.
        /// </summary>
        public string Audience { get; set; }

        public string Issuer { get; set; }

        public int AccessTokenExpiration { get; set; }

        public string SecurityKey { get; set; }
    }
}
