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
        static void Main(string[] args)
        {
            IFormatter formatter = new BinaryFormatter();
            //Stream stream = new FileStream("BaseDeDatos.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            //Files.AllMovies = (List<Movies>)formatter.Deserialize(stream);               
            //Files.AllSongs = (List<Songs>)formatter.Deserialize(stream);
            //Files.AllPlaylistsSongs = (List<Playlists>)formatter.Deserialize(stream);
            //Files.AllPlaylistsMovies = (List<Playlists>)formatter.Deserialize(stream);
            //Files.Users = (List<User>)formatter.Deserialize(stream);
            //stream.Close();

            Computer computer = new Computer();
            MailSender mailSender = new MailSender();
            User emptyuser = new User();

            Console1.InitialMessage();
            while (true)
            {
                Console.WriteLine("\n¿Qué desea realizar?");
                Console.WriteLine("(a) Iniciar/Crear Sesión, modificar cuenta\n(b) Salir del programa");
                string desition = Console.ReadLine();
                if (desition == "a")
                {
                    computer.Registered += mailSender.OnRegistered;
                    computer.PasswordChanged += mailSender.OnPasswordChanged;
                    mailSender.EmailSent += emptyuser.OnEmailSent;
                    emptyuser.EmailVerified += computer.OnEmailVerified;

                    User userlogin = Console1.Account(computer, emptyuser, mailSender);
                    
                    while (true)
                    {
                        Console.Clear();
                        Console1.SecondMessage(computer);
                        Console.WriteLine("(a) Ver todas las películas\n(b) Ver todas las canciones \n(c) Crear Playlist\n(d) Modificar Playlist (Cambiar nombre, Agregar/Quitar elementos)\n(e) Ver Mis Playlists\n(f) BUSCADOR\n(g) Cerrar Sesión (para volvera a inicio/creación de sesión o salir del programa)");
                        string option = Console.ReadLine();
                        if (option == "a")
                        {
                            Console1.SeeMovies(computer, userlogin);
                        }
                        else if (option == "b")
                        {
                            Console1.SeeSongs(computer, userlogin);
                        }
                        else if (option == "c")
                        {
                            Console1.CreatePlaylist(computer, userlogin);
                        }
                        else if (option == "d")
                        {
                            Console1.ModifiedPlaylist(computer, userlogin);
                        }
                        else if (option == "e")
                        {
                            Console1.SeePlaylist(computer, userlogin);
                        }
                        else if (option == "f")
                        {
                            Console1.Search(computer, userlogin);
                        }
                        else if (option == "g")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nLa opción que seleccionó no es válida, por favor seleccione una que si lo sea\n");
                        }
                        
                    }
                }
                else if (desition == "b")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\nLa opción que seleccionó no es válida, por favor seleccione una que si lo sea\n");
                }
            }
            //Console.WriteLine("Prueba");
            //Console.Read();
            Artist Artist = new Artist("Phil Collins", new DateTime(1951, 1, 30, 5, 5, 5), 'M', "");
            Album Album = new Album("Tarzan: An Original Walt Disney Records Soundtrack",DateTime.Now, Artist);
            string Type = ".mp3";
            string TitleS = "Son of man";
            char M = 'M';
            char F = 'F';
            Person Composer = new Person("Phil Collins", new DateTime(1951, 1, 30, 5, 5, 5), M,"");
            int LenghtS = 165;
            List<string> GenreS = new List<string>();
            GenreS.Add("Pop Rock");
            GenreS.Add("Soft Rock");
            string LyricsS = "letra";
            string ResolutionS = "192kbps";
            string MemoryS = "3,78MB";
            int numReproductionsS = 0;
            double RatingS = 0;
            List<double> rating = new List<double>();
            rating.Add(RatingS);
            string Music = @"\Tarzan_-Son_Of_Man_Phil_Collins";
            // C:\Users\56984\Desktop\Universidad\Progra\Proyecto\proyecto-equipo-13\Songs\Tarzan_-Son_Of_Man_Phil_Collins
            int MinS = 0;
            Songs song1 = new Songs(TitleS, Composer, Artist, Composer, LenghtS, GenreS, LyricsS, ResolutionS, MemoryS, numReproductionsS,rating, RatingS, Music,Type, MinS, Album);

            string Title = "Tarzan";
            Person Director = new Person("Kevin Lima", new DateTime(1962,6,12,5,5,5), M,"");
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
            string Trailer = @"\Tarzan_-Son_Of_Man_Phil_Collins.mp4";
            //C: \Users\56984\Desktop\Universidad\Progra\Proyecto\proyecto - equipo - 13\Movies\Tarzan_-Son_Of_Man_Phil_Collins
            string Video = @"\Tarzan_-Son_Of_Man_Phil_Collins.mp4";
            //C: \Users\56984\Desktop\Universidad\Progra\Proyecto\proyecto - equipo - 13\Movies\Tarzan_-Son_Of_Man_Phil_Collins
            List<Songs> SongsMovie = new List<Songs>();
            //SongsMovie.Add(song1);
            int Min = 0;
            //Movies movie1 = new Movies(Title, Director, Actors, Writer, Lenght, Categories, Studio, Description, Year, Resolution, Memory, numReproductions, Rating, Trailer, Video, SongsMovie, Min);
            //movie1.Play();

             //song1.Play();

            Stream stream2 = new FileStream("BaseDeDatos.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream2, Files.AllMovies);
            formatter.Serialize(stream2, Files.AllSongs);
            formatter.Serialize(stream2, Files.AllPlaylistsMovies);
            formatter.Serialize(stream2, Files.AllPlaylistsSongs);
            formatter.Serialize(stream2, Files.Users);
            stream2.Close();
        }
    }
}
