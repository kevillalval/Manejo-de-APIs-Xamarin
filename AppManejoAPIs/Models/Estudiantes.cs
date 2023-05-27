using System;
using System.Collections.Generic;
using System.Text;

namespace AppManejoAPIs.Models
{
    public class Estudiantes
    {
        public string id_estudiante { get; set; }

        public string cedula { get; set; }

        public string nombres { get; set; }

        public string apellidos { get; set; }

        public string email { get; set; }

        public int nivel { get; set; }

        public string materias { get; set; }

        public string materia2 { get; set; }
    }
}
