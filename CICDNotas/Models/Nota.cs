using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CICDNotas.Models
{
  public class Nota
  {
    public int Id_Nota { get; set; }
    public double Value { get; set; }
    public double Porcentaje { get; set; }
    public string? Actividad { get; set; }
    public int Id_Materia { get; set; }
    public virtual ICollection<Materia>? Materia { get; set; }
    public int Id_Estudiante{ get; set; }
    public virtual ICollection<Estudiante>? Estudiante { get; set; }

    public string? LaNotaAlta { get; set; }

    }
}