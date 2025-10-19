using Estacion_climatica.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estacion_climatica
{
    

    public partial class Form1 : Form
    {
        private readonly EstacionController _controller;
        public Form1()
        {
            InitializeComponent();
            _controller = new EstacionController();
        }

        private  async void Form1_Load(object sender, EventArgs e)
        {
            dataGridViewLecturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewLecturas.ReadOnly = true;

            // Cargar sensores al iniciar
            var sensores = await _controller.ObtenerSensores();
            comboBoxSensores.DataSource = sensores;
            comboBoxSensores.DisplayMember = "Model";
            comboBoxSensores.ValueMember = "Id";
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        private async void btnObtenerLecturas_Click(object sender, EventArgs e)
        {
            var lecturas = await _controller.ObtenerLecturas();
            dataGridViewLecturas.DataSource = lecturas;
        }
        private async void btnLecturasSensor_Click(object sender, EventArgs e)
        {
            if (comboBoxSensores.SelectedValue != null)
            {
                string idSensor = comboBoxSensores.SelectedValue.ToString();
                var lecturas = await _controller.ObtenerLecturasDeSensor(idSensor);
                dataGridViewLecturas.DataSource = lecturas;
            }
        }

    }
}
