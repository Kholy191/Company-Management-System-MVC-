using Kholy.IKEA.BLL.Common.Services.Attachments;
using Kholy.IKEA.BLL.Services.Departments;
using Kholy.IKEA.BLL.Services.Employee;
using Kholy.IKEA.DAL.Contracts;
using Kholy.IKEA.DAL.Entites.Identity;
using Kholy.IKEA.DAL.Persistence.Data;
using Kholy.IKEA.DAL.Persistence.UnitOfWork;
using Kholy.IKEA.PL.Controllers.Mappping;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Kholy.IKEA.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            builder.Services.AddDbContext<ApplicationDbContext>((optionsBuilder) =>
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server=.; Database=IKEA_MVC;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;"
));

            //builder.Services.AddScoped<DbContextOptions<ApplicationDbContext>>();
            //builder.Services.AddScoped<ApplicationDbContext>((serviceprovider) =>
            //{
            //    var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            //    optionsBuilder.UseSqlServer("Server=.; Database=IKEA_MVC;Trusted_Connection=True;");
            //    return new ApplicationDbContext(optionsBuilder.Options);
            //});

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IDepartmentServices, DepartmentService>();
            builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();
            builder.Services.AddTransient<IAttachmentService, AttachmentService>();
            builder.Services.AddAutoMapper(M => M.AddProfile(new MappingProfile()));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            else
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.MapStaticAssets();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
