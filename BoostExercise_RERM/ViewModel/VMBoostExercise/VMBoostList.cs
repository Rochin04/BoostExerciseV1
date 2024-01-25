using BoostExercise_RERM.Data;
using BoostExercise_RERM.Model;
using BoostExercise_RERM.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BoostExercise_RERM.ViewModel.VMBoostExercise
{
    public class VMBoostList : ViewModelBase
    {
        #region Variables
        ObservableCollection<BoostExerciseModel> _ListBoostE;
        #endregion
        #region Object
        public ObservableCollection<BoostExerciseModel> ListBoostE
        {
            get { return _ListBoostE; }
            set { SetValue(ref _ListBoostE, value);
                OnpropertyChanged();
            }
        }
        #endregion
        #region Process
        public async Task RegistrarActividad()
        {
            await Navigation.PushModalAsync(new Registra());
        }
        public async Task DetallesEjercicio(BoostExerciseModel parametros)
        {
            await Navigation.PushModalAsync(new Detalles(parametros));//
        }
        public async Task MostrarEjercicios()
        {
            var funcion = new DataBoostE();
            //ListBoostE = await funcion.MostrarEjercicios(); pendiente
        }
        #endregion
        #region Commands
        public ICommand RegistraECommand => new Command(async () => await RegistrarActividad());
        public ICommand DetallesCommand => new Command<BoostExerciseModel>(async (p) => await DetallesEjercicio(p));
        #endregion
        #region Constructor
        public VMBoostList(INavigation navigation)
        {
            Navigation = navigation;
            MostrarEjercicios();
        }
        #endregion
    }
}
