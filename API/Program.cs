using Business.Abstract;
using Business.Concrete;
using Business.DependencyInjection;
using Business.SignalR;
using Core.Helpers;
using Core.Middleware;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Migrations.Mysql;
using Migrations.SqlServer;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddBusinessServices();
builder.Services.AddDataAccessServices();
builder.Services.AddTransient<IHttpContextHelperService, HttpContextHelperManager>();
builder.Services.AddCors(options => { options.AddPolicy("AllowOrigin", builder => builder.AllowAnyOrigin()); });
builder.Services.AddSignalR();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new OpenApiInfo { Title = "Test01", Version = "v1" });
  c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
  {
    Name = "Authorization",
    Type = SecuritySchemeType.ApiKey,
    Scheme = "Bearer",
    BearerFormat = "JWT",
    In = ParameterLocation.Header,
    Description = "JWT Authorization header using the Bearer scheme."
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
var appSettingsSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingsSection);
var appSettings = appSettingsSection.Get<AppSettings>();
var key = Encoding.ASCII.GetBytes(appSettings.Secret);
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication(x =>
{
  x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
  x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
  x.RequireHttpsMetadata = false;
  x.SaveToken = true;
  x.TokenValidationParameters = new TokenValidationParameters
  {
    ValidateIssuerSigningKey = false,
    IssuerSigningKey = new SymmetricSecurityKey(key),
    ValidateIssuer = false,
    ValidateAudience = false
  };
  x.Events = new JwtBearerEvents
  {
    OnMessageReceived = context =>
    {
      var accessToken = context.Request.Query["access_token"];
      var path = context.HttpContext.Request.Path;
      if (!string.IsNullOrEmpty(accessToken) &&
          ((path.StartsWithSegments("/messages") || path.StartsWithSegments("/notifications"))))
      {
        // Read the token out of the query string
        context.Token = accessToken;
      }
      return Task.CompletedTask;
    }
  };


});
builder.Services.AddCors(options =>
{
  options.AddPolicy("corsMachines",
                        policy =>
                        {
                          policy.WithOrigins("http://localhost:4200")
                                                .AllowAnyHeader()
                                                .AllowAnyMethod()
                                                .AllowCredentials();
                        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseCors("corsMachines");
  app.UseSwagger();
  app.UseSwaggerUI();
}
using (var scope = app.Services.CreateScope())
{
  DbContext db = new AppDbContextForSqlServer();
  if (builder.Configuration.GetSection("SqlProvider").Value == "mysql")
  {
    db = new AppDbContextForMysql();
  }

  db.Database.Migrate();
}
app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapHub<MessagesHub>("/messages");
app.MapHub<NotificationsHub>("/notifications");
app.MapControllers();
app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseHsts();
app.Run();
