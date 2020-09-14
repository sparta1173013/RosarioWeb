using System;
using System.Collections.Generic;

namespace RosarioWeb.Models
{
    public partial class Notas
    {
        public Notas()
        {
            Estudiantes = new HashSet<Estudiantes>();
        }

        public int Idnota { get; set; }
        public string PrimerParcial { get; set; }
        public string SegundoParcial { get; set; }
        public string TercerParcial { get; set; }
        public string NotaFinal { get; set; }

        public virtual ICollection<Estudiantes> Estudiantes { get; set; }
    }
}
