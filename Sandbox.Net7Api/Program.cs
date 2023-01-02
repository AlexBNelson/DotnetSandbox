using Microsoft.AspNetCore.Mvc;
using Sandbox;
using Sandbox.Net7Api;
using Sandbox.Serialization;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOutputCache(options =>
{
    options.AddBasePolicy(x => x.Expire(TimeSpan.FromSeconds(30)));
    options.AddBasePolicy(x => x.With(y => y.HttpContext.Request.Query["nocache"]==true).NoCache());
    options.AddPolicy("nocache", x => x.NoCache());
});

builder.Services.AddMediatR(x => x.AsScoped(), typeof(Program));

builder.Services.AddHostedService<MatchService>();


var app = builder.Build();

app.UseOutputCache();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MediateGet<UserRequest>("first20usersAppendTag/{tag}");

app.MapGet("firstUserSerializedAndConvertedToRunes", async () => {
    var users = UserGenerator.GenerateUsers();

    var userSerializer = new UserSerializer();

    var serialized = userSerializer.SerializeUsersListReturnFirst(users) + "🐂";

    var array = serialized.EnumerateRunes();


    var runeList = array.ToArray();

    return Results.Ok(runeList);
}).CacheOutput("nocache");

app.Run();
