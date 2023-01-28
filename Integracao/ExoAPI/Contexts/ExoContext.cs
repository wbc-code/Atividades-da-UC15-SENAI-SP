using System;
using ExoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ExoAPI.Contexts
{
	public class ExoContext : DbContext
	{
		public ExoContext()
		{
		}

        public ExoContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=192.168.1.250;Database=ExoProjetos;User Id=van;Password=tredfg;");
            }
        }

        public DbSet<Projeto> Projetos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}