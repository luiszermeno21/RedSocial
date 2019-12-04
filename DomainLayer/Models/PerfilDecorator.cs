using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public abstract class PerfilDecorator
    {
        protected string descripcion = "Perfil no especificado";
        public virtual string Descripcion()
        {
            return descripcion;
        }
    }
}
