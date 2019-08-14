using Slick.Models.Skills;
using System.Collections.Generic;
using Slick.Models.Contracts;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace Slick.Models.People
{
    public class Consultant : Person
    {
        public string Email { get; set; }
        public string WorkEmail { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }

        public virtual IList<ConsultantSpecialisation> Specialisation { get; set; }

        public IList<Contract> Contracts { get; set; }

        [NotMapped]
        public Contract CurrentContract
        {
            get
            {
                if (this.Contracts != null)
                {
                    var query = from C in this.Contracts
                                orderby C?.StartDate descending
                                select C;
                    return query.FirstOrDefault();
                }
                else return null;
            }
        }

        //TODO: Account 
    }
}
