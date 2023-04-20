using NSE.Identity.API.Configuration;

string baseUrl = "nse/identity";
string serviceName = "Identity";

var builder = WebApplication.CreateBuilder(args);

// Configure Services
builder.Services.AddControllers();
builder.Services.AddAuthenticationConfiguration(builder.Configuration);
builder.Services.AddSwaggerConfiguration();
builder.Services.RegisterHandlers();


var app = builder.Build();
// Configure
if (app.Environment.IsDevelopment()) app.UseDeveloperExceptionPage();
app.UseSwaggerConfiguration(baseUrl, serviceName);
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthenticationConfiguration();
app.MapControllers();
app.Run();
