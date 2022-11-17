using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MSTAPIV1.Models
{
    public partial class Address
    {
        public Address()
        {
            User = new HashSet<User>();
        }

        public Guid Id { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string ApartmentNumber { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
