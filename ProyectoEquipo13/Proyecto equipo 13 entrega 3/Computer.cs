using Proyecto_equipo_13_entrega_3.CustomsEvenArgs;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Proyecto_equipo_13_entrega_3
{
    public class Computer
    {
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

            if (type == "Director" || type == "director")
            {
                foreach (Movies movies in Files.AllMovies)
                {
                    if (movies.Director1.Name == name)
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
            if (type == "Categoria" || type == "categoria" || type == "Categoría" || type == "categoría")
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

        public Playlists CreatePlaylist(string type, string name, bool privacidad)
        {
            if (type == "Pelicula" || type == "Película" || type == "pelicula" || type == "película")
            {
                Playlists playlists = new Playlists(name, privacidad, type);

                return playlists;
            }
            if (type == "Cancion" || type == "Canción" || type == "canción" || type == "cancion")
            {
                Playlists playlists = new Playlists(name, privacidad, type);

                return playlists;
            }
            return null;
        }

        public SmartPlaylist CreateSmartPlaylist(string type, string criterio, string namecriterio, string name, bool privacidad)
        {
            if (type == "Pelicula" || type == "Película" || type == "pelicula" || type == "película")
            {
                SmartPlaylist smart = new SmartPlaylist(name, privacidad, type, criterio, namecriterio);
                return smart;
            }
            if (type == "Cancion" || type == "Canción" || type == "canción" || type == "cancion")
            {
                SmartPlaylist smart = new SmartPlaylist(name, privacidad, type, criterio, namecriterio);
                return smart;
            }
            return null;

        }

        public void AutomaticRep(List<Songs> songs)
        {
            foreach(Songs song in songs)
            {
                song.Play();
                Console.WriteLine();
            }
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
                Registered(this, new RegisterEventArgs() {/* VerificationLink = verificationlink,*/ Password = password, Username = username, Email = email });
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
            Console.WriteLine("\n(a) Premium \n(b) Free");
            string type = Console.ReadLine();
            // Genera el link de verificacion para el usuario
            if (type == "a") 
            { 
                Console.WriteLine("¿Desea que su usuario sea público o privado (que otros usuarios puedan acceder a sus fututas playlists o no)?");
                Console.WriteLine("(a) Público \n(b) Privado");
                string choice = Console.ReadLine();
                if (choice == "a") { type="PremiumT";}
                else if (choice == "b") { type = "PremiumF"; }
                else { Console.WriteLine("¡ERROR! El tipo seleccionado no existe!"); return false; }
            }
            else if (type == "b") { type = "Free"; }
            else { Console.WriteLine("¡ERROR! El tipo de usuario seleccionado no existe!"); return false; }
            string verificationLink = GenerateLink(usr);
            // Intenta agregar el usuario a la bdd. Si retorna null, se registro correctamente,
            // sino, retorna un string de error, que es el que se muestra al usuario
            string result = Files.AddUser(new List<string>()
                {usr, email, psswd/*, verificationLink*/, Convert.ToString(DateTime.Now), type});
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
                foreach (List<string> user in Files.AllUsers.Values)
                {
                    if (user[0] == usr && user[2]==pswd)
                    {
                        user[5] = "Premium";

                    }
                }
                foreach (User user in Files.Users)
                {
                    if (user.UserName == usr && user.Password == pswd)
                    {
                        user.Type = "Premium";
                        Console.WriteLine("Quiere que su cuenta Premium sea:");
                        Console.WriteLine("(a) Pública\n(b) Privada");
                        while (true)
                        {
                            string privacy = Console.ReadLine();
                            if (privacy == "a")
                            {
                                user.Privacy1 = true;
                                break;
                            }
                            else if (privacy == "b")
                            {
                                user.Privacy1 = false;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("\nSeleccione una opción válida ((a) (b))");
                            }
                        }
                    }
                }
                Thread.Sleep(1200);
                Console.WriteLine("\nSe modifico correctamente\n");
                Thread.Sleep(2000);
            }
            else
            {
                // Mostramos el error
                Console.WriteLine("[!] ERROR: " + result + " o simplemente no existe\n");
            }
        }

        public void AddQueue(Songs songs)
        {
            List<Songs> cola = new List<Songs>();
            cola.Add(songs);
        }
        
    }
}
