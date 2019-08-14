using Slick.Models.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slick.Services.People
{
    public interface IConsultantsService
    {
        IEnumerable<Consultant> GetAll();
        IEnumerable<Consultant> GetAll(string sort);
        IEnumerable<Consultant> FindByFirstName(string firstname);
        IEnumerable<Consultant> FindByFirstName(string firstname, string sort);

        IEnumerable<Consultant> FindByLastName(string Lastname);
        IEnumerable<Consultant> FindByLastName(string Lastname, string sort);

        Consultant GetById(Guid Id);
        Consultant Create(Consultant consultant);
        void Update(Consultant consultant);
        void Delete(Consultant consultant);
    }
}
