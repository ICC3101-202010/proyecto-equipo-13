using Proyecto_equipo_13_entrega_3.CustomsEvenArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_equipo_13_entrega_3.Controllers
{
    class UserController
    {
        AppForm view;
        
        public UserController(Form view)
        {
            initialize();
            this.view = view as AppForm;
            this.view.LoginButtonClicked += OnLoginButtonClicked;
            this.view.CreateAccountClicked += OnCreateAccountClicked;
            this.view.UserChecked += OnUserChecked;
        }

        public bool OnCreateAccountClicked(object sender, RegisterEventArgs e)
        {
            string result = Files.AddUser(new List<string>()
                {e.Username, e.Email, e.Password, Convert.ToString(DateTime.Now),e.TypePrivacy });
            if (result == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool OnLoginButtonClicked(object sender, LoginEventArgs e)
        {
            User result = null;
            result = Files.Users.Where(t =>
               t.UserName.ToUpper().Contains(e.UsernameText.ToUpper())).FirstOrDefault();
            if (result is null)
            {
                return false;
            }
            else
            {
                return result.CheckCredentials(e.UsernameText, e.PasswordText);
            }
        }

        public void OnUserChecked(object sender, LoginEventArgs e)
        {
            User user = null;
            user = Files.Users.Where(t =>
               t.UserName.ToUpper().Contains(e.UsernameText.ToUpper())).FirstOrDefault();
            view.setNameUser(user.UserName);
        }

        public void initialize()
        {
            //Serialización
        }
    }
}
