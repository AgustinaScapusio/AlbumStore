using AlbumStore.Models;
using Microsoft.EntityFrameworkCore;

namespace AlbumStore.Data;

public class AlbumDbContext : DbContext
{
    public AlbumDbContext(DbContextOptions<AlbumDbContext> opt) : base(opt)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=AlbumsDB.db");
    }

    public DbSet<Album> Albums { get; set; }
}