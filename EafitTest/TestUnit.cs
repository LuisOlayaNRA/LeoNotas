using System.Net;
using CICDNotas;
using CICDNotas.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EafitTest
{
  [TestClass]
  public class TestUnit
  {
    [TestMethod]
    public void DatosEnEstudiante()
    {
      EafitContext eafit = new EafitContext();
      var result = eafit.EjecutarSelectMySQL("Estudiante", "Listar", "", "", "", "", "");
      Assert.AreEqual(true, result.Tables["EjecucionSelect"].Rows.Count > 0);
    }

    [TestMethod]
    public void DatosEnMateria()
    {
      EafitContext eafit = new EafitContext();
      var result = eafit.EjecutarSelectMySQL("Materia", "Listar", "", "", "", "", "");
      Assert.AreEqual(true, result.Tables["EjecucionSelect"].Rows.Count > 0);
    }

    [TestMethod]
    public void DatosEnNota()
    {
      EafitContext eafit = new EafitContext();
      var result = eafit.EjecutarSelectMySQL("Nota", "Listar", "", "", "", "", "");
      Assert.AreEqual(true, result.Tables["EjecucionSelect"].Rows.Count > 0);
    }

    [TestMethod]
    public void ObtenerInformacioneEnBuscarEstudiante()
    {
      EafitContext eafit = new EafitContext();
      var result = eafit.EjecutarSelectMySQL("Estudiante", "Buscar", "1", "", "", "", "");
      var result2 = eafit.obtenerDatos(result);
      Assert.AreEqual(true, result2.Count > 0);
    }

      [TestMethod]
      public void ObtenerInformacioneEnBuscarMateria()
      {
        EafitContext eafit = new EafitContext();
        var result = eafit.EjecutarSelectMySQL("Materia", "Buscar", "1", "", "", "", "");
        var result2 = eafit.obtenerDatos(result);
        Assert.AreEqual(true, result2.Count > 0);
      }

    [TestMethod]
    public void CalculoNota()
    {
      EafitContext eafit = new EafitContext();
      var result = eafit.EjecutarSelectMySQL("Nota", "Calculo", "1", "1", "", "", "");
      var result2 = eafit.obtenerDatos(result);
      Assert.AreEqual(true, Convert.ToDouble(result2["NOTA"][0]) > 0);
    }

    [TestMethod]
    public void RquestNota()
    {
      NotaController notaC = new NotaController();
      Assert.AreEqual(true, true);
    }
  }
}