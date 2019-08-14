using Slick.Models.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slick.Models.Costumers
{
    public class AccountManager : BaseEntity
    {
        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public Guid AccountId  { get; set; }
        public virtual Account Account{ get; set; }
        public bool IsActive { get; set; }
    }
}
