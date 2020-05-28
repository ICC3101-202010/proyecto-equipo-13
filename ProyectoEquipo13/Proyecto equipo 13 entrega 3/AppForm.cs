using Proyecto_equipo_13_entrega_3.CustomsEvenArgs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_equipo_13_entrega_3
{
    public partial class AppForm : Form
    {
        public delegate bool LoginEventHandler(object source, LoginEventArgs args);
        public event LoginEventHandler LoginButtonClicked;
        public event EventHandler<LoginEventArgs> UserChecked;
        public delegate bool CreateAccountEventHandler(object source, RegisterEventArgs args);
        public event CreateAccountEventHandler CreateAccountClicked;

        //Organizacion
        List<Panel> stackPanels = new List<Panel>();
        Dictionary<string, Panel> panels = new Dictionary<string, Panel>();

        public AppForm()
        {
            InitializeComponent();
            //this.WindowState = FormWindowState.Maximized;
            panels.Add("WelcomePanel", WelcomeMenu);
            panels.Add("LoginPanel", LoginView);
            panels.Add("UserPanel", UserPanel);
            panels.Add("CreateAccountPanel", CreateAccountView);
            panels.Add("ModificarCuentaPanel", ModificarCuentaPanel);
            stackPanels.Add(panels["WelcomePanel"]);
            ShowLastPanel();
        }

        private void AppForm_Load(object sender, EventArgs e)
        {

        }

        private void IniciarSesión_Click(object sender, EventArgs e)
        {
            stackPanels.Add(panels["LoginPanel"]);
            ShowLastPanel();            
        }

        private void CrearCuenta_Click(object sender, EventArgs e)
        {
            InputPrivacidadCreateAccountView.SelectedIndex = -1;
            InputTipoUsuarioCreateAccountView.SelectedIndex = -1;
            InputPasswordCreateAccountView.ResetText();
            InputEmailCreateAccountView.ResetText();
            InputUserNameCreateAccountView.ResetText();
            stackPanels.Add(panels["CreateAccountPanel"]);
            ShowLastPanel();
        }

        private void WelcomeMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ShowLastPanel()
        {
            foreach (Panel panel in panels.Values)
            {
                if (panel != stackPanels.Last())
                {
                    panel.Visible = false;
                }
                else
                {
                    panel.Dock = DockStyle.Fill;
                    panel.Visible = true;
                }
            }
        }

        public void setNameUser(string username)
        {
            ReadUserName.Text = username;
        }

        private void OnUserChecked(string username)
        {
            if (UserChecked != null)
            {
                UserChecked(this, new LoginEventArgs() { UsernameText = username });
                InputUsuarioLoginView.ResetText();
                InputContraseñaLoginView.ResetText();
                stackPanels.Add(panels["UserPanel"]);
                setNameUser(username);
                ShowLastPanel();
            }
        }

        private void UserPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoginButtonLoginView_Click(object sender, EventArgs e)
        {
            string username = InputUsuarioLoginView.Text;
            string pass = InputContraseñaLoginView.Text;
            OnLoginButtonClicked(username, pass);
        }

        private void OnLoginButtonClicked(string username, string pass)
        {
            bool result = LoginButtonClicked(this, new LoginEventArgs() { UsernameText = username, PasswordText = pass });
            if (!result)
            {
                loginViewInvalidCredentialsAlert.Text = "Credenciales inválidas";
                loginViewInvalidCredentialsAlert.Visible = true;
            }
            else
            {
                loginViewInvalidCredentialsAlert.ResetText();
                loginViewInvalidCredentialsAlert.Visible = false;
                OnUserChecked(username);
            }
        }

        private void CreateAccountView_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            string username = InputUserNameCreateAccountView.Text;
            string email = InputEmailCreateAccountView.Text;
            string pass = InputPasswordCreateAccountView.Text;
            string type = InputTipoUsuarioCreateAccountView.Text;
            string privacy = InputPrivacidadCreateAccountView.Text;
            OnCreateAccountClicked(username, email, pass,type, privacy);
        }

        private void OnCreateAccountClicked(string username, string email, string pass, string type, string privacy)
        {
            if ((type =="") || (type=="Premium" && privacy == "") || (username=="") || pass=="" || email =="")
            {
                CheckRegistration.Text = "Agregue los valores que faltan";
                CheckRegistration.Visible = true;
            }
            else
            {
                string typeprivacy = null;
                if (type == "Premium")
                {
                    if (privacy == "Público")
                    {
                        typeprivacy = "PremiumT";
                    }
                    else
                    {
                        typeprivacy = "PremiumF";
                    }
                }
                else if (type == "Free")
                {
                    typeprivacy = "Free";
                }
                bool result = CreateAccountClicked(this, new RegisterEventArgs() { Username = username, Password = pass, Email = email, TypePrivacy= typeprivacy });
                if (!result)
                {
                    CheckRegistration.Text = "Usuario y/o email ya existen";
                    CheckRegistration.Visible = true;
                }
                else
                {
                    CheckRegistration.ResetText();
                    CheckRegistration.Visible = false;
                    OnUserChecked(username);
                }
            }
        }

        private void CerrarSesiónButton_Click(object sender, EventArgs e)
        {
            stackPanels.Add(panels["WelcomePanel"]);
            setNameUser("");
            ShowLastPanel();
        }

        private void ModificarCuentaButton_Click(object sender, EventArgs e)
        {
            stackPanels.Add(panels["ModificarCuentaPanel"]);
            ShowLastPanel();
            ChangeUserPanel.Visible = false;
            ChangePasswordPanel.Visible = false;
            ChangeFreePanel.Visible = false;
            ChangeFreePanel.Visible = false;
            YaEsPremiumPanel.Visible = false;
            ModCorrPanel.Visible = false;
        }

        private void BackToUserMenuButton_Click(object sender, EventArgs e)
        {
            stackPanels.Add(panels["UserPanel"]);
            ShowLastPanel();
        }

        private void AceptarCambioNombreUsuarioButton_Click(object sender, EventArgs e)
        {
            string oldUser = ReadUserName.Text;
            string newUser = NuevoNombreUsuarioTextBox.Text;
            List<string> UserValues = Files.GetData(oldUser);
            UserValues[0] = newUser;
            foreach (User usuario in Files.Users)
            {
                if (usuario.UserName == oldUser)
                {
                    usuario.UserName = newUser;
                }
            }
            ReadUserName.Text = newUser;
            ChangeUserPanel.Visible = false;
            ModCorrPanel.Visible = true;
        }

        private void CambiarUsuarioButton_Click(object sender, EventArgs e)
        {
            ChangePasswordPanel.Visible = false;
            ChangeFreePanel.Visible = false;
            YaEsPremiumPanel.Visible = false;
            ModCorrPanel.Visible = false;
            NuevoNombreUsuarioTextBox.ResetText();
            ChangeUserPanel.Visible = true;
        }

        private void CambiarContraseñaButton_Click(object sender, EventArgs e)
        {
            ChangeUserPanel.Visible = false;
            ChangeFreePanel.Visible = false;
            YaEsPremiumPanel.Visible = false;
            ModCorrPanel.Visible = false;
            CheckOldPassword.ResetText();
            InputNewPassword.ResetText();
            InputOldPassword.ResetText();
            ChangePasswordPanel.Visible = true;
        }

        private void AceptarNuevaContraseñaButton_Click(object sender, EventArgs e)
        {
            string oldUser = ReadUserName.Text;
            string oldPass = InputOldPassword.Text;
            string newPass = InputNewPassword.Text;
            List<string> UserValues = Files.GetData(oldUser);
            foreach (User usuario in Files.Users)
            {
                if (usuario.UserName == oldUser)
                {
                    if (oldPass == usuario.Password)
                    {
                        usuario.Password = newPass;
                        UserValues[2] = newPass;
                        ChangePasswordPanel.Visible = false;
                        ModCorrPanel.Visible = true;
                    }
                    else
                    {
                        CheckOldPassword.Text = "Contraseña Actual Incorrecta";
                    }
                }
            }
        }

        private void ChangeFreePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AceptarCambioCuentaButton_Click(object sender, EventArgs e)
        {
            if (PrivacidadFreeNuevaComboBox.Text == "")
            {
                CheckPrivacyInformation.Text = "Seleccione Privacidad";
            }
            else
            {
                string oldUser = ReadUserName.Text;
                string privacy = PrivacidadFreeNuevaComboBox.Text;
                List<string> UserValues = Files.GetData(oldUser);
                foreach (User usuario in Files.Users)
                {
                    if (usuario.UserName == oldUser)
                    {
                       if (privacy == "Público")
                       {
                            UserValues[4] = "PremiumT";
                            usuario.Type = "Premium";
                            usuario.Privacy1 = true;
                            ChangeFreePanel.Visible = false;

                       }
                       else if (privacy == "Privado")
                       {
                            UserValues[4] = "PremiumF";
                            usuario.Type = "Premium";
                            usuario.Privacy1 = false;
                            ChangeFreePanel.Visible = false;
                       }
                       ModCorrPanel.Visible = true;
                    }
                }
            }
        }

        private void CambioTipoCuentaButton_Click(object sender, EventArgs e)
        {
            YaEsPremiumPanel.Visible = false;
            ChangeUserPanel.Visible = false;
            ChangePasswordPanel.Visible = false;
            ModCorrPanel.Visible = false;
            PrivacidadFreeNuevaComboBox.SelectedIndex = -1;
            CheckPrivacyInformation.ResetText();
            string oldUser = ReadUserName.Text;
            List<string> UserValues = Files.GetData(oldUser);
            if (UserValues[4].Contains("Premium"))
            {
                YaEsPremiumPanel.Visible = true;
            }
            else
            { 
                ChangeFreePanel.Visible = true;
            }
        }

        private void VolverButtonLoginView_Click(object sender, EventArgs e)
        {
            stackPanels.Add(panels["WelcomePanel"]);
            InputContraseñaLoginView.ResetText();
            InputUsuarioLoginView.ResetText();
            loginViewInvalidCredentialsAlert.ResetText();
            ShowLastPanel();
        }

    }
}
