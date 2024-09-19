using System.Globalization;

namespace CICDNotas.Models;

public class Parcial
{
    public int Id { get; set; }
    public string Nombres { get; set; }
    public string Profes { get; set; }
    public int Nota { get; set; }
    public int NotaExtra { get; set; }
    public int EstudianteId { get; set; }
    public Estudiante Estudiante { get; set; }

    public string variable_1 { get; set; }

    public string Variable_2 { get; set; }
    public string Variable_3 { get; set; }
    public string Variable_4 { get; set; }
    public string Variable_44 { get; set; }
    public string Variable_5 { get; set; }
}
