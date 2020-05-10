using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEquipo13
{
    [Serializable]
    static class Files
    {
        private static List<Movies> allMovies = new List<Movies>();
        private static List<Songs> allSongs = new List<Songs>();
        private static List<Playlists> allPlaylistsSongs = new List<Playlists>();
        private static List<Playlists> allPlaylistsMovies = new List<Playlists>();
        private static List<SmartPlaylist> allSmartPlaylistsSongs = new List<SmartPlaylist>();
        private static List<SmartPlaylist> allSmartPlaylistsMovies = new List<SmartPlaylist>();
        private static Dictionary<int, List<string>> allUsers = new Dictionary<int, List<string>>();
        private static List<User> users = new List<User>();

        public static List<Movies> AllMovies { get => allMovies; set => allMovies = value; }
        public static List<Songs> AllSongs { get => allSongs; set => allSongs = value; }
        public static List<Playlists> AllPlaylistsSongs { get => allPlaylistsSongs; set => allPlaylistsSongs = value; }
        public static List<Playlists> AllPlaylistsMovies { get => allPlaylistsMovies; set => allPlaylistsMovies = value; }
        public static List<SmartPlaylist> AllSmartPlaylistsSongs { get => allSmartPlaylistsSongs; set => allSmartPlaylistsSongs = value; }
        public static List<SmartPlaylist> AllSmartPlaylistsMovies { get => allSmartPlaylistsMovies; set => allSmartPlaylistsMovies = value; }
        public static Dictionary<int, List<string>> AllUsers { get => allUsers; set => allUsers = value; }
        public static List<User> Users { get => users; set => users = value; }

        // Metodo para cambiar la contrasena de usr por newpsswds
        public static void ChangePassword(string usr, string newpsswd)
        {
            foreach (List<string> user in AllUsers.Values)
            {
                if (user[0] == usr)
                {
                    user[2] = newpsswd;
                }
            }
        }

        // Metodo para cambiar nombre de Usuario
        public static void ChangeUserName(string usr, string newusername)
        {
            foreach (List<string> user in AllUsers.Values)
            {
                if (user[0] == usr)
                {
                    user[0] = newusername;
                }
            }
        }

        // Metodo para agregar un nuevo usuario, verificando ademas que no exista
        public static string AddUser(List<string> data)
        {
            string description = null;
            foreach (List<string> value in AllUsers.Values)
            {
                if (data[0] == value[0])
                {
                    description = "El nombre de usuario especificado ya existe";
                }
                else if (data[1] == value[1])
                {
                    description = "El correo ingresado ya existe";
                }
            }
            if (description == null)
            { 
                AllUsers.Add(AllUsers.Count + 1, data);
                if (data[5] == "PremiumT") { Premium premium = new Premium(data[0], data[1], data[2], true); Users.Add(premium); }
                else if(data[5] == "PremiumF") { Premium premium = new Premium(data[0], data[1], data[2], false); Users.Add(premium); }
                else if (data[5] == "Free") { Free free = new Free(data[0], data[1], data[2]); Users.Add(free); }
            }
            return description;
        }

        // Metodo para obtener los datos de usr
        public static List<string> GetData(string usr)
        {
            foreach (List<string> user in AllUsers.Values)
            {
                if (user[0] == usr)
                {
                    return user;
                }
            }

            return new List<string>();
        }

        // Metodo para realizar el LogIn
        public static string LogIn(string usrname, string password)
        {
            string description = null;
            foreach (List<string> user in AllUsers.Values)
            {
                if (user[0] == usrname && user[2] == password)
                {
                    return description;
                }
            }
            return "Usuario o contrasena incorrecta";
        }
    }
}

