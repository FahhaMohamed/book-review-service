using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);


//******Calling Seeders******
builder.Services.AddSingleton<ISeederService, SeederService>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "Welcome to Book Review App!!!");

app.MapControllers();

app.Run();
