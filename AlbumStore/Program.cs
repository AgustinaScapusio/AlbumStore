using AlbumStore.Data;
using Microsoft.EntityFrameworkCore;

namespace AlbumStore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add dependencies
        builder.Services.AddControllers();
        builder.Services.AddDbContext<AlbumDbContext>(opt => 
            opt.UseSqlite(builder.Configuration.GetConnectionString("AlbumDbContext")));
        
        // Dokumentasjon
        builder.Services.AddSwaggerGen();
        
        var app = builder.Build();
        
        // Dokumentasjon
        app.UseSwagger();
        app.UseSwaggerUI();
        
        app.MapControllers();

        app.Run();
    }
}