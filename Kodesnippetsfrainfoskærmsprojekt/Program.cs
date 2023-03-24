using InformationScreen.Models;
using InformationScreen.Web.Infrastructure;
using InformationScreen.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<InfoDbContext>(opts =>
    opts.UseSqlServer(
        builder.Configuration["ConnectionStrings:InfoConnection"]));

builder.Services.AddScoped<IInfoRepository, EFInfoRepository>();

builder.Services.AddDbContext<IdentityDbContext>(opts =>
    opts.UseSqlServer(
        builder.Configuration["ConnectionStrings:IdentityConnection"]));

builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<IdentityDbContext>();

var app = builder.Build();

app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.MapDefaultControllerRoute();



app.Run();