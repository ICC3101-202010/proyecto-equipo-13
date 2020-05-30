using Proyecto_equipo_13_entrega_3.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_equipo_13_entrega_3
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {            
            Files.Users.Add(new User("Premium", "Admin", "email", "", false));
            Files.AllUsers[0] =new List<string>() {"Admin", "email","",Convert.ToString(DateTime.Now),"PremiumF" };
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppForm appform = new AppForm();
            UserController userController = new UserController(appform);
            Application.Run(appform);
        }
    }
}
