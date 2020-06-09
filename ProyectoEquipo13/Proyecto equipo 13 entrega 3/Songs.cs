using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using WMPLib;
using System.IO;
using System.Windows.Forms;

namespace Proyecto_equipo_13_entrega_3
{
    [Serializable]
    public class Songs
    {
        public static WindowsMediaPlayer player = new WindowsMediaPlayer();
        string Title;
        Person Composer;
        Artist Artist;
        Person Writer;
        int Lenght; // suma en segundos
        List<string> Genre;
        string Lyrics;
        string Resolution;
        string Memory;
        int numReproductions;
        List<double> Rating;
        double RatingProm;
        string Music; //nombre archivo
        string Type; // tipo archivo ej. ".wav",".mp3"
        int Min;
        Album Album;

        public Songs(string Title, Person Composer, Artist Artist, Person Writer, int Lenght, List<string> Genre, string Lyrics, string Resolution, string Memory, int numReproductions, List<double> Rating, double RatingProm, string Music, string Type, int Min, Album Album)
        {
            this.Title = Title;
            this.Composer = Composer;
            this.Artist = Artist;
            this.Writer = Writer;
            this.Lenght = Lenght;
            this.Genre = Genre;
            this.Lyrics = Lyrics;
            this.Resolution = Resolution;
            this.Memory = Memory;
            this.numReproductions = numReproductions;
            this.Rating = Rating;
            this.RatingProm = RatingProm;
            this.Music = Music;
            this.Type = Type;
            this.Min = Min;
            this.Album = Album;
            AgregarPersona(Composer);
            AgregarArtista(Artist);
            AgregarPersona(Writer);
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
        public List<double> Rating1 { get => Rating; set => Rating = value; }
        public double RatingProm1 { get => RatingProm; set => RatingProm = value; }
        public string Music1 { get => Music; set => Music = value; }
        public string Type1 { get => Type; set => Type = value; }
        public int Min1 { get => Min; set => Min = value; }
        public Album Album1 { get => Album; set => Album = value; }

        public void AgregarPersona(Person name)
        {
            int contador = 0;
            foreach (Person person in Files.AllPersons)
            {
                if (name.Name == person.Name)
                {
                    contador += 1;
                }
            }
            if (contador == 0)
            {
                Files.AllPersons.Add(name);
            }
        }

        public void AgregarArtista(Person name)
        {
            int contador = 0;
            foreach (Person person in Files.AllPersons)
            {
                if (name.Name == person.Name)
                {
                    contador += 1;
                }
            }
            if (contador == 0)
            {
                Files.AllPersons.Add(name);
            }
        }
    }
}
