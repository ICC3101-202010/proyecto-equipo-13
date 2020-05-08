using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEquipo13
{
    public class Songs
    {
        
        string Title;
        Person Composer;
        Artist Artist;
        Person Writer;
        int Lenght;
        List<string> Genre;
        string Lyrics;
        string Resolution;
        string Memory;
        int numReproductions;
        int Rating;
        string Music;
        int Min;
        Album Album;

        Songs(string Title, Person Composer, Artist Artist, Person Writer, int Lenght, List<string> Genre, string Lyrics, string Resolution, string Memory, int numReproductions, int Rating, string Music, int Min, Album Album)
        {
            Title = this.Title;
            Composer = this.Composer;
            Artist = this.Artist;
            Writer = this.Writer;
            Lenght = this.Lenght;
            Genre = this.Genre;
            Lyrics = this.Lyrics;
            Resolution = this.Resolution;
            Memory = this.Memory;
            numReproductions = this.numReproductions;
            Rating = this.Rating;
            Music = this.Music;
            Min = this.Min;
            Album = this.Album;
        }

        public string Title1 { get => Title; set => Title = value; }
        public Person Composer1 { get => Composer; set => Composer = value; }
        public Artist Artist1 { get => Artist; set => Artist = value; }
        public Person Writer1 { get => Writer; set => Writer = value; }
        public int Lenght1 { get => Lenght; set => Lenght = value; }
        public List<string> Genre1 { get => Genre; set => Genre = value; }
        public string Lyrics1 { get => Lyrics; set => Lyrics = value; }
        public string Resolution1 { get => Resolution; set => Resolution = value; }
        public string Memory1 { get => Memory; set => Memory = value; }
        public int NumReproductions { get => numReproductions; set => numReproductions = value; }
        public int Rating1 { get => Rating; set => Rating = value; }
        public string Music1 { get => Music; set => Music = value; }
        public int Min1 { get => Min; set => Min = value; }
        internal Album Album1 { get => Album; set => Album = value; }
    }
}
