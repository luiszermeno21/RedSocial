using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Usuario
    {
        public int id { get; set; }
        public string correo { get; set; }
        public string contraseña { get; set; }
    }
}
