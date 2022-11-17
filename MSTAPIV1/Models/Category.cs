using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MSTAPIV1.Models
{
    public partial class Category
    {
        public Category()
        {
            Course = new HashSet<Course>();
            Event = new HashSet<Event>();
            Grade = new HashSet<Grade>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual ICollection<Course> Course { get; set; }

        public virtual ICollection<Event> Event { get; set; }
        public virtual ICollection<Grade> Grade { get; set; }
    }
}
