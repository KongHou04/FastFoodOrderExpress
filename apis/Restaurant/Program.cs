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
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins",
        builder =>
        {
            builder.WithOrigins("http://localhost:52326", "http://localhost:5089", "https://localhost:7280", "http://localhost:5089",
                                "http://localhost:52991", "http://localhost:5016", "https://localhost:7051", "http://localhost:5016")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

// Add DbContexts
builder.Services.AddDbContext<FFOEContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:Default"]!);
});

// Authenticate to use JWTapi
// Dot not change this
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

// You can add more service here
// For example: EmailSender(send an email to client by their information)
// Add Email service
builder.Services.AddSingleton<EmailSender>(options =>
{
    string username = builder.Configuration["MailInfo:Mail"]?? "";
    string password = builder.Configuration["MailInfo:Password"] ?? "";
    return new EmailSender(username, password);
});

// Add Application Repositories and Services
// Do not change these config!
builder.Services.AddScoped<ICategoryRES, CategoryRES>();
builder.Services.AddScoped<ICategorySVC, CategorySVC>();

builder.Services.AddScoped<IProductRES, ProductRES>();
builder.Services.AddScoped<IProductSVC, ProductSVC>();

builder.Services.AddScoped<IProductDiscountRES, ProductDiscountRES>();
builder.Services.AddScoped<IProductDiscountSVC, ProductDiscountSVC>();

builder.Services.AddScoped<IComboDetailsRES, ComboDetailsRES>();
builder.Services.AddScoped<IComboDetailsSVC, ComboDetailsSVC>();

builder.Services.AddScoped<IOrderRES, OrderRES>();
builder.Services.AddScoped<IOrderSVC, OrderSVC>();

builder.Services.AddScoped<IOrderDetailsRES, OrderDetailsRES>();
builder.Services.AddScoped<IOrderDetailsSVC, OrderDetailsSVC>();

builder.Services.AddScoped<ICouponTypeRES, CouponTypeRES>();
builder.Services.AddScoped<ICouponTypeSVC, CouponTypeSVC>();

builder.Services.AddScoped<ICouponRES, CouponRES>();
builder.Services.AddScoped<ICouponSVC, CouponSVC>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigins");
app.UseHttpsRedirection();
app.MapControllers();



app.Run();
