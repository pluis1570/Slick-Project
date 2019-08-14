using Slick.Models.Contact;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Slick.Models.People
{
    public abstract class Person: BaseEntity
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public Guid? AddressId { get; set; }
        public virtual Address Address{ get; set; }
        public DateTime Birthdate { get; set; }

        //TODO: Rijksrigisternummer

        public bool IsDeleted { get; set; } = false;

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}";
        }
    }
}
