using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEquipo13
{
    [Serializable]
    public class User
    {
        //Todos
        private string type= "nada";
        private string userName;
        private string email;
        private string password;

        //Premium
        private bool Privacy;
        private List<Playlists> MyPlaylist;
        private List<User> Follows;

        //Free
        //Nada

        //Admin
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
            foreach (SmartPlaylist smart in Files.AllSmartPlaylistsSongs)
            {
                foreach (string categoria in movie.Categories1)
                {
                    if (categoria == smart.NameCriterio)
                    {
                        smart.Playlistmovie.Add(movie);
                    }
                }
                if (movie.Director1.Name == smart.NameCriterio)
                {
                    smart.Playlistmovie.Add(movie);
                }
                foreach (Person actores in movie.Actors1)
                {
                    if (actores.Name == smart.NameCriterio)
                    {
                        smart.Playlistmovie.Add(movie);
                    }
                }
                if (movie.Studio1 == smart.NameCriterio)
                {
                    smart.Playlistmovie.Add(movie);
                }

            }
            return true;
        }

        //Propiedades
        public string Type { get => type; set => type = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public bool Privacy1 { get => Privacy; set => Privacy = value; }
        public List<Playlists> MyPlaylist1 { get => MyPlaylist; set => MyPlaylist = value; }
        public List<User> Follows1 { get => Follows; set => Follows = value; }

        public User() { } //Constructor para implementar Crear Cuenta, etc...

        public User(string type, string userName, string email, string password) //Constructor para Free y Admin
        {
            this.type = type;
            this.userName = userName;
            this.email = email;
            this.password = password;
        }

        public User(string userName, string email, string password, bool privacy) //Constructor para Premium
        {
            this.type = "Premium";
            this.userName = userName;
            this.email = email;
            this.password = password;
            this.Privacy = privacy;
        }
        //Recordad que Premium tiene más cosas


        //1.- Definir el delegate
        public delegate void VerifiedEmailEventHandler(object source, EventArgs args);
        //2.- Definir el evento basado en el delegate anterior
        public event VerifiedEmailEventHandler EmailVerified;
        //3.- Disparar el evento
        protected virtual void OnEmailVerified()
        {
            EmailVerified(this, new EventArgs());
        }

        public void OnEmailSent(object source, EventArgs args)
        {

            Console.Write("¿Quiere revisar su correo? (si)(no)\n");
            while (true)
            {
                string option = Console.ReadLine();
                if (option == "si")
                {
                    EmailVerified(source, args);
                    break;
                }
                else if (option == "no") { break; }
                else { Console.WriteLine("La opción que selecciono no es válida seleccione (si) o (no)"); }
            }
        }
    }
}
