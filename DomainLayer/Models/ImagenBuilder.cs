using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public abstract class ImagenBuilder
    {
        public Imagen _imagen;
        public Imagen ObtenerImagen() { return _imagen; }

        public virtual void setIdImagen(int id)
        {
            
        }
        public virtual void setUrlImagen(string url)
        {

        }
        public virtual void setLikes(int l)
        {

        }

        public virtual void setFecha(DateTime f)
        {

        }

        public virtual void setIdUsuario(int id)
        {

        }

    }
}