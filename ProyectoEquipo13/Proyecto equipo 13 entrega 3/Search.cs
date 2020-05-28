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
        public static void Searching(Computer computer, User user)
        {
            Console.WriteLine("\nSeleccione que desea buscar:");
            Console.WriteLine("\n(a) Películas\n(b) Canciones \n(c) Lista de Canciones de una Película");
            string option = Console.ReadLine();
            if (option == "a")
            {
                Console.WriteLine("\nSeleccione el titulo que desea buscar:");
                string title = Console.ReadLine();
                List<Movies> movies = QueryTitle(Files.AllMovies, title);
                Console.WriteLine("\nSeleccione el nombre de una persona que trabajó en la película (Actor, Escritor, Director):");
                string person = Console.ReadLine();
                List<Movies> movies2 = QueryPerson(movies, person);
                Console.WriteLine("\nSeleccione una categoría de la película:");
                string categorie = Console.ReadLine();
                List<Movies> movies3 = QueryCategories(movies2, categorie);
                Console.WriteLine("\nSeleccione el Estudio de la película:");
                string studio = Console.ReadLine();
                List<Movies> movies4 = QueryStudio(movies3, studio);
                Console.WriteLine("\nSeleccione el año de la película:");
                string year = Console.ReadLine();
                List<Movies> movies5 = QueryYear(movies4, year);
                Console.WriteLine("\nSeleccione el Rating mínimo que desea para su película (todas las películas mayores o iguales al rating seleccionado) (Seleccione 0 en caso de no querer poner criterio):");
                double rating = Convert.ToDouble(Console.ReadLine());
                List<Movies> movies6 = QueryRating(movies5, rating);
                Console.WriteLine("\nSeleccione el número de reproducciones mínimo que desea (todas las películas mayores o iguales al número de reproducciones seleccionado) (Seleccione 0 en caso de no querer poner criterio):");
                int numrep = int.Parse(Console.ReadLine());
                List<Movies> movies7 = QueryNumRep(movies6, numrep);
                if (movies7.Count != 0)
                {
                    SeeNamesMovies(movies7, user, computer);
                }
                else
                {
                    Console.WriteLine("No se encontraron películas con los criterios utilizados en su búsqueda");
                }
            }
            else if (option == "b")
            {
                Console.WriteLine("\nSeleccione el título de la canción:");
                string title= Console.ReadLine();
                List<Songs> songs = QueryTitleS(Files.AllSongs, title);
                Console.WriteLine("\nSeleccione alguna persona involucrada en la canción (Compositor, Artista, Escritor):");
                string person = Console.ReadLine();
                List<Songs> songs2 = QueryPersonsS(songs,person);
                Console.WriteLine("\nSeleccione un género de la canción:");
                string genre= Console.ReadLine();
                List<Songs> songs3 = QueryGenreS(songs2,genre);
                Console.WriteLine("\nSeleccione el número de reproducciones mínimo que desea (todas las canciones mayores o iguales al número de reproducciones seleccionado) (Seleccione 0 en caso de no querer poner criterio):");              
                int numrep = int.Parse(Console.ReadLine());
                List<Songs> songs4 = QueryNumRepS(songs3, numrep);
                Console.WriteLine("\nSeleccione el Rating mínimo que desea (todas las cacniones mayores o iguales al rating seleccionado) (Seleccione 0 en caso de no querer poner criterio):");
                double rating = Convert.ToDouble(Console.ReadLine());
                List<Songs> songs5 = QueryRatingS(songs4,rating);
                Console.WriteLine("\nSeleccione el nombre del álbum:");
                string album= Console.ReadLine();
                List<Songs> songs6 = QueryAlbumS(songs5,album);
                if (songs6.Count != 0)
                {
                    SeeNamesSongs(songs6, user, computer);
                }
                else
                {
                    Console.WriteLine("No se encontraron canciones con los criterios utilizados en su búsqueda");
                }
            }
            else if (option == "c")
            {
                Console.WriteLine("\nSeleccione la película de donde quiere sacar la lista de canciones:");
                string movietitle = Console.ReadLine();
                List<Songs> songs = QueryMovieSong(movietitle);
                if (songs.Count() !=0 )
                {
                    SeeNamesSongs(songs, user, computer);
                }
                else
                {
                    Console.WriteLine("No se encontró la película o la película buscada no tiene canciones involucradas");
                }
            }
            else
            {
                Console.WriteLine("\nLa opción que seleccionó no es válida");
            }
        }

        //Query Movies
        static List<Movies> QueryTitle(List<Movies> movies, string Title)
        {
            List<Movies> movies2 = new List<Movies>();
            if (Title != "")
            {
                foreach(Movies movie in movies)
                {
                    if (movie.Title1==Title || movie.Title1.Contains(Title))
                    {
                        movies2.Add(movie);
                    }
                }
                return movies2;
            }
            else
            {
                return movies;
            }
            
        }

        static List<Movies> QueryPerson(List<Movies> movies, string person)
        {
            List<Movies> movies2 = new List<Movies>();
            if (person != "")
            {
                foreach(Movies movie in movies)
                {
                    if (movie.Director1.Name == person || movie.Director1.Name.Contains(person))
                    {
                        movies2.Add(movie);
                    }
                }
                foreach (Movies movie in movies)
                {
                    if (movie.Writer1.Name == person || movie.Writer1.Name.Contains(person))
                    {
                        movies2.Add(movie);
                    }
                }
                foreach (Movies movie in movies)
                {
                    foreach(Person j in movie.Actors1)
                    {
                        if ((j.Name == person || j.Name.Contains(person)))
                        {
                            movies2.Add(movie);
                        }
                    }
                }
                return movies2;
            }
            else
            {
                return movies;
            }
            
        }

        static List<Movies> QueryCategories(List<Movies> movies, string categorie)
        {
            List<Movies> movies2 = new List<Movies>();
            if ( categorie!= "")
            {
                foreach (Movies movie in movies)
                {
                    foreach (string j in movie.Categories1)
                    {
                        if (j == categorie || j.Contains(categorie))
                        {
                            movies2.Add(movie);
                        }
                    }
                }
                return movies2;
            }
            else
            {
                return movies;
            }
        }

        static List<Movies> QueryStudio(List<Movies> movies, string studio)
        {
            List<Movies> movies2 = new List<Movies>();
            if (studio != "")
            {
                foreach(Movies movie in movies)
                {
                    if (movie.Studio1 == studio || movie.Studio1.Contains(studio))
                    {
                        movies2.Add(movie);
                    }
                }
                return movies2;
            }
            else
            {
                return movies;
            }
        }

        static List<Movies> QueryYear(List<Movies> movies, string year)
        {
            List<Movies> movies2 = new List<Movies>();
            if (year != "")
            {
                foreach(Movies movie in movies)
                {
                    if (movie.Year1 == year)
                    {
                        movies2.Add(movie);
                    }
                }
                return movies2;
            }
            else
            {
                return movies;
            }
        }

        //Mayor o igual que ese ranking
        static List<Movies> QueryRating(List<Movies> movies, double rating)
        {
            List<Movies> movies2 = new List<Movies>();
            if (rating != 0)
            {
                foreach (Movies movie in movies)
                {
                    if (movie.RatingProm1 >= rating)
                    {
                        movies2.Add(movie);
                    }
                }
                return movies2;
            }
            else
            {
                return movies;
            }
        }

        //Mayor o igual que ese numero de reproducciones
        static List<Movies> QueryNumRep(List<Movies> movies, int numrep)
        {
            List<Movies> movies2 = new List<Movies>();
            if (numrep != 0)
            {
                foreach (Movies movie in movies)
                {
                    if (movie.NumReproductions >= numrep)
                    {
                        movies2.Add(movie);
                    }
                }
                return movies2;
            }
            else
            {
                return movies;
            }
        }


        //Query Songs
        static List<Songs> QueryTitleS(List<Songs> songs, string Title)
        {
            List<Songs> songs2 = new List<Songs>();
            if (Title != "")
            {
                foreach(Songs song in songs)
                {
                    if (song.Title1 == Title || song.Title1.Contains(Title))
                    {
                        songs2.Add(song);
                    }
                }
                return songs2;
            }
            else
            {
                return songs;
            }
        }

        static List<Songs> QueryPersonsS(List<Songs> songs, string person)
        {
            List<Songs> songs2 = new List<Songs>();
            if (person != "")
            {
                foreach (Songs song in songs)
                {
                    if(song.Artist1.Name == person || song.Artist1.Name.Contains(person))
                    {
                        songs2.Add(song);
                    }
                }
                foreach (Songs song in songs)
                {
                    if(song.Composer1.Name == person || song.Composer1.Name.Contains(person))
                    {
                        songs2.Add(song);
                    }
                }
                foreach(Songs song in songs)
                {
                    if (song.Writer1.Name == person || song.Writer1.Name.Contains(person))
                    {
                        songs2.Add(song);
                    }
                }
                return songs2;
            }
            else
            {
                return songs;
            }

        }

        static List<Songs> QueryGenreS(List<Songs> songs, string genre)
        {
            List<Songs> songs2 = new List<Songs>();
            if (genre != "")
            {
                foreach (Songs song in songs)
                {
                    foreach (string j in song.Genre1)
                    {
                        if (j == genre || j.Contains(genre))
                        {
                            songs2.Add(song);
                        }
                    }
                }
                return songs2;
            }
            else
            {
                return songs;
            }
        }

        //Mayor o igual que ese numero de reproducciones
        static List<Songs> QueryNumRepS(List<Songs> songs, int numrep)
        {
            List<Songs> songs2 = new List<Songs>();
            if (numrep != 0)
            {
                foreach (Songs song in songs)
                {
                    if ((song.NumReproductions >= numrep))
                    {
                        songs2.Add(song);
                    }
                }
                return songs2;
            }
            else
            {
                return songs;
            }
        }

        static List<Songs> QueryRatingS(List<Songs> songs, double rating)
        {
            List<Songs> songs2 = new List<Songs>();
            if (rating != 0)
            {
                foreach (Songs song in songs)
                {
                    if (song.RatingProm1 >= rating)
                    {
                        songs2.Add(song);
                    }
                }
                return songs2;
            }
            else
            {
                return songs;
            }
        }

        static List<Songs> QueryAlbumS(List<Songs> songs, string album)
        {
            List<Songs> songs2 = new List<Songs>();
            if (album != "")
            {
                foreach (Songs song in songs)
                {
                    if (song.Album1.Name1 == album || song.Album1.Name1.Contains(album))
                    {
                        songs2.Add(song);
                    }
                }
                return songs2;
            }
            else
            {
                return songs;
            }
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
