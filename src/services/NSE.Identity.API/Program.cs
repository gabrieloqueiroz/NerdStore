using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NSE.Identity.API.Data;
using NSE.Identity.API.Configuration;
using NSE.Identity.API.Model;
using System.Runtime.CompilerServices;

string baseUrl = "nse/identity";
string serviceName = "Identity";

var builder = WebApplication.CreateBuilder(args);

// Configure Services
builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.addAuthenticationConfiguration(builder.Configuration);
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();
// Configure
if (app.Environment.IsDevelopment()) app.UseDeveloperExceptionPage();
app.UseSwaggerConfiguration(baseUrl, serviceName);
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers ();
app.Run();
