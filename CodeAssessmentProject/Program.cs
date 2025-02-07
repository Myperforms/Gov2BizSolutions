using CodeAssessment.Application;
using CodeAssessment.Infrastructure;
using CodeAssessment.Infrastructure.Context;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddApplicationServices();

DependencyContainer.RegisterServices(builder.Services);
ApplicationServiceRegistration.RegisterServices(builder.Services);
builder.Services.AddDbContext<CodeAssessmentDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CodeAssessmentConnection")).EnableSensitiveDataLogging();
});

builder.Services.AddSession();

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
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employee}/{action=Login}/{id?}");

app.Run();
