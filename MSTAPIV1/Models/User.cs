using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MSTAPIV1.Models
{
    [Index(nameof(Username), Name = "UQ__User__536C85E400B711FC", IsUnique = true)]
    public partial class User
    {
        public User()
        {
            Booking = new HashSet<Booking>();
            Course = new HashSet<Course>();
            Feedback = new HashSet<Feedback>();
            Event = new HashSet<Event>();
        }

        [Key]
        public Guid Id { get; set; }
       
        public string Username { get; set; }
        
        public string Password { get; set; }
       
       
        public string PasswordHash { get; set; }
        
        
        public string PasswordSalt { get; set; }
        
        public string Avatar { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public DateTime? LastLoginAt { get; set; }
        public Guid? AddressId { get; set; }
        public Guid? RoleId { get; set; }
        public bool? Status { get; set; }

        public virtual Address Address { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Booking> Booking { get; set; }
        public virtual ICollection<Course> Course { get; set; }
        public virtual ICollection<Feedback> Feedback { get; set; }

        public virtual ICollection<Event> Event { get; set; }
    }
}
