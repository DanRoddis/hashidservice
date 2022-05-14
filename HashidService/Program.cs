using HashidsNet;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapGet("/encode", (int id, string salt) =>
{
    var hashids = new Hashids(salt, 6, "0123456789ABCDEGHJKLMPQRSTUVWXYZ");
    var hash = hashids.Encode(id);
    return hash;
});

app.MapGet("/decode", (string hash, string salt) =>
{
    var hashids = new Hashids(salt, 6, "0123456789ABCDEGHJKLMPQRSTUVWXYZ");
    var id = hashids.Decode(hash);
    return id;
});

app.Run();