namespace CICDNotas.Models;

public class Parcial
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int Nota { get; set; }
    public int EstudianteId { get; set; }
    public Estudiante Estudiante { get; set; }
}
