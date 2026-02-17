
using WebApplication1.Service;

var builder = WebApplication.CreateBuilder(args);

// Добавляем сервис
builder.Services.AddSingleton<TaskService>();

builder.Services.AddControllers();

// CORS для frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowAll");

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();