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
                string urlimagen = "C:\\temp\\uu.jpg";
                return _dataService.AddPerfil(perfil,urlimagen) ? "Profile created successfully" : "Errror creating Profile";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public Perfil GetPerfil(string correo)
        {
            try
            {
                int aux = _dataService.GetUsuarioId(correo);
                Perfil p = _dataService.GetPerfil(aux);
                return p;
            }
            catch
            {
                return null;
            }
        }

        public PerfilBuilder GetImagenPerfil(int idusuario)
        {
            try
            {
                PerfilBuilder ip = _dataService.GetImagenPerfil(idusuario);
                return ip;
            }
            catch
            {
                return null;
            }
        }

        public bool SetImagenPerfil(PerfilBuilder ip)
        {
            try
            {
                return _dataService.SetImagenPerfil(ip) ? true : false ;
            }
            catch
            {
                return false;
            }
        }

        public int GetSeguidores(int idusuario)
        {
            try
            {
                int aux = _dataService.GetSeguidores(idusuario);
                return aux;
            }
            catch
            {
                return 0;
            }
        }

        public int GetSiguiendo(int idusuario)
        {
            try
            {
                int aux = _dataService.GetSiguiendo(idusuario);
                return aux;
            }
            catch
            {
                return 0;
            }
        }

        public List<ImagenPropiaBuilder> GetImagenesPropias(int idusuario)
        {
            try
            {
                List<ImagenPropiaBuilder> aux = _dataService.GetImagenesPropias(idusuario);
                return aux;
            }
            catch
            {
                return null;
            }
        }

        public List<ImagenSeguidorBuilder> GetImagenesSiguiendo(int idusuario)
        {
            try
            {
                List<ImagenSeguidorBuilder> aux = _dataService.GetImagenesSiguiendo(idusuario);
                return aux;
            }
            catch
            {
                return null;
            }
        }

        public Perfil GetPerfilConId(int idusuario)
        {
            try
            {
                Perfil p = _dataService.GetPerfil(idusuario);
                return p;
            }
            catch
            {
                return null;
            }
        }

        public bool MasMeGusta(int idimagen)
        {
            try
            {
                bool p = _dataService.MasMeGusta(idimagen);
                return p;
            }
            catch
            {
                return false;
            }
        }

        public bool MenosMeGusta(int idimagen)
        {
            try
            {
                bool p = _dataService.MenosMeGusta(idimagen);
                return p;
            }
            catch
            {
                return false;
            }
        }

        public int GetSigoATal(int idusuario, int idsigoatal)
        {
            try
            {
                int aux = _dataService.GetSigoATal(idusuario,idsigoatal);
                return aux;
            }
            catch
            {
                return 0;
            }
        }

        public bool SeguirPerfil(int idusuario, int idsigoatal)
        {
            try
            {
                return _dataService.SeguiPerfil(idusuario, idsigoatal) ? true : false;
            }
            catch
            {
                return false;
            }
        }

        public bool DejarDeSeguir(int idusuario, int idsigoatal)
        {
            try
            {
                return _dataService.DejarDeSeguir(idusuario, idsigoatal) ? true : false;
            }
            catch
            {
                return false;
            }
        }

        public List<Perfil> GetAllPerfiles(string cadena, int idusuario)
        {
            return _dataService.GetAllPerfiles(idusuario,cadena);
        }

        public bool DejarDeSeguir(string urlimagen, int idusuario)
        {
            try
            {
                return _dataService.AddHistoria(urlimagen,idusuario) ? true : false;
            }
            catch
            {
                return false;
            }
        }

        public List<Perfil> GetPerfilesSiguiendo(int idusuario)
        {
            return _dataService.GetPerfilesSiguiendo(idusuario);
        }

        public List<Historia> GetHistorias(int idusuario)
        {
            return _dataService.GetHistorias(idusuario);
        }

        public bool AddHistoria(Historia h)
        {
            try
            {
                return _dataService.AddHistoria(h) ? true : false;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteHistoria(Historia h)
        {
            try
            {
                return _dataService.DeleteHistoria(h) ? true : false;
            }
            catch
            {
                return false;
            }
        }

        public bool AddImagen(string urlimagen, int idusuario)
        {
            try
            {
                return _dataService.AddImagen(urlimagen,idusuario) ? true : false;
            }
            catch
            {
                return false;
            }
        }

        public List<Comentario> GetComentarios(int idimagen)
        {
            try
            {
                List<Comentario> aux = _dataService.GetComentarios(idimagen);
                return aux;
            }
            catch
            {
                return null;
            }
        }

        public bool AddComentario(Comentario comentario)
        {
            try
            {
                return _dataService.AddComentario(comentario) ? true : false;
            }
            catch
            {
                return false;
            }
        }
    }
}
