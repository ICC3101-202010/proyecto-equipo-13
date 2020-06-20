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
    public partial class Form1 : Form
    {
        Game game;
        int velocidad = 5;
        int cont = 0;
        int puntaje = 0;
        bool Arriba;
        bool Izquierda;

        public Form1()
        {
            InitializeComponent();
            GamePanel.Visible = true;
            SnakePanel.Visible = false;
            PongPanel.Visible = false;
        }

        private void Start_Pong(object sender, EventArgs e)
        {
            this.Text = "Puntaje: 0";
            Random aleatorio = new Random();
            BolaPong.Location = new Point(0, aleatorio.Next(this.Height));
            Arriba = true;
            Izquierda = true;
            timerPong.Enabled = true;
            puntaje = 0;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.NumPad8 || e.KeyCode == Keys.W || Keys.Up == e.KeyData)
            {
                if (game != null)
                    game.DireccionActual = Game.Direction.Up;
            }
            if (e.KeyCode == Keys.NumPad2 || e.KeyCode == Keys.S)
            {
                if (game != null)
                    game.DireccionActual = Game.Direction.Down;
            }
            if (e.KeyCode == Keys.NumPad6 || e.KeyCode == Keys.D)
            {
                if (game != null)
                    game.DireccionActual = Game.Direction.Right;
            }
            if (e.KeyCode == Keys.NumPad4 || e.KeyCode == Keys.A)
            {
                if (game != null)
                    game.DireccionActual = Game.Direction.Left;
            }
            if (e.KeyCode == Keys.Escape)
            {
                GamePanel.Visible = true;
                PongPanel.Visible = false;
                SnakePanel.Visible = false;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Left:
                    if (game != null)
                        game.DireccionActual = Game.Direction.Left;
                    return true;
                case Keys.Right:
                    if (game != null)
                        game.DireccionActual = Game.Direction.Right;
                    return true;
                case Keys.Up:
                    if (game != null)
                        game.DireccionActual = Game.Direction.Up;
                    return true;
                case Keys.Down:
                    if (game != null)
                        game.DireccionActual = Game.Direction.Down;
                    return true;
                case Keys.Enter:
                    Start_Pong(new object(), new EventArgs());
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void PongPanel_MouseMove(object sender, MouseEventArgs e)
        {
            BarraPong.Top = e.Y;
            BarraPong2.Top = e.Y;
            BarraPong3.Top = e.Y;
            BarraPong4.Top = e.Y;
        }

        private void IniciarSnakeGameButton_Click(object sender, EventArgs e)
        {
            game = new Game(SnakePictureBox, lblPuntos);
            timer15.Enabled = true;
        }

        private void timer15_Tick(object sender, EventArgs e)
        {
            if (game.Perdi)
            {
                game.Next();
                game.Mostrar();
            }
            else
            {
                timer15.Enabled = false;
                MessageBox.Show("¡Haz Perdido! Tuviste una puntación de: " + lblPuntos.Text.ToString());
            }
        }

        private void SnakeButton_Click(object sender, EventArgs e)
        {
            GamePanel.Visible = false;
            PongPanel.Visible = false;
            SnakePanel.Visible = true;
        }

        private void VolverGamePanel_Click(object sender, EventArgs e)
        {
            GamePanel.Visible = true;
            SnakePanel.Visible = false;
            PongPanel.Visible = false;
        }

        private void PongButton_Click(object sender, EventArgs e)
        {
            GamePanel.Visible = false;
            SnakePanel.Visible = false;
            PongPanel.Visible = true;
            Start_Pong(sender, e);
        }

        private void timerPong_Tick(object sender, EventArgs e)
        {
            if (BolaPong.Left > BarraPong.Left || BolaPong.Left > BarraPong2.Left || BolaPong.Left > BarraPong3.Left || BolaPong.Left > BarraPong4.Left)
            {
                timerPong.Enabled = false;
                MessageBox.Show("Puntaje: " + puntaje.ToString());
                puntaje = 0;
                velocidad = 5;
                cont = 0;
            }

            if ((BolaPong.Left + BolaPong.Width >= BarraPong.Left &&
                BolaPong.Left + BolaPong.Width <= BarraPong.Left + BarraPong.Width &&
                BolaPong.Top + BolaPong.Height >= BarraPong.Top &&
                BolaPong.Top + BolaPong.Height <= BarraPong.Top + BarraPong.Height) ||
                (BolaPong.Left + BolaPong.Width >= BarraPong2.Left &&
                BolaPong.Left + BolaPong.Width <= BarraPong2.Left + BarraPong2.Width &&
                BolaPong.Top + BolaPong.Height >= BarraPong2.Top &&
                BolaPong.Top + BolaPong.Height <= BarraPong2.Top + BarraPong2.Height) ||
                (BolaPong.Left + BolaPong.Width >= BarraPong3.Left &&
                BolaPong.Left + BolaPong.Width <= BarraPong3.Left + BarraPong3.Width &&
                BolaPong.Top + BolaPong.Height >= BarraPong3.Top &&
                BolaPong.Top + BolaPong.Height <= BarraPong3.Top + BarraPong3.Height) ||
                (BolaPong.Left + BolaPong.Width >= BarraPong4.Left &&
                BolaPong.Left + BolaPong.Width <= BarraPong4.Left + BarraPong4.Width &&
                BolaPong.Top + BolaPong.Height >= BarraPong4.Top &&
                BolaPong.Top + BolaPong.Height <= BarraPong4.Top + BarraPong4.Height))
            {
                Izquierda = false;
                puntaje += 1;
                this.Text = "Puntaje: " + puntaje.ToString();
                cont += 1;
                if (cont > 5)
                {
                    velocidad += 1;
                    cont = 0;
                }
            }
            #region Movimiento Bola
            if (Izquierda)
            {
                BolaPong.Left += velocidad;
            }
            else
            {
                BolaPong.Left -= velocidad;
            }

            if (Arriba)
            {
                BolaPong.Top += velocidad;
            }
            else
            {
                BolaPong.Top -= velocidad;
            }

            if (BolaPong.Top >= this.Height - 80)
            {
                Arriba = false;
            }

            if (BolaPong.Top <= 0)
            {
                Arriba = true;
            }
            if (BolaPong.Left <= 0)
            {
                Izquierda = true;
            }
            //if (BolaPong.Left >= this.Width - 80)
            //{
            //    Izquierda = false;
            //}
            #endregion
        }

        private void VolverToProgramButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Hide();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner.Show();
            this.Hide();
        }
    }
}
