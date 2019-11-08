using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Imagen
    {
        int idimagen { get; set; }
        string urlimagen { get; set; }
        int likes { get; set; }
        DateTime fecha { get; set; }
    }
}
