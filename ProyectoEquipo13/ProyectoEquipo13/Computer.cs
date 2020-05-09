using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEquipo13
{
    class Computer
    {
        public Songs PlaySong(string name)
        {
            foreach(Songs songs in Files.AllSongs)
            {
                if(name == songs.Title1)
                {
                    return songs;
                }
            }
            return null;
        }

        public Movies PlayMovie(string name)
        {
            foreach (Movies movies in Files.AllMovies)
            {
                if (name == movies.Title1)
                {
                    return movies;
                }
            }
            return null;
        }

        public List<Songs> SearchTypeSongs(string type, string name)
        {
            List<Songs> show = new List<Songs>();

            if (type == "Título" || type == "Titulo" || type == "título" || type == "titulo")
            {
                foreach (Songs song in Files.AllSongs)
                {
                    if (song.Title1 == name)
                    {
                        show.Add(song);
                    }
                }
            }
            if (type == "Genero" || type == "Género" || type == "genero" || type == "género")
            {
                foreach (Songs song in Files.AllSongs)
                {
                    foreach (string genero in song.Genre1)
                    {
                        if (genero == name)
                        {
                            show.Add(song);
                        }
                    }
                }
            }
            if (type == "Artista" || type == "artista")
            {
                foreach (Songs song in Files.AllSongs)
                {
                    if (song.Artist1.GetName() == name)
                    {
                        show.Add(song);
                    }
                }
            }
            if (type == "Album" || type == "album")
            {
                foreach (Songs song in Files.AllSongs)
                {
                    if (song.Album1.GetName() == name)
                    {
                        show.Add(song);
                    }
                }
            }
            if (type == "Compositor" || type == "compositor")
            {
                foreach (Songs song in Files.AllSongs)
                {
                    if (song.Composer1.GetName() == name)
                    {
                        show.Add(song);
                    }
                }
            }
            if (type == "Escritor" || type == "escritor")
            {
                foreach (Songs song in Files.AllSongs)
                {
                    if (song.Writer1.GetName() == name)
                    {
                        show.Add(song);
                    }
                }
            }

            return show;


        }
        public List<Movies> SearchTypeMovies(string type, string name)
        {
            List<Movies> show = new List<Movies>();

            if (type == "Título" || type == "Titulo" || type == "título" || type == "titulo")
            {
                foreach (Movies movies in Files.AllMovies)
                {
                    if (movies.Title1 == name)
                    {
                        show.Add(movies);
                    }
                }
            }

            if (type == "Director" || type == "director" )
            {
                foreach (Movies movies in Files.AllMovies)
                {
                    if (movies.Director1.GetName() == name)
                    {
                        show.Add(movies);
                    }
                }
            }
            if (type == "Actor" || type == "actor")
            {
                foreach (Movies movies in Files.AllMovies)
                {
                    foreach (Person actor in movies.Actors1)
                    {
                        if (actor.GetName() == name)
                        {
                            show.Add(movies);
                        }
                    }
                }
            }
            if (type == "Escritor" || type == "escritor")
            {
                foreach (Movies movies in Files.AllMovies)
                {
                    if (movies.Writer1.GetName() == name)
                    {
                        show.Add(movies);
                    }
                }
            }
            if (type == "Categoria" || type == "categoria"||type == "Categoría" || type == "categoría")
            {
                foreach (Movies movies in Files.AllMovies)
                {
                    foreach (string categoria in movies.Categories1)
                    {
                        if (categoria == name)
                        {
                            show.Add(movies);
                        }
                    }
                }
            }
            if (type == "Estudio" || type == "estudio")
            {
                foreach (Movies movies in Files.AllMovies)
                {
                    if (movies.Studio1 == name)
                    {
                        show.Add(movies);
                    }
                }
            }
            return show;
        }

        public void Rate(string type, string name, List<double> rate) //FALTA IF PARA SABER QUE PELICULA
        {
            if (type == "Pelicula" || type == "Película" || type == "pelicula" || type == "película")
            {
                foreach (Movies movies in Files.AllMovies)
                {
                    if (name == movies.Title1)
                    {
                        double sum = rate.Sum();
                        double value = (sum / rate.Count());
                        movies.RatingProm1 = value;
                    }
                }
            }
            else if (type == "Cancion" || type == "Canción" || type == "canción" || type == "cancion")
            {
                foreach (Songs songs in Files.AllSongs)
                {
                    if (name == songs.Title1)
                    {
                        double sum = rate.Sum();
                        double value = (sum / rate.Count());
                        songs.RatingProm1 = value;
                    }
                }
            }
            else
            {
                Console.WriteLine("No se encontro referencia");
            }
        }

        public void CreatePlaylist(string type, string name, bool privacidad)
        {
            if(type == "Pelicula" || type == "Película" || type == "pelicula" || type == "película")
            {
                Playlists playlists = new Playlists(name, privacidad, type);
                Files.AllPlaylistsMovies.Add(playlists);
            }
            if (type == "Cancion" || type == "Canción" || type == "canción" || type == "cancion")
            {
                Playlists playlists = new Playlists(name, privacidad, type);
                Files.AllPlaylistsSongs.Add(playlists);
            }
        }

        public List<Movies> SeeTopMovies()
        {
            List<Movies> top = new List<Movies>();
            List<Movies> peliculas = new List<Movies>();
            foreach (Movies movies in Files.AllMovies)
            {
                peliculas.Add(movies);
            }
            var peliculasorden = peliculas.OrderByDescending(songs => songs.Rating1).ToList();
            for (int i = 0; i < 10; i++)
            {
                top.Add(peliculasorden[i]);
            }
            return top;

        }
        public List<Songs> SeeTopSong()
        {
            List<Songs> top = new List<Songs>();
            List<Songs> canciones = new List<Songs>();
            foreach (Songs songs in Files.AllSongs)
            {
                canciones.Add(songs);
            }
            var cancionesorden = canciones.OrderByDescending(songs => songs.Rating1).ToList();
            for (int i = 0; i < 10; i++)
            {
                top.Add(cancionesorden[i]);
            }
            return top;
        }
    }
}
