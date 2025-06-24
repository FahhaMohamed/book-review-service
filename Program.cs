using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ISeederService, SeederService>();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});


builder.Services.AddControllers();

var app = builder.Build();


app.UseMiddleware<ErrorHandleMiddleware>();

app.MapGet("/", () => "Welcome to Book Review App!!!");

app.MapControllers();

app.Run();
