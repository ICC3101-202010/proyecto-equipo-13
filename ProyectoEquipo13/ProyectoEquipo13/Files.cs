using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEquipo13
{
    static class Files
    {
        private List<Movies> allMovies = new List<Movies>();
        private List<Songs> allSongs = new List<Songs>();
        private List<Playlists> allPlaylistsSongs = new List<Playlists>();
        private List<Playlists> allPlaylistsMovies = new List<Playlists>();
        private List<User> allUsers = new List<User>();

        public List<Movies> AllMovies { get => allMovies; set => allMovies = value; }
        public List<Songs> AllSongs { get => allSongs; set => allSongs = value; }
        public List<Playlists> AllPlaylistsSongs { get => allPlaylistsSongs; set => allPlaylistsSongs = value; }
        public List<Playlists> AllPlaylistsMovies { get => allPlaylistsMovies; set => allPlaylistsMovies = value; }
        public List<User> AllUsers { get => allUsers; set => allUsers = value; }
    }
}
