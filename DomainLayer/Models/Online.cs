﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Online: EstadoUsuario
    {
        public string estado { get; set; }
        public string Accion()
        {
            estado = "Online";
            return estado;
        }
    }
}
