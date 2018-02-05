﻿using Fairy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fairy.DTOmodels
{
    public class CustomerDTO
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }

        public int MembershipTypeId { get; set; }

        //[Min18YearsIfAMember]
        public DateTime? BrithDate { get; set; }
    }
}