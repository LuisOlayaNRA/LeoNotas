namespace CICDNotas.Models;

public class Parcial
{
    public int Id { get; set; }
    public string Nombresitos { get; set; }
    public int Nota { get; set; }
    public int NotaExtra { get; set; }
    public int EstudianteId { get; set; }
    public Estudiante Estudiante { get; set; }
}
