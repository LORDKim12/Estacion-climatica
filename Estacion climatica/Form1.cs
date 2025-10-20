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

            // === CORRECCIÓN 1: CONECTAR EL BOTÓN ===
            // Asignamos el evento Click del botón (asumo que se llama 'btnLecturasSensor' 
            // en el diseñador) al método 'btnActualizarClima_Click'.
            // Si tu botón se llama "btnActualizarClima", cambia 'btnLecturasSensor' por ese nombre.
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizarClima_Click);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            // Esto se mantiene igual para cargar el ComboBox
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

        // Este es el NUEVO método para actualizar la UI del clima
        private async void btnActualizarClima_Click(object sender, EventArgs e)
        {
            if (comboBoxSensores.SelectedValue != null)
            {
                try
                {
                    string idSensor = comboBoxSensores.SelectedValue.ToString();
                    var lecturas = await _controller.ObtenerLecturasDeSensor(idSensor);

                    if (lecturas != null && lecturas.Any())
                    {
                        // === CORRECCIÓN 2: BUSCAR "temp" ===
                        // Tu API usa "TEMP" para la temperatura
                        var tempReading = lecturas.Where(r => r.Variable.ToLower() == "temp")
                                                  .OrderByDescending(r => r.Timestamp)
                                                  .FirstOrDefault();

                        // === CORRECCIÓN 3: BUSCAR "rh" ===
                        // Tu API usa "RH" para la humedad
                        var humidityReading = lecturas.Where(r => r.Variable.ToLower() == "rh")
                                                      .OrderByDescending(r => r.Timestamp)
                                                      .FirstOrDefault();

                        // 3. Asignar valores a los Labels
                        if (tempReading != null)
                        {
                            lblTemperatura.Text = $"{tempReading.Value:F1}°{tempReading.Unit}"; // F1 = 1 decimal
                        }
                        else
                        {
                            lblTemperatura.Text = "--°C";
                        }

                        if (humidityReading != null)
                        {
                            // La API no incluye "%" en la unidad de RH, así que lo añadimos manualmente
                            lblHumedad.Text = $"Humedad: {humidityReading.Value:F0}%"; // F0 = 0 decimales
                        }
                        else
                        {
                            lblHumedad.Text = "Humedad: --%";
                        }

                        // 4. Calcular valores derivados
                        if (tempReading != null && humidityReading != null)
                        {
                            double sensacion = CalcularSensacionTermica(tempReading.Value, humidityReading.Value);
                            lblSensacion.Text = $"Sensación: {sensacion:F1}°C";
                        }
                        else
                        {
                            lblSensacion.Text = "Sensación: --°C";
                        }

                        // 5. Simular probabilidad de lluvia
                        lblProbLluvia.Text = $"Prob. Lluvia: {SimularProbLluvia(humidityReading?.Value)}%";

                        // 6. Actualizar icono
                        ActualizarIconoClima(tempReading?.Value, humidityReading?.Value);
                    }
                    else
                    {
                        MessageBox.Show("No se recibieron datos para este sensor.");
                    }
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

        // --- MÉTODOS DE AYUDA (Estos están bien) ---

        private double CalcularSensacionTermica(double temperatura, double humedad)
        {
            if (temperatura < 20)
            {
                return temperatura;
            }

            double c1 = -8.78469475556;
            double c2 = 1.61139411;
            double c3 = 2.33854883889;
            double c4 = -0.14611605;
            double c5 = -0.012308094;
            double c6 = -0.0164248277778;
            double c7 = 0.002211732;
            double c8 = 0.00072546;
            double c9 = -0.000003582;

            double T = temperatura;
            double R = humedad;

            double sensacion = c1 + (c2 * T) + (c3 * R) + (c4 * T * R) + (c5 * T * T) + (c6 * R * R) + (c7 * T * T * R) + (c8 * T * R * R) + (c9 * T * T * R * R);

            return sensacion;
        }

        private string SimularProbLluvia(double? humedad)
        {
            if (humedad == null) return "--";
            if (humedad > 90) return "90";
            if (humedad > 80) return "75";
            if (humedad > 70) return "40";
            if (humedad > 60) return "10";
            return "0";
        }

        private void ActualizarIconoClima(double? temp, double? humedad)
        {
            if (temp == null || humedad == null)
            {
                // Si tienes un icono "desconocido", ponlo aquí
                // picIconoClima.Image = Properties.Resources.desconocido; 
                lblDescripcion.Text = "Datos no disponibles";
                return;
            }

            // Asumiendo que tienes imágenes llamadas 'lluvia', 'nube', 'sol', 'nublado'
            // en tus Recursos (Properties/Resources.resx)
            if (humedad > 85 && temp > 10)
            {
                picIconoClima.Image = Properties.Resources.lluvia;
                lblDescripcion.Text = "Lluvioso";
            }
            else if (humedad > 70)
            {
                picIconoClima.Image = Properties.Resources.nube;
                lblDescripcion.Text = "Muy Nublado";
            }
            else if (temp > 28)
            {
                picIconoClima.Image = Properties.Resources.sol;
                lblDescripcion.Text = "Caluroso";
            }
            else
            {
                picIconoClima.Image = Properties.Resources.nublado;
                lblDescripcion.Text = "Parcialmente Nublado";
            }
        }
    }
}