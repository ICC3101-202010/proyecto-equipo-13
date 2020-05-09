using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEquipo13
{
    class Premium : User, ISubscribing
    {
        private string Type;
        private List<Playlists> MyPlaylist;
        private List<User> Follows;

        public Premium(int userID, string userName, string email, string password, bool privacy) : base(userID, userName, email, password, privacy)
        {
            this.Type = "Premium";
            this.UserID = userID;
            this.UserName = userName;
            this.Email = email;
            this.Password = password;
            this.Privacy = privacy;
        }

        public void Subscribing(User user,int userid, string username, string email, string password, bool privacy) 
        {
            user.CreateAccount("Premium",userid, username, email, password, privacy);
        }

        //Playlist determinada favoritos
    }
}
