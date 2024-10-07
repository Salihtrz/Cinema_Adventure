using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Context;

using Microsoft.EntityFrameworkCore;
using EntityLayer.Class;

namespace DataAccessLayer.Context
{
    public partial class CinemaDb : DbContext
    {
        public CinemaDb() 
        { 
        }

        public CinemaDb(DbContextOptions<CinemaDb> options) : base(options)
        {

        }

        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Category> Categorys { get; set; }
        public virtual DbSet<AboutUs> AboutUss { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Cast> Casts { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
		public virtual DbSet<Review_News> Reviews_News { get; set; }
		public virtual DbSet<MovieCast> MovieCasts { get; set; }
        public virtual DbSet<MovieCategory> MovieCategory { get; set; }
        public virtual DbSet<News> News { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=SALIH\\SQLEXPRESS;Initial Catalog=CinemaDb;Integrated Security=True;TrustServerCertificate=True");
		}
	}
}
