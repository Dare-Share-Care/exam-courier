using Courier.Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace Courier.Web.Data;

public class CourierContext : DbContext
{
    public DbSet<Delivery> Deliveries { get; set; } = null!;
    
    public CourierContext(DbContextOptions<CourierContext> options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) { }
}