using Microsoft.OpenApi;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using pro5_auth;
using pro5_auth.Services;
using pro5_auth.Services.IServices;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// -------------------- Controllers --------------------
builder.Services.AddControllers();

// -------------------- Database --------------------
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// -------------------- Services --------------------
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductService, ProductService>();

// -------------------- JWT Authentication --------------------
var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]!);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

// -------------------- Authorization --------------------
builder.Services.AddAuthorization();

// -------------------- Swagger + JWT Support (Swashbuckle 10.x / Microsoft.OpenApi 2.x) --------------------
builder.Services.AddEndpointsApiExplorer();

const string SecuritySchemeId = "Bearer";

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Pro5 Auth API",
        Version = "v1"
    });

    // JWT Bearer Token Support
    options.AddSecurityDefinition(SecuritySchemeId, new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter token like: Bearer eyJhbGciOiJIUzI1NiIs..."
    });

    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference(SecuritySchemeId, document)] = new List<string>()
    });
});

var app = builder.Build();

// -------------------- Swagger --------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// IMPORTANT ORDER
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();