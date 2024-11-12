using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using NZWalk.API.Data;
using NZWalk.API.Mappings;
using NZWalk.API.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<NZWalkDbContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("NZWalkConnectionString")));
builder.Services.AddDbContext<NZWalksAuthDBContext>(option => 
option.UseSqlServer(builder.Configuration.GetConnectionString("NZWalkAuthConnectionString")));
builder.Services.AddScoped<IRegionRepository, SqlRegionRepository>();
builder.Services.AddScoped<IWalkRepository, SqlWalkRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer=true,//server ya check kry ga (jinho ny token generate kya hei) vo trusted hei
        // Iska purpose ye hai ke sirf trusted issuer se aane wale tokens ko hi accept kiya jaye.
        ValidateAudience = true,//ya token kis application ky liay valid hei
        ValidateLifetime=true,
        ValidateIssuerSigningKey=true,
        ValidIssuer = builder.Configuration["JWt:Issuer"],
        ValidAudience= builder.Configuration["JWt:Audience"],
        IssuerSigningKey= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWt:key"]))

    });

var app = builder.Build();

// Configure the HTTP request pipeline.
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
