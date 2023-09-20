using Microsoft.EntityFrameworkCore;
using TurniketWebApi.Data.Context;
using TurniketWebApi.Service.Configuration;
using TurniketWebApi.Service.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddCustomExtension();

builder.Services.AddDbContext<DatabaseContext>(options =>
     options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
          builder =>
          {
              builder.EnableRetryOnFailure(10, TimeSpan.FromSeconds(10), null);
              builder.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
          })
    );

builder.Services.AddAutoMapper(typeof(MappingProFiles));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
