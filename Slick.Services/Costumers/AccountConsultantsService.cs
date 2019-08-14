using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using Slick.Models.Costumers;
using Slick.Repositories.Enities;

namespace Slick.Services.Costumers
{
    public class AccountConsultantsService : IAccountsConsultantsService
    {

        private readonly IEntityRepository<AccountConsultant> repo;
        public AccountConsultantsService(IEntityRepository<AccountConsultant> repo)
        {
            this.repo = repo;
        }

        public AccountConsultant Create(AccountConsultant account)
        {
            return repo.Add(account);
        }

        public void Delete(AccountConsultant account)
        {
        }

        public IEnumerable<AccountConsultant> FindByFirstName(string firstname)
        {
            return this.repo.FindBy(c => c.Consultant.FirstName == firstname).ToList();
        }

        public IEnumerable<AccountConsultant> FindByFirstName(string firstname, string sort)
        {
            if (string.IsNullOrEmpty(sort)) sort = "firstname";

            return this.repo.FindBy(c => c.Consultant.FirstName == firstname).OrderBy(sort).ToList();
        }

        public IEnumerable<AccountConsultant> FindByLastName(string Lastname)
        {
            return this.repo.FindBy(c => c.Consultant.LastName == Lastname).ToList();
        }

        public IEnumerable<AccountConsultant> FindByLastName(string Lastname, string sort)
        {
            if (string.IsNullOrEmpty(sort)) sort = "lastname";

            return repo.FindBy(c => c.Consultant.LastName == Lastname).OrderBy(sort).ToList();
        }

        public IEnumerable<AccountConsultant> GetAll()
        {
            return repo.GetAll().ToList();
        }

        public IEnumerable<AccountConsultant> GetAll(string sort)
        {
            if (string.IsNullOrEmpty(sort)) sort = "firstname";

            return this.repo.GetAll().OrderBy(acon => acon.Employee.FirstName).ToList();
        }

        public AccountConsultant GetById(Guid Id)
        {
            return repo.GetById(Id);
        }

        public void Update(AccountConsultant account)
        {
            repo.Update(account);
        }
    }
}
