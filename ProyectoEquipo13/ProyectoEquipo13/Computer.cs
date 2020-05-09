using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEquipo13
{
    class Computer
    {
        public void PlaySong()
        {

        }

        public void PlayMovie()
        {

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
            if (type == "Actor" || type == "actor")
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

        public void Rate(string type, string name, int rate)
        {
            foreach (Movies movies in Files.AllMovies)
            {
                if (type == "Pelicula"|| type == "Película"|| type == "pelicula" || type == "película")
                {
                        int a = movies.Rating1 += rate;
                        int b = a / 2;
                        movies.Rating1 = b;
                }
            }
            if (type == "Cancion" || type == "Canción" || type == "canción" || type == "cancion")
            {
                foreach (Songs songs in Files.AllSongs)
                {
                    if(name == songs.Title1)
                    {
                        int a = songs.Rating1 += rate;
                        int b = a / 2;
                        songs.Rating1 = b;
                    }
                }
            }


        }

        public void CreatePlaylist()
        {

        }

        public void SeeTopMovies()
        {

        }
        public void SeeTopSong()
        {

        }
    }
}
