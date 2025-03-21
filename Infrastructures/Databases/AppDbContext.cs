using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Databases;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    
}