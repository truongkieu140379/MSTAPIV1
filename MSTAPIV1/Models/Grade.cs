using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MSTAPIV1.Models
{
    public partial class Grade
    {
        public Grade()
        {
            Category = new HashSet<Category>();
            Course = new HashSet<Course>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual ICollection<Category> Category { get; set; }
        public virtual ICollection<Course> Course { get; set; }
    }
}
