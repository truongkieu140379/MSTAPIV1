using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MSTAPIV1.Models
{
    public partial class Event
    {
        public Event()
        {
            Category = new HashSet<Category>();
            User = new HashSet<User>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public Guid? PromotionId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual Promotion Promotion { get; set; }

        public virtual ICollection<Category> Category { get; set; }
        public virtual ICollection<User> User
        {
            get; set;
        }
    }
}
