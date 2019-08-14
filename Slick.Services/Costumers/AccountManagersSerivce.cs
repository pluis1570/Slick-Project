using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Slick.Models.Costumers;
using Slick.Repositories.Enities;

namespace Slick.Services.Costumers
{
    public class AccountManagersSerivce : IAccountManagersService
    {
        private readonly IEntityRepository<AccountManager> repo;
        public AccountManagersSerivce(IEntityRepository<AccountManager> repo)
        {
            this.repo = repo;
        }


        public AccountManager Create(AccountManager account)
        {
            return repo.Add(account);
        }

        public void Delete(AccountManager account)
        {
        }

        public IEnumerable<AccountManager> GetAll()
        {
            return repo.GetAll().ToList();
        }

        public AccountManager GetById(Guid Id)
        {
            return repo.GetById(Id);
        }

        public void Update(AccountManager account)
        {
            repo.Update(account);
        }
    }
}
