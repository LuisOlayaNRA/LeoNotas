using System.Data;
using CICDNotas.Models;
using Microsoft.AspNetCore.Mvc;

namespace CICDNotas.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class MateriaController : ControllerBase
  {
    public MateriaController()
    {
    }
    readonly EafitContext _context = new EafitContext();
    DataSet conjuntoDatosResultado;
    Dictionary<string, List<string>> datosProcesadosLista = new Dictionary<string, List<string>>();

    [HttpGet]
    [Route("Listar")]
    public string GetListaMaterias()
    {
      string variable = "";
      conjuntoDatosResultado = _context.EjecutarSelectMySQL("Materia", "Listar", "", "", "", "", "");
      datosProcesadosLista = _context.obtenerDatos(conjuntoDatosResultado);

      for (int i = 0; i < datosProcesadosLista["Id"].Count; i++)
      {
        variable += "\n Id - " + datosProcesadosLista["Id"][i] + " Nombre: " + datosProcesadosLista["Nombre"][i];
      }
      return variable;
    }

    [HttpGet]
    [Route("Buscar/{Id_Materia}")]
    public IActionResult GetBuscarMateria(int Id_Materia)
    {
      conjuntoDatosResultado = _context.EjecutarSelectMySQL("Materia", "Buscar", Id_Materia.ToString(), "", "", "", "");
      datosProcesadosLista = _context.obtenerDatos(conjuntoDatosResultado);
      return Ok($"Materia Encontrada: {Id_Materia} --> {datosProcesadosLista["Nombre"][0]}");
    }

    [HttpPost]
    [Route("Registrar")]
    public IActionResult PostRegistrarMateria([FromBody] Estudiante estudiante)
    {
      conjuntoDatosResultado = _context.EjecutarSelectMySQL("Materia", "Insertar", estudiante.Id_Estudiante.ToString(), estudiante.Nombre.ToString(), "", "", "");
      return Ok("Materia Insertada");
    }
  }
}