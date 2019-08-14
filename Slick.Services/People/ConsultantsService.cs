using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using Slick.Models.Contracts;
using Slick.Models.People;
using Slick.Repositories.Enities;

namespace Slick.Services.People
{
    public class ConsultantsService : IConsultantsService
    {
        private readonly IEntityRepository<Consultant> repo;
        public ConsultantsService(IEntityRepository<Consultant> repo)
        {
            this.repo = repo;
        }
        public Consultant Create(Consultant consultant)
        {
            return repo.Add(consultant);
        }
        public void Delete(Consultant consultant)
        {
            consultant.IsDeleted = true;
            repo.Update(consultant);
        }
        public IEnumerable<Consultant> GetAll()
        {
            return repo.GetAll().Where(sl => sl.IsDeleted == false).ToList();
        }
        public IEnumerable<Consultant> GetAll(string sort)
        {
            if (string.IsNullOrEmpty(sort)) sort = "firstname";

            return this.repo.GetAll().OrderBy(con => con.FirstName).ToList();
        }
        public IEnumerable<Consultant> FindByFirstName(string firstname)
        {
            return this.repo.FindBy(c => c.FirstName == firstname).ToList();
        }
        public IEnumerable<Consultant> FindByFirstName(string firstname, string sort)
        {
            if (string.IsNullOrEmpty(sort)) sort = "firstname";

            return this.repo.FindBy(c => c.FirstName == firstname).OrderBy(sort).ToList();
        }
        public IEnumerable<Consultant> FindByLastName(string Lastname)
        {
            return this.repo.FindBy(c => c.LastName == Lastname).ToList();
        }
        public IEnumerable<Consultant> FindByLastName(string Lastname, string sort)
        {
            if (string.IsNullOrEmpty(sort)) sort = "lastname";

            return repo.FindBy(c => c.LastName == Lastname).OrderBy(sort).ToList();
        }                     
        public Consultant GetById(Guid Id)
        {
            return repo.GetById(Id);
        }
        public void Update(Consultant consultant)
        {
            repo.Update(consultant);
        }


        //public IEnumerable<Consultant> OrderBy()
        //{
        //    return repo.GetAll().Where(sl => sl.IsDeleted == false).ToList().OrderBy(Con => Con.FirstName);
        //}


    }
}
