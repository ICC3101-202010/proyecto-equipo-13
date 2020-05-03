using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEquipo13
{
    public class Movies
    {
        string Title;
        Person Director;
        List<Person> Actors;
        Person Writer;
        int Lenght;
        List<string> Categories;
        string Studio;
        string Description;
        DateTime Year;
        string Resolution;
        string Memory;
        int numReproductions;
        int Rating;
        // mp4 Trailer;
        // mp4 Video;
        List<Songs> SongsMovie;
        int Min;

        Movies(string Title, Person Director, List<Person> Actors, Person Writer, int Lenght, List<string> Categories, string Studio, string Description, DateTime Year, string Resolution, string Memory, int numReproductions, int Rating, List<Songs> SongsMovie, int Min)
        {

        }
    }
}
 