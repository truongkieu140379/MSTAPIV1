using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MSTAPIV1.Models
{
    public partial class Course
    {
        public Course()
        {
            Booking = new HashSet<Booking>();
            Schedule = new HashSet<Schedule>();
            Document = new HashSet<Document>();
            Grade = new HashSet<Grade>();
        }

        [Key]
        public Guid Id { get; set; }
       
        public string Title { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public double Fee { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int? Rate { get; set; }
        public bool? Status { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public Guid CategoryId { get; set; }
        public Guid Owner { get; set; }
        public Guid? Feedback { get; set; }

        public virtual Category Category { get; set; }
        public virtual Feedback FeedbackNavigation { get; set; }
        public virtual User OwnerNavigation { get; set; }
        public virtual ICollection<Booking> Booking { get; set; }
        public virtual ICollection<Schedule> Schedule { get; set; }

        public virtual ICollection<Document> Document { get; set; }
        public virtual ICollection<Grade> Grade { get; set; }
    }
}
