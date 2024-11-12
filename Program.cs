using System.Text.Json.Serialization;
using api.healthy.src.components.diet.repositories;
using api.healthy.src.components.diet.services;
using api.healthy.src.components.users.repositories;
using api.healthy.src.components.users.services;
using api.healthy.src.context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDbContext<ApiContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IDietRespository, DietRepository>();
builder.Services.AddScoped<IDietService, DietService>();



builder.Services.AddCors(options => {
  options.AddPolicy("Free", policy => {
    policy.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
  });
});


var app = builder.Build();


app.UseCors("Free");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
