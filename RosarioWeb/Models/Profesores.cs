using System;
using System.Collections.Generic;

namespace RosarioWeb.Models
{
    public partial class Profesores
    {
        public int Idprofesor { get; set; }
        public int Idmateria { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Sexo { get; set; }
        public string Nacionalidad { get; set; }
        public string Departamento { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Titulo { get; set; }
        public string Inss { get; set; }

        public virtual Materia IdmateriaNavigation { get; set; }
    }
}
