using Slick.Models.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slick.Models.Costumers
{
   public class AccountConsultant:BaseEntity
    {
        public Guid ConsultantId { get; set; }
        public virtual Consultant Consultant{ get; set; }
        public  Guid AccountId{ get; set; }
        public virtual Account Account { get; set; }
        public DateTime Startdate{ get; set; }
        public DateTime EndDate { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }
        //Persoon die contract heeft opgesteld tussen consultant en account
        public virtual Employee Employee { get; set; }
        public Guid EmployeeId{ get; set; }
    }
}
