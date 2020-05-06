using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEquipo13
{
    interface ISubscribing
    {
        void Subscribing(User user, int userid, string username, string email, string password, bool privacy);
    }
}
