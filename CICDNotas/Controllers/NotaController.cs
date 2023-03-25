using System.Data;
using CICDNotas.Models;
using Microsoft.AspNetCore.Mvc;
using RegistroNotas.Services.NotaR;

namespace CICDNotas.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class NotaController : ControllerBase
  {
    public NotaController() { }

    EafitContext _context = new EafitContext();
    DataSet conjuntoDatosResultado;
    Dictionary<string, List<string>> datosProcesadosLista = new Dictionary<string, List<string>>();

    [HttpGet]
    [Route("Listar")]
    public string GetListarNotas()
    {
      string variable = "";
      conjuntoDatosResultado = _context.EjecutarSelectMySQL("Nota", "Listar", "", "", "", "", "");
      datosProcesadosLista = _context.obtenerDatos(conjuntoDatosResultado);

      for (int i = 0; i < datosProcesadosLista["Id"].Count; i++)
      {
        variable += "\n Id - " + datosProcesadosLista["Id"][i] + " Nombre: " + datosProcesadosLista["Nombre"][i];
      }
      return variable;
    }

    [HttpPost]
    [Route("Registrar")]
    public IActionResult PostRegistrarNotas([FromBody] Nota nota)
    {
      conjuntoDatosResultado = _context.EjecutarSelectMySQL("Nota", "Insertar", nota.Id_Nota.ToString(), nota.Value.ToString(), nota.Porcentaje.ToString(), nota.Actividad.ToString(), nota.Id_Materia.ToString());
      return Ok("Nota Insertada");
    }

    [HttpGet]
    [Route("TodasLasNotas/{Id_Materia}/{Id_Estudiante}")]
    public IActionResult GetBuscarNotas(int Id_Materia, int Id_Estudiante)
    {
      string? variable = "";
      conjuntoDatosResultado = _context.EjecutarSelectMySQL("Nota", "Buscar", Id_Materia.ToString(), Id_Estudiante.ToString(), "", "", "");
      datosProcesadosLista = _context.obtenerDatos(conjuntoDatosResultado);

      for (int i = 0; i < datosProcesadosLista["Value"].Count; i++)
      {
        variable += $"\n Value: {datosProcesadosLista["Value"][i]} Porcentaje: {datosProcesadosLista["Porcentaje"][i]} Actividad: {datosProcesadosLista["Actividad"][i]}";
      }
      return Ok($"Nota son: {variable}");
    }

    [HttpGet]
    [Route("CalcularNota/{Id_Materia}/{Id_Estudiante}")]
    public IActionResult GetCalcularNota(int Id_Materia, int Id_Estudiante)
    {
      conjuntoDatosResultado = _context.EjecutarSelectMySQL("Nota", "Calculo", Id_Materia.ToString(), Id_Estudiante.ToString(), "", "", "");
      datosProcesadosLista = _context.obtenerDatos(conjuntoDatosResultado);


      return Ok($"La Nota de La Materia es: {datosProcesadosLista["NOTA"][0]}");
    }
  }
}