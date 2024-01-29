using BoostExercise_RERM.Model;
using BoostExercise_RERM.Connection;
using Firebase.Database.Query;
using System.Linq;
using Firebase.Database;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoostExercise_RERM.Data
{
    public class DataBoostE
    {
        public async Task InsertarEjercicio(BoostExerciseModel parametros)
        {
            await Connections.firebase.Child("Ejercicio").PostAsync(new BoostExerciseModel()
            {
                IdExercise = parametros.IdExercise,
                DateTime = parametros.DateTime,
                duracion = parametros.duracion,
                TimePickerr = parametros.TimePickerr,
                tipoEjercico = parametros.tipoEjercico,
                lugarEjercico = parametros.lugarEjercico,
                //herramientaEjercico = parametros.herramientaEjercico,
                //pesoKG = parametros.pesoKG
            });
        }
        public async Task<ObservableCollection<BoostExerciseModel>> MostrarExercise()
        {
            var data = await Task.Run(() => Connections.firebase.Child("Ejercicio").AsObservable<BoostExerciseModel>().AsObservableCollection());
            return data;
        }
        public async Task EditarExeercise(BoostExerciseModel parametrosRecibe)
        {
            await Connections.firebase.Child("Ejercicio").PutAsync(new BoostExerciseModel()
            {
                IdExercise = parametrosRecibe.IdExercise,
                DateTime = parametrosRecibe.DateTime,
                TimePickerr = parametrosRecibe.TimePickerr,
                duracion = parametrosRecibe.duracion,
                tipoEjercico = parametrosRecibe.tipoEjercico,
                lugarEjercico = parametrosRecibe.lugarEjercico,
                //herramientaEjercico = parametrosRecibe.herramientaEjercico,
                //pesoKG = parametrosRecibe.pesoKG
            });
        }
        public async Task Eliminar(BoostExerciseModel hora)
        {
            string borra = hora.DateTime.ToString();
            //await Connections.firebase.Child("Ejercicio").Child(borra).DeleteAsync();
            if (hora != null)// && !string.IsNullOrEmpty(IdExercise.IdExercise))
            {
                var eliminar = (await Connections.firebase.Child("Ejercicio").OnceAsync<BoostExerciseModel>()).Where(a => a.Object.DateTime == hora.DateTime).FirstOrDefault();
                await Connections.firebase.Child("Ejercicio").Child(eliminar.Key).DeleteAsync();
            }
        }
        public async Task Completartarea(BoostExerciseModel hora)
        {
            if (hora != null)// && !string.IsNullOrEmpty(IdExercise.IdExercise))
            {
                var eliminar = (await Connections.firebase.Child("Ejercicio").OnceAsync<BoostExerciseModel>()).Where(a => a.Object.DateTime == hora.DateTime).FirstOrDefault();
                await Connections.firebase.Child("Ejercicio").Child(eliminar.Key).DeleteAsync();
            }
        }
    }
}
