using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProyectoEquipo13
{
    class Computer
    {
        public void PlaySong(string name)
        {

        }

        public void PlayMovie(string name)
        {

        }

        public List<Songs> SearchTypeSongs(string type, string name)
        {
            List<Songs> show = new List<Songs>();

            if (type == "Título" || type == "Titulo" || type == "título" || type == "titulo")
            {
                foreach (Songs song in Files.AllSongs)
                {
                    if (song.Title1 == name)
                    {
                        show.Add(song);
                    }
                }
            }
            if (type == "Genero" || type == "Género" || type == "genero" || type == "género")
            {
                foreach (Songs song in Files.AllSongs)
                {
                    foreach (string genero in song.Genre1)
                    {
                        if (genero == name)
                        {
                            show.Add(song);
                        }
                    }
                }
            }
            if (type == "Artista" || type == "artista")
            {
                foreach (Songs song in Files.AllSongs)
                {
                    if (song.Artist1.Name == name)
                    {
                        show.Add(song);
                    }
                }
            }
            if (type == "Album" || type == "album")
            {
                foreach (Songs song in Files.AllSongs)
                {
                    if (song.Album1.Name1 == name)
                    {
                        show.Add(song);
                    }
                }
            }
            if (type == "Compositor" || type == "compositor")
            {
                foreach (Songs song in Files.AllSongs)
                {
                    if (song.Composer1.Name == name)
                    {
                        show.Add(song);
                    }
                }
            }
            if (type == "Escritor" || type == "escritor")
            {
                foreach (Songs song in Files.AllSongs)
                {
                    if (song.Writer1.Name == name)
                    {
                        show.Add(song);
                    }
                }
            }

            return show;


        }
        public List<Movies> SearchTypeMovies(string type, string name)
        {
            List<Movies> show = new List<Movies>();

            if (type == "Título" || type == "Titulo" || type == "título" || type == "titulo")
            {
                foreach (Movies movies in Files.AllMovies)
                {
                    if (movies.Title1 == name)
                    {
                        show.Add(movies);
                    }
                }
            }

            if (type == "Director" || type == "director" )
            {
                foreach (Movies movies in Files.AllMovies)
                {
                    if (movies.Director1.Name== name)
                    {
                        show.Add(movies);
                    }
                }
            }
            if (type == "Actor" || type == "actor")
            {
                foreach (Movies movies in Files.AllMovies)
                {
                    foreach (Person actor in movies.Actors1)
                    {
                        if (actor.Name == name)
                        {
                            show.Add(movies);
                        }
                    }
                }
            }
            if (type == "Escritor" || type == "escritor")
            {
                foreach (Movies movies in Files.AllMovies)
                {
                    if (movies.Writer1.Name == name)
                    {
                        show.Add(movies);
                    }
                }
            }
            if (type == "Categoria" || type == "categoria"||type == "Categoría" || type == "categoría")
            {
                foreach (Movies movies in Files.AllMovies)
                {
                    foreach (string categoria in movies.Categories1)
                    {
                        if (categoria == name)
                        {
                            show.Add(movies);
                        }
                    }
                }
            }
            if (type == "Estudio" || type == "estudio")
            {
                foreach (Movies movies in Files.AllMovies)
                {
                    if (movies.Studio1 == name)
                    {
                        show.Add(movies);
                    }
                }
            }
            return show;
        }

        public void Rate(string type, string name, List<double> rate) //FALTA IF PARA SABER QUE PELICULA
        {
            if (type == "Pelicula" || type == "Película" || type == "pelicula" || type == "película")
            {
                foreach (Movies movies in Files.AllMovies)
                {
                    if (name == movies.Title1)
                    {
                        double sum = rate.Sum();
                        double value = (sum / rate.Count());
                        movies.RatingProm1 = value;
                    }
                }
            }
            else if (type == "Cancion" || type == "Canción" || type == "canción" || type == "cancion")
            {
                foreach (Songs songs in Files.AllSongs)
                {
                    if (name == songs.Title1)
                    {
                        double sum = rate.Sum();
                        double value = (sum / rate.Count());
                        songs.RatingProm1 = value;
                    }
                }
            }
            else
            {
                Console.WriteLine("No se encontro referencia");
            }
        }

        public void CreatePlaylist(string type, string name, bool privacidad)
        {
            if(type == "Pelicula" || type == "Película" || type == "pelicula" || type == "película")
            {
                Playlists playlists = new Playlists(name, privacidad, type);
                Files.AllPlaylistsMovies.Add(playlists);
            }
            if (type == "Cancion" || type == "Canción" || type == "canción" || type == "cancion")
            {
                Playlists playlists = new Playlists(name, privacidad, type);
                Files.AllPlaylistsSongs.Add(playlists);
            }
        }
        public void CreateSmartPlaylist(string type,string criterio, string name, bool privacidad)
        {

        }

        public List<Movies> SeeTopMovies()
        {
            List<Movies> top = new List<Movies>();
            List<Movies> peliculas = new List<Movies>();
            foreach (Movies movies in Files.AllMovies)
            {
                peliculas.Add(movies);
            }
            var peliculasorden = peliculas.OrderByDescending(songs => songs.Rating1).ToList();
            for (int i = 0; i < 10; i++)
            {
                top.Add(peliculasorden[i]);
            }
            return top;

        }
        public List<Songs> SeeTopSong()
        {
            List<Songs> top = new List<Songs>();
            List<Songs> canciones = new List<Songs>();
            foreach (Songs songs in Files.AllSongs)
            {
                canciones.Add(songs);
            }
            var cancionesorden = canciones.OrderByDescending(songs => songs.Rating1).ToList();
            for (int i = 0; i < 10; i++)
            {
                top.Add(cancionesorden[i]);
            }
            return top;
        }

        //Parte Usuario

        // Paso 1: Creamos el delegate para el evento del registro
        public delegate void RegisterEventHandler(object source, RegisterEventArgs args);
        // Paso 2: Creamos el evento que se engatilla cuando el usuario se registra
        public event RegisterEventHandler Registered;
        // Paso 3: Publicamos el evento. Notar que cuando se quiere engatillar el evento, se llama OnRegistered(). 
        // Por definicion, debe ser protected virtual. Los parametros que recibe son los necesarios para crear una instancia
        // de la clase  RegisterEventArgs
        protected virtual void OnRegistered(string username, string password, string verificationlink, string email)
        {
            // Verifica si hay alguien suscrito al evento
            if (Registered != null)
            {
                // Engatilla el evento
                Registered(this, new RegisterEventArgs() { VerificationLink = verificationlink, Password = password, Username = username, Email = email });
            }
        }

        // Paso 1: Creamos el delegate para el evento del cambio de contrasena
        public delegate void ChangePasswordEventHandler(object source, ChangePasswordEventArgs args);
        // Paso 2: Creamos el evento que se engatilla cuando se cambia la contrasena
        public event ChangePasswordEventHandler PasswordChanged;
        // Paso 3: Publicamos el evento. Notar que cuando se quiere engatillar el evento, se llama OnPasswordChanged(). 
        // Por definicion, debe ser protected virtual. Los parametros que recibe son los necesarios para crear una instancia
        // de la clase ChangePasswordEventArgs
        protected virtual void OnPasswordChanged(string username, string email)
        {
            if (PasswordChanged != null)
            {
                PasswordChanged(this, new ChangePasswordEventArgs() { Username = username, Email = email });
            }
        }

        // Paso 1: Creamos el delegate para el evento del cambio nombre de usuario
        public delegate void ChangeUserNameEventHandler(object source, ChangeUserNameEventArgs args);
        // Paso 2: Creamos el evento que se engatilla cuando se cambia el nombre de Usuario
        public event ChangeUserNameEventHandler UserNameChanged;
        // Paso 3: Publicamos el evento. Notar que cuando se quiere engatillar el evento, se llama OnPasswordChanged(). 
        // Por definicion, debe ser protected virtual. Los parametros que recibe son los necesarios para crear una instancia
        // de la clase ChangePasswordEventArgs
        protected virtual void OnUserNameChanged(string username2, string email)
        {
            if (UserNameChanged != null)
            {
                UserNameChanged(this, new ChangeUserNameEventArgs() { Username = username2, Email = email});
            }
        }

        // Realiza el registro 
        public bool Register()
        {
            // Pedimos todos los datos necesarios
            Console.Write("Bienvenido! Ingrese sus datos de registro en Netfy\nUsuario: ");
            string usr = Console.ReadLine();
            Console.Write("Correo: ");
            string email = Console.ReadLine();
            Console.Write("Contraseña: ");
            string psswd = Console.ReadLine();
            Console.Write("Seleccione que tipo de usuario quiere ser:");
            Console.WriteLine("(a) Premium \n(b) Free");
            string type = Console.ReadLine();
            // Genera el link de verificacion para el usuario
            if (type == "a") 
            { 
                Console.WriteLine("¿Desea que su usuario sea público o privado (que otros usuarios puedan acceder a sus fututas playlists o no)?");
                Console.WriteLine("(a) Público \n(b) Privado");
                string choice = Console.ReadLine();
                if (choice == "a") { type="PremimumT";}
                else if (choice == "b") { type = "PremiumF"; }
                else { Console.WriteLine("¡ERROR! El tipo seleccionado no existe!"); return false; }
            }
            else if (type == "b") { type = "Free"; }
            else if (type != "b" && type != "a") { Console.WriteLine("¡ERROR! El tipo de usuario seleccionado no existe!"); return false; }
            string verificationLink = GenerateLink(usr);
            // Intenta agregar el usuario a la bdd. Si retorna null, se registro correctamente,
            // sino, retorna un string de error, que es el que se muestra al usuario
            string result = Files.AddUser(new List<string>()
                {usr, email, psswd, verificationLink, Convert.ToString(DateTime.Now), type});
            if (result == null)
            {
                // Disparamos el evento
                OnRegistered(usr, psswd, verificationlink: verificationLink, email: email);
                return true;
            }
            else
            {
                // Mostramos el error
                Console.WriteLine("[!] ERROR: " + result + "\n");
                return false;
            }
        }

        // Realiza el cambio de contrasena
        public void ChangePassword()
        {
            // Pedimos todos los datos necesarios
            Console.WriteLine("Ingresa tu nombre de usuario: ");
            string usr = Console.ReadLine();
            Console.WriteLine("Ingresa tu contrasena: ");
            string pswd = Console.ReadLine();
            // Intenta realizar el login, si retorna null se logeo correctamente,
            // sino, retorna un string de error que se le muestra al usuario
            string result = Files.LogIn(usr, pswd);
            if (result == null)
            {
                // Pedimos y cambiamos la contrasena
                Console.Write("Ingrese la nueva contraseña: ");
                string newPsswd = Console.ReadLine();
                Files.ChangePassword(usr, newPsswd);
                // Obtenemos los datos del usuario que se logueo y disparamos el evento con los datos necesarios
                List<string> data = Files.GetData(usr);
                OnPasswordChanged(data[0], data[1]);
            }
            else
            {
                // Mostramos el error
                Console.WriteLine("[!] ERROR: " + result + "\n");
            }
        }

        // Realiza el cambio de de nombre de usuario
        public void ChangeUserName()
        {
            // Pedimos todos los datos necesarios
            Console.WriteLine("Ingresa tu nombre de usuario: ");
            string usr = Console.ReadLine();
            Console.WriteLine("Ingresa tu contraseña: ");
            string pswd = Console.ReadLine();
            // Intenta realizar el login, si retorna null se logeo correctamente,
            // sino, retorna un string de error que se le muestra al usuario
            string result = Files.LogIn(usr, pswd);
            if (result == null)
            {
                // Pedimos y cambiamos el usuario
                Console.Write("Ingrese el nuevo nombre de usuario: ");
                string newusername = Console.ReadLine();
                Files.ChangeUserName(usr, newusername);
                // Obtenemos los datos del usuario que se logueo y disparamos el evento con los datos necesarios
                List<string> data = Files.GetData(usr);
                OnUserNameChanged(newusername, data[1]);
            }
            else
            {
                // Mostramos el error
                Console.WriteLine("[!] ERROR: " + result + "\n");
            }
        }

        // Metodo que genera un link de verificacion, dado un usuario
        private string GenerateLink(string usr)
        {
            Random rnd = new Random();
            string result = "";
            for (int ctr = 0; ctr <= 99; ctr++)
            {
                char rndom = (char)rnd.Next(33, 126);
                result += rndom;
            }
            return "http://Netfy.com/verificar-correo.php?=" + usr + "_" + result;
        }

        public void OnEmailVerified(object source, EventArgs args)
        {
            Thread.Sleep(1500);
            Console.WriteLine("\nEl correo fue verificado correctamente\n");
            Thread.Sleep(1500);
        }

        public void UpgradeFree ()
        {
            // Pedimos todos los datos necesarios
            Console.WriteLine("Ingresa tu nombre de usuario: ");
            string usr = Console.ReadLine();
            Console.WriteLine("Ingresa tu contrasena: ");
            string pswd = Console.ReadLine();
            // Intenta realizar el login, si retorna null se logeo correctamente,
            // sino, retorna un string de error que se le muestra al usuario
            string result = Files.LogIn(usr, pswd);
            if (result == null)
            {
                for (int i = 0; i < Files.AllUsers.Count; i++) 
                {
                    if (Files.AllUsers[i][0] == usr && Files.AllUsers[i][2] == pswd)
                    {
                        Console.WriteLine("¿Desea que su usuario sea público o privado (que otros usuarios puedan acceder a sus fututas playlists o no)?");
                        Console.WriteLine("(a) Público \n(b) Privado");
                        string choice = Console.ReadLine();
                        bool choice2 = new bool();
                        if (choice == "a") 
                        { 
                            choice = "Premium";
                            choice2 = true;
                            Files.AllUsers[i][5] = choice;
                            for (int j = 0; j < Files.Users.Count; j++)
                            {
                                if (Files.Users[j].UserName == usr && Files.Users[j].Password == pswd)
                                {
                                    Premium premium = new Premium(Files.Users[j].UserName, Files.Users[j].Email, Files.Users[j].Password, choice2);
                                    Files.Users.RemoveAt(j);
                                    Files.Users.Insert(j, premium);
                                }
                            }
                            Console.WriteLine("Su cuenta se ha modificado con éxito");
                        }
                        else if (choice == "b") 
                        { 
                            choice = "Premium";
                            choice2 = false;
                            Files.AllUsers[i][5] = choice;
                            for (int j = 0; j < Files.Users.Count; j++)
                            {
                                if (Files.Users[j].UserName == usr && Files.Users[j].Password == pswd)
                                {
                                    Premium premium = new Premium(Files.Users[j].UserName, Files.Users[j].Email, Files.Users[j].Password, choice2);
                                    Files.Users.RemoveAt(j);
                                    Files.Users.Insert(j, premium);
                                }
                            }
                            Console.WriteLine("Su cuenta se ha modificado con éxito");
                        }
                        else { Console.WriteLine("¡ERROR! El tipo seleccionado no existe!"); }                        
                    }
                }

            }
            else
            {
                // Mostramos el error
                Console.WriteLine("[!] ERROR: " + result + " o simplemente no existe\n");
            }
        }
    }
}
