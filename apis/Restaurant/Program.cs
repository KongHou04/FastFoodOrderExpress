using System.Text;
using Db.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repositories.Implements;
using Repositories.Interfaces;
using Services.Implements;
using Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();


builder.Services.AddDbContext<FFOEContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:Default"]!);
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
    };
});

// Add Email service
builder.Services.AddSingleton<EmailSender>(options =>
{
    string username = builder.Configuration["MailInfo:Mail"]?? "";
    string password = builder.Configuration["MailInfo:Password"] ?? "";
    return new EmailSender(username, password);
});

// Add Application Repositories and Services
builder.Services.AddScoped<ICategoryRES, CategoryRES>();
builder.Services.AddScoped<ICategorySVC, CategorySVC>();
builder.Services.AddScoped<IProductRES, ProductRES>();
builder.Services.AddScoped<IProductSVC, ProductSVC>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();



app.Run();
