using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MSTAPIV1.Models
{
    public partial class Document
    {
        public Document()
        {
            Couse = new HashSet<Course>();
        }

  
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Course> Couse { get; set; }
    }
}
