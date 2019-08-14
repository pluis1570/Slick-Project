using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Slick.Models.Costumers;
using Slick.Repositories.Enities;

namespace Slick.Services.Costumers
{
    public class AccountsService : IAccountsService
    {
        private readonly IEntityRepository<Account> repo;
        public AccountsService(IEntityRepository<Account> repo)
        {
            this.repo = repo;
        }
        public Account Create(Account account)
        {
            return repo.Add(account);
        }

        public void Delete(Account account)
        {
        }

        public IEnumerable<Account> GetAll()
        {
            return repo.GetAll().ToList();
        }

        public Account GetById(Guid Id)
        {
            return repo.GetById(Id);
        }

        public void Update(Account account)
        {
            repo.Update(account);
        }
    }
}
