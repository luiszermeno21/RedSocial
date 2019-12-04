using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Comentario
    {
        public int idcomentario { get; set; }
        public int idimagen { get; set; }
        public string texto { get; set; }
        public int idusuarioquecomento { get; set; }
    }
}
