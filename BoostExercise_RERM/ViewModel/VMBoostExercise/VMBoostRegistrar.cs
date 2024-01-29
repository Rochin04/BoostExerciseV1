using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using BoostExercise_RERM.Data;
using BoostExercise_RERM.Model;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace BoostExercise_RERM.ViewModel.VMBoostExercise
{
    public class VMBoostRegistrar : ViewModelBase
    {
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
        private bool _activationPesita;
        private bool _activationBarra;
        private bool _activationAbdomen;
        private bool _activationCardioBici;
        private bool _activationPierna;
        private bool _activationPushUp;
        private bool _activationCasa;
        private bool _activationGYM;
        private string _imagenSeleccionada;
        private string imagenSeleccionada;
        string _tipoEjercico;
        string _lugarEjercico;
        //string _herramientaEjercico;
        //int _pesoKG;
        #endregion
        #region Objetos
        public bool ActivationCasa
        {
            get { return _activationCasa; }
            set { SetValue(ref _activationCasa, value); }
        }
        public bool ActivationGYM
        {
            get { return _activationGYM; }
            set { SetValue(ref _activationGYM, value); }
        }
        public bool ActivationPesita
        {
            get { return _activationPesita; }
            set { SetValue(ref _activationPesita, value); }
        }
        public bool ActivationBarra
        {
            get { return _activationBarra; }
            set { SetValue(ref _activationBarra, value); }
        }
        public bool ActivationAbdomen
        {
            get { return _activationAbdomen; }
            set { SetValue(ref _activationAbdomen, value); }
        }
        public bool ActivationCardioBici
        {
            get { return _activationCardioBici; }
            set { SetValue(ref _activationCardioBici, value); }
        }
        public bool ActivationPierna
        {
            get { return _activationPierna; }
            set { SetValue(ref _activationPierna, value); }
        }
        public bool ActivationPushUp
        {
            get { return _activationPushUp; }
            set { SetValue(ref _activationPushUp, value); }
        }
        public string ImagenSeleccionadas
        {
            get { return _imagenSeleccionada; }
            set
            {
                if (_imagenSeleccionada != value)
                {
                    _imagenSeleccionada = value;
                    OnPropertyChanged(nameof(ImagenSeleccionadas));
                }
            }
        }
        public DateTime Fecha
        {
            get { return _dateTime; }
            set { SetValue(ref _dateTime, value);
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
        public async Task Insertar()
        {
            var function = new DataBoostE();//
            var parametros = new BoostExerciseModel();//
            parametros.DateTime = _dateTime;
            parametros.TimePickerr = _timePicker;
            //parametros.duracion = _duracion;
            parametros.duracion = _selectedValue;
            parametros.tipoEjercico = _tipoEjercico;
            parametros.lugarEjercico = _lugarEjercico;
            //parametros.herramientaEjercico = _herramientaEjercico;
            //parametros.pesoKG = _pesoKG;
            await function.InsertarEjercicio(parametros);
            await Volver();
        }
        //-------------------////////////////////////----------------------------------\\
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
                ActivationBarra = true;
                ActivationPesita = false;
                ActivationAbdomen = false;
                ActivationCardioBici = false;
                ActivationPierna = false;
                ActivationPushUp = false;
            }
            else if(imagen == "Abdomen")
            {
                TipoEjercicio = "Abdomen";
                ActivationBarra = false;
                ActivationPesita = false;
                ActivationAbdomen = true;
                ActivationCardioBici = false;
                ActivationPierna = false;
                ActivationPushUp = false;
            }
            else if(imagen == "CardioBici")
            {
                TipoEjercicio = "CardioBici";
                ActivationBarra = false;
                ActivationPesita = false;
                ActivationAbdomen = false;
                ActivationCardioBici = true;
                ActivationPierna = false;
                ActivationPushUp = false;
            }
            else if(imagen == "Pierna")
            {
                TipoEjercicio = "Pierna";
                ActivationBarra = false;
                ActivationPesita = false;
                ActivationAbdomen = false;
                ActivationCardioBici = false;
                ActivationPierna = true;
                ActivationPushUp = false;
            }
            else if(imagen == "Pesita")
            {
                TipoEjercicio = "Pesita";
                ActivationBarra = false;
                ActivationPesita = true;
                ActivationAbdomen = false;
                ActivationCardioBici = false;
                ActivationPierna = false;
                ActivationPushUp = false;
            }
            else if(imagen == "PushUp")
            {
                TipoEjercicio = "PushUp";
                ActivationBarra = false;
                ActivationPesita = false;
                ActivationAbdomen = false;
                ActivationCardioBici = false;
                ActivationPierna = false;
                ActivationPushUp = true;
            }
            else if(imagen == "Casa")
            {
                LugarEjercicio = "Casa";
                ActivationCasa = true;
                ActivationGYM = false;
            }
            else if(imagen == "Gym")
            {
                LugarEjercicio = "GYM";
                ActivationCasa = false;
                ActivationGYM = true;
            }
            return "Nombre Asignado";
        }
        private void ImagenSelected(string imagen)
        {
            ImagenSeleccionadas = imagen;
            string nombreAsignado = ObtenerImagen(imagen);
        }
        private string ObtenerImagen(string imagen)
        {
            return "Se selecciono la imagem";
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
        public async Task Volver()
        {
            await Navigation.PopModalAsync();
        }
        #endregion
        #region Commands
        public ICommand InsertarCommand => new Command(async () => await Insertar());
        public ICommand VolverCommand => new Command(async () => await Volver());
        public ICommand ImageTappedCommand => new Command<string>(OnImageTapped);

        #endregion
        #region Constructor
        public VMBoostRegistrar(INavigation navigation)
        {
            Navigation = navigation;
            Fecha = DateTime.Now;
        }
        #endregion
    }
}
