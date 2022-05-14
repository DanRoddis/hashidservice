using HashidsNet;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

var alphabet = "0123456789ABCDEGHJKLMPQRSTUVWXYZ";
var minHashLength = 6;

app.MapGet("/encode", (int id, string salt) =>
{
    var hashids = new Hashids(salt, minHashLength, alphabet);
    var hash = hashids.Encode(id);
    return hash;
});

app.MapGet("/decode", (string hash, string salt) =>
{
    var hashids = new Hashids(salt, minHashLength, alphabet);
    var id = hashids.Decode(hash);
    return id;
});

app.Run();