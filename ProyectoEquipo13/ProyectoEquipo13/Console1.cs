using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProyectoEquipo13
{
    public static class Console1
    {
        public static void InitialMessage()
        {
            Console.WriteLine("¡Bienvenido a Netfy! \n¡La nueva plataforma donde podrás tener tu música y películas en un solo lugar!");
        }

        public static User Account(Computer computer, User user, MailSender mailSender)
        {
            Console.WriteLine("Seleccione que desea hacer");
            Console.WriteLine("(a) Iniciar Sesión \n(b) Crear Cuenta \n(c) Cambiar contraseña \n(d) Cambiar nombre de usuario \n (e) Cambia tu cuenta de Free a Premium");
            string option = Console.ReadLine();
            computer.Registered += mailSender.OnRegistered;
            computer.PasswordChanged += mailSender.OnPasswordChanged;
            computer.UserNameChanged += mailSender.OnUserNameChanged;
            mailSender.EmailSent += user.OnEmailSent;
            user.EmailVerified += computer.OnEmailVerified;
            if (option == "a")
            {
                Console.WriteLine("Seleccione su Usuario:");
                string usrname = Console.ReadLine();
                Console.WriteLine("seleccione su COntraseña");
                string password = Console.ReadLine();
                string login = Files.LogIn(usrname, password);
                if (login == null)
                {
                    foreach (User i in Files.Users)
                    {
                        if (i.UserName == usrname && i.Password == password)
                        {
                            Thread.Sleep(2000);
                            Console.Clear();
                            return i;
                        }
                    }
                }
                else
                {
                    Console1.Account(computer, user, mailSender);
                }
            }
            else if (option == "b")
            {
                bool option2 = computer.Register();
                //Suponiendo que el mail si debería haber llegado
                if (option2 == true) { user.OnEmailSent(new object(), new EventArgs()); }
                Console1.Account(computer, user, mailSender);
            }
            else if (option == "c")
            {
                Console.Clear();
                computer.ChangePassword();
                Console1.Account(computer, user, mailSender);
            }
            else if (option == "d")
            {
                Console.Clear();
                computer.ChangeUserName();
                Console1.Account(computer, user, mailSender);
            }
            else if (option == "e")
            {
                Console.Clear();
                computer.UpgradeFree();
                Console1.Account(computer, user, mailSender);
            }
            else
            {
                Console.WriteLine("La opción que seleccionó no es válida");
                Console1.Account(computer, user, mailSender);
            }
            Thread.Sleep(2000);
            Console.Clear();
            return null;
        }

        static void SecondMessage(Computer computer)
        {
            
        }

        static void SeeMovies(Computer computer)
        {
            Dictionary<int, Movies> dic = new Dictionary<int, Movies>();
            Console.WriteLine("\nSeleccione la película que desee:\n");
            int counter = 1;
            foreach (Movies movie in Files.AllMovies)
            {
                Console.WriteLine('(' + counter + ')' + movie.Title1);
                dic.Add(counter, movie);
                counter += 1;
            }
            int option = Convert.ToInt32(Console.ReadLine());
            Movies movie2 = dic[option];
            movie2.MovieInformation();

        }
    }   

}
