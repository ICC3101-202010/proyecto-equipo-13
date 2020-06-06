using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_equipo_13_entrega_3
{
    [Serializable]
    public class User
    {
        //Todos
        private string type;
        private string userName;
        private string email;
        private string password;
        private bool lOGIN;

        //Premium
        private bool Privacy;
        private List<Playlists> MyPlaylist =new List<Playlists>();
        private Playlists MeGustaSongs = new Playlists("Me gusta", "Canción");
        private Playlists MeGustaMovies = new Playlists("Me gusta","Película");
        
        private List<User> Follows = new List<User>();
        private List<Person> Follows2 = new List<Person>();

        //Free
        //Nada


        //Propiedades
        public string Type { get => type; set => type = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public bool Privacy1 { get => Privacy; set => Privacy = value; }
        public List<Playlists> MyPlaylist1 { get => MyPlaylist; set => MyPlaylist = value; }
        public List<User> FollowsU { get => Follows; set => Follows = value; }
        public List<Person> FollowsP { get => Follows2; set => Follows2 = value; }
        public bool LOGIN { get => lOGIN; set => lOGIN = value; }
        public Playlists MeGustaSongs1 { get => MeGustaSongs; set => MeGustaSongs = value; }
        public Playlists MeGustaMovies1 { get => MeGustaMovies; set => MeGustaMovies = value; }

        public User() { } //Constructor para implementar Crear Cuenta, etc...

        public User(string type, string userName, string email, string password) //Constructor para Free y Admin
        {
            this.Type = type;
            this.userName = userName;
            this.email = email;
            this.password = password;
            MyPlaylist1.Add(MeGustaSongs1);
            MyPlaylist1.Add(MeGustaMovies1);
        }

        public User(string type, string userName, string email, string password, bool privacy) //Constructor para Premium
        {
            this.Type = type;
            this.userName = userName;
            this.email = email;
            this.password = password;
            this.Privacy = privacy;
            MyPlaylist1.Add(MeGustaSongs1);
            MyPlaylist1.Add(MeGustaMovies1);
        }
        //Recordar que Premium tiene más cosas

        public bool CheckCredentials(string username, string pass)
        {
            if (this.UserName.Equals(username) && this.Password.Equals(pass))
                return true;
            return false;
        }
    }
}
