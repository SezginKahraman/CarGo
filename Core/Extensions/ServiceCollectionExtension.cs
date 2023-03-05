using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    //This is an extension. So the class must be static !
    public static class ServiceCollectionExtension
    {
        //We are going to extent Microsoft's IoC container to reference Core refereneces that can be used in other
        //projects like Cache, HttpContextAccessor etc.
        public static void AddDependencyResolver(this IServiceCollection serviceCollection, ICoreModule[] coreModules)
        {
            //coreModules represents the IoC containers that needs to be load in the run time.
            foreach (var coreModule in coreModules)
            {
                coreModule.Load(serviceCollection);
            }
        }

    }
}
