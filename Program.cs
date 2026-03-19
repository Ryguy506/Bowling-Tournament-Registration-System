using Microsoft.EntityFrameworkCore;
using Bowling_Tournament_Registration_System.Persistence.Ef;
using Bowling_Tournament_Registration_System.Domain.Daos;
using Bowling_Tournament_Registration_System.Persistence.Daos;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// Configure Razor view engine to look for views in the /Ui/Views folder
builder.Services.Configure<Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions>(options =>
{
	options.ViewLocationFormats.Clear();
	options.ViewLocationFormats.Add("/Ui/Views/{1}/{0}.cshtml");
	options.ViewLocationFormats.Add("/Ui/Views/Shared/{0}.cshtml");
});

var dbPath = Path.Combine(builder.Environment.ContentRootPath, "AppData", "btrs.db");
builder.Services.AddDbContext<BowlingDbContext>(options =>
{
    options.UseSqlite($"Data Source={dbPath}");
});

builder.Services.AddScoped<ITournamentDao, TournamentDao>();
builder.Services.AddScoped<ITeamDao, TeamDao>();
builder.Services.AddScoped<ITournamentRegistrationDao, TournamentRegistrationDao>();
builder.Services.AddScoped<IUserDao, UserDao>();
builder.Services.AddScoped<IPlayerDao, PlayerDao>();

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
