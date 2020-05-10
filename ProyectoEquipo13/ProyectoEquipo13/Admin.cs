using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEquipo13
{
    public class Admin : User
    {
        private string Type;

        public Admin(string userName, string email, string password, bool privacy) : base(userName, email, password)
        {
            this.Type = "Admin";
            this.UserName = userName;
            this.Email = email;
            this.Password = password;
        }

        public bool AddSong(Songs song)
        {
            for (int i = 0; i < Files.AllSongs.Count; i++)
            {
                if (Files.AllSongs[i] == song)
                {
                    return false;
                }
            }
            Files.AllSongs.Add(song);
            foreach (SmartPlaylist smart in Files.AllSmartPlaylistsSongs)
            {
                foreach (string genero in song.Genre1)
                {
                    if (genero == smart.NameCriterio)
                    {
                        smart.Playlistsong.Add(song);
                    }
                }
                if (song.Artist1.Name == smart.NameCriterio)
                {
                    smart.Playlistsong.Add(song);
                }

            }
            return true;
        }

        public bool AddMovie(Movies movie)
        {
            for (int i = 0; i < Files.AllMovies.Count; i++)
            {
                if (Files.AllMovies[i] == movie)
                {
                    return false;
                }
            }
            Files.AllMovies.Add(movie);
            return true;
        }
    }
}

