using System;
using System.Collections.Generic;
using System.Linq;
using Slick.Models.Skills;
using Slick.Repositories.Enities;
using Slick.Repositories.Skills;

namespace Slick.Services.Skills
{
    public class SpecialisationLevelsService : ISpecialisationLevelsService
    {
        private readonly IEntityRepository<SpecialisationLevel> repo;

        public SpecialisationLevelsService(IEntityRepository<SpecialisationLevel> repo)
        {
            this.repo = repo;
        }

        public SpecialisationLevel Create(SpecialisationLevel level)
        {
            return repo.Add(level);
        }

        public void Delete(SpecialisationLevel level)
        {
            level.IsDeleted = true;
            repo.Update(level);
        }

        public IEnumerable<SpecialisationLevel> GetAll()
        {
            return repo.GetAll().Where(sl => sl.IsDeleted == false).ToList();
        }

        public SpecialisationLevel GetById(Guid Id)
        {
            return repo.GetById(Id);

        }

        public void Update(SpecialisationLevel level)
        {
            repo.Update(level);
        }
    }
}
