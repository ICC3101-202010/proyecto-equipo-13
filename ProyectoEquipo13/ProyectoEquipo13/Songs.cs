using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using WMPLib;
using System.IO;

namespace ProyectoEquipo13
{
    [Serializable]
    public class Songs
    {
        
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
            RatingProm = this.RatingProm;
            Music = this.Music;
            Type = this.Type;
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
        public List<double> Rating1 { get => Rating; set => Rating = value; }
        public double RatingProm1 { get => RatingProm; set => RatingProm = value; }
        public string Music1 { get => Music; set => Music = value; }
        public string Type1 { get => Type; set => Type = value; }
        public int Min1 { get => Min; set => Min = value; }
        public Album Album1 { get => Album; set => Album = value; }

        public void SongsInformation()
        {
            Console.WriteLine("Título: " + this.Title1 + "\nArtista: " + this.Artist1 + "\nAlbum: " + this.Album1 + "\nRating: " + this.RatingProm1);
            Console.WriteLine("Género/os: ");
            foreach(string genero in this.Genre1)
            {
                Console.WriteLine(genero);
            }
        }
        public void Play()
        {
            var carpeta = Directory.GetCurrentDirectory();
            string D = carpeta + this.Music;
            if (this.Type == ".wav")
            {
                SoundPlayer player = new SoundPlayer();
                player.SoundLocation = D;
                player.Play();
                Console.ReadLine();
                player.Stop();
            }
            else
            {
                WindowsMediaPlayer player = new WindowsMediaPlayer();
                player.URL = D;
                player.controls.play();
                Console.ReadLine();
                player.controls.stop();
            }
        }
    }

}
