using System.Text.Json.Serialization;
using MemorableAI.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TrilhaApiDesafio.Context;

var builder = WebApplication.CreateBuilder(args);


# region DBCONTEXT
builder.Services.AddDbContext<MemorableContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("MemorableDbConnection")));
#endregion


builder.Services.AddControllers().AddJsonOptions(options =>options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
