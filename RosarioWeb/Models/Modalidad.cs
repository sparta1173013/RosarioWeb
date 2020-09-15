using System;
using System.Collections.Generic;

namespace RosarioWeb.Models
{
    public partial class Modalidad
    {
        public int Idmodalidad { get; set; }
        public int Idestudiante { get; set; }
        public string Modalidad1 { get; set; }

        public virtual Estudiantes IdestudianteNavigation { get; set; }
    }
}
