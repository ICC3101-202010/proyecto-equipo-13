using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEquipo13
{
    public class Premium : User
    {
        private string Type;
        private bool Privacy;
        private List<Playlists> MyPlaylist;
        private List<User> Follows;

        public string Type1 { get => Type; set => Type = value; }
        public bool Privacy1 { get => Privacy; set => Privacy = value; }
        public List<Playlists> MyPlaylist1 { get => MyPlaylist; set => MyPlaylist = value; }
        public List<User> Follows1 { get => Follows; set => Follows = value; }

        public Premium(string userName, string email, string password, bool privacy) : base(userName, email, password)
        {
            this.Type1 = "Premium";
            this.UserName = userName;
            this.Email = email;
            this.Password = password;
            this.Privacy1 = privacy;
        }
    }
}
