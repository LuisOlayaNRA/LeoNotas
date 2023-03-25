using System.Data;
using CICDNotas.Models;
using Microsoft.AspNetCore.Mvc;

namespace CICDNotas.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class EstudianteController : ControllerBase
  {
    readonly EafitContext _context = new EafitContext();
    DataSet conjuntoDatosResultado;
    Dictionary<string, List<string>> datosProcesadosLista = new Dictionary<string, List<string>>();
    public EstudianteController()
    {

    }
    [HttpGet]
    [Route("Listar")]
    public string GetListaEstudiantes()
    {
      string variable = "";
      conjuntoDatosResultado = _context.EjecutarSelectMySQL("Estudiante", "Listar", "" , "", "", "", "");
      datosProcesadosLista = _context.obtenerDatos(conjuntoDatosResultado);

      for (int i = 0; i < datosProcesadosLista["Id"].Count; i++)
      {
        variable += $"\n Id - {datosProcesadosLista["Id"][i]} Nombre: {datosProcesadosLista["Nombre"][i]}";
      }
      return variable;
    }

    [HttpGet]
    [Route("Buscar/{Id_Estudiante}")]
    public IActionResult GetBuscarEstudiantes(int Id_Estudiante)
    {
      conjuntoDatosResultado = _context.EjecutarSelectMySQL("Estudiante", "Buscar", Id_Estudiante.ToString(), "", "", "", "");
      datosProcesadosLista = _context.obtenerDatos(conjuntoDatosResultado);

      return Ok($"Estudiante Encontrado: {Id_Estudiante}");
    }

    [HttpPost]
    [Route("Registrar")]
    public IActionResult PostRegistrarEstudiante([FromBody] Estudiante estudiante)
    {
      conjuntoDatosResultado = _context.EjecutarSelectMySQL("Estudiante", "Insertar", estudiante.Id_Estudiante.ToString(), estudiante.Nombre.ToString(), "", "", "");
      return Ok("Estudiante Insertado");
    }
  }
}