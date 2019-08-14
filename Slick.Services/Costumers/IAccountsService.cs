using Slick.Models.Costumers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slick.Services.Costumers
{
    public interface IAccountsService
    {
        IEnumerable<Account> GetAll();
        Account GetById(Guid Id);
        Account Create(Account account);
        void Update(Account account);
        void Delete(Account account);
    }
}
