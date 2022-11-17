using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MSTAPIV1.Models
{
    public partial class Booking
    {

        public Guid Id { get; set; }
        public Guid? CourseId { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? PaymentId { get; set; }
        public DateTime? BookingAt { get; set; }
        public Guid? BookingStatusId { get; set; }

        public virtual BookingStatus BookingStatus { get; set; }
        public virtual Course Course { get; set; }
        public virtual User Customer { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
