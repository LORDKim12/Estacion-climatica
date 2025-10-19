using Estacion_climatica.Models;
using Estacion_climatica.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacion_climatica.Controllers
{
    internal class EstacionController
    {
        private readonly ApiService _apiService;

        public EstacionController()
        {
            _apiService = new ApiService();
        }

        public async Task<List<Sensor>> ObtenerSensores()
        {
            return await _apiService.ObtenerSensoresAsync();
        }

        public async Task<List<Reading>> ObtenerLecturas()
        {
            var datos = await _apiService.ObtenerLecturasAsync(1);
            return datos.Data;
        }

        public async Task<List<Reading>> ObtenerLecturasDeSensor(string idSensor)
        {
            var datos = await _apiService.ObtenerLecturasPorSensorAsync(idSensor, 3);
            return datos.Data;
        }
    }
}
