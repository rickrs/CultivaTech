using Microsoft.EntityFrameworkCore;
using CultivaTech.Data; // Adicione o namespace para o DbContext
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CultivaTechContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("CultivaTechDB")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
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
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");


app.Run();
