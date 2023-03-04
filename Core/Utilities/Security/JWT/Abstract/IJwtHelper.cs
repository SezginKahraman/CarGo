using Core.Entity.Concrete;
using Core.Utilities.Security.JWT.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT.Abstract
{
    public interface IJwtHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
