using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Historia
    {
        public int idhistoria { get; set; }
        public string urlimagen { get; set; }
        public DateTime fecha { get; set; }
        public int idusuario { get; set; }
    }
}
