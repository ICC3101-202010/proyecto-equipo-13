using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace ProyectoEquipo13
{
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
        string Trailer;
        string Video;
        List<Songs> SongsMovie;
        int Min;

        public Movies(string Title, Person Director, List<Person> Actors, Person Writer, int Lenght, List<string> Categories, string Studio, string Description, string Year, string Resolution, string Memory, int numReproductions, List<double> Rating, double RatingProm, string Trailer, string Video, List<Songs> SongsMovie, int Min)
        {
            Title = this.Title;
            Director = this.Director;
            Actors = this.Actors;
            Writer = this.Writer;
            Lenght = this.Lenght;
            Categories = this.Categories;
            Studio = this.Studio;
            Description = this.Description;
            Year = this.Year;
            Resolution = this.Resolution;
            Memory = this.Memory;
            numReproductions = this.numReproductions;
            Rating = this.Rating;
            RatingProm = this.RatingProm;
            Video = this.Video;
            Trailer = this.Trailer;
            SongsMovie = this.SongsMovie;
            Min = this.Min;
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



        public void Play()
        {
            PlayMovie play = new PlayMovie();
            play.axWindowsMediaPlayer(Video1);
        }
        public void PlayTrailer()
        {
            PlayMovie play = new PlayMovie();
            play.axWindowsMediaPlayer(Trailer1);
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
 