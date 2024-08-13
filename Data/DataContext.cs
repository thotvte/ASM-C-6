using Microsoft.EntityFrameworkCore;
using System.Data;
using web_ban_do_an.Models;

namespace web_ban_do_an.Data
{
    public class DataContext :DbContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Role> Role { get; set; }
        public DbSet<AccountEmp> AccountEmp { get; set; }
        public DbSet<AccountCus> AccountCus { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ProductItem> ProductItem { get; set; }
        public DbSet<ProductItemProduct> ProductItemProduct { get; set; }
        public DbSet<Products> Product { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<InvoiceDetails> InvoiceDetail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cấu hình khóa chính cho ProductItemProduct
            modelBuilder.Entity<ProductItemProduct>()
                .HasKey(pip => new { pip.productItemId, pip.productId });

            // Cấu hình mối quan hệ với ProductItem
            modelBuilder.Entity<ProductItemProduct>()
                .HasOne(pip => pip.productItem) // ProductItemProduct có một ProductItem
                .WithMany(pi => pi.productItemProducts) // ProductItem có nhiều ProductItemProduct
                .HasForeignKey(pip => pip.productItemId); // Khóa ngoại

            // Cấu hình mối quan hệ với Products
            modelBuilder.Entity<ProductItemProduct>()
                .HasOne(pip => pip.product) // ProductItemProduct có một Products
                .WithMany(p => p.productItemProducts) // Products có nhiều ProductItemProduct
                .HasForeignKey(pip => pip.productId); // Khóa ngoại

            modelBuilder.Entity<Products>()
            .Property(p => p.Price)
            .HasColumnType("decimal(18,2)"); // Cấu hình kiểu dữ liệu cho Price

            modelBuilder.Entity<InvoiceDetails>()
                .Property(id => id.Price)
                .HasColumnType("decimal(18,2)"); // Cấu hình kiểu dữ liệu cho Price

            base.OnModelCreating(modelBuilder); // Gọi phương thức cơ sở
        }


    }
}
