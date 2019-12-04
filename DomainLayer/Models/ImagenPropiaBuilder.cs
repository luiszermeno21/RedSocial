using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class ImagenPropiaBuilder:ImagenBuilder
    {
        public ImagenPropiaBuilder()
        {
            _imagen = new Imagen
            {

            };
        }

        public override void setIdImagen(int id)
        {
            _imagen.idimagen = id;
        }
        public override void setUrlImagen(string url)
        {
            _imagen.urlimagen = url;
        }
        public override void setLikes(int l)
        {
            _imagen.likes = l;
        }

        public override void setFecha(DateTime f)
        {
            _imagen.fecha = f;
        }

        public override void setIdUsuario(int id)
        {
            _imagen.idusuario = id;
        }
    }
}
