using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class PerfilHombre:PerfilDecorator
    {
        public PerfilHombre(Perfil p)
        {
            descripcion = p.nombre + "\n\n" + p.genero;
        }
    }
}
