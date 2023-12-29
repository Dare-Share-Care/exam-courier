using Courier.Web.Entities;
using Courier.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Courier.Web.Data;

public class CourierContext : DbContext
{
    public DbSet<Delivery> Deliveries { get; set; } = null!;
    
    public CourierContext(DbContextOptions<CourierContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Delivery>().HasKey(d => d.Id);
        modelBuilder.Entity<Delivery>().Property(d => d.Id).ValueGeneratedOnAdd();
        
        modelBuilder.Entity<Delivery>().Property(d => d.OrderId).IsRequired();
        modelBuilder.Entity<Delivery>().Property(d => d.CourierId).IsRequired();
        modelBuilder.Entity<Delivery>().Property(d => d.DeliveryAddress).IsRequired();
        modelBuilder.Entity<Delivery>().Property(d => d.DeliveryStatus).IsRequired();
        modelBuilder.Entity<Delivery>().Property(d => d.TimeClaimed).IsRequired(false);
        modelBuilder.Entity<Delivery>().Property(d => d.TimeDelivered).IsRequired(false);
        
        modelBuilder.Entity<Delivery>().Property(d => d.Latitude).IsRequired(false);
        modelBuilder.Entity<Delivery>().Property(d => d.Longitude).IsRequired(false);

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Delivery>().HasData(
            new Delivery
            {
                Id = 1,
                OrderId = 1,
                CourierId = 1,
                DeliveryAddress = "Janusevej 90, 2300 København S",
                DeliveryStatus = DeliveryStatus.Claimed,
                TimeClaimed = DateTime.Now,
            },
            new Delivery
            {
                Id = 2,
                OrderId = 2,
                CourierId = 2,
                DeliveryAddress = "Frederiksgade 9, 8000 Helsingør C",
                DeliveryStatus = DeliveryStatus.Claimed,
                TimeClaimed = DateTime.Now,
            },
            new Delivery
            {
                Id = 3,
                OrderId = 3,
                CourierId = 3,
                DeliveryAddress = "Julisvej 9, 2300 København S",
                DeliveryStatus = DeliveryStatus.Delivered,
                TimeClaimed = DateTime.Now,
                TimeDelivered = DateTime.Now
            });
    }
}