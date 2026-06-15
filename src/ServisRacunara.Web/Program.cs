using Microsoft.EntityFrameworkCore;
using ServisRacunara.DAL.Kontekst;
using ServisRacunara.BLL.Servisi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BazaKontekst>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<KlijentServis>();

builder.Services.AddScoped<UredjajServis>();

builder.Services.AddScoped<ServiserServis>();

builder.Services.AddScoped<ServisniNalogServis>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();