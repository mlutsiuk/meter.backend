using Meter.Auth;
using Meter.Mapping;
using Meter.Models;
using Meter.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(opt =>  opt.AddPolicy("CorsPolicy", c =>
{ 
    c.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
}));

JwtAuthOptions jwtAuthOptions = new JwtAuthOptions(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddScoped<JwtAuthOptions>();

builder.Services.AddScoped<CounterRepository>();
builder.Services.AddScoped<DashboardRepository>();
builder.Services.AddScoped<GroupRepository>();
builder.Services.AddScoped<IconRepository>();
builder.Services.AddScoped<MeasureRepository>();
builder.Services.AddScoped<UserRepository>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtAuthOptions.Issuer,
            ValidateAudience = true,
            ValidAudience = jwtAuthOptions.Audience,
            ValidateLifetime = true,
            IssuerSigningKey = jwtAuthOptions.GetSymmetricSecurityKey()
        };
    });
builder.Services.AddAuthorization();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

builder.Services.AddSwaggerGen();

// if (builder.Environment.IsDevelopment())
// {
//     string connection = builder.Configuration.GetConnectionString("MySQL");
//     builder.Services.AddDbContext<AppDbContext>(options =>
//         options.UseMySql(connection, ServerVersion.AutoDetect(connection)));
// }
// else
// {
    string connection = builder.Configuration.GetConnectionString("SQLServer");
    builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));
// }


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<AppDbContext>();    
    context.Database.Migrate();
}

app.Run();