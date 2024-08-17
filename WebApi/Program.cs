using Application.Contracts;
using Application.Implementations;
using Domain.Contracts;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("allOrigins", policyBuilder =>
    {
        policyBuilder.AllowAnyOrigin();
        policyBuilder.AllowAnyHeader();
        policyBuilder.AllowAnyMethod();
    });
});

// Add authentication and authorization
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);
builder.Services
    .AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        // TODO READ https://matteosonoio.it/aspnet-core-authentication-schemes/
        // TOOD READ https://learn.microsoft.com/es-es/aspnet/core/security/authentication/jwt-authn?view=aspnetcore-8.0&tabs=windows

        // IDENTITY PROVIDER
        options.RequireHttpsMetadata = false; // make it true for poduction
        options.Authority = builder.Configuration["JWT:Issuer"];
        options.ClaimsIssuer = builder.Configuration["JWT:Issuer"];

        // The target application for which the JWT is emitted
        options.Audience = builder.Configuration["JWT:Audience"];

        var Key = Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]!);
        options.SaveToken = true;
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
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("IsAdming", "True"));
    options.AddPolicy("AdminOnly", policy => policy.RequireClaim("Role", "Admin"));
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services
builder.Services.AddScoped<IAuthServices, AuthServices>();

builder.Services.AddScoped<IUsersRepository, UsersRepository>();

builder.Services.AddDbContext<DatabaseContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("LocalWebApiDatabase")));

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
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("allOrigins");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
