using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEquipo13
{
    public class Free : User
    {
        private string Type;

        public Free(string userName, string email, string password) : base(userName, email, password)
        {
            this.Type = "Free";
            this.UserName = userName;
            this.Email = email;
            this.Password = password;
        }
    }
}
