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
        private List<List<Playlists>> MyPlaylist;
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

        public void Subscribing(User user,int userid, string username, string email, string password, bool privacy) //Ver bien tema de hacer User y Admin estáticos
        {
            user.CreateAccount("Premium",userid, username, email, password, privacy);
        }

        //Faltaría método que agregara elementos a su playlist, cuando quiera, y le pregunte en un inicio tambn
        //Debería tener 2 playlists, una de movies y una de películas, o hacer que la list sea una lista de listas con dos listas dentro... Ahora puede tener todas las playlist que quiera, deberian haber algunas predeterinadas que se llamen Guardadas o algo así
    }
}
