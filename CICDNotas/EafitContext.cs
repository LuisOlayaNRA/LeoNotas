using System.Collections.Generic;
using System.Data;
using CICDNotas.Models;
using MySql.Data.MySqlClient;

namespace CICDNotas
{
  public class EafitContext
  {
    public DbSet<Estudiante>? Estudiantes { get; set; }
    public DbSet<Materia>? Materias { get; set; }
    public DbSet<Nota>? Notas { get; set; }

    public DataSet EjecutarSelectMySQL(string controlador, string tipo, string parametro1, string parametro2,  string parametro3, string parametro4,string parametro5)
    {
      string sentenciaSQL = "SELECT * FROM EAFIT.Estudiante;";
      switch (controlador)
      {
        case "Estudiante":
          if (tipo == "Listar")
          {
            sentenciaSQL = "SELECT * FROM EAFIT.Estudiante;";
          }
          else if (tipo == "Buscar")
          {
            sentenciaSQL = "SELECT * FROM EAFIT.Estudiante WHERE Id_Estudiante = {0};";
            sentenciaSQL = string.Format(sentenciaSQL, parametro1);
          }
          else if (tipo == "Insertar")
          {
            sentenciaSQL = "INSERT INTO EAFIT.Estudiante (Id_Estudiante,Nombre) VALUES ({0},'{1}');";
            sentenciaSQL = string.Format(sentenciaSQL, parametro1,parametro2);
          }
          break;

        case "Materia":
          if (tipo == "Listar")
          {
            sentenciaSQL = "SELECT * FROM EAFIT.Materia;";
          }
          else if (tipo == "Buscar")
          {
            sentenciaSQL = "SELECT * FROM EAFIT.Materia WHERE Id_Materia = {0};";
            sentenciaSQL = string.Format(sentenciaSQL, parametro1);
          }
          else if (tipo == "Insertar")
          {
            sentenciaSQL = "INSERT INTO EAFIT.Materia (Id_Materia,Nombre) VALUES ({0},'{1}');";
            sentenciaSQL = string.Format(sentenciaSQL, parametro1,parametro2);
          }
          break;

        case "Nota":
          if (tipo == "Listar")
          {
            sentenciaSQL = "SELECT * FROM EAFIT.Nota;";
          }
          else if (tipo == "Buscar")
          {
            sentenciaSQL = "SELECT * FROM EAFIT.Nota WHERE Id_Materia = {0} AND Id_Estudiante = {1};";
            sentenciaSQL = string.Format(sentenciaSQL, parametro1, parametro2);
          }
          break;
      }
      
      string conexionProcesos = "Data Source=databaseproyectosuniversidad.ckifuzsq7wye.us-east-1.rds.amazonaws.com;Initial Catalog=EAFIT;User Id=admin;Password=Canito2706.*;";
      using (var conn = new MySqlConnection(conexionProcesos))
      {
        var conjuntoDatosSelect = new DataSet();
        try
        {
          conn.Open();
          using (var adaptadorDatos = new MySqlDataAdapter(sentenciaSQL, conn))
          {
            adaptadorDatos.Fill(conjuntoDatosSelect, "EjecucionSelect");
            
          }
        }
        catch (MySqlException ex)
        {
          Console.WriteLine(ex.Message);
        }
        return conjuntoDatosSelect;
      }
    }

    public Dictionary<string, List<string>> obtenerDatos(DataSet conjuntoDatosResultado)
    {
      Dictionary<string, List<string>> datosProcesadosLista = new Dictionary<string, List<string>>();

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
      return datosProcesadosLista;
    }
  }
}