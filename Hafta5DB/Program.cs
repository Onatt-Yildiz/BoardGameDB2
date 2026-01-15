using BoardGameDB.Data;
using BoardGameDB.Filters;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<SecurityActionFilter>();
});


builder.Services.AddDbContext<GameDbContext>(options =>
    options.UseSqlServer(
        "Server=LAPTOP-1ENVQMFE\\SQLEXPRESS;Database=BoardGameDB;Trusted_Connection=True;TrustServerCertificate=True;"
    )
);


builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
});


builder.Services.AddScoped<SecurityActionFilter>();


builder.Services.AddScoped<BoardGameDB.Service.BoardGameService>();


builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}"
);

app.Run();