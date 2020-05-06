using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEquipo13
{
    public class Playlist
    {
        private string Type;
        protected string Name;
        protected bool Privacy;
        protected List<Songs> playlistsong = new List<Songs>();
        protected List<Movies> playlistmovie = new List<Movies>();

        public Playlist(string name, bool privacy, string type)
        {
            this.Name = name;
            this.Privacy = privacy;
            this.Type = type;
        }
        public void AddSongs(Songs songs)
        {
            if (Type == "Song"|| Type == "song")
            {
                playlistsong.Add(songs);
            }

        }
        public void AddMovies(Movies movies)
        {
            if (Type == "Movie" || Type == "Movie")
            {
                playlistmovie.Add(movies);
            }
        }

    }
}
