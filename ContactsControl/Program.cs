using ContactsControl.Data;
using ContactsControl.Repository;
using Microsoft.EntityFrameworkCore;

namespace ContactsControl
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            
            builder.Services.AddEntityFrameworkSqlServer().AddDbContext<DataBaseContext>(conn =>
            {
               conn.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"), sqlServerOptionsAction: sqlOptions =>
               {
                  sqlOptions.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
               });
            });

            builder.Services.AddScoped<IContactRepository, ContactRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            var app = builder.Build();
           
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Index}/{id?}");
                //pattern: "{controller=Home}/{action=Index}/{id?}");//rota padrão da aplicação
                

            app.Run();
        }
    }
}