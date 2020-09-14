using System;
using System.Collections.Generic;

namespace RosarioWeb.Models
{
    public partial class Materia
    {
        public Materia()
        {
            Estudiantes = new HashSet<Estudiantes>();
            Profesores = new HashSet<Profesores>();
        }

        public int Idmateria { get; set; }
        public string Materia1 { get; set; }
        public string Año { get; set; }
        public string Semestre { get; set; }

        public virtual ICollection<Estudiantes> Estudiantes { get; set; }
        public virtual ICollection<Profesores> Profesores { get; set; }
    }
}
