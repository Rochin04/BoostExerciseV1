using System;
using System.Collections.Generic;
using System.Text;

namespace BoostExercise_RERM.Model
{
    public class BoostExerciseModel
    {
        public int IdExercise { get; set; }
        public string dia { get; set; }
        public string hora { get; set; }
        public string duracion { get; set; }
        public string tipoEjercico { get; set; }
        public string lugarEjercico { get; set; }
        public string herramientaEjercico { get; set; }
        public int pesoKG { get; set; }
        //public int alturaCM { get; set; }   
    }
}
