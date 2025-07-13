using System.Text.Json.Serialization;
using MemorableAI.Application.Interfaces;
using MemorableAI.Application.Services;
using MemorableAI.Domain.Interfaces;
using MemorableAI.Infra.Context;
using MemorableAI.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TrilhaApiDesafio.Context;

var builder = WebApplication.CreateBuilder(args);


# region DBCONTEXT
builder.Services.AddDbContext<MemorableContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("MemorableDbConnection")));
#endregion


builder.Services.AddControllers().AddJsonOptions(options =>options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IMemorableRepository, MemorableRepository>();
builder.Services.AddScoped<ITaskService, TaskService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
