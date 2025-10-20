namespace Estacion_climatica
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
            this.comboBoxSensores = new System.Windows.Forms.ComboBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.lblTemperatura = new System.Windows.Forms.Label();
            this.lblSensacion = new System.Windows.Forms.Label();
            this.lblHumedad = new System.Windows.Forms.Label();
            this.lblProbLluvia = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.picIconoClima = new System.Windows.Forms.PictureBox();
            this.lblViento = new System.Windows.Forms.Label();
            this.lblLluvia = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPM25 = new System.Windows.Forms.Label();
            this.lblCO2 = new System.Windows.Forms.Label();
            this.lblCalidadGeneral = new System.Windows.Forms.Label();
            this.lblPresion = new System.Windows.Forms.Label();
            this.lblIndiceUV = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picIconoClima)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxSensores
            // 
            this.comboBoxSensores.FormattingEnabled = true;
            this.comboBoxSensores.Location = new System.Drawing.Point(12, 415);
            this.comboBoxSensores.Name = "comboBoxSensores";
            this.comboBoxSensores.Size = new System.Drawing.Size(224, 24);
            this.comboBoxSensores.TabIndex = 0;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(599, 415);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(179, 23);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar Clima";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // lblTemperatura
            // 
            this.lblTemperatura.AutoSize = true;
            this.lblTemperatura.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemperatura.Location = new System.Drawing.Point(12, 54);
            this.lblTemperatura.Name = "lblTemperatura";
            this.lblTemperatura.Size = new System.Drawing.Size(205, 81);
            this.lblTemperatura.TabIndex = 4;
            this.lblTemperatura.Text = "label1";
            // 
            // lblSensacion
            // 
            this.lblSensacion.AutoSize = true;
            this.lblSensacion.Location = new System.Drawing.Point(23, 135);
            this.lblSensacion.Name = "lblSensacion";
            this.lblSensacion.Size = new System.Drawing.Size(44, 16);
            this.lblSensacion.TabIndex = 5;
            this.lblSensacion.Text = "label2";
            // 
            // lblHumedad
            // 
            this.lblHumedad.AutoSize = true;
            this.lblHumedad.Location = new System.Drawing.Point(23, 178);
            this.lblHumedad.Name = "lblHumedad";
            this.lblHumedad.Size = new System.Drawing.Size(44, 16);
            this.lblHumedad.TabIndex = 6;
            this.lblHumedad.Text = "label3";
            // 
            // lblProbLluvia
            // 
            this.lblProbLluvia.AutoSize = true;
            this.lblProbLluvia.Location = new System.Drawing.Point(23, 217);
            this.lblProbLluvia.Name = "lblProbLluvia";
            this.lblProbLluvia.Size = new System.Drawing.Size(44, 16);
            this.lblProbLluvia.TabIndex = 7;
            this.lblProbLluvia.Text = "label4";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(268, 285);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(44, 16);
            this.lblDescripcion.TabIndex = 8;
            this.lblDescripcion.Text = "label5";
            // 
            // picIconoClima
            // 
            this.picIconoClima.Location = new System.Drawing.Point(262, 54);
            this.picIconoClima.Name = "picIconoClima";
            this.picIconoClima.Size = new System.Drawing.Size(190, 206);
            this.picIconoClima.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconoClima.TabIndex = 9;
            this.picIconoClima.TabStop = false;
            // 
            // lblViento
            // 
            this.lblViento.AutoSize = true;
            this.lblViento.Location = new System.Drawing.Point(26, 316);
            this.lblViento.Name = "lblViento";
            this.lblViento.Size = new System.Drawing.Size(44, 16);
            this.lblViento.TabIndex = 10;
            this.lblViento.Text = "label1";
            // 
            // lblLluvia
            // 
            this.lblLluvia.AutoSize = true;
            this.lblLluvia.Location = new System.Drawing.Point(26, 348);
            this.lblLluvia.Name = "lblLluvia";
            this.lblLluvia.Size = new System.Drawing.Size(44, 16);
            this.lblLluvia.TabIndex = 11;
            this.lblLluvia.Text = "label2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCalidadGeneral);
            this.groupBox1.Controls.Add(this.lblCO2);
            this.groupBox1.Controls.Add(this.lblPM25);
            this.groupBox1.Location = new System.Drawing.Point(486, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 188);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // lblPM25
            // 
            this.lblPM25.AutoSize = true;
            this.lblPM25.Location = new System.Drawing.Point(7, 22);
            this.lblPM25.Name = "lblPM25";
            this.lblPM25.Size = new System.Drawing.Size(44, 16);
            this.lblPM25.TabIndex = 0;
            this.lblPM25.Text = "label1";
            // 
            // lblCO2
            // 
            this.lblCO2.AutoSize = true;
            this.lblCO2.Location = new System.Drawing.Point(7, 52);
            this.lblCO2.Name = "lblCO2";
            this.lblCO2.Size = new System.Drawing.Size(44, 16);
            this.lblCO2.TabIndex = 1;
            this.lblCO2.Text = "label2";
            // 
            // lblCalidadGeneral
            // 
            this.lblCalidadGeneral.AutoSize = true;
            this.lblCalidadGeneral.Location = new System.Drawing.Point(7, 77);
            this.lblCalidadGeneral.Name = "lblCalidadGeneral";
            this.lblCalidadGeneral.Size = new System.Drawing.Size(44, 16);
            this.lblCalidadGeneral.TabIndex = 2;
            this.lblCalidadGeneral.Text = "label3";
            // 
            // lblPresion
            // 
            this.lblPresion.AutoSize = true;
            this.lblPresion.Location = new System.Drawing.Point(493, 263);
            this.lblPresion.Name = "lblPresion";
            this.lblPresion.Size = new System.Drawing.Size(44, 16);
            this.lblPresion.TabIndex = 13;
            this.lblPresion.Text = "label1";
            // 
            // lblIndiceUV
            // 
            this.lblIndiceUV.AutoSize = true;
            this.lblIndiceUV.Location = new System.Drawing.Point(493, 285);
            this.lblIndiceUV.Name = "lblIndiceUV";
            this.lblIndiceUV.Size = new System.Drawing.Size(44, 16);
            this.lblIndiceUV.TabIndex = 14;
            this.lblIndiceUV.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblIndiceUV);
            this.Controls.Add(this.lblPresion);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblLluvia);
            this.Controls.Add(this.lblViento);
            this.Controls.Add(this.picIconoClima);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblProbLluvia);
            this.Controls.Add(this.lblHumedad);
            this.Controls.Add(this.lblSensacion);
            this.Controls.Add(this.lblTemperatura);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.comboBoxSensores);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picIconoClima)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSensores;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label lblTemperatura;
        private System.Windows.Forms.Label lblSensacion;
        private System.Windows.Forms.Label lblHumedad;
        private System.Windows.Forms.Label lblProbLluvia;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.PictureBox picIconoClima;
        private System.Windows.Forms.Label lblViento;
        private System.Windows.Forms.Label lblLluvia;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCalidadGeneral;
        private System.Windows.Forms.Label lblCO2;
        private System.Windows.Forms.Label lblPM25;
        private System.Windows.Forms.Label lblPresion;
        private System.Windows.Forms.Label lblIndiceUV;
    }
}

