using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MSTAPIV1.Models
{
    public partial class Feedback
    {
        public Feedback()
        {
            Course = new HashSet<Course>();
        }

        public Guid Id { get; set; }
        public Guid? CustomerId { get; set; }
        public string Feedback1 { get; set; }
        public double Star { get; set; }

        public virtual User Customer { get; set; }
        public virtual ICollection<Course> Course { get; set; }
    }
}
