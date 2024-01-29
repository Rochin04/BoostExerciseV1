using BoostExercise_RERM.Model;
using BoostExercise_RERM.ViewModel.VMBoostExercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BoostExercise_RERM.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Editar : ContentPage
    {
        public Editar(BoostExerciseModel parametros)
        {
            InitializeComponent();
            BindingContext = new VMEditar(Navigation, parametros);
        }
    }
}