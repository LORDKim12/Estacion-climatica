using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacion_climatica.Models
{
    internal class Reading
    {
        public string Sensor_Id { get; set; }
        public string Variable { get; set; }
        public double Value { get; set; }
        public string Unit { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
