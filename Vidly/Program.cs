using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Vidly.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Recupere la chaine de connexion depuis appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

app.UseAuthentication();
app.UseAuthorization();

//app.MapControllerRoute(
//    "MoviesByReleaseDate",
//    "movies/released/{year}/{month}",
//    new { controller = "Movies", action = "ByReleaseDate" },
//    new {year = @"\d{4}", month = @"\d{2}"});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
