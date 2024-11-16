using URL_Shorter.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using URL_Shorter.Server.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "URL_Shorter",
                      policy =>
                      {
                          policy.WithOrigins("http://localhost4200",
                                              "http://www.localhost7222",
                                              "https://127.0.0.1:4200",
                                              "http://myhost.com",
                                              "http://myhost.com:4200")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod();
                      });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPasswordHasher<Account>, PasswordHasher<Account>>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(builder =>
{
builder.AllowAnyOrigin();
builder.AllowAnyHeader();
builder.AllowAnyMethod();
            });

app.UseAuthorization();

void ConfigureServices(IServiceCollection services)
{
    services.AddRazorPages();
    services.AddScoped<IAboutService, AboutService>(); 
}


app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
