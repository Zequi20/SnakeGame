namespace SnakeGame
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.score = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.Timer(this.components);
            this.lbl_pausa = new System.Windows.Forms.Label();
            this.lbl_over = new System.Windows.Forms.Label();
            this.dif = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.puntos = new System.Windows.Forms.Label();
            this.tJuego = new System.Windows.Forms.Timer(this.components);
            this.lblT = new System.Windows.Forms.Label();
            this.TimeShow = new System.Windows.Forms.Label();
            this.pMenu = new System.Windows.Forms.Label();
            this.pSalir = new System.Windows.Forms.Label();
            this.Help = new System.Windows.Forms.Label();
            this.screen = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.screen)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(250, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Puntaje:";
            // 
            // score
            // 
            this.score.AutoSize = true;
            this.score.Font = new System.Drawing.Font("PMingLiU-ExtB", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score.Location = new System.Drawing.Point(335, 3);
            this.score.Name = "score";
            this.score.Size = new System.Drawing.Size(17, 16);
            this.score.TabIndex = 2;
            this.score.Text = "0";
            // 
            // time
            // 
            this.time.Enabled = true;
            this.time.Interval = 80;
            this.time.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbl_pausa
            // 
            this.lbl_pausa.AutoSize = true;
            this.lbl_pausa.BackColor = System.Drawing.Color.Black;
            this.lbl_pausa.Font = new System.Drawing.Font("Papyrus", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pausa.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_pausa.Location = new System.Drawing.Point(434, 0);
            this.lbl_pausa.Name = "lbl_pausa";
            this.lbl_pausa.Size = new System.Drawing.Size(191, 38);
            this.lbl_pausa.TabIndex = 4;
            this.lbl_pausa.Text = "Juego pausado";
            this.lbl_pausa.Visible = false;
            // 
            // lbl_over
            // 
            this.lbl_over.AutoSize = true;
            this.lbl_over.BackColor = System.Drawing.Color.Black;
            this.lbl_over.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_over.Font = new System.Drawing.Font("Papyrus", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_over.ForeColor = System.Drawing.Color.LightYellow;
            this.lbl_over.Location = new System.Drawing.Point(217, 137);
            this.lbl_over.Name = "lbl_over";
            this.lbl_over.Size = new System.Drawing.Size(218, 55);
            this.lbl_over.TabIndex = 5;
            this.lbl_over.Text = "Game Over";
            this.lbl_over.Visible = false;
            this.lbl_over.Click += new System.EventHandler(this.lbl_over_Click);
            // 
            // dif
            // 
            this.dif.AutoSize = true;
            this.dif.Font = new System.Drawing.Font("Papyrus", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dif.Location = new System.Drawing.Point(592, 417);
            this.dif.Name = "dif";
            this.dif.Size = new System.Drawing.Size(18, 21);
            this.dif.TabIndex = 6;
            this.dif.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Papyrus", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(515, 419);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Dificultad:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // puntos
            // 
            this.puntos.AutoSize = true;
            this.puntos.BackColor = System.Drawing.Color.Black;
            this.puntos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.puntos.Font = new System.Drawing.Font("Papyrus", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.puntos.ForeColor = System.Drawing.Color.LightYellow;
            this.puntos.Location = new System.Drawing.Point(221, 192);
            this.puntos.Name = "puntos";
            this.puntos.Size = new System.Drawing.Size(83, 33);
            this.puntos.TabIndex = 8;
            this.puntos.Text = "Puntaje";
            this.puntos.Visible = false;
            this.puntos.Click += new System.EventHandler(this.puntos_Click);
            // 
            // tJuego
            // 
            this.tJuego.Interval = 950;
            this.tJuego.Tick += new System.EventHandler(this.tJuego_Tick);
            // 
            // lblT
            // 
            this.lblT.AutoSize = true;
            this.lblT.BackColor = System.Drawing.Color.Black;
            this.lblT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblT.Font = new System.Drawing.Font("Papyrus", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblT.ForeColor = System.Drawing.Color.LightYellow;
            this.lblT.Location = new System.Drawing.Point(221, 225);
            this.lblT.Name = "lblT";
            this.lblT.Size = new System.Drawing.Size(67, 25);
            this.lblT.TabIndex = 9;
            this.lblT.Text = "Tiempo";
            this.lblT.Visible = false;
            this.lblT.Click += new System.EventHandler(this.lblT_Click);
            // 
            // TimeShow
            // 
            this.TimeShow.AutoSize = true;
            this.TimeShow.Font = new System.Drawing.Font("Papyrus", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeShow.Location = new System.Drawing.Point(21, 418);
            this.TimeShow.Name = "TimeShow";
            this.TimeShow.Size = new System.Drawing.Size(63, 21);
            this.TimeShow.TabIndex = 10;
            this.TimeShow.Text = "Tiempo";
            this.TimeShow.Click += new System.EventHandler(this.TimeShow_Click);
            // 
            // pMenu
            // 
            this.pMenu.AutoSize = true;
            this.pMenu.BackColor = System.Drawing.Color.Black;
            this.pMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pMenu.Font = new System.Drawing.Font("Papyrus", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pMenu.ForeColor = System.Drawing.Color.LightYellow;
            this.pMenu.Location = new System.Drawing.Point(511, 149);
            this.pMenu.Name = "pMenu";
            this.pMenu.Size = new System.Drawing.Size(121, 38);
            this.pMenu.TabIndex = 11;
            this.pMenu.Text = "Ir al Menu";
            this.pMenu.Visible = false;
            this.pMenu.Click += new System.EventHandler(this.pMenu_Click);
            // 
            // pSalir
            // 
            this.pSalir.AutoSize = true;
            this.pSalir.BackColor = System.Drawing.Color.Black;
            this.pSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pSalir.Font = new System.Drawing.Font("Papyrus", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pSalir.ForeColor = System.Drawing.Color.LightYellow;
            this.pSalir.Location = new System.Drawing.Point(552, 217);
            this.pSalir.Name = "pSalir";
            this.pSalir.Size = new System.Drawing.Size(70, 38);
            this.pSalir.TabIndex = 12;
            this.pSalir.Text = "Salir";
            this.pSalir.Visible = false;
            this.pSalir.Click += new System.EventHandler(this.pSalir_Click);
            // 
            // Help
            // 
            this.Help.AutoSize = true;
            this.Help.BackColor = System.Drawing.Color.Black;
            this.Help.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Help.Font = new System.Drawing.Font("Papyrus", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Help.ForeColor = System.Drawing.Color.LightYellow;
            this.Help.Location = new System.Drawing.Point(532, 87);
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(90, 38);
            this.Help.TabIndex = 13;
            this.Help.Text = "Ayuda";
            this.Help.Visible = false;
            this.Help.Click += new System.EventHandler(this.label3_Click);
            // 
            // screen
            // 
            this.screen.BackColor = System.Drawing.Color.Black;
            this.screen.Cursor = System.Windows.Forms.Cursors.Default;
            this.screen.Location = new System.Drawing.Point(2, 25);
            this.screen.Name = "screen";
            this.screen.Size = new System.Drawing.Size(620, 390);
            this.screen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.screen.TabIndex = 0;
            this.screen.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Papyrus", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(-2, -1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 25);
            this.label3.TabIndex = 14;
            this.label3.Text = "Snake";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Help);
            this.Controls.Add(this.pSalir);
            this.Controls.Add(this.pMenu);
            this.Controls.Add(this.TimeShow);
            this.Controls.Add(this.lblT);
            this.Controls.Add(this.puntos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dif);
            this.Controls.Add(this.lbl_over);
            this.Controls.Add(this.lbl_pausa);
            this.Controls.Add(this.score);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.screen);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Snake";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.screen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox screen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label score;
        private System.Windows.Forms.Timer time;
        private System.Windows.Forms.Label lbl_pausa;
        private System.Windows.Forms.Label lbl_over;
        public System.Windows.Forms.Label dif;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label puntos;
        private System.Windows.Forms.Timer tJuego;
        private System.Windows.Forms.Label lblT;
        private System.Windows.Forms.Label TimeShow;
        private System.Windows.Forms.Label pMenu;
        private System.Windows.Forms.Label pSalir;
        private System.Windows.Forms.Label Help;
        private System.Windows.Forms.Label label3;
    }
}

