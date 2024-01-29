using BoostExercise_RERM.Data;
using BoostExercise_RERM.Model;
using BoostExercise_RERM.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BoostExercise_RERM.ViewModel.VMBoostExercise
{
    public class VMEditar : ViewModelBase
    {
        public BoostExerciseModel parametrosRecibe { get; set; }
        public VMEditar(INavigation navigation, BoostExerciseModel parametrosTrae)
        {
            Navigation = navigation;
            parametrosRecibe = parametrosTrae;
        }
        #region Variables
        DateTime _dateTime;
        string _resultadoFecha;
        DateTime _timePicker;
        string _resultadoHora;
        //string _duracion;
        private bool _radioButton10;
        private bool _radioButton15;
        private bool _radioButton20;
        private bool _radioButton25;
        private bool _radioButton30;
        private bool _radioButton35;
        private int _selectedValue;
        private bool _isEliminarButtonSelected;
        private bool _isCompletadoButtonSelected;
        private string imagenSeleccionada;
        string _tipoEjercico;
        string _lugarEjercico;
        //string _herramientaEjercico;
        //int _pesoKG;
        #endregion
        #region Objetos
        public bool EliminarEjercicio
        {
            get { return _isEliminarButtonSelected; }
            set { SetValue(ref _isEliminarButtonSelected, value); }
        }
        public bool CompletarEjercicio
        {
            get { return _isCompletadoButtonSelected; }
            set { SetValue(ref _isCompletadoButtonSelected, value); }
        }
        public DateTime Fecha
        {
            get { return _dateTime; }
            set
            {
                SetValue(ref _dateTime, value);
                ResultadoFecha = _dateTime.ToString("dd/mm/yyyy");
            }
        }
        public string ResultadoFecha
        {
            get { return _resultadoFecha; }
            set { SetValue(ref _resultadoFecha, value); }
        }
        public DateTime Hora
        {
            get { return _timePicker; }
            set
            {
                SetValue(ref _timePicker, value);
                ResultadoHora = _timePicker.ToString();
            }
        }
        public string ResultadoHora
        {
            get { return _resultadoHora; }
            set { SetValue(ref _resultadoHora, value); }
        }
        //public string Duracion
        //{
        //    get { return _duracion; }
        //    set { SetValue(ref _duracion, value); }
        //}
        public bool RadioButton10
        {
            get { return _radioButton10; }
            set
            {
                if (_radioButton10 != value)
                {
                    _radioButton10 = value;
                    OnPropertyChanged(nameof(RadioButton10));
                    UpdateSelectedValue(10);
                }
            }
        }
        public bool RadioButton15
        {
            get { return _radioButton15; }
            set
            {
                if (_radioButton15 != value)
                {
                    _radioButton15 = value;
                    OnPropertyChanged(nameof(RadioButton15));
                    UpdateSelectedValue(15);
                }
            }
        }
        public bool RadioButton20
        {
            get { return _radioButton20; }
            set
            {
                if (_radioButton20 != value)
                {
                    _radioButton20 = value;
                    OnPropertyChanged(nameof(RadioButton20));
                    UpdateSelectedValue(20);
                }
            }
        }
        public bool RadioButton25
        {
            get { return _radioButton25; }
            set
            {
                if (_radioButton25 != value)
                {
                    _radioButton25 = value;
                    OnPropertyChanged(nameof(RadioButton25));
                    UpdateSelectedValue(25);
                }
            }
        }
        public bool RadioButton30
        {
            get { return _radioButton30; }
            set
            {
                if (_radioButton30 != value)
                {
                    _radioButton30 = value;
                    OnPropertyChanged(nameof(RadioButton30));
                    UpdateSelectedValue(30);
                }
            }
        }
        public bool RadioButton35
        {
            get { return _radioButton35; }
            set
            {
                if (_radioButton35 != value)
                {
                    _radioButton35 = value;
                    OnPropertyChanged(nameof(RadioButton35));
                    UpdateSelectedValue(35);
                }
            }
        }
        public int SelectedValue
        {
            get { return _selectedValue; }
            set
            {
                if (_selectedValue != value)
                {
                    _selectedValue = value;
                    OnPropertyChanged(nameof(SelectedValue));
                }
            }
        }
        //
        public string ImagenSeleccionada
        {
            get { return imagenSeleccionada; }
            set
            {
                if (imagenSeleccionada != value)
                {
                    imagenSeleccionada = value;
                    OnPropertyChanged(nameof(ImagenSeleccionada));
                }
            }
        }
        //
        public string TipoEjercicio
        {
            get { return _tipoEjercico; }
            set { SetValue(ref _tipoEjercico, value); }
        }
        public string LugarEjercicio
        {
            get { return _lugarEjercico; }
            set { SetValue(ref _lugarEjercico, value); }
        }
        //public string HerramientaEjercicio
        //{
        //    get { return _herramientaEjercico; }
        //    set { SetValue(ref _herramientaEjercico, value); }
        //}
        //public int PesoKG
        //{
        //    get { return _pesoKG; }
        //    set { SetValue(ref _pesoKG, value); }
        //}
        #endregion
        #region Procesos
        public async Task Editar()
        {
            var function = new DataBoostE();//
            parametrosRecibe.DateTime = _dateTime;
            parametrosRecibe.TimePickerr = _timePicker;
            //parametros.duracion = _duracion;
            parametrosRecibe.duracion = _selectedValue;
            parametrosRecibe.tipoEjercico = _tipoEjercico;
            parametrosRecibe.lugarEjercico = _lugarEjercico;
            //parametros.herramientaEjercico = _herramientaEjercico;
            //parametros.pesoKG = _pesoKG;
            await function.EditarExeercise(parametrosRecibe);
            await Volver();
        }
        public async Task Eliminar()
        {

            var funcion = new DataBoostE();
            await funcion.Eliminar(parametrosRecibe);
            EliminarEjercicio = true;
            await Volver(); ;
        }
        public async Task Completar()
        {

            var funcion = new DataBoostE();
            await funcion.Eliminar(parametrosRecibe);
            CompletarEjercicio = true;
            await Volver(); ;
        }
        //
        private void OnImageTapped(string imagen)
        {
            ImagenSeleccionada = imagen;

            // Aquí puedes asignar el string según la imagen seleccionada
            string nombreAsignado = ObtenerNombreAsignado(imagen);

            // Puedes almacenar la dirección de la imagen para usarla en otra vista
            //string direccionImagen = ObtenerDireccionImagen(imagen);
        }
        private string ObtenerNombreAsignado(string imagen)
        {
            // Lógica para asignar nombres
            // Puedes usar un switch o cualquier otro método que prefieras
            if (imagen == "Barra")
            {
                TipoEjercicio = "Barra";
            }
            else if (imagen == "Abdomen")
            {
                TipoEjercicio = "Abdomen";
            }
            else if (imagen == "CardioBici")
            {
                TipoEjercicio = "CardioBici";
            }
            else if (imagen == "Pierna")
            {
                TipoEjercicio = "Pierna";
            }
            else if (imagen == "Pesita")
            {
                TipoEjercicio = "Pesita";
            }
            else if (imagen == "PushUp")
            {
                TipoEjercicio = "PushUp";
            }
            else if (imagen == "Casa")
            {
                LugarEjercicio = "Casa";
            }
            else if (imagen == "Gym")
            {
                LugarEjercicio = "GYM";
            }
            return "Nombre Asignado";
        }

        //private string ObtenerDireccionImagen(string imagen)
        //{
        //    // Lógica para obtener direcciones de imágenes
        //    // Puedes tener un diccionario o cualquier otra lógica
        //    return "Direccion de la Imagen";
        //}
        private void UpdateSelectedValue(int value)
        {
            if (RadioButton10)
                SelectedValue = 10;
            else if (RadioButton15)
                SelectedValue = 15;
            else if (RadioButton20)
                SelectedValue = 20;
            else if (RadioButton25)
                SelectedValue = 25;
            else if (RadioButton30)
                SelectedValue = 30;
            else if (RadioButton35)
                SelectedValue = 35;
            // Repite para los otros RadioButtons...
        }
        public ICommand InsertarCommand => new Command(async () => await Editar());
        public ICommand EliminarCommand => new Command(async () => await Eliminar());
        public ICommand CompletarCommand => new Command(async () => await Completar());
        public ICommand VolverCommand => new Command(async () => await Volver());
        public ICommand ImageTappedCommand => new Command<string>(OnImageTapped);
        public async Task Volver()
        {
            await Navigation.PushModalAsync(new MainPage());
            //await Navigation.PopModalAsync();
        }
        #endregion
    }
}
