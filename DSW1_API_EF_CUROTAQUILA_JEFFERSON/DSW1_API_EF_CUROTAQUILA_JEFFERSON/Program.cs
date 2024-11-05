using DSW1_API_EF_CUROTAQUILA_JEFFERSON.dao;
using DSW1_API_EF_CUROTAQUILA_JEFFERSON.dao.daoImplements;
using DSW1_API_EF_CUROTAQUILA_JEFFERSON.Service;

var builder = WebApplication.CreateBuilder(args);

// Agrega los servicios al contenedor
builder.Services.AddControllersWithViews();

// Registra las implementaciones concretas de las interfaces
builder.Services.AddScoped<DocenteService>();
builder.Services.AddScoped<iDocentesDAO, DaoImplements>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Configure the HTTP request pipeline.



var app = builder.Build();

// Configura el pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Habilitar CORS
app.UseCors(builder =>
{
    builder.WithOrigins("https://localhost:7019")
           .AllowAnyHeader()
           .AllowAnyMethod();
});
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
