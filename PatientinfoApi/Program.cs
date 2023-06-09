using BuisnessLogic;
using DataLogic;
using PIDataLogic.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ILogic, Logic>();
builder.Services.AddScoped<IRepo , Repo>();

var AllowAllPolicy = "AllowAllPolicy";
builder.Services.AddCors(options =>
    options.AddPolicy(AllowAllPolicy, policy => { policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); }));

/*
var config = builder.Configuration.GetConnectionString("connectionstring");*/
builder.Services.AddDbContext<PatientInfoServiceDbContext>(options => options.UseSqlServer("Server=tcp:teamperseverance.database.windows.net,1433;Initial Catalog=patientinfodb;Persist Security Info=False;User ID=manoj;Password=Team@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment()) 
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }
app.UseCors(AllowAllPolicy);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
