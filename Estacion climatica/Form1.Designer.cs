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
            this.btnLecturasSensor = new System.Windows.Forms.Button();
            this.btnObtenerLecturas = new System.Windows.Forms.Button();
            this.dataGridViewLecturas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLecturas)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxSensores
            // 
            this.comboBoxSensores.FormattingEnabled = true;
            this.comboBoxSensores.Location = new System.Drawing.Point(256, 22);
            this.comboBoxSensores.Name = "comboBoxSensores";
            this.comboBoxSensores.Size = new System.Drawing.Size(224, 24);
            this.comboBoxSensores.TabIndex = 0;
            // 
            // btnLecturasSensor
            // 
            this.btnLecturasSensor.Location = new System.Drawing.Point(599, 415);
            this.btnLecturasSensor.Name = "btnLecturasSensor";
            this.btnLecturasSensor.Size = new System.Drawing.Size(179, 23);
            this.btnLecturasSensor.TabIndex = 1;
            this.btnLecturasSensor.Text = "button1";
            this.btnLecturasSensor.UseVisualStyleBackColor = true;
            // 
            // btnObtenerLecturas
            // 
            this.btnObtenerLecturas.Location = new System.Drawing.Point(12, 409);
            this.btnObtenerLecturas.Name = "btnObtenerLecturas";
            this.btnObtenerLecturas.Size = new System.Drawing.Size(136, 34);
            this.btnObtenerLecturas.TabIndex = 2;
            this.btnObtenerLecturas.Text = "button2";
            this.btnObtenerLecturas.UseVisualStyleBackColor = true;
            this.btnObtenerLecturas.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridViewLecturas
            // 
            this.dataGridViewLecturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLecturas.Location = new System.Drawing.Point(12, 52);
            this.dataGridViewLecturas.Name = "dataGridViewLecturas";
            this.dataGridViewLecturas.RowHeadersWidth = 51;
            this.dataGridViewLecturas.RowTemplate.Height = 24;
            this.dataGridViewLecturas.Size = new System.Drawing.Size(776, 310);
            this.dataGridViewLecturas.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewLecturas);
            this.Controls.Add(this.btnObtenerLecturas);
            this.Controls.Add(this.btnLecturasSensor);
            this.Controls.Add(this.comboBoxSensores);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLecturas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSensores;
        private System.Windows.Forms.Button btnLecturasSensor;
        private System.Windows.Forms.Button btnObtenerLecturas;
        private System.Windows.Forms.DataGridView dataGridViewLecturas;
    }
}

