using Microsoft.EntityFrameworkCore;
using LojaVirtualAPI.Context;
using LojaVirtualAPI.Repositories;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")); 
});
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddControllers();


var app = builder.Build();
app.MapControllers();
app.UseCors(policy => 
    policy.WithOrigins("http://localhost:5059", "https://localhost:7292")
    .AllowAnyMethod().AllowAnyHeader().WithHeaders(HeaderNames.ContentType)
);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapSwagger();
}

app.MapGet("/", () => "Hello World!");

app.Run();
