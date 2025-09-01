using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PatentWebApiProject.Data;
using PatentWebApiProject.Interface;
using PatentWebApiProject.Models;
using PatentWebApiProject.Repository;
using PatentWebApiProject.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<ICrud<Members>, MembersRepository>();
builder.Services.AddScoped<MembersService>();
builder.Services.AddScoped<IToken,TokenService>();

builder.Services.AddScoped<ICrud<Patent>, PatentRepository>();
builder.Services.AddScoped<ICrud<InternationalPatent>, InternationalPatentRepository>();
builder.Services.AddScoped<ICrud<PatentGrants>, PatentGrantRepository>();
builder.Services.AddScoped<IPatent, PatentRepository>();
builder.Services.AddScoped<IInPatent, InternationalPatentRepository>();
builder.Services.AddScoped<IGrants, PatentGrantRepository>();
builder.Services.AddScoped<PatentService>();
builder.Services.AddScoped<InternationalPatentService>();
builder.Services.AddScoped<PatentGrantService>();


builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
    });
builder.Services.AddDbContext<PatentContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConn")));

builder.Services.Configure<Members>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,

        IssuerSigningKey = new

    SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"]!)),
        ValidateIssuer = false,
        ValidateAudience = false

    };
});
builder.Services.AddSwaggerGen(c => {
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
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
Array.Empty<string>()
}
});
});


var app = builder.Build();

app.UseStatusCodePages(context =>
{
    if (context.HttpContext.Response.StatusCode == 403)
    {
        context.HttpContext.Response.ContentType = "application/json";
        return context.HttpContext.Response.WriteAsync("{\"message\":\"Forbidden : You are not allowed to perform this operation\"}");
    }
    return Task.CompletedTask;
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
