using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEquipo13
{
    class Free : User, ISubscribing
    {
        private string Type;

        public Free(int userID, string userName, string email, string password, bool privacy) : base(userID, userName, email, password, privacy)
        {
            this.Type = "Free";
            this.UserID = userID;
            this.UserName = userName;
            this.Email = email;
            this.Password = password;
            this.Privacy = privacy;
        }

        public void Subscribing(User user, int userid, string username, string email, string password, bool privacy) //Ver bien tema de hacer User y Admin estáticos
        {
            user.CreateAccount("Free", userid, username, email, password, privacy);
        }
    }
}
