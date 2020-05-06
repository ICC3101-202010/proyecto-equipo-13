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
        protected string UserName;
        protected string Email;
        protected string Password;
        protected bool Privacy;

        public User(int userID, string userName, string email, string password, bool privacy)
        {
            this.UserID = userID;
            this.UserName = userName;
            this.Email = email;
            this.Password = password;
            this.Privacy = privacy;
        }

        public bool CreateAccount(string type, int userid, string username, string email, string password, bool privacy)   
        {
            for (int i = 0; i < Files.AllUsers.Count ; i++)
            {
                if ((Files.AllUsers[i].Email==email ) || (Files.AllUsers[i].UserName == username))
                {
                    Console.WriteLine("La cuenta no se puede crear, debido a que ya existe, o el mail usado ya esta usado");
                    return false;
                }
                else if (Files.AllUsers[i].Email != email || Files.AllUsers[i].UserName != username)
                {
                    if (type == "Admin") 
                    { 
                    Admin admin = new Admin(userid, username, email, password, privacy);
                    Files.AllUsers.Add(admin);
                    }
                    else if (type == "Premium")
                    {
                        Premium premium = new Premium(userid, username, email, password, privacy);
                        Files.AllUsers.Add(premium);
                    }
                    else if (type == "Free")
                    {
                        Free free = new Free(userid, username, email, password, privacy);
                        Files.AllUsers.Add(free);
                    }
                    else
                    {
                        Console.WriteLine("Tipo seleccionado no existe");
                        return false;
                    }
                    Console.WriteLine("La cuenta ha sido creada correctamente");
                    return true;
                }
            }
            Console.WriteLine("La opción que seleccionó no es válida");
            return false;
        }
    }
}
