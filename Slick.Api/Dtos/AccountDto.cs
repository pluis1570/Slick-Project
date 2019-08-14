using Slick.Models.Costumers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Slick.Api.Dtos
{
    public class AccountDto
    {
        public string CompanyName { get; set; }
        public string VatNumber { get; set; }
        public string TelephoneNumber { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public virtual IList<AccountManager> AccountManagers { get; set; }
    }
}
