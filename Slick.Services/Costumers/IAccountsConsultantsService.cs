using Slick.Models.Costumers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slick.Services.Costumers
{
    public interface IAccountsConsultantsService
    {
        IEnumerable<AccountConsultant> GetAll();
        IEnumerable<AccountConsultant> GetAll(string sort);
        IEnumerable<AccountConsultant> FindByFirstName(string firstname);
        IEnumerable<AccountConsultant> FindByFirstName(string firstname, string sort);

        IEnumerable<AccountConsultant> FindByLastName(string Lastname);
        IEnumerable<AccountConsultant> FindByLastName(string Lastname, string sort);

        AccountConsultant GetById(Guid Id);
        AccountConsultant Create(AccountConsultant account);
        void Update(AccountConsultant account);
        void Delete(AccountConsultant account);
    }
}
