using FileUploadLayer;
using MessagingLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddHostedService<RabbitMqListener>();

builder.Services.Configure<RabbitMqSettings>(
    builder.Configuration.GetSection("RabbitMq"));

builder.Services.Configure<BlobSettings>(
    builder.Configuration.GetSection("BlobStorage"));

builder.Services.AddScoped<MessageSender>();
builder.Services.AddScoped<FileDAO>();

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
