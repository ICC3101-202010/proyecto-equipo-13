using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_equipo_13_entrega_3
{
    static class Search
    {
        public static List<Movies> SearchingMovies(string titulo1, string titulo2, string artist1, string artist2, string cat1, string cat2, int numrep1, int numrep2, double rating1, double rating2, string año1, string año2)
        {
            List<Movies> movies1 = QueryTitle(Files.AllMovies, titulo1, titulo2);
            List<Movies> movies2 = QueryPerson(movies1, artist1, artist2);
            List<Movies> movies3 = QueryCategories(movies2, cat1, cat2);
            List<Movies> movies4 = QueryNumRep(movies3, numrep1, numrep2);
            List<Movies> movies5 = QueryRating(movies4, rating1, rating2);
            List<Movies> movies6 = QueryYear(movies5, año1, año2);
            return movies6;
        }
        public static List<Songs> SearchingSongs(string titulo1, string titulo2, string artist1, string artist2, string cat1, string cat2, int numrep1, int numrep2, double rating1, double rating2, string album1, string album2)
        {
            List<Songs> songs1 = QueryTitleS(Files.AllSongs, titulo1, titulo2);
            List<Songs> songs2 = QueryPersonsS(songs1, artist1, artist2);
            List<Songs> songs3 = QueryGenreS(songs2, cat1, cat2);
            List<Songs> songs4 = QueryNumRepS(songs3, numrep1, numrep2);
            List<Songs> songs5 = QueryRatingS(songs4, rating1, rating2);
            List<Songs> songs6 = QueryAlbumS(songs5, album1, album2);
            return songs6;
        }
        public static List<Person> SearchingPerson(string titulo1, string titulo2, string artist1, string artist2, bool masc, bool fem, int edad1, int edad2)
        {
            List<Person> persons1 = QueryName(Files.AllPersons, titulo1, titulo2);
            List<Person> persons2 = QueryName(persons1, artist1, artist2);
            List<Person> persons3 = QuerySexo(persons2, masc, fem);
            List<Person> persons4 = QueryEdad(persons3, edad1, edad2);
            return persons4;
        }

        //Query Movies
        static List<Movies> QueryTitle(List<Movies> movies, string TitleA, string TitleB)
        {
            List<Movies> movies2 = new List<Movies>();
            if (TitleA != "")
            {
                foreach(Movies movie in movies)
                {
                    if (movie.Title1.ToUpper()==TitleA.ToUpper() || movie.Title1.ToUpper().Contains(TitleA.ToUpper()))
                    {
                        movies2.Add(movie);
                    }
                }
            }
            if (TitleB != "")
            {
                foreach (Movies movie in movies)
                {
                    if (movie.Title1.ToUpper() == TitleB.ToUpper() || movie.Title1.ToUpper().Contains(TitleB.ToUpper()))
                    {
                        movies2.Add(movie);
                    }
                }
            }
            if (movies2.Count == 0)
            {
                return movies;
            }
            else
            {
                return movies2;
            }
            
        }

        static List<Movies> QueryPerson(List<Movies> movies, string personA, string personB)
        {
            List<Movies> movies2 = new List<Movies>();
            if (personA != "")
            {
                foreach(Movies movie in movies)
                {
                    if (movie.Director1.Name.ToUpper() == personA.ToUpper() || movie.Director1.Name.ToUpper().Contains(personA.ToUpper()))
                    {
                        movies2.Add(movie);
                    }
                }
                foreach (Movies movie in movies)
                {
                    if (movie.Writer1.Name.ToUpper() == personA.ToUpper() || movie.Writer1.Name.ToUpper().Contains(personA.ToUpper()))
                    {
                        movies2.Add(movie);
                    }
                }
                foreach (Movies movie in movies)
                {
                    foreach(Person j in movie.Actors1)
                    {
                        if ((j.Name.ToUpper() == personA.ToUpper() || j.Name.ToUpper().Contains(personA.ToUpper())))
                        {
                            movies2.Add(movie);
                        }
                    }
                }
            }
            if (personB != "")
            {
                foreach (Movies movie in movies)
                {
                    if (movie.Director1.Name.ToUpper() == personB.ToUpper() || movie.Director1.Name.ToUpper().Contains(personB.ToUpper()))
                    {
                        movies2.Add(movie);
                    }
                }
                foreach (Movies movie in movies)
                {
                    if (movie.Writer1.Name.ToUpper() == personB.ToUpper() || movie.Writer1.Name.ToUpper().Contains(personB.ToUpper()))
                    {
                        movies2.Add(movie);
                    }
                }
                foreach (Movies movie in movies)
                {
                    foreach (Person j in movie.Actors1)
                    {
                        if ((j.Name.ToUpper() == personB.ToUpper() || j.Name.ToUpper().Contains(personB.ToUpper())))
                        {
                            movies2.Add(movie);
                        }
                    }
                }
            }
            if (movies2.Count == 0)
            {
                return movies;
            }
            else
            {
                return movies2;
            }
            
        }

        static List<Movies> QueryCategories(List<Movies> movies, string categorieA, string categorieB)
        {
            List<Movies> movies2 = new List<Movies>();
            if (categorieA!="")
            {
                foreach (Movies movie in movies)
                {
                    foreach (string j in movie.Categories1)
                    {
                        if (j.ToUpper() == categorieA.ToUpper() || j.ToUpper().Contains(categorieA.ToUpper()))
                        {
                            movies2.Add(movie);
                        }
                    }
                }
            }
            if (categorieB != "")
            {
                foreach (Movies movie in movies)
                {
                    foreach (string j in movie.Categories1)
                    {
                        if (j.ToUpper() == categorieB.ToUpper() || j.ToUpper().Contains(categorieB.ToUpper()))
                        {
                            movies2.Add(movie);
                        }
                    }
                }
            }
            if (movies2.Count == 0)
            {
                return movies;
            }
            else
            {
                return movies2;
            }
        }

        static List<Movies> QueryYear(List<Movies> movies, string yearA, string yearB)
        {
            List<Movies> movies2 = new List<Movies>();
            if (yearA != "")
            {
                foreach(Movies movie in movies)
                {
                    if (movie.Year1 == yearA)
                    {
                        movies2.Add(movie);
                    }
                }
            }
            if (yearB != "")
            {
                foreach (Movies movie in movies)
                {
                    if (movie.Year1 == yearB)
                    {
                        movies2.Add(movie);
                    }
                }
            }
            if (movies2.Count == 0)
            {
                return movies;
            }
            else
            {
                return movies2;
            }
        }

        //Mayor o igual que ese ranking
        static List<Movies> QueryRating(List<Movies> movies, double ratingA, double ratingB)
        {
            List<Movies> movies2 = new List<Movies>();
            try
            {
                foreach (Movies movie in movies)
                {
                    if (movie.RatingProm1 >= ratingA)
                    {
                        movies2.Add(movie);
                    }
                }
            }
            catch
            {

            }
            try
            {
                foreach (Movies movie in movies)
                {
                    if (movie.RatingProm1 >= ratingB)
                    {
                        movies2.Add(movie);
                    }
                }
            }
            catch
            {

            }
            if (movies2.Count == 0)
            {
                return movies;
            }
            else
            {
                return movies2;
            }
        }

        //Mayor o igual que ese numero de reproducciones
        static List<Movies> QueryNumRep(List<Movies> movies, int numrepA, int numrepB)
        {
            List<Movies> movies2 = new List<Movies>();
            try
            {
                foreach (Movies movie in movies)
                {
                    if (movie.NumReproductions >= numrepB)
                    {
                        movies2.Add(movie);
                    }
                }
            }
            catch
            {

            }
            try
            {
                foreach (Movies movie in movies)
                {
                    if (movie.NumReproductions >= numrepB)
                    {
                        movies2.Add(movie);
                    }
                }
            }
            catch
            {

            }
            if (movies2.Count == 0)
            {
                return movies;
            }
            else
            {
                return movies2;
            }
        }



        //Query Songs
        static List<Songs> QueryTitleS(List<Songs> songs, string TitleA,string TitleB)
        {
            List<Songs> songs2 = new List<Songs>();
            if (TitleA != "")
            {
                foreach(Songs song in songs)
                {
                    if (song.Title1.ToUpper() == TitleA.ToUpper() || song.Title1.ToUpper().Contains(TitleA.ToUpper()))
                    {
                        songs2.Add(song);
                    }
                }
            }
            if (TitleB != "")
            {
                foreach (Songs song in songs)
                {
                    if (song.Title1.ToUpper() == TitleB.ToUpper() || song.Title1.ToUpper().Contains(TitleB.ToUpper()))
                    {
                        songs2.Add(song);
                    }
                }
            }
            if (songs2.Count == 0)
            {
                return songs;
            }
            else
            {
                return songs2;
            }
        }

        static List<Songs> QueryPersonsS(List<Songs> songs, string personA, string personB)
        {
            List<Songs> songs2 = new List<Songs>();
            if (personA != "")
            {
                foreach (Songs song in songs)
                {
                    if(song.Artist1.Name.ToUpper() == personA.ToUpper() || song.Artist1.Name.ToUpper().Contains(personA.ToUpper()))
                    {
                        songs2.Add(song);
                    }
                }
                foreach (Songs song in songs)
                {
                    if(song.Composer1.Name.ToUpper() == personA.ToUpper() || song.Composer1.Name.ToUpper().Contains(personA.ToUpper()))
                    {
                        songs2.Add(song);
                    }
                }
                foreach(Songs song in songs)
                {
                    if (song.Writer1.Name.ToUpper() == personA.ToUpper() || song.Writer1.Name.ToUpper().Contains(personA.ToUpper()))
                    {
                        songs2.Add(song);
                    }
                }
            }
            if (personB != "")
            {
                foreach (Songs song in songs)
                {
                    if (song.Artist1.Name.ToUpper() == personB.ToUpper() || song.Artist1.Name.ToUpper().Contains(personB.ToUpper()))
                    {
                        songs2.Add(song);
                    }
                }
                foreach (Songs song in songs)
                {
                    if (song.Composer1.Name.ToUpper() == personB.ToUpper() || song.Composer1.Name.ToUpper().Contains(personB.ToUpper()))
                    {
                        songs2.Add(song);
                    }
                }
                foreach (Songs song in songs)
                {
                    if (song.Writer1.Name.ToUpper() == personB.ToUpper() || song.Writer1.Name.ToUpper().Contains(personB.ToUpper()))
                    {
                        songs2.Add(song);
                    }
                }
            }
            if (songs2.Count == 0)
            {
                return songs;
            }
            else
            {
                return songs2;
            }

        }

        static List<Songs> QueryGenreS(List<Songs> songs, string genreA,string genreB)
        {
            List<Songs> songs2 = new List<Songs>();
            if (genreA != "")
            {
                foreach (Songs song in songs)
                {
                    foreach (string j in song.Genre1)
                    {
                        if (j.ToUpper() == genreA.ToUpper() || j.ToUpper().Contains(genreA.ToUpper()))
                        {
                            songs2.Add(song);
                        }
                    }
                }
            }
            if (genreB != "")
            {
                foreach (Songs song in songs)
                {
                    foreach (string j in song.Genre1)
                    {
                        if (j.ToUpper() == genreB.ToUpper() || j.ToUpper().Contains(genreB.ToUpper()))
                        {
                            songs2.Add(song);
                        }
                    }
                }
            }
            if (songs2.Count == 0)
            {
                return songs;
            }
            else
            {
                return songs2;
            }
        }

        //Mayor o igual que ese numero de reproducciones
        static List<Songs> QueryNumRepS(List<Songs> songs, int numrepA, int numrepB)
        {
            List<Songs> songs2 = new List<Songs>();
            try
            {
                foreach (Songs song in songs)
                {
                    if ((song.NumReproductions >= numrepA))
                    {
                        songs2.Add(song);
                    }
                }
            }
            catch
            {
            }
            try
            {
                foreach (Songs song in songs)
                {
                    if ((song.NumReproductions >= numrepB))
                    {
                        songs2.Add(song);
                    }
                }
            }
            catch
            {
            }
            if (songs2.Count == 0)
            {
                return songs;
            }
            else
            {
                return songs;
            }
        }

        static List<Songs> QueryRatingS(List<Songs> songs, double ratingA,double ratingB)
        {
            List<Songs> songs2 = new List<Songs>();
            try
            {
                foreach (Songs song in songs)
                {
                    if (song.RatingProm1 >= ratingA)
                    {
                        songs2.Add(song);
                    }
                }
            }
            catch
            {
            }
            try
            {
                foreach (Songs song in songs)
                {
                    if (song.RatingProm1 >= ratingB)
                    {
                        songs2.Add(song);
                    }
                }
            }
            catch
            {
            }
            if (songs2.Count == 0)
            {
                return songs;
            }
            else
            {
                return songs2;
            }
        }

        static List<Songs> QueryAlbumS(List<Songs> songs, string albumA, string albumB)
        {
            List<Songs> songs2 = new List<Songs>();
            if (albumA != "")
            {
                foreach (Songs song in songs)
                {
                    if (song.Album1.Name1.ToUpper() == albumA.ToUpper() || song.Album1.Name1.ToUpper().Contains(albumA.ToUpper()))
                    {
                        songs2.Add(song);
                    }
                }
            }
            if (albumB != "")
            {
                foreach (Songs song in songs)
                {
                    if (song.Album1.Name1.ToUpper() == albumB.ToUpper() || song.Album1.Name1.ToUpper().Contains(albumB.ToUpper()))
                    {
                        songs2.Add(song);
                    }
                }
            }
            if (songs2.Count == 0)
            {
                return songs;
            }
            else
            {
                return songs2;
            }
        }

        //Persons
         static List<Person> QueryName(List<Person> persons, string nameA,string nameB)
         {
            List<Person> persons2 = new List<Person>();
            foreach (Person person in persons)
            {
                if (person.Name.ToUpper()==nameA.ToUpper() || person.Name.ToUpper().Contains(nameB.ToUpper()))
                {
                    persons2.Add(person);
                }
                if (person.Name.ToUpper() == nameB.ToUpper() || person.Name.ToUpper().Contains(nameB.ToUpper()))
                {
                    persons2.Add(person);
                }
            }
            if (persons2.Count == 0)
            {
                return persons;
            }
            else
            {
                return persons2;
            }
         }

         static List<Person> QuerySexo(List<Person> persons, bool masc,bool fem)
         {
            List<Person> persons2 = new List<Person>();
            foreach (Person person in persons)
            {
                if (person.Genre == 'M' && masc==true)
                {
                    persons2.Add(person);
                }
                if (person.Genre == 'F' && fem == true)
                {
                    persons2.Add(person);
                }
            }
            if (persons2.Count == 0)
            {
                return persons;
            }
            else
            {
                return persons2;
            }
         }

        static List<Person> QueryEdad(List<Person> persons, int edadA, int edadB)
        {
            List<Person> persons2 = new List<Person>();
            foreach (Person person in persons)
            {
                int age = GetAge(person.Birthday);
                if (age == edadA)
                {
                    persons2.Add(person);
                }
                if (age == edadB)
                {
                    persons2.Add(person);
                }
            }
            if (persons2.Count == 0)
            {
                return persons;
            }
            else
            {
                return persons2;
            }
        }

        public static Int32 GetAge(this DateTime dateOfBirth)
        {
            var today = DateTime.Today;

            var a = (today.Year * 100 + today.Month) * 100 + today.Day;
            var b = (dateOfBirth.Year * 100 + dateOfBirth.Month) * 100 + dateOfBirth.Day;

            return (a - b) / 10000;
        }

        //Mezcla
        static List<Songs> QueryMovieSong(string movieTitle)
        {
            List<Songs> songs2 = new List<Songs>();
            if (movieTitle != "")
            {
                foreach (Movies movie in Files.AllMovies)
                {
                    if (movie.Title1 == movieTitle)
                    {
                        songs2 = movie.SongsMovie1;
                    }
                }
                return songs2;
            }
            else
            {
                return null;
            }
        }

        //Imprimir cancioens/películas encontradas...no debería servir

        static void SeeNamesMovies(List<Movies> movies, User userlogin, Computer computer)
        {
            Console.WriteLine("\nLas películas encontradas son:\n");
            for (int i = 0; i < movies.Count; i++)
            {
                Console.WriteLine("-"+movies[i].Title1);
                //Falta opción para que pueda reproducirla si quiere o agregarla a una playlis
            }
            Console.WriteLine("Quiere Seleccionar algúna (Podra ver la información de esta, además podrá escoger si quiere reproducirla o agregarla a una Playlist)");
            Console.WriteLine("(si)\n(no)");
            string option = Console.ReadLine();
            if (option == "si")
            {
                Console1.SeeMoviesSearch(computer, userlogin, movies);
            }
            else if (option == "no")
            {
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("La opción seleccionada no es válida");
            }
        }

        static void SeeNamesSongs(List<Songs> songs, User userlogin, Computer computer)
        {
            Console.WriteLine("\nLas canciones encontradas son:\n");
            for (int i = 0; i < songs.Count; i++)
            {
                Console.WriteLine("-"+songs[i].Title1);
                //Falta opción para que pueda reproducirla si quiere o agregarla a una playlis
            }
            Console.WriteLine("Quiere Seleccionar algúna (Podra ver la información de esta, además podrá escoger si queire reproducirla o agregarla a una Playlist)");
            Console.WriteLine("(si)\n(no)");
            string option = Console.ReadLine();
            if (option == "si")
            {
                Console1.SeeSongsSearch(computer, userlogin, songs);
            }
            else if (option == "no")
            {
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("La opción seleccionada no es válida");
            }
        }
    }
}
