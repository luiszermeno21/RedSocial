using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Perfil
    {
        public int idusuario { get; set; }
        public string nombre { get; set; }
        public string nombreusuario { get; set; }
        public string genero { get; set; }

        public string setOnline()
        {
            return new Online().Accion();
            
        }
        public string setOfline()
        {
            return new Ofline().Accion();
        }

        public string Descripcion()
        {
            if (genero == "Hombre")
                return new PerfilHombre(this).Descripcion();
            else if (genero == "Mujer")
                return new PerfilMujer(this).Descripcion();
            
            return new PerfilIndefinido(this).Descripcion();
        }
    }
}
