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
        #region Constructor
        public VMBoostList(INavigation navigation)
        {
            Navigation = navigation;
            MostrarEjercicios();
        }
        #endregion
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
        public async Task EditarEjercicio(BoostExerciseModel parametros)
        {
            await Navigation.PushModalAsync(new Editar(parametros));//
            //await Navigation.PushModalAsync(new Editar());
        }
        public async Task EliminaEjercicio(BoostExerciseModel parametrosRecibe)//
        {
            var funcion = new DataBoostE();
            await funcion.Eliminar(parametrosRecibe);
        }
        public async Task MostrarEjercicios()
        {
            var funcion = new DataBoostE();
            ListBoostE = await funcion.MostrarExercise();
        }
        #endregion
        #region Commands
        public ICommand RegistraECommand => new Command(async () => await RegistrarActividad());
        //public ICommand EditarCommand => new Command(async () => await EditarEjercicio());
        public ICommand EditarCommand => new Command<BoostExerciseModel>(async (parametros) => await EditarEjercicio(parametros));//
        public ICommand EliminarCommand => new Command<BoostExerciseModel>(async (p) => await EditarEjercicio(p));//
        #endregion
    }
}
