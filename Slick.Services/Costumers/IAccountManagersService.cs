using Slick.Models.Costumers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slick.Services.Costumers
{
   public interface IAccountManagersService
    {
        IEnumerable<AccountManager> GetAll();
        AccountManager GetById(Guid Id);
        void Update(AccountManager account);
        void Delete(AccountManager account);
        AccountManager Create(AccountManager account);
    }
}
