using Slick.Models.Contracts;
using Slick.Models.Costumers;
using Slick.Models.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Slick.Api.Dtos
{
    public class AccountConsultantDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string WorkEmail { get; set; }
        public string Telephone { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Mobile { get; set; }
        public string CompanyName { get; set; }
        public string VatNumber { get; set; }
        public IList<AccountManager> AccountManagers { get; set; }
        public IList<ConsultantSpecialisation> Specialisation { get; set; }
        public IList<Contract> Contracts { get; set; }

    }
}
