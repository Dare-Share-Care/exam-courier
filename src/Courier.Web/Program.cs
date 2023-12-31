using System.Text;
using Courier.Web.Data;
using Courier.Web.Interfaces.DomainServices;
using Courier.Web.Interfaces.Repositories;
using Courier.Web.Producer;
using Courier.Web.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;


const string policyName = "AllowOrigin";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyName,
        builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

// Register IHttpClientFactory
builder.Services.AddHttpClient();

// DBContext
builder.Services.AddDbContext<CourierContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbContext"));
});

// Build services
builder.Services.AddScoped<ICourierService, CourierService>();

// Register GeocodingService
builder.Services.AddSingleton<IGeocodingService>(provider => {
    var httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();
    var httpClient = httpClientFactory.CreateClient();
    return new GeocodingService("pk.fe397984a9406a068bd52eb413d8d784", httpClient);
});

// Build repositories
builder.Services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

// JWT Configuration
var key = Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecretKey"]!);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireCourierRole", policy => policy.RequireRole("Courier"));
    // Add more policies for other roles as needed
});

// Kafka Producer
builder.Services.AddSingleton<KafkaProducer>();

var app = builder.Build();

app.UseStaticFiles();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(policyName);

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.UseHttpsRedirection();

app.MapControllers();

app.MapFallbackToFile("index.html");

app.Run();

public partial class Program { }