namespace Proyecto_equipo_13_entrega_3
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.PongPanel = new System.Windows.Forms.Panel();
            this.BarraPong = new System.Windows.Forms.PictureBox();
            this.BolaPong = new System.Windows.Forms.PictureBox();
            this.BarraPong2 = new System.Windows.Forms.PictureBox();
            this.BarraPong3 = new System.Windows.Forms.PictureBox();
            this.BarraPong4 = new System.Windows.Forms.PictureBox();
            this.GamePanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1001 = new System.Windows.Forms.TableLayoutPanel();
            this.SnakeButton = new System.Windows.Forms.Button();
            this.PongButton = new System.Windows.Forms.Button();
            this.labelgamespanel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.VolverToProgramButton = new System.Windows.Forms.Button();
            this.SnakePanel = new System.Windows.Forms.Panel();
            this.VolverGamePanel = new System.Windows.Forms.Button();
            this.lblPuntos = new System.Windows.Forms.Label();
            this.IniciarSnakeGameButton = new System.Windows.Forms.Button();
            this.SnakePictureBox = new System.Windows.Forms.PictureBox();
            this.timer15 = new System.Windows.Forms.Timer(this.components);
            this.timerPong = new System.Windows.Forms.Timer(this.components);
            this.PongPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BarraPong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BolaPong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarraPong2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarraPong3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarraPong4)).BeginInit();
            this.GamePanel.SuspendLayout();
            this.tableLayoutPanel1001.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SnakePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SnakePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PongPanel
            // 
            this.PongPanel.Controls.Add(this.BarraPong);
            this.PongPanel.Controls.Add(this.BolaPong);
            this.PongPanel.Controls.Add(this.BarraPong2);
            this.PongPanel.Controls.Add(this.BarraPong3);
            this.PongPanel.Controls.Add(this.BarraPong4);
            this.PongPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PongPanel.Location = new System.Drawing.Point(0, 0);
            this.PongPanel.Name = "PongPanel";
            this.PongPanel.Size = new System.Drawing.Size(658, 634);
            this.PongPanel.TabIndex = 5;
            this.PongPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PongPanel_MouseMove);
            // 
            // BarraPong
            // 
            this.BarraPong.BackColor = System.Drawing.Color.Fuchsia;
            this.BarraPong.Location = new System.Drawing.Point(627, 433);
            this.BarraPong.Margin = new System.Windows.Forms.Padding(4);
            this.BarraPong.Name = "BarraPong";
            this.BarraPong.Size = new System.Drawing.Size(18, 91);
            this.BarraPong.TabIndex = 6;
            this.BarraPong.TabStop = false;
            // 
            // BolaPong
            // 
            this.BolaPong.BackColor = System.Drawing.Color.Transparent;
            this.BolaPong.Image = ((System.Drawing.Image)(resources.GetObject("BolaPong.Image")));
            this.BolaPong.Location = new System.Drawing.Point(22, 193);
            this.BolaPong.Margin = new System.Windows.Forms.Padding(4);
            this.BolaPong.Name = "BolaPong";
            this.BolaPong.Size = new System.Drawing.Size(70, 65);
            this.BolaPong.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BolaPong.TabIndex = 7;
            this.BolaPong.TabStop = false;
            // 
            // BarraPong2
            // 
            this.BarraPong2.BackColor = System.Drawing.Color.Transparent;
            this.BarraPong2.Location = new System.Drawing.Point(627, 328);
            this.BarraPong2.Margin = new System.Windows.Forms.Padding(4);
            this.BarraPong2.Name = "BarraPong2";
            this.BarraPong2.Size = new System.Drawing.Size(18, 91);
            this.BarraPong2.TabIndex = 8;
            this.BarraPong2.TabStop = false;
            // 
            // BarraPong3
            // 
            this.BarraPong3.BackColor = System.Drawing.Color.Transparent;
            this.BarraPong3.Location = new System.Drawing.Point(627, 214);
            this.BarraPong3.Margin = new System.Windows.Forms.Padding(4);
            this.BarraPong3.Name = "BarraPong3";
            this.BarraPong3.Size = new System.Drawing.Size(18, 91);
            this.BarraPong3.TabIndex = 9;
            this.BarraPong3.TabStop = false;
            // 
            // BarraPong4
            // 
            this.BarraPong4.BackColor = System.Drawing.Color.Transparent;
            this.BarraPong4.Location = new System.Drawing.Point(627, 103);
            this.BarraPong4.Margin = new System.Windows.Forms.Padding(4);
            this.BarraPong4.Name = "BarraPong4";
            this.BarraPong4.Size = new System.Drawing.Size(18, 91);
            this.BarraPong4.TabIndex = 10;
            this.BarraPong4.TabStop = false;
            // 
            // GamePanel
            // 
            this.GamePanel.Controls.Add(this.tableLayoutPanel1001);
            this.GamePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GamePanel.Location = new System.Drawing.Point(0, 0);
            this.GamePanel.Name = "GamePanel";
            this.GamePanel.Size = new System.Drawing.Size(658, 634);
            this.GamePanel.TabIndex = 6;
            // 
            // tableLayoutPanel1001
            // 
            this.tableLayoutPanel1001.ColumnCount = 5;
            this.tableLayoutPanel1001.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1001.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1001.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1001.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1001.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1001.Controls.Add(this.SnakeButton, 1, 1);
            this.tableLayoutPanel1001.Controls.Add(this.PongButton, 3, 1);
            this.tableLayoutPanel1001.Controls.Add(this.labelgamespanel, 2, 0);
            this.tableLayoutPanel1001.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel1001.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1001.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1001.Name = "tableLayoutPanel1001";
            this.tableLayoutPanel1001.RowCount = 3;
            this.tableLayoutPanel1001.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1001.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1001.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1001.Size = new System.Drawing.Size(658, 634);
            this.tableLayoutPanel1001.TabIndex = 0;
            // 
            // SnakeButton
            // 
            this.SnakeButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SnakeButton.Location = new System.Drawing.Point(134, 214);
            this.SnakeButton.Name = "SnakeButton";
            this.SnakeButton.Size = new System.Drawing.Size(125, 205);
            this.SnakeButton.TabIndex = 1;
            this.SnakeButton.Text = "Snake";
            this.SnakeButton.UseVisualStyleBackColor = true;
            this.SnakeButton.Click += new System.EventHandler(this.SnakeButton_Click);
            // 
            // PongButton
            // 
            this.PongButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PongButton.Location = new System.Drawing.Point(396, 214);
            this.PongButton.Name = "PongButton";
            this.PongButton.Size = new System.Drawing.Size(125, 205);
            this.PongButton.TabIndex = 2;
            this.PongButton.Text = "Pong";
            this.PongButton.UseVisualStyleBackColor = true;
            this.PongButton.Click += new System.EventHandler(this.PongButton_Click);
            // 
            // labelgamespanel
            // 
            this.labelgamespanel.AutoSize = true;
            this.labelgamespanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelgamespanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelgamespanel.Location = new System.Drawing.Point(265, 0);
            this.labelgamespanel.Name = "labelgamespanel";
            this.labelgamespanel.Size = new System.Drawing.Size(125, 211);
            this.labelgamespanel.TabIndex = 3;
            this.labelgamespanel.Text = "Games Panel";
            this.labelgamespanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.VolverToProgramButton, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.14634F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.85366F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(125, 205);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // VolverToProgramButton
            // 
            this.VolverToProgramButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VolverToProgramButton.Location = new System.Drawing.Point(3, 3);
            this.VolverToProgramButton.Name = "VolverToProgramButton";
            this.VolverToProgramButton.Size = new System.Drawing.Size(119, 63);
            this.VolverToProgramButton.TabIndex = 0;
            this.VolverToProgramButton.Text = "Volver";
            this.VolverToProgramButton.UseVisualStyleBackColor = true;
            this.VolverToProgramButton.Click += new System.EventHandler(this.VolverToProgramButton_Click);
            // 
            // SnakePanel
            // 
            this.SnakePanel.Controls.Add(this.VolverGamePanel);
            this.SnakePanel.Controls.Add(this.lblPuntos);
            this.SnakePanel.Controls.Add(this.IniciarSnakeGameButton);
            this.SnakePanel.Controls.Add(this.SnakePictureBox);
            this.SnakePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SnakePanel.Location = new System.Drawing.Point(0, 0);
            this.SnakePanel.Name = "SnakePanel";
            this.SnakePanel.Size = new System.Drawing.Size(658, 634);
            this.SnakePanel.TabIndex = 7;
            // 
            // VolverGamePanel
            // 
            this.VolverGamePanel.Location = new System.Drawing.Point(22, 575);
            this.VolverGamePanel.Name = "VolverGamePanel";
            this.VolverGamePanel.Size = new System.Drawing.Size(155, 47);
            this.VolverGamePanel.TabIndex = 3;
            this.VolverGamePanel.Text = "Volver";
            this.VolverGamePanel.UseVisualStyleBackColor = true;
            this.VolverGamePanel.Click += new System.EventHandler(this.VolverGamePanel_Click);
            // 
            // lblPuntos
            // 
            this.lblPuntos.AutoSize = true;
            this.lblPuntos.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPuntos.Location = new System.Drawing.Point(307, 578);
            this.lblPuntos.Name = "lblPuntos";
            this.lblPuntos.Size = new System.Drawing.Size(31, 32);
            this.lblPuntos.TabIndex = 2;
            this.lblPuntos.Text = "0";
            // 
            // IniciarSnakeGameButton
            // 
            this.IniciarSnakeGameButton.Location = new System.Drawing.Point(467, 576);
            this.IniciarSnakeGameButton.Name = "IniciarSnakeGameButton";
            this.IniciarSnakeGameButton.Size = new System.Drawing.Size(155, 47);
            this.IniciarSnakeGameButton.TabIndex = 0;
            this.IniciarSnakeGameButton.Text = "Iniciar";
            this.IniciarSnakeGameButton.UseVisualStyleBackColor = true;
            this.IniciarSnakeGameButton.Click += new System.EventHandler(this.IniciarSnakeGameButton_Click);
            // 
            // SnakePictureBox
            // 
            this.SnakePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SnakePictureBox.Location = new System.Drawing.Point(22, 12);
            this.SnakePictureBox.MinimumSize = new System.Drawing.Size(300, 300);
            this.SnakePictureBox.Name = "SnakePictureBox";
            this.SnakePictureBox.Size = new System.Drawing.Size(600, 558);
            this.SnakePictureBox.TabIndex = 1;
            this.SnakePictureBox.TabStop = false;
            // 
            // timer15
            // 
            this.timer15.Interval = 50;
            this.timer15.Tick += new System.EventHandler(this.timer15_Tick);
            // 
            // timerPong
            // 
            this.timerPong.Interval = 10;
            this.timerPong.Tick += new System.EventHandler(this.timerPong_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 634);
            this.Controls.Add(this.GamePanel);
            this.Controls.Add(this.SnakePanel);
            this.Controls.Add(this.PongPanel);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.PongPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BarraPong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BolaPong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarraPong2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarraPong3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarraPong4)).EndInit();
            this.GamePanel.ResumeLayout(false);
            this.tableLayoutPanel1001.ResumeLayout(false);
            this.tableLayoutPanel1001.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.SnakePanel.ResumeLayout(false);
            this.SnakePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SnakePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PongPanel;
        private System.Windows.Forms.PictureBox BarraPong;
        private System.Windows.Forms.PictureBox BolaPong;
        private System.Windows.Forms.PictureBox BarraPong2;
        private System.Windows.Forms.PictureBox BarraPong3;
        private System.Windows.Forms.PictureBox BarraPong4;
        private System.Windows.Forms.Panel GamePanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1001;
        private System.Windows.Forms.Button SnakeButton;
        private System.Windows.Forms.Button PongButton;
        private System.Windows.Forms.Label labelgamespanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button VolverToProgramButton;
        private System.Windows.Forms.Panel SnakePanel;
        private System.Windows.Forms.Button VolverGamePanel;
        private System.Windows.Forms.Label lblPuntos;
        private System.Windows.Forms.Button IniciarSnakeGameButton;
        private System.Windows.Forms.PictureBox SnakePictureBox;
        private System.Windows.Forms.Timer timer15;
        private System.Windows.Forms.Timer timerPong;
    }
}