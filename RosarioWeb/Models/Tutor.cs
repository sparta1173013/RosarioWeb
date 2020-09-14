using System;
using System.Collections.Generic;

namespace RosarioWeb.Models
{
    public partial class Tutor
    {
        public Tutor()
        {
            Estudiantes = new HashSet<Estudiantes>();
        }

        public int Idtutor { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Sexo { get; set; }
        public string Departamento { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public string Ocupacion { get; set; }
        public string EstadoCivil { get; set; }

        public virtual ICollection<Estudiantes> Estudiantes { get; set; }
    }
}
