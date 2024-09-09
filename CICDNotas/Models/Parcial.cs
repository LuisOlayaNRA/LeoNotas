﻿namespace CICDNotas.Models;

public class Parcial
{
    public int Id { get; set; }
    public string Nombres { get; set; }
    public string Profes { get; set; }
    public int Nota { get; set; }
    public int EstudianteId { get; set; }
    public Estudiante Estudiante { get; set; }
}
