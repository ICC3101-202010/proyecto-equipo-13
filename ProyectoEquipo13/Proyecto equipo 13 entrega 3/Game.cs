using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_equipo_13_entrega_3
{
    public class Game
    {
        private int escala = 15;
        private int largoMap = 30;
        private int[,] cuadros;
        private List<Cuadro> Snake;

        public enum Direction { Right, Down, Left, Up }
        private Direction DireccionActual1 = Direction.Right;
        private Cuadro comida = null;
        private Random rdn = new Random();
        private int puntos = 0;

        public int Escala { get => escala; set => escala = value; }
        public int LargoMap { get => largoMap; set => largoMap = value; }
        public Direction DireccionActual { get => DireccionActual1; set => DireccionActual1 = value; }

        PictureBox picturebox;
        Label lblPuntos;

        private int PosInicialX
        {
            get
            {
                return LargoMap / 2;
            }
        }
        private int PosInicialY
        {
            get
            {
                return LargoMap / 2;
            }
        }

        public bool Perdi
        {
            get
            {
                foreach (Cuadro cuadro in Snake)
                {
                    if (Snake.Where(d => d.Y == cuadro.Y && d.X == cuadro.X && cuadro != d).Count() > 0)
                        return false;
                }
                return true;
            }
        }

        public Game(PictureBox picbox, Label lblPuntos)
        {
            this.picturebox = picbox;
            this.lblPuntos = lblPuntos;
            Reset();
        }

        public void Reset()
        {
            Snake = new List<Cuadro>();
            Cuadro cuadroInicial = new Cuadro(PosInicialX, PosInicialY);
            Snake.Add(cuadroInicial);
            cuadros = new int[LargoMap, LargoMap];
            for (int i = 0; i < largoMap; i++)
            {
                for (int j = 0; j < largoMap; j++)
                {
                    cuadros[j, i] = 0;
                }
            }
            puntos = 0;
        }

        public void Mostrar()
        {
            Bitmap bmp = new Bitmap(picturebox.Width, picturebox.Height);
            for (int i = 0; i < largoMap; i++)
            {
                for (int j = 0; j < largoMap; j++)
                {
                    if (Snake.Where(d => d.X == j && d.Y == i).Count() > 0)
                        PutPixel(bmp, j, i, Color.Black);
                    else
                        PutPixel(bmp, j, i, Color.White);
                }
            }
            //Comida
            if (comida != null)
            {
                PutPixel(bmp, comida.X, comida.Y, Color.Red);
            }

            picturebox.Image = bmp;

            lblPuntos.Text = puntos.ToString();
        }

        public void Next()
        {
            if (comida == null)
            {
                GetComida();
            }

            GetSnakeEntera();
            switch (DireccionActual)
            {
                case Direction.Right:
                    {
                        if (Snake[0].X == (largoMap - 1))
                            Snake[0].X = 0;
                        else
                            Snake[0].X++;
                        break;
                    }
                case Direction.Left:
                    {
                        if (Snake[0].X == 0)
                            Snake[0].X = largoMap - 1;
                        else
                            Snake[0].X--;
                        break;
                    }
                case Direction.Down:
                    {
                        if (Snake[0].Y == (largoMap - 1))
                            Snake[0].Y = 0;
                        else
                            Snake[0].Y++;
                        break;
                    }
                case Direction.Up:
                    {
                        if (Snake[0].Y == 0)
                            Snake[0].Y = largoMap - 1;
                        else
                            Snake[0].Y--;
                        break;
                    }
            }

            GetSiguientecuadro();

            Comido();
        }

        private void GetSiguientecuadro()
        {
            if (Snake.Count > 1)
            {
                for (int i = 1; i < Snake.Count; i++)
                {
                    Snake[i].X = Snake[i - 1].Xantiguo;
                    Snake[i].Y = Snake[i - 1].Yantiguo;
                }
            }
        }

        private void GetSnakeEntera()
        {
            foreach (Cuadro cuadro in Snake)
            {
                cuadro.Xantiguo = cuadro.X;
                cuadro.Yantiguo = cuadro.Y;
            }
        }

        private void Comido()
        {
            if (Snake[0].X == comida.X && Snake[0].Y == comida.Y)
            {
                comida = null;
                puntos += 1;

                //Agregamos Cola de Snake
                Cuadro ultimocuadro = Snake[Snake.Count - 1];
                Cuadro cuadro1 = new Cuadro(ultimocuadro.Xantiguo, ultimocuadro.Yantiguo);
                Snake.Add(cuadro1);
            }
        }

        private void PutPixel(Bitmap bmp, int x, int y, Color color)
        {
            for (int i = 0; i < Escala; i++)
                for (int j = 0; j < Escala; j++)
                    bmp.SetPixel(i + (x * Escala), j + (y * Escala), color);
        }

        private void GetComida()
        {
            int X = rdn.Next(0, LargoMap - 1);
            int Y = rdn.Next(0, LargoMap - 1);

            comida = new Cuadro(X, Y);
        }
    }

    public class Cuadro
    {
        private int x, y, xantiguo, yantiguo;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Xantiguo { get => xantiguo; set => xantiguo = value; }
        public int Yantiguo { get => yantiguo; set => yantiguo = value; }

        public Cuadro(int x1, int y1)
        {
            this.X = x1;
            this.Y = y1;
            this.Xantiguo = x;
            this.Yantiguo = y;
        }
    }
}
