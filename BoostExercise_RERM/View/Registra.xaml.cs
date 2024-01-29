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
    public partial class Registra : ContentPage
    {
        public Registra()
        {
            InitializeComponent();
            BindingContext = new VMBoostRegistrar(Navigation);
        }
    }
}