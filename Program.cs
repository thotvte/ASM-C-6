using Microsoft.EntityFrameworkCore;
using System.Configuration;
using web_ban_do_an.Data;
using web_ban_do_an.Repositories;
using web_ban_do_an.Services;

namespace web_ban_do_an
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddSession(); // Kích hoạt session
            // Đăng ký DbContext
            builder.Services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Con")));

            // Đăng ký các dịch vụ
            builder.Services.AddScoped<ProductService>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            // Thêm các dịch vụ khác nếu cần

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Cấu hình ứng dụng
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession(); // Sử dụng session
            app.UseAuthorization();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }

}
