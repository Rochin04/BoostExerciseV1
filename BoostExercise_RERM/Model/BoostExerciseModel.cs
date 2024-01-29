using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BoostExercise_RERM.Model
{
    public class BoostExerciseModel
    {
        public int IdExercise { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime TimePickerr { get; set; }
        //public string dia { get; set; }
        //public string hora { get; set; }
        public int duracion { get; set; }
        public string tipoEjercico { get; set; }
        public string lugarEjercico { get; set; }
        //public string herramientaEjercico { get; set; }
        //public int pesoKG { get; set; }
        //public int alturaCM { get; set; }   
    }
}
