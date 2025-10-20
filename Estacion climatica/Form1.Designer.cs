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
            ((System.ComponentModel.ISupportInitialize)(this.picIconoClima)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxSensores
            // 
            this.comboBoxSensores.FormattingEnabled = true;
            this.comboBoxSensores.Location = new System.Drawing.Point(554, 24);
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
            // 
            // lblTemperatura
            // 
            this.lblTemperatura.AutoSize = true;
            this.lblTemperatura.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemperatura.Location = new System.Drawing.Point(40, 54);
            this.lblTemperatura.Name = "lblTemperatura";
            this.lblTemperatura.Size = new System.Drawing.Size(205, 81);
            this.lblTemperatura.TabIndex = 4;
            this.lblTemperatura.Text = "label1";
            // 
            // lblSensacion
            // 
            this.lblSensacion.AutoSize = true;
            this.lblSensacion.Location = new System.Drawing.Point(51, 144);
            this.lblSensacion.Name = "lblSensacion";
            this.lblSensacion.Size = new System.Drawing.Size(44, 16);
            this.lblSensacion.TabIndex = 5;
            this.lblSensacion.Text = "label2";
            // 
            // lblHumedad
            // 
            this.lblHumedad.AutoSize = true;
            this.lblHumedad.Location = new System.Drawing.Point(51, 187);
            this.lblHumedad.Name = "lblHumedad";
            this.lblHumedad.Size = new System.Drawing.Size(44, 16);
            this.lblHumedad.TabIndex = 6;
            this.lblHumedad.Text = "label3";
            // 
            // lblProbLluvia
            // 
            this.lblProbLluvia.AutoSize = true;
            this.lblProbLluvia.Location = new System.Drawing.Point(51, 226);
            this.lblProbLluvia.Name = "lblProbLluvia";
            this.lblProbLluvia.Size = new System.Drawing.Size(44, 16);
            this.lblProbLluvia.TabIndex = 7;
            this.lblProbLluvia.Text = "label4";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(51, 266);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(44, 16);
            this.lblDescripcion.TabIndex = 8;
            this.lblDescripcion.Text = "label5";
            // 
            // picIconoClima
            // 
            this.picIconoClima.Location = new System.Drawing.Point(251, 54);
            this.picIconoClima.Name = "picIconoClima";
            this.picIconoClima.Size = new System.Drawing.Size(225, 225);
            this.picIconoClima.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picIconoClima.TabIndex = 9;
            this.picIconoClima.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}

