using Slick.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slick.Services.Contracts
{
    public interface IContractsService
    {
        IEnumerable<Contract> GetAll();
        IEnumerable<Contract> GetActiveContratcs();
        IEnumerable<Contract> GetContractsFromConsultant(Guid conId);
        Contract GetById(Guid id);
        void Update(Contract c);
        void Delete(Contract c);
        Contract Create(Contract c);
    }
}
