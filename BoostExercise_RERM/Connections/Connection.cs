using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;

namespace BoostExercise_RERM.Connection
{
    public class Connections
    {
        public static FirebaseClient firebase = new FirebaseClient("https://boostexercise-2c5a9-default-rtdb.firebaseio.com/");
    }
}
