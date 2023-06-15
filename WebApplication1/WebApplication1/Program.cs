using WebApplication1.Models;
using WebApplication1.Models.ViewModel;
using WebApplication1.Service;
using WebApplication1.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DatasDbContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("MyLocalDBSql")));
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<ITxtService, TxtService>();
builder.Services.AddTransient<IDatabaseAccessService, DatabaseAccessService>();
builder.Services.AddTransient<IDataConvertService<Datas,MyApiViewModel>, DataConvertService>();
builder.Services.AddTransient<IFileProvideService, FileProvideService>();
builder.Services.AddTransient<ILibraryService, LibraryService>();

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
