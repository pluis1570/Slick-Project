using Slick.Models.Skills;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slick.Services.Skills
{
    public interface ISpecialisationLevelsService
    {
        IEnumerable<SpecialisationLevel> GetAll();
        SpecialisationLevel GetById(Guid Id);
        void Update(SpecialisationLevel level);
        void Delete(SpecialisationLevel level);
        SpecialisationLevel Create(SpecialisationLevel level);
    }
}
