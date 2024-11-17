using Application;
using Application.Contracts;
using Application.Implementations;
using Domain.Enums;
using Infrastructure;
using Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Configure JWT settings - prueba
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddHttpContextAccessor();

builder.Services.AddCors(options =>
{
    options.AddPolicy("allOrigins", policyBuilder =>
    {
        policyBuilder.AllowAnyOrigin();
        policyBuilder.AllowAnyHeader();
        policyBuilder.AllowAnyMethod();
    });
});

builder.Services
    .AddAuthentication(options => options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        // TODO READ https://matteosonoio.it/aspnet-core-authentication-schemes/
        // TOOD READ https://learn.microsoft.com/es-es/aspnet/core/security/authentication/jwt-authn?view=aspnetcore-8.0&tabs=windows

        // IDENTITY PROVIDER
        options.RequireHttpsMetadata = false; // make it true for poduction
        options.Authority = builder.Configuration["JWT:Issuer"];
        options.ClaimsIssuer = builder.Configuration["JWT:Issuer"];
        options.Audience = builder.Configuration["JWT:Audience"];
        options.SaveToken = true;

        var Key = Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]!);

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false, // on production make it true
            ValidateAudience = false, // on production make it true
            ValidateLifetime = false, // on production make it true
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidAudience = builder.Configuration["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Key),
            //ClockSkew = TimeSpan.Zero,
            ClockSkew = TimeSpan.FromMinutes(5),
        };
    });

builder.Services.AddAuthorization(options =>
{
    //options.AddPolicy("AdminOnly", policy => policy.RequireRole("IsAdming", "True"));
    //options.AddPolicy("AdminOnly", policy => policy.RequireClaim("Role", "Admin"));
    options.AddPolicy("AdminOnly", policy => policy.RequireClaim("Role", nameof(UserRoles.Admin)));
});

builder.Services.AddControllers();
builder.Services.AddApplication();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
    {
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Scheme = JwtBearerDefaults.AuthenticationScheme,
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization header required"
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                },
                new string[] {}
            }
        });
    }
);

// Add services
builder.Services.AddScoped<IAuthServices, AuthServices>();
//builder.Services.AddScoped<IUsersRepository, UsersRepository>();

var connString = builder.Configuration.GetConnectionString("LocalWebApiDatabase");
if (bool.TryParse(Environment.GetEnvironmentVariable("IS_DOCKER"), out bool isDocker) && isDocker)
{
    connString = builder.Configuration.GetConnectionString("WebApiDatabase");
}

builder.Services.AddInfrastructure(connString);

var app = builder.Build();

// Apply migrations
using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    var dbContext = serviceScope.ServiceProvider.GetService<DatabaseContext>();
    if (dbContext is null) Console.WriteLine("Unable to establish connection to db");
    dbContext?.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    Console.WriteLine("DEVELOPMENT ENVIRONMENT");
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("allOrigins");
app.UseAuthentication();
app.UseAuthorization();

app.UseExceptionHandler();

app.MapControllers();

app.Run();
