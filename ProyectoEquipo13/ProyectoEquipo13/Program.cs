﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEquipo13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Prueba");
            Console.Read();
            Album Album = new Album();
            string TitleS = "Son of man";
            char M = 'M';
            char F = 'F';
            Person Composer = new Person("Phil Collins", new DateTime(1951, 1, 30, 5, 5, 5), M);
            Artist Artist = new Artist("Phil Collins", new DateTime(1951, 1, 30, 5, 5, 5), M);
            int LenghtS = 165;
            List<string> GenreS = new List<string>();
            GenreS.Add("Pop Rock");
            GenreS.Add("Soft Rock");
            string LyricsS = "letra";
            string ResolutionS = "192kbps";
            string MemoryS = "3,78MB";
            int numReproductionsS = 0;
            int RatingS = 0;
            string  Music = "";
            // C:\Users\56984\Desktop\Universidad\Progra\Proyecto\proyecto-equipo-13\Songs\Tarzan_-Son_Of_Man_Phil_Collins
            int MinS = 0;
            Songs song1 = new Songs(TitleS, Composer, Artist, Composer, LenghtS, GenreS, LyricsS, ResolutionS, MemoryS, numReproductionsS, RatingS, Music, MinS, Album);
            
            string Title = "Tarzan";
            Person Director = new Person("Kevin Lima", new DateTime(1962,6,12,5,5,5), M);
            List<Person> Actors = new List<Person>();
            Person Actor1 = new Person("Frank Welker",new DateTime(1946,3,12,5,5,5), M);
            Person Actor2 = new Person("Danielle Keaton", new DateTime(1986,7,30,5,5,5), F);
            Actors.Add(Actor1);
            Actors.Add(Actor2);
            Person Writer = new Person("Tab Murphy", new DateTime(1966,2,25,5,5,5), F);
            int Lenght = 88;
            List<string> Categories = new List<string>();
            Categories.Add("Animación musical");
            Categories.Add("Aventura");
            Categories.Add("Comedia");
            string Studio = "Walt Disney Pictures";
            string Description = "descripcion";
            DateTime Year = new DateTime(1999,6,18,5,5,5);
            string Resolution = "617kbps";
            string Memory = "12,2MB";
            int numReproductions = 0;
            int Rating = 0;
            string Trailer = "";
            //C: \Users\56984\Desktop\Universidad\Progra\Proyecto\proyecto - equipo - 13\Movies\Tarzan_-Son_Of_Man_Phil_Collins
            string Video = "";
            //C: \Users\56984\Desktop\Universidad\Progra\Proyecto\proyecto - equipo - 13\Movies\Tarzan_-Son_Of_Man_Phil_Collins
            List<Songs> SongsMovie = new List<Songs>();
            SongsMovie.Add(song1);
            int Min = 0;
            Movies movie1 = new Movies(Title, Director, Actors, Writer, Lenght, Categories, Studio, Description, Year, Resolution, Memory, numReproductions, Rating, Trailer, Video, SongsMovie, Min);

        }
    }
}
