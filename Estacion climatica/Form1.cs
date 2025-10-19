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

            // === CORRECCIÓN ===
            // Asignar los eventos a los botones correctos
            // Esto soluciona el problema de que los botones no estuvieran conectados
            this.btnObtenerLecturas.Click += new System.EventHandler(this.btnObtenerLecturas_Click);
            this.btnLecturasSensor.Click += new System.EventHandler(this.btnLecturasSensor_Click);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            dataGridViewLecturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewLecturas.ReadOnly = true;

            // Cargar sensores al iniciar
            try
            {
                var sensores = await _controller.ObtenerSensores();
                if (sensores != null && sensores.Any())
                {
                    comboBoxSensores.DataSource = sensores;
                    comboBoxSensores.DisplayMember = "Model";
                    comboBoxSensores.ValueMember = "Id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los sensores: {ex.Message}\n\nAsegúrate de que la API de Python esté corriendo en http://localhost:8000");
            }
        }

        // Este método estaba vacío en tu archivo original. 
        // El diseñador lo usaba, pero la lógica estaba en 'btnObtenerLecturas_Click'.
        // Ya no es necesario si asignamos el evento en el constructor.
        private void button2_Click(object sender, EventArgs e)
        {
            // Esta lógica ahora está en btnObtenerLecturas_Click, que es donde debe estar.
        }

        // Evento para el botón "Obtener Todas las Lecturas" (btnObtenerLecturas)
        private async void btnObtenerLecturas_Click(object sender, EventArgs e)
        {
            try
            {
                var lecturas = await _controller.ObtenerLecturas();
                dataGridViewLecturas.DataSource = lecturas;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener las lecturas: {ex.Message}");
            }
        }

        // Evento para el botón "Lecturas por Sensor" (btnLecturasSensor)
        private async void btnLecturasSensor_Click(object sender, EventArgs e)
        {
            if (comboBoxSensores.SelectedValue != null)
            {
                try
                {
                    string idSensor = comboBoxSensores.SelectedValue.ToString();
                    var lecturas = await _controller.ObtenerLecturasDeSensor(idSensor);
                    dataGridViewLecturas.DataSource = lecturas;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al obtener las lecturas del sensor: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un sensor.");
            }
        }
    }
}