using CShop.Entities;
using Microsoft.EntityFrameworkCore;

namespace CShop.Auth
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Brand> Brand { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Discount> Discount { get; set; }
        public DbSet<Evaluate> Evaluate { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductDetail> ProductDetail { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasMany(o => o.Evaluates)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId);
            builder.Entity<User>()
                .HasMany(o => o.Ratings)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId);
            builder.Entity<User>()
                .HasMany(o => o.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId);
            builder.Entity<Brand>()
                .HasMany(o => o.Products)
                .WithOne(o => o.Brand)
                .HasForeignKey(o => o.BrandId);
            builder.Entity<Supplier>()
                .HasMany(o => o.Products)
                .WithOne(o => o.Supplier)
                .HasForeignKey(o => o.SupplierId);
            builder.Entity<Category>()
                .HasMany(o => o.Products)
                .WithOne(o => o.Category)
                .HasForeignKey(o => o.CategoryId);
            builder.Entity<Order>()
                .HasMany(o => o.OrderDetails)
                .WithOne(o => o.Order)
                .HasForeignKey(o => o.OrderId);
            builder.Entity<Product>()
                .HasMany(o => o.ProductDetails)
                .WithOne(o => o.Product)
                .HasForeignKey(o => o.ProductId);
            builder.Entity<ProductDetail>()
                .HasMany(o => o.OrderDetails)
                .WithOne(o => o.ProductDetail)
                .HasForeignKey(o => o.ProductDetailId);
        }

    }
}
