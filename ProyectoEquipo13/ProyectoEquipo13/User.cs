using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEquipo13
{
    public class User
    {
        protected int UserID;
        protected string user
        protected string Email;
        protected string Password;
        protected bool Privacy;

        public bool CreateAccount(Files.AllUsers() list, string email, string password,)
        {
            for (int i = 0; i <list.Count ; i++)
            {
                if list[i].Email==email && list[i].Password==password || list[i].user==user
            }
        }
    }
}
