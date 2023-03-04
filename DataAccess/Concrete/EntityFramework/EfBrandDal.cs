using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //                                               Brand represent the entity, 
    //                                               CarGoContext represents which db the brand will come from.
    public class EfBrandDal : EfEntityRepositoryBase<Brand, CarGoContext>, IBrandDal
    {
    }
}
