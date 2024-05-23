using ExamDemo.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();


//appsettings.json dosyasinda bulunan TestApi degerini asagidaki satirda okuyunuz.

var bases = builder.Configuration.GetConnectionString("TestApi");


//ConnectionString değerini environment üzerinden okuyun ve asagida tanimlanan sqlConnectionString degiskenine atayiniz.
var sqlConnectionString = builder.Configuration.GetConnectionString("Default");


builder.Services.AddDbContext<MyDbContext>(opt =>
{
    //ConnectionString değişkenini buraya ekle..
    //opt.UseSqlServer(sqlConnectionString);

    opt.UseInMemoryDatabase("DemoDB");
});



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
