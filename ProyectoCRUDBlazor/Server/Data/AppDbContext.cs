using Microsoft.EntityFrameworkCore;
using ProyectoCRUDBlazor.Server.Core.Entities;

namespace ProyectoCRUDBlazor.Server.Data;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{

	}
	public virtual DbSet<Club> Clubes { get; set; }
	public virtual DbSet<Player> Players { get; set; }
}
