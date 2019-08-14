using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Slick.Models.Contracts;
using Slick.Repositories.Enities;

namespace Slick.Services.Contracts
{
    public class ContractsService : IContractsService
    {
        private readonly IEntityRepository<Contract> contractRepo;

        public ContractsService(IEntityRepository<Contract> contractRepo)
        {
            this.contractRepo = contractRepo;
        }
        public Contract Create(Contract c)
        {
            return contractRepo.Add(c);
        }

        public void Delete(Contract c)
        {
           
        }

        public IEnumerable<Contract> GetActiveContratcs()
        {
            return null;
        }

        public IEnumerable<Contract> GetContractsFromConsultant(Guid conId)
        {
            return this.contractRepo.FindBy(c => c.ConsultantId == conId).ToList();
        }

        public IEnumerable<Contract> GetAll()
        {
            return contractRepo.GetAllIncluding(c => c.ContractType).ToList();
        }

        public Contract GetById(Guid id)
        {
            return contractRepo.GetById(id);
        }

        public void Update(Contract c)
        {
            contractRepo.Update(c);
        }
    }
}
