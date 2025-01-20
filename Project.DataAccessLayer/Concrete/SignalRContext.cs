using Microsoft.EntityFrameworkCore;
using Project.Data.Entities;
using Project.Data.Enums;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Project.DataAccess.Concrete
{
    public class SignalRContext : IdentityDbContext<AppUser, Roles, int>
    {
        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=CAN-TOKHAY-MASA\\CANTOKHAY;initial Catalog=SignalRDB; integrated Security=true");
            optionsBuilder.UseSqlServer("Server=DESKTOP-OHO9G30\\SQLEXPRESS;initial Catalog=SignalRDB; integrated Security=true");
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<MoneyCase> MoneyCases { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserLogin<int>>(entity =>
            {
                entity.HasKey(login => new { login.LoginProvider, login.ProviderKey });
            });

            modelBuilder.Entity<IdentityUserRole<int>>(entity =>
            {
                entity.HasKey(role => new { role.UserId, role.RoleId });
            });

            modelBuilder.Entity<IdentityUserToken<int>>(entity =>
            {
                entity.HasKey(token => new { token.UserId, token.LoginProvider, token.Name });
            });

            // About entity configuration
            modelBuilder.Entity<About>(entity =>
            {
                entity.HasKey(e => e.AboutId);
                entity.Property(e => e.AboutTitle).HasMaxLength(100).IsRequired();
                entity.Property(e => e.AboutDescription).HasMaxLength(250).IsRequired();
                entity.Property(e => e.AboutImageURL).IsRequired();
            });

            // Booking entity configuration
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(e => e.BookingId);
                entity.Property(e => e.BookingName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.BookingEmail).IsRequired();
                entity.Property(e => e.BookingPhone).IsRequired();
                entity.Property(e => e.BookingDate).HasColumnType("datetime2").IsRequired();
                entity.Property(e => e.PersonCount).IsRequired();
            });

            // Basket entity configuration
            modelBuilder.Entity<Basket>(entity =>
            {
                entity.HasKey(e => e.BasketId);
                entity.Property(e => e.Price).IsRequired();
                entity.Property(e => e.Count).IsRequired();
                entity.Property(e => e.TotalProductPrice).IsRequired();
                entity.HasOne(e => e.Product).WithMany(p => p.Baskets).HasForeignKey(e => e.ProductId);
                entity.HasOne(e => e.Customer).WithMany(c => c.Baskets).HasForeignKey(e => e.CustomerId);
            });

            // Category entity configuration
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategoryId);
                entity.Property(e => e.CategoryName).HasMaxLength(100).IsRequired();
            });

            // Contact entity configuration
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasKey(e => e.ContactId);
                entity.Property(e => e.ContactLocation).HasMaxLength(250).IsRequired();
                entity.Property(e => e.ContactPhone).IsRequired();
                entity.Property(e => e.ContactEmail).IsRequired();
                entity.Property(e => e.FooterTitle).HasMaxLength(50).IsRequired();
                entity.Property(e => e.FooterDescription).HasMaxLength(250).IsRequired();
                entity.Property(e => e.OpenDays).HasMaxLength(100).IsRequired();
                entity.Property(e => e.OpenDaysDescription).HasMaxLength(250).IsRequired();
                entity.Property(e => e.OpenHours).HasMaxLength(100).IsRequired();
            });

            // Customer entity configuration
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerId);
                entity.Property(e => e.CustomerName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.CustomerStatus).IsRequired();
            });

            // Discount entity configuration
            modelBuilder.Entity<Discount>(entity =>
            {
                entity.HasKey(e => e.DiscountId);
                entity.Property(e => e.Title).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Description).HasMaxLength(250).IsRequired();
                entity.Property(e => e.DiscountAmount).IsRequired();
                entity.Property(e => e.ImageURL).IsRequired();
            });

            // Message entity configuration
            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(e => e.MessageId);
                entity.Property(e => e.MessageFullName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.MessageEmail).IsRequired();
                entity.Property(e => e.MessageSubject).HasMaxLength(100).IsRequired();
                entity.Property(e => e.MessageContent).HasMaxLength(500).IsRequired();
                entity.Property(e => e.MessagePhone).IsRequired();
            });

            // MoneyCase entity configuration
            modelBuilder.Entity<MoneyCase>(entity =>
            {
                entity.HasKey(e => e.MoneyCaseId);
                entity.Property(e => e.TotalMoneyInCase).IsRequired();
            });

            // Notification entity configuration
            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasKey(e => e.NotificationId);
                entity.Property(e => e.Type).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Icon).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Message).HasMaxLength(250).IsRequired();
                entity.Property(e => e.NotificationDate).IsRequired();
            });

            // Order entity configuration
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderId);
                entity.Property(e => e.CustomerName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.OrderDescription).IsRequired();
                entity.Property(e => e.OrderDate).HasColumnType("Date").IsRequired();
                entity.Property(e => e.TotalPrice).IsRequired();
            });

            // OrderDetail entity configuration
            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => e.OrderDetailId);
                entity.Property(e => e.Quantity).IsRequired();
                entity.Property(e => e.UnitPrice).IsRequired();
                entity.Property(e => e.TotalPrice).IsRequired();
                entity.HasOne(e => e.Order).WithMany(o => o.OrderDetails).HasForeignKey(e => e.OrderId);
                entity.HasOne(e => e.Product).WithMany(p => p.OrderDetails).HasForeignKey(e => e.ProductId);
            });

            // Product entity configuration
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductId);
                entity.Property(e => e.ProductName).HasMaxLength(50).IsRequired();
                entity.Property(e => e.ProductDescription).HasMaxLength(100).IsRequired();
                entity.Property(e => e.ProductPrice).IsRequired();
                entity.Property(e => e.ProductImageURL).IsRequired();
                entity.HasOne(e => e.Category).WithMany(c => c.Products).HasForeignKey(e => e.CategoryId);
            });

            // Slider entity configuration
            modelBuilder.Entity<Slider>(entity =>
            {
                entity.HasKey(e => e.SliderId);
                entity.Property(e => e.SliderTitle1).HasMaxLength(30).IsRequired();
                entity.Property(e => e.SliderDescription1).HasMaxLength(100).IsRequired();
                entity.Property(e => e.SliderTitle2).HasMaxLength(30).IsRequired();
                entity.Property(e => e.SliderDescription2).HasMaxLength(100).IsRequired();
                entity.Property(e => e.SliderTitle3).HasMaxLength(30).IsRequired();
                entity.Property(e => e.SliderDescription3).HasMaxLength(100).IsRequired();
            });

            // SocialMedia entity configuration
            modelBuilder.Entity<SocialMedia>(entity =>
            {
                entity.HasKey(e => e.SocialMediaId);
                entity.Property(e => e.SocialMediaTitle).HasMaxLength(50).IsRequired();
                entity.Property(e => e.SocialMediaURL).IsRequired();
                entity.Property(e => e.SocialMediaIcon).IsRequired();
            });

            // Testimonial entity configuration
            modelBuilder.Entity<Testimonial>(entity =>
            {
                entity.HasKey(e => e.TestimonialId);
                entity.Property(e => e.Comment).HasMaxLength(50).IsRequired();
                entity.Property(e => e.TestimonialName).HasMaxLength(50).IsRequired();
                entity.Property(e => e.TestimonialTitle).HasMaxLength(50).IsRequired();
                entity.Property(e => e.TestimonialImageURL).IsRequired();
            });
        }
    }
}
