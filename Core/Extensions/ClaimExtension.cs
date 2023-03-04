using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    // The classes which are created for the extension must be a static class.
    public static class ClaimExtension
    {
        public static void AddClaimRole(this ICollection<Claim> claims, string[] roles)
        {
            roles.ToList().ForEach(role=> claims.Add(new Claim(ClaimTypes.Role, role)));
        }

        //extension test
        //public static void myAddingTest(this string[] array)
        //{
        //    Console.WriteLine("test is working");
        //}
        
    }
}
