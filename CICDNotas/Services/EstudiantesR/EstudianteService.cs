
using System.Data;
using System.Text.RegularExpressions;
using CICDNotas.Models;
using Microsoft.AspNetCore.Mvc;

namespace CICDNotas.Services.EstudiantesR
{
  public class EstudianteService : IEstudianteService
  {
    readonly EafitContext _context = new EafitContext();
    public EstudianteService()
    {
    }

    public IEnumerable<Estudiante> GetMostrarEstudiantes()
    {
     var datos = _context.EjecutarSelectMySQL("","","","","","","");

      foreach (DataRow dr in datos.Tables["EjecucionSelect"].Rows)
      {
        var t  = dr.ItemArray[1];   
      }
       //Se hace comentario de Ejemplo
        return (IEnumerable<Estudiante>)datos;
    }
  }
}