using Drogaria.Domain.Entities.ApplicationUsers;
using Drogaria.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Drogaria.Infra.Data.Repository;
using Drogaria.Api.Token;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Drogaria.Api.AutoMapper;
using Microsoft.AspNetCore.Identity;
using Drogaria.Domain.Interfaces;
using DrPay.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Drogaria.Api.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Http.Features;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API_DDD_2022", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description =
            "JWT Authorization Header - utilizado com Bearer Authentication.\r\n\r\n" +
            "Digite 'Bearer' [espaço] e então seu token no campo abaixo.\r\n\r\n" +
            "Exemplo (informar sem as aspas): 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
});

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 4;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = true;
});

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//Dependency Injection
builder.Services.AddDIConfiguration();

builder.Services.AddOptions();



//ConfigServices
var connectionStringMysql = builder.Configuration.GetConnectionString("ConnectionMysql")!;
builder.Services.AddDbContext<DrogariaDbContext>(options => options.UseMySQL(connectionStringMysql));

builder.Services.Configure<FormOptions>(options =>
{
    options.ValueLengthLimit = int.MaxValue;
    options.MultipartBodyLengthLimit = int.MaxValue;
});

builder.Services.AddOptions();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//Interface e Repositorio
builder.Services.AddSingleton(typeof(IRepository<>), typeof(Repository<>));

//Serviço Dominio
//builder.Services.AddSingleton<IServiceMessage, IServiceMessage>();

//JWT]
var key = Encoding.ASCII.GetBytes("BrunoFaria0123456789_JWTToken_2023_Drogaria");

var tokenValidationParams = new TokenValidationParameters
{
    ValidateIssuerSigningKey = true,
    IssuerSigningKey = new SymmetricSecurityKey(key),
    ValidateIssuer = false,
    ValidateAudience = false,
    ValidateLifetime = true,
    RequireExpirationTime = false,
    ClockSkew = TimeSpan.Zero
};


builder.Services.AddSingleton(tokenValidationParams);

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = false;
})
    .AddEntityFrameworkStores<DrogariaDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(jwt => {
    jwt.RequireHttpsMetadata = false;
    jwt.SaveToken = true;
    
    jwt.TokenValidationParameters = tokenValidationParams;
    jwt.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            var accessToken = context.Request.Path;
            var path = context.HttpContext.Request.Path;
            if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/notificacaoHub"))
                context.Token = accessToken;

            return Task.CompletedTask;
        }
    };
});




builder.Services.AddAutoMapper(options =>
{
    options.AddProfile(new DomainToViewModelMappingProfile());
    options.AddProfile(new ViewModelToDomainMappingProfile());
    options.AddProfile(new ApplicationMappingProfile());
    options.AllowNullCollections = true;
});


var app = builder.Build();
var devClient = "http://localhost:7068";
app.UseCors(builder => builder.SetIsOriginAllowed(origin => true)
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowAnyOrigin()
    .AllowCredentials()
    .WithOrigins(devClient)) ;

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseSwaggerUI();

app.Run();

