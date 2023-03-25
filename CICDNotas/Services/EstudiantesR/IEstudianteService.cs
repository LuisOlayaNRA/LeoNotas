using CICDNotas.Models;
using Microsoft.AspNetCore.Mvc;

namespace CICDNotas.Services.EstudiantesR
{
  public interface IEstudianteService
  {
    public IEnumerable<Estudiante> GetMostrarEstudiantes();
    //public Task Save(Estudiante estudiante);
    //public Estudiante GetFindEstudiante(int Id);

  }
}
