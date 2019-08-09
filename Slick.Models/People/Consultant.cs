using Slick.Models.Skills;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slick.Models.People
{
    public class Consultant: Person
    {
        public string Email{ get; set; }
        public string WorkEmail { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }

        public virtual IList<ConsultantSpecialisation> Specialisation { get; set; }

        //TODO: Contract
        //TODO: Specialisation
        //TODO: Account 
    }
}
