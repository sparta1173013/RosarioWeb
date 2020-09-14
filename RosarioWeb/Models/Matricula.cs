using System;
using System.Collections.Generic;

namespace RosarioWeb.Models
{
    public partial class Matricula
    {
        public Matricula()
        {
            Estudiantes = new HashSet<Estudiantes>();
        }

        public int Idmatricula { get; set; }
        public string NombreCompleto { get; set; }
        public string Seccion { get; set; }
        public string Modalidad { get; set; }
        public string AñoLectivo { get; set; }

        public virtual ICollection<Estudiantes> Estudiantes { get; set; }
    }
}
