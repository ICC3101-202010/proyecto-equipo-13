using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEquipo13
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
                    //SeeNamesSongs(songs6, user, computer);
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
                    //SeeNamesSongs(songs, user, computer);
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
            List<Movies> movies3 = new List<Movies>();
            if (person != "")
            {
                var movieDirector = from movie1 in movies
                                    where (movie1.Director1.Name == person || movie1.Director1.Name.Contains(person))
                                    orderby movie1 ascending
                                    select movie1;
                var movieWriter = from movie2 in movies
                                  where (movie2.Writer1.Name == person || movie2.Writer1.Name.Contains(person))
                                  orderby movie2 ascending
                                  select movie2;
                foreach (Movies movie in movies)
                {
                    foreach(Person j in movie.Actors1)
                    {
                        var movieActors = from movie3 in movies
                                          where (j.Name == person || j.Name.Contains(person))
                                          orderby movie3 ascending
                                          select movie3;

                        foreach (Movies y in movieActors)
                        {
                            movies2.Add(y);
                        }
                    }
                }
                foreach (Movies z in movieDirector)
                {
                    movies2.Add(z);
                }
                foreach (Movies g in movieWriter)
                {
                    movies2.Add(g);
                }

                foreach (Movies t in movies2)
                {
                    if (movies3.Contains(t))
                    {
                        continue;
                    }
                    else
                    {
                        movies3.Add(t);
                    }
                }
                return movies3;
            }
            else
            {
                return movies;
            }
            
        }

        static List<Movies> QueryCategories(List<Movies> movies, string categorie)
        {
            List<Movies> movies2 = new List<Movies>();
            List<Movies> movies3 = new List<Movies>();
            if ( categorie!= "")
            {
                foreach (Movies movie in movies)
                {
                    foreach (string j in movie.Categories1)
                    {
                        var movieCategories = from movie3 in movies
                                          where (j == categorie || j.Contains(categorie))
                                          orderby movie3 ascending
                                          select movie3;

                        foreach (Movies y in movieCategories)
                        {
                            movies2.Add(y);
                        }
                    }

                }
                foreach (Movies t in movies2)
                {
                    if (movies3.Contains(t))
                    {
                        continue;
                    }
                    else
                    {
                        movies3.Add(t);
                    }
                }
                return movies3;
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
                var movieStudio = from movie in movies
                                  where (movie.Studio1 == studio || movie.Studio1.Contains(studio))
                                  orderby movie ascending
                                  select movie;
                foreach (Movies i in movieStudio)
                {
                    movies2.Add(i);
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
                var movieYear = from movie in movies
                                where (movie.Year1 == year)
                                orderby movie ascending
                                select movie;
                foreach (Movies i in movieYear)
                {
                    movies2.Add(i);
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
            if (rating != null)
            {
                var movieRating = from movie in movies
                                where (movie.RatingProm1>= rating)
                                orderby movie ascending
                                select movie;
                foreach (Movies i in movieRating)
                {
                    movies2.Add(i);
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
            if (numrep != null)
            {
                var movieRating = from movie in movies
                                  where (movie.NumReproductions >= numrep)
                                  orderby movie ascending
                                  select movie;
                foreach (Movies i in movieRating)
                {
                    movies2.Add(i);
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
                var songTitle = from song in songs
                                 where (song.Title1 == Title || song.Title1.Contains(Title))
                                 orderby song ascending
                                 select song;

                foreach (var i in songTitle)
                {
                    songs2.Add(i);
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
                var songArtist = from song in songs
                                where (song.Artist1.Name == person || song.Artist1.Name.Contains(person))
                                orderby song ascending
                                select song;
                var songComposer = from song in songs
                                 where (song.Composer1.Name == person || song.Composer1.Name.Contains(person))
                                 orderby song ascending
                                 select song;
                var songWriter = from song in songs
                                   where (song.Writer1.Name == person || song.Writer1.Name.Contains(person))
                                   orderby song ascending
                                   select song;

                foreach (var i in songArtist)
                {
                    songs2.Add(i);
                }
                foreach (var i in songComposer)
                {
                    songs2.Add(i);
                }
                foreach (var i in songWriter)
                {
                    songs2.Add(i);
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
            List<Songs> songs3 = new List<Songs>();
            if (genre != "")
            {
                foreach (Songs song in songs)
                {
                    foreach (string j in song.Genre1)
                    {
                        var songGenre = from song3 in songs
                                      where (j == genre || j.Contains(genre))
                                      orderby song3 ascending
                                      select song3;

                        foreach (Songs y in songGenre)
                        {
                            songs2.Add(y);
                        }
                    }

                }
                foreach (Songs t in songs2)
                {
                    if (songs3.Contains(t))
                    {
                        continue;
                    }
                    else
                    {
                        songs3.Add(t);
                    }
                }
                return songs3;
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
            if (numrep != null)
            {
                var songnumRep = from song in songs
                                  where (song.NumReproductions >= numrep)
                                  orderby song ascending
                                  select song;
                foreach (Songs i in songnumRep)
                {
                    songs2.Add(i);
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
            if (rating != null)
            {
                var songRating = from song in songs
                                 where (song.RatingProm1 >= rating)
                                 orderby song ascending
                                 select song;
                foreach (Songs i in songRating)
                {
                    songs2.Add(i);
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
                var songAlbum = from song in songs
                                 where (song.Album1.Name1==album || song.Album1.Name1.Contains(album))
                                 orderby song ascending
                                 select song;
                foreach (Songs i in songAlbum)
                {
                    songs2.Add(i);
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
                var songinMovie = from movie in Files.AllMovies
                                 where (movie.Title1==movieTitle)
                                 select movie;
                foreach (Movies i in songinMovie)
                {
                    songs2 = i.SongsMovie1;
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
            Console.WriteLine("Quiere Seleccionar algúna (Podra ver la infromación de esta, además podrá escoger si quiere reproducirla o agregarla a una Playlist)");
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
                Console.WriteLine(songs[i].Title1);
                //Falta opción para que pueda reproducirla si quiere o agregarla a una playlis
            }
            Console.WriteLine("Quiere Seleccionar algúna (Podra ver la infromación de esta, además podrá escoger si queire reproducirla o agregarla a una Playlist)");
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
