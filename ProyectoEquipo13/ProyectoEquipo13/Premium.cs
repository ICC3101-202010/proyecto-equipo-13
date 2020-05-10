using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEquipo13
{
    class Premium : User
    {
        private string Type;
        private bool Privacy;
        private List<Playlists> MyPlaylist;
        private List<User> Follows;

        public Premium(string userName, string email, string password, bool privacy) : base(userName, email, password)
        {
            this.Type = "Premium";
            this.UserName = userName;
            this.Email = email;
            this.Password = password;
            this.Privacy = privacy;
        }

        //Playlist determinada favoritos
    }
}
