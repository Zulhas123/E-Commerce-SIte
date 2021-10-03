using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using E_Commerce_System.Models;


namespace E_Commerce_System.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProductTypes> productTypes { get; set; }
        public DbSet<SpacialTag> spacialTags { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
