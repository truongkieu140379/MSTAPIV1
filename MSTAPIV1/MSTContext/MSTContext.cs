using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MSTAPIV1.Models;

namespace MSTAPIV1.MSTContext
{
    public partial class MSTContext : DbContext
    {
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<BookingStatus> BookingStatus { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<Grade> Grade { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Promotion> Promotion { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<User> User { get; set; }

        public MSTContext(DbContextOptions<MSTContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=SE140379\\SQLEXPRESS;Initial Catalog=MST;User ID=sa;Password=123456;Trust Server Certificate=True;Command Timeout=300");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BookingAt).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.BookingStatus)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.BookingStatusId)
                    .HasConstraintName("FK__Booking__Booking__32E0915F");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__Booking__CourseI__2F10007B");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Booking__Custome__300424B4");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK__Booking__Payment__30F848ED");
            });

            modelBuilder.Entity<BookingStatus>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");

                entity.HasMany(d => d.Grade)
                    .WithMany(p => p.Category)
                    .UsingEntity<Dictionary<string, object>>(
                        "CategoryGrade",
                        l => l.HasOne<Grade>().WithMany().HasForeignKey("GradeId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__CategoryG__Grade__398D8EEE"),
                        r => r.HasOne<Category>().WithMany().HasForeignKey("CategoryId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__CategoryG__Categ__38996AB5"),
                        j =>
                        {
                            j.HasKey("CategoryId", "GradeId").HasName("PK__Category__7C46BDAE4533ABAE");

                            j.ToTable("CategoryGrade");
                        });
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Thumbnail).IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Course__Category__21B6055D");

                entity.HasOne(d => d.FeedbackNavigation)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.Feedback)
                    .HasConstraintName("FK__Course__Feedback__239E4DCF");

                entity.HasOne(d => d.OwnerNavigation)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.Owner)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Course__Owner__22AA2996");

                entity.HasMany(d => d.Document)
                    .WithMany(p => p.Couse)
                    .UsingEntity<Dictionary<string, object>>(
                        "CouseDocument",
                        l => l.HasOne<Document>().WithMany().HasForeignKey("DocumentId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__CouseDocu__Docum__276EDEB3"),
                        r => r.HasOne<Course>().WithMany().HasForeignKey("CouseId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__CouseDocu__Couse__267ABA7A"),
                        j =>
                        {
                            j.HasKey("CouseId", "DocumentId").HasName("PK__CouseDoc__061DB4BFEEC9A2C7");

                            j.ToTable("CouseDocument");
                        });
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StartDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Promotion)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.PromotionId)
                    .HasConstraintName("FK__Event__Promotion__440B1D61");

                entity.HasMany(d => d.Category)
                    .WithMany(p => p.Event)
                    .UsingEntity<Dictionary<string, object>>(
                        "CourseEvent",
                        l => l.HasOne<Category>().WithMany().HasForeignKey("CategoryId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__CourseEve__Categ__48CFD27E"),
                        r => r.HasOne<Event>().WithMany().HasForeignKey("EventId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__CourseEve__Event__47DBAE45"),
                        j =>
                        {
                            j.HasKey("EventId", "CategoryId").HasName("PK__CourseEv__D8D45BB0F2493FE2");

                            j.ToTable("CourseEvent");
                        });

                entity.HasMany(d => d.User)
                    .WithMany(p => p.Event)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserEvent",
                        l => l.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UserEvent__UserI__4CA06362"),
                        r => r.HasOne<Event>().WithMany().HasForeignKey("EventId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UserEvent__Event__4BAC3F29"),
                        j =>
                        {
                            j.HasKey("EventId", "UserId").HasName("PK__UserEven__A83C44D41E0979C2");

                            j.ToTable("UserEvent");
                        });
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Feedback)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Feedback__Custom__1ED998B2");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");

                entity.HasMany(d => d.Course)
                    .WithMany(p => p.Grade)
                    .UsingEntity<Dictionary<string, object>>(
                        "CouseGrade",
                        l => l.HasOne<Course>().WithMany().HasForeignKey("CourseId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__CouseGrad__Cours__3D5E1FD2"),
                        r => r.HasOne<Grade>().WithMany().HasForeignKey("GradeId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__CouseGrad__Grade__3C69FB99"),
                        j =>
                        {
                            j.HasKey("GradeId", "CourseId").HasName("PK__CouseGra__386AAD4D7C5EA016");

                            j.ToTable("CouseGrade");
                        });
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsPayment).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Promotion>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Slot).IsUnicode(false);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Schedule)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__Schedule__Course__4F7CD00D");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Avatar).IsUnicode(false);

                entity.Property(e => e.Username).IsUnicode(false);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK__User__AddressId__15502E78");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__User__RoleId__164452B1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
