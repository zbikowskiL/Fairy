using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fairy.Models
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }

        
        public MembershipType MembershipType { get; set; }
        
        [Display(Name = "Membership Type")]
        public int MembershipTypeId { get; set; }

        [Min18YearsIfAMember]
        [Display(Name = "Date of Brith")]
        public DateTime? BrithDate  { get; set; }



    }
}