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
                dia = parametros.dia,
                hora = parametros.hora,
                duracion = parametros.duracion,
                tipoEjercico = parametros.tipoEjercico,
                lugarEjercico = parametros.lugarEjercico,
                herramientaEjercico = parametros.herramientaEjercico
            });
        }
        public async Task<ObservableCollection<BoostExerciseModel>> MostrarExercise()
        {
            var data = await Task.Run(() => Connections.firebase.Child("Exercise").AsObservable<BoostExerciseModel>().AsObservableCollection());
            return data;
        }
        public async Task EditarExeercise(BoostExerciseModel parametrosRecibe)
        {
            await Connections.firebase.Child("Exercise").PutAsync(new BoostExerciseModel()
            {
                IdExercise = parametrosRecibe.IdExercise,
                dia = parametrosRecibe.dia,
                hora = parametrosRecibe.hora,
                duracion = parametrosRecibe.duracion,
                tipoEjercico = parametrosRecibe.tipoEjercico,
                lugarEjercico = parametrosRecibe.lugarEjercico,
                herramientaEjercico = parametrosRecibe.herramientaEjercico
            });
        }
        public async Task Eliminar(BoostExerciseModel IdExercise)
        {
            if(IdExercise != null)// && !string.IsNullOrEmpty(IdExercise.IdExercise))
            {
                var eliminar = (await Connections.firebase.Child("Exercise").OnceAsync<BoostExerciseModel>()).Where(a => a.Object.IdExercise == IdExercise.IdExercise).FirstOrDefault();
                await Connections.firebase.Child("Exercise").Child(eliminar.Key).DeleteAsync();
            }
        }
        public async Task Completartarea(BoostExerciseModel IdExercise)
        {
            if (IdExercise != null)// && !string.IsNullOrEmpty(IdExercise.IdExercise))
            {
                var eliminar = (await Connections.firebase.Child("Exercise").OnceAsync<BoostExerciseModel>()).Where(a => a.Object.IdExercise == IdExercise.IdExercise).FirstOrDefault();
                await Connections.firebase.Child("Exercise").Child(eliminar.Key).DeleteAsync();
            }
        }
    }
}
