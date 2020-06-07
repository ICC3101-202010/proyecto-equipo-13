using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;
using System.Media;
using System.IO;

namespace Proyecto_equipo_13_entrega_3
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
        string movieDirection;

        public Movies(string Title, Person Director, List<Person> Actors, Person Writer, int Lenght, List<string> Categories, string Studio, string Description, string Year, string Resolution, string Memory, int numReproductions, List<double> Rating, double RatingProm, string Trailer, string Video, List<Songs> SongsMovie, int Min, string movieDirection2)
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
            this.movieDirection = movieDirection2;
            Files.AllPersons.Add(Director);
            foreach (Person p in Actors)
            {
                Files.AllPersons.Add(p);
            }
            Files.AllPersons.Add(Writer);
            List<Person> Final = ((from s in Files.AllPersons select s).Distinct()).ToList();
            Files.AllPersons = Final;
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
        public string MovieDirection { get => movieDirection; set => movieDirection = value; }

    }
}
 