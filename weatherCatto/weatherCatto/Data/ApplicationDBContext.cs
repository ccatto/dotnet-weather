using System;
using Microsoft.EntityFrameworkCore;
using weatherCatto.Models;

namespace weatherCatto.Data
{
	public class ApplicationDBContext : DbContext
    {
		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> option) : base(option)
		{

		}

		public DbSet<WeatherData> weatherDatas { get; set; }
	}
}

