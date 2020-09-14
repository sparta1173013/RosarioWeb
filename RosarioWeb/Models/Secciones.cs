using System;
using System.Collections.Generic;

namespace RosarioWeb.Models
{
    public partial class Secciones
    {
        public int Idseccion { get; set; }
        public int? Idestudiante { get; set; }
        public string Seccion { get; set; }

        public virtual Estudiantes IdestudianteNavigation { get; set; }
    }
}
