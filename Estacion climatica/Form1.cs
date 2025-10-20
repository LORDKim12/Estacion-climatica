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

                    // 1. OBTENEMOS LAS LECTURAS (AQUÍ SE CREA LA VARIABLE)
                    var lecturas = await _controller.ObtenerLecturasDeSensor(idSensor);

                    // 2. COMPROBAMOS QUE NO ESTÉN VACÍAS
                    if (lecturas != null && lecturas.Any())
                    {
                        // ===================================================================
                        // TODO EL CÓDIGO DEBE IR AQUÍ ADENTRO
                        // ===================================================================

                        // --- SECCIÓN 1: CLIMA BÁSICO (TEMP Y HUMEDAD) ---
                        var tempReading = lecturas.Where(r => r.Variable.ToLower() == "temp")
                                                  .OrderByDescending(r => r.Timestamp)
                                                  .FirstOrDefault();

                        var humidityReading = lecturas.Where(r => r.Variable.ToLower() == "rh")
                                                      .OrderByDescending(r => r.Timestamp)
                                                      .FirstOrDefault();

                        if (tempReading != null)
                        {
                            lblTemperatura.Text = $"{tempReading.Value:F1}°{tempReading.Unit}";
                        }
                        else { lblTemperatura.Text = "--°C"; }

                        if (humidityReading != null)
                        {
                            lblHumedad.Text = $"Humedad: {humidityReading.Value:F0}%";
                        }
                        else { lblHumedad.Text = "Humedad: --%"; }

                        // --- SECCIÓN 2: DATOS CALCULADOS (SENSACIÓN) ---
                        if (tempReading != null && humidityReading != null)
                        {
                            double sensacion = CalcularSensacionTermica(tempReading.Value, humidityReading.Value);
                            lblSensacion.Text = $"Sensación: {sensacion:F1}°C";
                        }
                        else { lblSensacion.Text = "Sensación: --°C"; }

                        // --- SECCIÓN 3: VIENTO Y LLUVIA (DATOS REALES DE LA API) ---
                        var windReading = lecturas.Where(r => r.Variable.ToLower() == "wind_speed")
                                                  .OrderByDescending(r => r.Timestamp)
                                                  .FirstOrDefault();

                        var rainReading = lecturas.Where(r => r.Variable.ToLower() == "rain")
                                                  .OrderByDescending(r => r.Timestamp)
                                                  .FirstOrDefault();

                        if (windReading != null)
                        {
                            lblViento.Text = $"Viento: {windReading.Value} {windReading.Unit}";
                        }
                        else { lblViento.Text = "Viento: --"; }

                        // Reemplazamos la simulación de lluvia por el dato real
                        if (rainReading != null && rainReading.Value > 0)
                        {
                            lblProbLluvia.Text = $"Precipitación: {rainReading.Value} {rainReading.Unit}";
                            // Actualizar icono si llueve
                            picIconoClima.Image = Properties.Resources.lluvia;
                            lblDescripcion.Text = "Lluvioso";
                        }
                        else
                        {
                            lblProbLluvia.Text = "Precipitación: 0 mm/h";
                            // Si no llueve, actualizamos el icono según el resto de datos
                            ActualizarIconoClima(tempReading?.Value, humidityReading?.Value);
                        }


                        // --- SECCIÓN 4: CALIDAD DE AIRE ---
                        var pm25Reading = lecturas.Where(r => r.Variable.ToLower() == "pm2.5")
                                                  .OrderByDescending(r => r.Timestamp)
                                                  .FirstOrDefault();

                        var co2Reading = lecturas.Where(r => r.Variable.ToLower() == "co2")
                                                 .OrderByDescending(r => r.Timestamp)
                                                 .FirstOrDefault();

                        if (pm25Reading != null)
                        {
                            lblPM25.Text = $"PM2.5: {pm25Reading.Value} {pm25Reading.Unit}";

                            if (pm25Reading.Value > 50)
                            {
                                lblCalidadGeneral.Text = "Calidad del Aire: Mala";
                                lblCalidadGeneral.ForeColor = Color.Red;
                            }
                            else if (pm25Reading.Value > 25)
                            {
                                lblCalidadGeneral.Text = "Calidad del Aire: Regular";
                                lblCalidadGeneral.ForeColor = Color.Orange;
                            }
                            else
                            {
                                lblCalidadGeneral.Text = "Calidad del Aire: Buena";
                                lblCalidadGeneral.ForeColor = Color.Green;
                            }
                        }
                        else
                        {
                            lblPM25.Text = "PM2.5: --";
                            lblCalidadGeneral.Text = "Calidad del Aire: --";
                            lblCalidadGeneral.ForeColor = Color.Black;
                        }

                        if (co2Reading != null)
                        {
                            lblCO2.Text = $"CO2: {co2Reading.Value} {co2Reading.Unit}";
                        }
                        else { lblCO2.Text = "CO2: --"; }


                        // --- SECCIÓN 5: DATOS ATMOSFÉRICOS (UV Y PRESIÓN) ---
                        var pressReading = lecturas.Where(r => r.Variable.ToLower() == "press")
                                                   .OrderByDescending(r => r.Timestamp)
                                                   .FirstOrDefault();

                        var uvReading = lecturas.Where(r => r.Variable.ToLower() == "uv")
                                                .OrderByDescending(r => r.Timestamp)
                                                .FirstOrDefault();

                        if (pressReading != null)
                        {
                            lblPresion.Text = $"Presión: {pressReading.Value:F0} {pressReading.Unit}";
                        }
                        else { lblPresion.Text = "Presión: --"; }

                        if (uvReading != null)
                        {
                            lblIndiceUV.Text = $"Índice UV: {uvReading.Value:F1}";
                        }
                        else { lblIndiceUV.Text = "Índice UV: --"; }

                        // ===================================================================
                        // FIN DEL CÓDIGO
                        // ===================================================================
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

        // (Recuerda que también necesitas el resto de métodos de ayuda:
        // CalcularSensacionTermica, SimularProbLluvia (que ya no se usa), y ActualizarIconoClima)

        // --- AJUSTE AL MÉTODO 'ActualizarIconoClima' ---
        // Lo modificamos para que no maneje la lluvia, ya que eso se hace arriba
        private void ActualizarIconoClima(double? temp, double? humedad)
        {
            if (temp == null || humedad == null)
            {
                lblDescripcion.Text = "Datos no disponibles";
                return;
            }

            // (La lógica de la lluvia ya no va aquí, se maneja en el botón)
            if (humedad > 70)
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

        

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }
    }
}