using System.Data;
using CICDNotas.Services.EstudiantesR;
using Microsoft.AspNetCore.Mvc;

namespace CICDNotas.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class EstudianteController : ControllerBase
  {
    readonly IEstudianteService estudianteService;
    EafitContext _context = new EafitContext();
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
      conjuntoDatosResultado = _context.EjecutarSelectMySQL("Estudiante", "Listar", "");
      int iteracionColumna = 0;
      foreach (DataRow dr in conjuntoDatosResultado.Tables["EjecucionSelect"].Rows)
      {
        foreach (var item in dr.ItemArray)
        {
          string key = dr.Table.Columns[iteracionColumna].ToString().Replace("@", "").Split('_')[0].Trim();

          if (!datosProcesadosLista.ContainsKey(key))
          {
            datosProcesadosLista.Add(key, new List<string>());
          }
          datosProcesadosLista[key].Add(item.ToString());
          iteracionColumna++;
          if (dr.Table.Columns.Count == iteracionColumna) iteracionColumna = 0;
        }
      }

      for (int i = 0; i < datosProcesadosLista["Id"].Count; i++)
      {
        variable += "\n Id - " + datosProcesadosLista["Id"][i] + " Nombre: " + datosProcesadosLista["Nombre"][i];
      }
      return variable;
    }

    [HttpGet]
    [Route("Buscar/{Id_Estudiante}")]
    public IActionResult GetBuscarEstudiantes(int Id_Estudiante)
    {
      conjuntoDatosResultado = _context.EjecutarSelectMySQL("Estudiante", "Buscar", Id_Estudiante.ToString());
      int iteracionColumna = 0;
      if (conjuntoDatosResultado.Tables["EjecucionSelect"].Rows.Count > 0)
      {
        foreach (DataRow dr in conjuntoDatosResultado.Tables["EjecucionSelect"].Rows)
        {
          foreach (var item in dr.ItemArray)
          {
            string key = dr.Table.Columns[iteracionColumna].ToString().Replace("@", "").Split('_')[0].Trim();

            if (!datosProcesadosLista.ContainsKey(key))
            {
              datosProcesadosLista.Add(key, new List<string>());
            }
            datosProcesadosLista[key].Add(item.ToString());
            iteracionColumna++;
            if (dr.Table.Columns.Count == iteracionColumna) iteracionColumna = 0;
          }
        }
      }

      return Ok($"Estudiante Encontrado: {Id_Estudiante}");
    }

    //[HttpPost]
    //[Route("Registrar")]
    //public IActionResult PostRegistrarEstudiante([FromBody] Estudiante estudiante)
    //{
    //  estudianteService.Save(estudiante);
    //  return Ok();
    //}
  }

}