using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using BoostExercise_RERM.ViewModel.VMBoostExercise;

namespace BoostExercise_RERM
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new VMBoostList(Navigation);
        }
    }
}
