using CICDNotas;
using CICDNotas.Services.EstudiantesR;
using CICDNotas.Services.MateriaR;
using RegistroNotas.Services.NotaR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEstudianteService, EstudianteService>();
//builder.Services.AddScoped<IMateriaService, MateriaService>();
//builder.Services.AddScoped<INotaService, NotaService>();

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
