using Crude_Operation1.WEB.Interface;
using Crude_Operation1.WEB.Manager;
using Crude_Operation1.WEB.DataModels; // Ensure this is included
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using Crude_Operation1.WEB.Validators;
using Crude_Operation1.WEB.ViewModel;
using Mapster;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Register your specific DbContext
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

// Register the EmployeeManager
builder.Services.AddScoped<IEmployeeManager, EmployeeManager>();

TypeAdapterConfig<EmployeeViewModel, Employee>.NewConfig()
    .Map(dest => dest.EmployeeId, src => 0);
builder.Services.AddControllersWithViews()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<EmployeeViewModelValidator>());

builder.Services.AddMediatR(typeof(Program).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employee}/{action=Index}/{id?}");

app.Run();
