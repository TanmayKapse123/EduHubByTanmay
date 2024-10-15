using EduHubMVC.Models;
using EduHubMVC.Repository;
using EduHubMVC.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("MyConstr") ?? throw new InvalidOperationException("Connection string 'AppDBContextConnection' not found.");

  builder.Services.AddDbContext<AppDbContext>(options =>
      options.UseSqlServer(connectionString));
      builder.Services.AddScoped<IUserService,UserRepository>();
      builder.Services.AddScoped<ICourseService, CourseRepository>();
      builder.Services.AddScoped<IMaterialService, MaterialRepository>();
      builder.Services.AddScoped<IEnrollmentService, EnrollmentRepository>();
      builder.Services.AddScoped<IFeedBackService, FeedBackRepository>();
      builder.Services.AddScoped<IEnquiryService, EnquiryRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
