using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class PerfilMujer:PerfilDecorator
    {
        public PerfilMujer(Perfil p)
        {
            descripcion = p.nombre + "\n\n" + p.genero;
        }
    }
}
