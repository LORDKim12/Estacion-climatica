using Estacion_climatica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Text.Json;
namespace Estacion_climatica.Services
{
    internal class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "http://localhost:8000"; // Cambia si tu API corre en otro puerto

        public ApiService()
        {
            _httpClient = new HttpClient();
        }

        // Obtener lista de sensores
        public async Task<List<Sensor>> ObtenerSensoresAsync()
        {
            var response = await _httpClient.GetStringAsync($"{_baseUrl}/sensors");
            var sensores = JsonSerializer.Deserialize<List<Sensor>>(response, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return sensores;
        }

        // Obtener lecturas de todos los sensores
        public async Task<SensorResponse> ObtenerLecturasAsync(int n = 1)
        {
            var response = await _httpClient.GetStringAsync($"{_baseUrl}/readings?n={n}");
            var datos = JsonSerializer.Deserialize<SensorResponse>(response, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return datos;
        }

        // Obtener lecturas de un sensor específico
        public async Task<SensorResponse> ObtenerLecturasPorSensorAsync(string sensorId, int n = 1)
        {
            var response = await _httpClient.GetStringAsync($"{_baseUrl}/reading/{sensorId}?n={n}");
            var datos = JsonSerializer.Deserialize<SensorResponse>(response, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return datos;
        }
    }
}
