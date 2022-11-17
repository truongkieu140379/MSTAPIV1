using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MSTAPIV1.Models
{
    public partial class Payment
    {
        public Payment()
        {
            Booking = new HashSet<Booking>();
        }

        public Guid Id { get; set; }
        public double Fee { get; set; }
        public bool? IsPayment { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Booking> Booking { get; set; }
    }
}
