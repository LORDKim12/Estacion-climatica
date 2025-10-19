using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacion_climatica.Models
{
    internal class Sensor
    {
        public string Id { get; set; }
        public string Model { get; set; }
        public List<string> Measures { get; set; }
    }
}
