using DataAccessLayer;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinnesLogicLayer.Services
{
    public class UsuarioService
    {
        private readonly UDSSingleton _dataService;

        public UsuarioService(string connectionString)
        {
            _dataService = UDSSingleton.GetInstance(connectionString);
        }

        public List<Usuario> GetUsuarios()
        {
            return _dataService.GetUsuarios();
        }

        public string AddUsuario(Usuario usuario)
        {
            try
            {
                return _dataService.AddUsuario(usuario) ? "User created successfully" : "Errror creating Usuario";
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }

        public string GetContraseña(string correo, string contraseña)
        {
            try
            {
                string aux = _dataService.GetContraseña(correo);
                if (aux == contraseña)
                    return "Bienvenido";
                else if (aux == "")
                    return "Usuario no registrado";
                else
                    return "Usuario o contraseña incorrecta";
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }

        public int GetUsuarioId(string correo)
        {
            try
            {
                int aux = _dataService.GetUsuarioId(correo);
                if (aux != 0)
                    return aux;
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        public string AddPerfil(Perfil perfil)
        {
            try
            {
                return _dataService.AddPerfil(perfil) ? "Profile created successfully" : "Errror creating Profile";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
