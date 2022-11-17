using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MSTAPIV1.Models
{
    public partial class Promotion
    {
        public Promotion()
        {
            Event = new HashSet<Event>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public int Value { get; set; }

        public virtual ICollection<Event> Event { get; set; }
    }
}
