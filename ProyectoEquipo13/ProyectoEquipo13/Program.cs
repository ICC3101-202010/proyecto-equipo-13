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
            //IFormatter formatter = new BinaryFormatter();
            //Stream stream = new FileStream("BaseDeDatos.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            //List<Movies> AllMovies = (List<Movies>)formatter.Deserialize(stream);
            //List<Songs> AllSongs = (List<Songs>)formatter.Deserialize(stream);
            //List<Playlists> AllPlaylistsSongs = (List<Playlists>)formatter.Deserialize(stream);
            //List<Playlists> AllPlaylistsMovies = (List<Playlists>)formatter.Deserialize(stream);
            //List<User> AllUsers = (List<User>)formatter.Deserialize(stream);
            //stream.Close();

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
            //Computer computer = new Computer();
            //MailSender mailSender = new MailSender();
            //User user = new User();

            //Stream stream2 = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            //formatter.Serialize(stream2, Files.AllMovies);
            //formatter.Serialize(stream2, Files.AllSongs);
            //formatter.Serialize(stream2, Files.AllPlaylistsMovies);
            //formatter.Serialize(stream2, Files.AllPlaylistsSongs);
            //formatter.Serialize(stream2, Files.AllUsers);
            //stream.Close();
            // Reproductor

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            PlayMovie pM = new PlayMovie();
            string t = @"Movies\Tarzan_-Son_Of_Man_Phil_Collins.mp4";
            pM.Generico();
            pM.URL(t);
            Application.Run(pM);
        }
    }
}
