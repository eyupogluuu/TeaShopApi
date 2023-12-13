using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaShopApi.EntityLayer.Concrete;

namespace TeaShopApi.DataAccessLayer.Context
{
	public class TeaContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=DESKTOP-2PU1K7L\\SQLEXPRESS; initial catalog=TeaShopDB;integrated security=true;");

		}
        public DbSet<Drink> drinks { get; set; }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<Question> questions { get; set; }
        public DbSet<Testimonial> testimonials { get; set; }
        public DbSet<Admin> admins { get; set; }
    }
}
