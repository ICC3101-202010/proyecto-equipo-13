using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEquipo13
{
    static class Files
    {
        private static List<Movies> allMovies = new List<Movies>();
        private static List<Songs> allSongs = new List<Songs>();
        private static List<Playlists> allPlaylistsSongs = new List<Playlists>();
        private static List<Playlists> allPlaylistsMovies = new List<Playlists>();
        private static List<User> allUsers = new List<User>();

        public static List<Movies> AllMovies { get => allMovies; set => allMovies = value; }
        public static List<Songs> AllSongs { get => allSongs; set => allSongs = value; }
        public static List<Playlists> AllPlaylistsSongs { get => allPlaylistsSongs; set => allPlaylistsSongs = value; }
        public static List<Playlists> AllPlaylistsMovies { get => allPlaylistsMovies; set => allPlaylistsMovies = value; }
        public static List<User> AllUsers { get => allUsers; set => allUsers = value; }
    }
}
