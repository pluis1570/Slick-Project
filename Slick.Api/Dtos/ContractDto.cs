using Slick.Models.Contracts;
using Slick.Models.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Slick.Api.Dtos
{
    public class ContractDto
    {
      
        public virtual ContractType ContractType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? SignedDate { get; set; }//Nullable<DateTime>
        public decimal? Salary { get; set; }
        public string DocumentUrl { get; set; }

    }
}
