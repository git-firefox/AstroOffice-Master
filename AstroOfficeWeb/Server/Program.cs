using System.Reflection;
using System.Text;
using ASBAL;
using ASDAL;
using ASDLL;
using ASDLL.AstroScienceWeb.BLL;
using ASDLL.DataAccess.Core;
using ASModels;
using AstroOfficeWeb.Shared.Models;
using AutoMapper;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

string astroOfficeConnectionString = builder.Configuration.GetConnectionString("AstroOfficeConnectionString");
string matchMakingConnectionString = builder.Configuration.GetConnectionString("MatchMakingConnectionString");

AstroGlobal.Online = true;
AstroGlobal.AstroConnectionString = astroOfficeConnectionString;

// Add services to the container.

builder.Services.AddDbContext<AstrooffContext>(options =>
{
    options.UseSqlServer(astroOfficeConnectionString);
});

//builder.Services.AddDbContext<MatchMakingContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("MatchMakingConnectionString"));
//});

builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
builder.Services.AddTransient<BALUser>();
builder.Services.AddTransient<DALUser>();
builder.Services.AddTransient<DALCountry>();
builder.Services.AddTransient<BALCountry>();
builder.Services.AddTransient<KPBLL>();
builder.Services.AddTransient<PlanetBLL>();
builder.Services.AddTransient<LocationBLL>();
builder.Services.AddTransient<PredictionBLL>();
builder.Services.AddTransient<KundliBLL>();
builder.Services.AddTransient<KPDAO>();
builder.Services.AddTransient<BestBLL>();
builder.Services.AddTransient<KPPredBLL>();
builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSwaggerGen(sg =>
{
    sg.SwaggerDoc("v1", new OpenApiInfo { Title = "AstroOfficeWeb.Server", Version = "v1" });
    sg.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please Bearer and then token in the field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    var securityRequirement = new OpenApiSecurityRequirement();
    var scheme = new OpenApiSecurityScheme
    {
        Reference = new OpenApiReference
        {
            Id = "Bearer",
            Type = ReferenceType.SecurityScheme,
        }
    };
    securityRequirement.Add(scheme, new List<string>() { "Bearer" });
    sg.AddSecurityRequirement(securityRequirement);
});

var sectionJWTSettings = builder.Configuration.GetSection("JWTSettings");
builder.Services.Configure<JWTSettings>(sectionJWTSettings);

var jwtSettings = sectionJWTSettings.Get<JWTSettings>();
var key = Encoding.ASCII.GetBytes(jwtSettings.SecretKey);

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidAudience = jwtSettings.ValidAudience,
        ValidIssuer = jwtSettings.ValidIssuer,
        ClockSkew = TimeSpan.Zero
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI(su =>
{
    su.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "AstroOfficeWeb.Server");
});

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
