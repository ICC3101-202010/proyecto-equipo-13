using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEquipo13
{
    
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("BaseDeDatos.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            List<Movies> AllMovies = (List<Movies>)formatter.Deserialize(stream);
            List<Songs> AllSongs = (List<Songs>)formatter.Deserialize(stream);
            List<Playlists> AllPlaylistsSongs = (List<Playlists>)formatter.Deserialize(stream);
            List<Playlists> AllPlaylistsMovies = (List<Playlists>)formatter.Deserialize(stream);
            List<User> AllUsers = (List<User>)formatter.Deserialize(stream);
            stream.Close();

            //Console.WriteLine("Prueba");
            //Console.Read();
            //Album Album = new Album("Tarzan: An Original Walt Disney Records Soundtrack");
            string TitleS = "Son of man";
            char M = 'M';
            char F = 'F';
            //Person Composer = new Person("Phil Collins", new DateTime(1951, 1, 30, 5, 5, 5), M);
            //Artist Artist = new Artist("Phil Collins", new DateTime(1951, 1, 30, 5, 5, 5), M);
            int LenghtS = 165;
            List<string> GenreS = new List<string>();
            GenreS.Add("Pop Rock");
            GenreS.Add("Soft Rock");
            string LyricsS = "letra";
            string ResolutionS = "192kbps";
            string MemoryS = "3,78MB";
            int numReproductionsS = 0;
            int RatingS = 0;
            string Music = " C:/Users/56984/Desktop/Universidad/Progra/Proyecto/proyecto-equipo-13/Songs/Tarzan_-Son_Of_Man_Phil_Collins";
            // C:\Users\56984\Desktop\Universidad\Progra\Proyecto\proyecto-equipo-13\Songs\Tarzan_-Son_Of_Man_Phil_Collins
            int MinS = 0;
            //Songs song1 = new Songs(TitleS, Composer, Artist, Composer, LenghtS, GenreS, LyricsS, ResolutionS, MemoryS, numReproductionsS, RatingS, Music, MinS, Album);

            string Title = "Tarzan";
            //Person Director = new Person("Kevin Lima", new DateTime(1962,6,12,5,5,5), M);
            List<Person> Actors = new List<Person>();
            // Person Actor1 = new Person("Frank Welker",new DateTime(1946,3,12,5,5,5), M);
            // Person Actor2 = new Person("Danielle Keaton", new DateTime(1986,7,30,5,5,5), F);
            //Actors.Add(Actor1);
            // Actors.Add(Actor2);
            // Person Writer = new Person("Tab Murphy", new DateTime(1966,2,25,5,5,5), F);
            int Lenght = 88;
            List<string> Categories = new List<string>();
            Categories.Add("Animación musical");
            Categories.Add("Aventura");
            Categories.Add("Comedia");
            string Studio = "Walt Disney Pictures";
            string Description = "descripcion";
            DateTime Year = new DateTime(1999, 6, 18, 5, 5, 5);
            string Resolution = "617kbps";
            string Memory = "12,2MB";
            int numReproductions = 0;
            int Rating = 0;
            string Trailer = "C: /Users/56984/Desktop/Universidad/Progra/Proyecto/proyecto - equipo - 13/Movies/Tarzan_-Son_Of_Man_Phil_Collins";
            //C: \Users\56984\Desktop\Universidad\Progra\Proyecto\proyecto - equipo - 13\Movies\Tarzan_-Son_Of_Man_Phil_Collins
            string Video = "C: /Users/56984/Desktop/Universidad/Progra/Proyecto/proyecto - equipo - 13/Movies/Tarzan_-Son_Of_Man_Phil_Collins";
            //C: \Users\56984\Desktop\Universidad\Progra\Proyecto\proyecto - equipo - 13\Movies\Tarzan_-Son_Of_Man_Phil_Collins
            List<Songs> SongsMovie = new List<Songs>();
            //SongsMovie.Add(song1);
            int Min = 0;
            //Movies movie1 = new Movies(Title, Director, Actors, Writer, Lenght, Categories, Studio, Description, Year, Resolution, Memory, numReproductions, Rating, Trailer, Video, SongsMovie, Min);
            //movie1.Play();


            //Creación Usuario + Cambio de Contraseña + Cambio nombre Usuario

            // Creamos todos los objetos necesarios
            Computer computer = new Computer();
            MailSender mailSender = new MailSender();
            User user = new User();

            //Suscribir los que escuchan los eventos
            // Notar que para poder realizar las suscripciones es necesario tener instancias de las clases, y que los parametros
            // del evento y del metodo que se le suscribe deben ser igual (object y eventargs)
            //1- Suscribir OnRegistrado de mailSender para que escuche el evento Registrado enviado por computer
            computer.Registered += mailSender.OnRegistered;
            //2- Suscribir OnCambiadaContrasena de mailSender para que escuche el evento CambiadaContrasena enviado por computer
            computer.PasswordChanged += mailSender.OnPasswordChanged;
            //3- Suscribir OnCambiadoNombreUsuario de mailSender para que escuche el evento CambiadoNombreUsuario enviado por computer
            computer.UserNameChanged += mailSender.OnUserNameChanged;
            //4- Suscribir OnEmailSent de User al evento EmailSent de MailSender
            mailSender.EmailSent += user.OnEmailSent;
            //5- Suscribir OnEmailVerified de Server al evento EmailVerified de User
            user.EmailVerified += computer.OnEmailVerified;

            // Controla la ejecucion mientras el usuario no quiera salir
            bool exec = true;
            while (exec)
            {
                // Pedimos al usuario una de las opciones
                string chosen = ShowOptions(new List<string>() { "Registrarse", "Cambiar contrasena", "Cambiar nombre de usuario","Upgrade cuenta Free", "Salir" });
                switch (chosen)
                {
                    case "Registrarse":
                        Console.Clear();
                        bool option = computer.Register();
                        //Suponiendo que el mail si debería haber llegado
                        if (option == true) { user.OnEmailSent(new object(), new EventArgs()); }
                        break;
                    case "Cambiar contrasena":
                        Console.Clear();
                        computer.ChangePassword();
                        break;
                    case "Cambiar nombre de Usuario":
                        Console.Clear();
                        computer.ChangeUserName();
                        break;
                    case "Upgrade ceunta Free":
                        Console.Clear();
                        computer.UpgradeFree();
                        break;
                    case "Salir":
                        exec = false;
                        break;
                }
                Thread.Sleep(2000);
                Console.Clear();
            }

            Stream stream2 = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream2, Files.AllMovies);
            formatter.Serialize(stream2, Files.AllSongs);
            formatter.Serialize(stream2, Files.AllPlaylistsMovies);
            formatter.Serialize(stream2, Files.AllPlaylistsSongs);
            formatter.Serialize(stream2, Files.AllUsers);
            stream.Close();
            // Reproductor

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            PlayMovie pM = new PlayMovie();
            string t = @"Videos\Tarzan_-Son_Of_Man_Phil_Collins.mp4";
            string r = pM.URL(t, pM);

            Application.Run(pM);
        }

        // Metodo para mostrar las opciones posibles
        private static string ShowOptions(List<string> options)
        {
            int i = 0;
            Console.WriteLine("\n\nSelecciona una opcion:");
            foreach (string option in options)
            {
                Console.WriteLine(Convert.ToString(i) + ". " + option);
                i += 1;
            }
            return options[Convert.ToInt16(Console.ReadLine())];

            
        }
    }
}
