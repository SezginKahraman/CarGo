using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Color = Entity.Concrete.Color;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : IColorDal
    {
        public void Add(Color color)
        {
            using (CarGoContext carGoContext = new CarGoContext())
            {
                //first find the entities information in the database.
                var addedEntity = carGoContext.Entry(color);
                //Add it to the database
                addedEntity.State = EntityState.Added;
                carGoContext.SaveChanges(); 
            }
        }

        public void Delete(Color color)
        {
            using (CarGoContext carGoContext = new CarGoContext())
            {
                //first find the entities information in the database.
                var addedEntity = carGoContext.Entry(color);
                //Add it to the database
                addedEntity.State = EntityState.Deleted;
                carGoContext.SaveChanges();
            }
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using (CarGoContext carGoContext = new CarGoContext())
            {
                return carGoContext.Set<Color>().SingleOrDefault(filter);
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (CarGoContext carGoContext = new CarGoContext())
            {
                return filter == null ? 
                    carGoContext.Set<Color>().ToList() :
                    carGoContext.Set<Color>().Where(filter).ToList();
            }
        }

        public void Update(Color color)
        {
            using (CarGoContext carGoContext = new CarGoContext())
            {
                //first find the entities information in the database.
                var addedEntity = carGoContext.Entry(color);
                //Add it to the database
                addedEntity.State = EntityState.Modified;
                carGoContext.SaveChanges();
            }
        }
    }
}
