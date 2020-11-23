using LinnWorks.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinnWorks.Data
{
	public class DataBaseContext:DbContext
	{
		public DataBaseContext(DbContextOptions <DataBaseContext> options) : base (options)
		{ }
		public DbSet<Country> Countries { get; set; }
		public DbSet<Import> Imports { get; set; }
		public DbSet<ItemType> ItemTypes { get; set; }
		public DbSet<OrderPriority> OrderPriorities { get; set; }
		public DbSet<Region> Regions { get; set; }
		public DbSet<Order> Orders { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
		}
	}
}
