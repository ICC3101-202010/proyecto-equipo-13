using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;
using System.Media;
using System.IO;

namespace ProyectoEquipo13
{
    [Serializable]
    public class Movies
    {
        string Title;
        Person Director;
        List<Person> Actors;
        Person Writer;
        int Lenght; // suma en minutos
        List<string> Categories;
        string Studio;
        string Description;
        string Year;
        string Resolution;
        string Memory;
        int numReproductions;
        List <double> Rating;
        double RatingProm;
        string Trailer; //nombre archivo
        string Video; //nombre archivo
        List<Songs> SongsMovie;
        int Min;

        public Movies(string Title, Person Director, List<Person> Actors, Person Writer, int Lenght, List<string> Categories, string Studio, string Description, string Year, string Resolution, string Memory, int numReproductions, List<double> Rating, double RatingProm, string Trailer, string Video, List<Songs> SongsMovie, int Min)
        {
            this.Title = Title;
            this.Director = Director;
            this.Actors = Actors;
            this.Writer = Writer;
            this.Lenght = Lenght;
            this.Categories = Categories;
            this.Studio = Studio;
            this.Description = Description;
            this.Year = Year;
            this.Resolution = Resolution;
            this.Memory = Memory;
            this.numReproductions = numReproductions;
            this.Rating = Rating;
            this.RatingProm = RatingProm;
            this.Video = Video;
            this.Trailer = Trailer;
            this.SongsMovie = SongsMovie;
            this.Min = Min;
        }

        public string Title1 { get => Title; set => Title = value; }
        public Person Director1 { get => Director; set => Director = value; }
        public List<Person> Actors1 { get => Actors; set => Actors = value; }
        public Person Writer1 { get => Writer; set => Writer = value; }
        public int Lenght1 { get => Lenght; set => Lenght = value; }
        public List<string> Categories1 { get => Categories; set => Categories = value; }
        public string Studio1 { get => Studio; set => Studio = value; }
        public string Description1 { get => Description; set => Description = value; }
        public string Year1 { get => Year; set => Year = value; }
        public string Resolution1 { get => Resolution; set => Resolution = value; }
        public string Memory1 { get => Memory; set => Memory = value; }
        public int NumReproductions { get => numReproductions; set => numReproductions = value; }
        public List<double> Rating1 { get => Rating; set => Rating = value; }
        public double RatingProm1 { get => RatingProm; set => RatingProm = value; }
        public string Trailer1 { get => Trailer; set => Trailer = value; }
        public string Video1 { get => Video; set => Video = value; }
        public List<Songs> SongsMovie1 { get => SongsMovie; set => SongsMovie = value; }
        public int Min1 { get => Min; set => Min = value; }



        public void Play2(WindowsMediaPlayer player)
        {
            var carpeta = Directory.GetCurrentDirectory();
            string D = carpeta + this.Video;
            player.URL = D;
            player.controls.play();
            Console.WriteLine("Reproduciendo");
            Console.ReadLine();
            player.controls.stop();
        }

        public void Play()
        {
            var carpeta = Directory.GetCurrentDirectory();
            string D = carpeta + this.Video;
            System.Diagnostics.Process.Start(D);
        }

        public void PlayTrailer()
        {
            var carpeta = Directory.GetCurrentDirectory();
            string D = carpeta + this.Trailer;
            System.Diagnostics.Process.Start(D);
        }

        public void PlayTrailer2(WindowsMediaPlayer player)
        {
            var carpeta = Directory.GetCurrentDirectory();
            string D = carpeta + this.Trailer;
            player.URL = D;
            player.controls.play();
            Console.WriteLine("Reproduciendo");
            Console.ReadLine();
            player.controls.stop();
        }
        public void MovieInformation()
        {
            Console.WriteLine("Nombre Película: " + this.Studio1 + "\nDirector: " + this.Director1 + "\nDuración: " + this.Lenght + "\nRating: " + this.RatingProm1 + "\nAño: " + this.Year1);
            Console.WriteLine("Categorias: ");
            foreach (string cat in this.Categories1)
            {
                Console.WriteLine(cat);
            }
            Console.WriteLine("Reparto: ");
            foreach (Person actores in this.Actors1)
            {
                Console.WriteLine(actores.Name);
            }
        }
    }
}
 