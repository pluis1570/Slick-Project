using System;
using System.Collections.Generic;
using System.Text;
using Slick.Database;
using Slick.Models.Skills;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Slick.Repositories.Skills
{
    public class SpecialisationLevelRepository : ISpecialisationLevelRepository
    {
        private readonly ApplicationDBContext entitiesContext;

        public SpecialisationLevelRepository(ApplicationDBContext entitiesContext)
        {
            this.entitiesContext = entitiesContext;
        }

        public SpecialisationLevel Add(SpecialisationLevel level)
        {
            entitiesContext.Set<SpecialisationLevel>().Add(level);
            entitiesContext.SaveChanges();
            return level;
        }

        public void Delete(SpecialisationLevel level)
        {
            EntityEntry dbEntity = entitiesContext.Entry<SpecialisationLevel>(level);
            dbEntity.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            entitiesContext.SaveChanges();
        }

        public IEnumerable<SpecialisationLevel> GetAll()
        {
            var items = entitiesContext.Set<SpecialisationLevel>();
            return items.ToList();
        }

        public SpecialisationLevel GetById(Guid Id)
        {
            var item = GetAll().Where(s => s.Id == Id).SingleOrDefault();
            return item;
        }

        public void Update(SpecialisationLevel level)
        {
            EntityEntry dbEntity = entitiesContext.Entry<SpecialisationLevel>(level);
            dbEntity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            entitiesContext.SaveChanges();
        }
    }
}
