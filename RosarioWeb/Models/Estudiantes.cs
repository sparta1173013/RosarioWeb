using System;
using System.Collections.Generic;

namespace RosarioWeb.Models
{
    public partial class Estudiantes
    {
        public Estudiantes()
        {
            Modalidad = new HashSet<Modalidad>();
            Secciones = new HashSet<Secciones>();
        }

        public int Idestudiante { get; set; }
        public int Idmateria { get; set; }
        public int Idtutor { get; set; }
        public int Idmatricula { get; set; }
        public int Idnota { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Sexo { get; set; }
        public string Nacionalidad { get; set; }
        public string Departamento { get; set; }
        public string Domicilio { get; set; }

        public virtual Materia IdmateriaNavigation { get; set; }
        public virtual Matricula IdmatriculaNavigation { get; set; }
        public virtual Notas IdnotaNavigation { get; set; }
        public virtual Tutor IdtutorNavigation { get; set; }
        public virtual ICollection<Modalidad> Modalidad { get; set; }
        public virtual ICollection<Secciones> Secciones { get; set; }
    }
}
