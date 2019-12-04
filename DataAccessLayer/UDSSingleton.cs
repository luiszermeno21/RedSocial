using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DomainLayer.Models;

namespace DataAccessLayer
{
    public class UDSSingleton
    {
        private readonly SqlClient _client;
        private static UDSSingleton _instance;

        private UDSSingleton(string connectionString)
        {
            _client = new SqlClient(connectionString);
        }

        public static UDSSingleton GetInstance(string connectionString)
        {
            if (_instance == null)
            {
                _instance = new UDSSingleton(connectionString);
            }
            return _instance;
        }

        public List<Usuario> GetUsuarios()
        {
            var result = new List<Usuario>();
            try
            {
                if (_instance._client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Connection,
                        CommandText = "getusuarios",
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        var usuario = new Usuario
                        {
                            id = Convert.ToInt32(dataReader["idusuario"].ToString()),
                            correo = dataReader["correo"].ToString(),
                            contraseña = dataReader["contraseña"].ToString()
                        };
                        result.Add(usuario);
                    }
                }
            }
            catch
            {

            }
            finally
            {
                _instance._client.Close();
            }
            return result;
        }

        public bool AddUsuario(Usuario usuario)
        {
            var result = false;
            try
            {
                if (_instance._client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Connection,
                        CommandText = "addusuario",
                        CommandType = CommandType.StoredProcedure
                    };

                    var par1 = new SqlParameter("@correo", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = usuario.correo
                    };

                    var par2 = new SqlParameter("@contraseña", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = usuario.contraseña
                    };

                    var par3 = new SqlParameter("@haserror", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(par1);
                    command.Parameters.Add(par2);
                    command.Parameters.Add(par3);

                    command.ExecuteNonQuery();

                    result = !Convert.ToBoolean(command.Parameters["@haserror"].Value.ToString());
                }
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                _instance._client.Close();
            }
            return result;
        }

        public string GetContraseña(string correo)
        {
            var result = "";
            try
            {
                if (_instance._client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Connection,
                        CommandText = "getcontraseña",
                        CommandType = CommandType.StoredProcedure
                    };

                    var par1 = new SqlParameter("@correo", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = correo
                    };

                    command.Parameters.Add(par1);
                    var dataReader = command.ExecuteReader();

                    if (dataReader.Read())
                    {
                        result = dataReader["contraseña"].ToString();
                    }
                }
            }
            catch
            {

            }
            finally
            {
                _instance._client.Close();
            }
            return result;
        }

        public int GetUsuarioId(string correo)
        {
            var result = 0;
            try
            {
                if (_instance._client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Connection,
                        CommandText = "getusuarioid",
                        CommandType = CommandType.StoredProcedure
                    };

                    var par1 = new SqlParameter("@correo", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = correo
                    };

                    command.Parameters.Add(par1);
                    var dataReader = command.ExecuteReader();

                    if (dataReader.Read())
                    {
                        result = Convert.ToInt32(dataReader["idusuario"].ToString());
                    }
                }
            }
            catch
            {

            }
            finally
            {
                _instance._client.Close();
            }
            return result;
        }

        public bool AddPerfil(Perfil perfil, string urlimagen)
        {
            var result = false;
            try
            {
                if (_instance._client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Connection,
                        CommandText = "addperfil",
                        CommandType = CommandType.StoredProcedure
                    };

                    var par1 = new SqlParameter("@nombre", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = perfil.nombre
                    };

                    var par2 = new SqlParameter("@nombreusuario", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = perfil.nombreusuario
                    };
                    var par3 = new SqlParameter("@idusuario", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Input,
                        Value = perfil.idusuario
                    };

                    var par4 = new SqlParameter("@genero", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = perfil.genero
                    };

                    var par5 = new SqlParameter("@urlimagen", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = urlimagen
                    };

                    var par6 = new SqlParameter("@haserror", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(par1);
                    command.Parameters.Add(par2);
                    command.Parameters.Add(par3);
                    command.Parameters.Add(par4);
                    command.Parameters.Add(par5);
                    command.Parameters.Add(par6);

                    command.ExecuteNonQuery();

                    result = !Convert.ToBoolean(command.Parameters["@haserror"].Value.ToString());
                }
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                _instance._client.Close();
            }
            return result;
        }

        public Perfil GetPerfil(int idusuario)
        {
            var result = new Perfil();
            try
            {
                if (_instance._client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Connection,
                        CommandText = "getperfil",
                        CommandType = CommandType.StoredProcedure
                    };

                    var par1 = new SqlParameter("@idusuario", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Input,
                        Value = idusuario
                    };

                    command.Parameters.Add(par1);
                    var dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        result.nombre = dataReader["nombre"].ToString();
                        result.nombreusuario = dataReader["nombreusuario"].ToString();
                        result.idusuario = idusuario;
                        result.genero = dataReader["genero"].ToString();
                    }
                }
            }
            catch
            {

            }
            finally
            {
                _instance._client.Close();
            }
            return result;
        }

        public PerfilBuilder GetImagenPerfil(int idusuario)
        {
            var result = new PerfilBuilder();
            try
            {
                if (_instance._client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Connection,
                        CommandText = "getimagenperfil",
                        CommandType = CommandType.StoredProcedure
                    };

                    var par1 = new SqlParameter("@idusuario", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Input,
                        Value = idusuario
                    };

                    command.Parameters.Add(par1);
                    var dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        /*ImagenBuilder ib = new PerfilBuilder();*/
                        result.setIdImagen(Convert.ToInt32(dataReader["idimagenperfil"].ToString()));
                        result.setUrlImagen(dataReader["urlimagen"].ToString());
                        result.setFecha(Convert.ToDateTime(dataReader["fecha"].ToString()));
                        result.setIdUsuario(Convert.ToInt32(dataReader["idusuario"].ToString()));
                        
                        /*result.idimagenperfil = ib._imagen.idimagen;
                        result.urlimagen = ib._imagen.urlimagen;
                        result.fecha = ib._imagen.fecha;
                        result.idusuario = ib._imagen.idusuario;*/
                    }
                }
            }
            catch
            {

            }
            finally
            {
                _instance._client.Close();
            }
            return result;
        }

        public bool SetImagenPerfil(PerfilBuilder ip)
        {
            var result = false;
            try
            {
                if (_instance._client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Connection,
                        CommandText = "setimagenperfil",
                        CommandType = CommandType.StoredProcedure
                    };

                    var par1 = new SqlParameter("@urlimagen", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = ip._imagen.urlimagen
                    };

                    var par2 = new SqlParameter("@idusuario", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Input,
                        Value = ip._imagen.idusuario
                    };
                    var par3 = new SqlParameter("@haserror", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(par1);
                    command.Parameters.Add(par2);
                    command.Parameters.Add(par3);
                    command.ExecuteNonQuery();

                    result = !Convert.ToBoolean(command.Parameters["@haserror"].Value.ToString());
                }
            }
            catch (Exception e)
            {
                string aux = e.ToString();
                result = false;
            }
            finally
            {
                _instance._client.Close();
            }
            return result;
        }

        public int GetSeguidores(int idusuariosiguiendo)
        {
            var result = 0;
            try
            {
                if (_instance._client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Connection,
                        CommandText = "getseguidores",
                        CommandType = CommandType.StoredProcedure
                    };

                    var par1 = new SqlParameter("@idusuariosiguiendo", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Input,
                        Value = idusuariosiguiendo
                    };

                    command.Parameters.Add(par1);
                    var dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        result = Convert.ToInt32(dataReader["Total"].ToString());
                    }
                }
            }
            catch
            {

            }
            finally
            {
                _instance._client.Close();
            }
            return result;
        }

        public int GetSiguiendo(int idusuario)
        {
            var result = 0;
            try
            {
                if (_instance._client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Connection,
                        CommandText = "getsiguiendo",
                        CommandType = CommandType.StoredProcedure
                    };

                    var par1 = new SqlParameter("@idusuario", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Input,
                        Value = idusuario
                    };

                    command.Parameters.Add(par1);
                    var dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {

                        result = Convert.ToInt32(dataReader["Total"].ToString());
                    }
                }
            }
            catch
            {

            }
            finally
            {
                _instance._client.Close();
            }
            return result;
        }

        public List<ImagenPropiaBuilder> GetImagenesPropias(int idusuario)
        {
            var result = new List<ImagenPropiaBuilder>();
            try
            {
                if (_instance._client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Connection,
                        CommandText = "getimagenespropias",
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    var par1 = new SqlParameter("@idusuario", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Input,
                        Value = idusuario
                    };

                    command.Parameters.Add(par1);
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        var imagen = new ImagenPropiaBuilder();
                        imagen.setIdImagen(Convert.ToInt32(dataReader["idimagen"].ToString()));
                        imagen.setUrlImagen(dataReader["urlimagen"].ToString());
                        imagen.setLikes(Convert.ToInt32(dataReader["likes"].ToString()));
                        imagen.setFecha(Convert.ToDateTime(dataReader["fecha"].ToString()));
                        imagen.setIdUsuario(Convert.ToInt32(dataReader["idusuario"].ToString()));
                        result.Add(imagen);
                    }
                }
            }
            catch
            {

            }
            finally
            {
                _instance._client.Close();
            }
            return result;
        }

        public List<ImagenSeguidorBuilder> GetImagenesSiguiendo(int idusuario)
        {
            var result = new List<ImagenSeguidorBuilder>();
            try
            {
                if (_instance._client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Connection,
                        CommandText = "getimagenessiguiendo",
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    var par1 = new SqlParameter("@idusuario", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Input,
                        Value = idusuario
                    };

                    command.Parameters.Add(par1);
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        var imagen = new ImagenSeguidorBuilder();
                        
                        imagen.setIdImagen(Convert.ToInt32(dataReader["idimagen"].ToString()));
                        imagen.setUrlImagen(dataReader["urlimagen"].ToString());
                        imagen.setLikes(Convert.ToInt32(dataReader["likes"].ToString()));
                        imagen.setFecha(Convert.ToDateTime(dataReader["fecha"].ToString()));
                        imagen.setIdUsuario(Convert.ToInt32(dataReader["idusuario"].ToString()));
                        
                        result.Add(imagen);
                    }
                }
            }
            catch
            {

            }
            finally
            {
                _instance._client.Close();
            }
            return result;
        }

        public bool MasMeGusta(int idimagen)
        {
            var result = false;
            try
            {
                if (_instance._client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Connection,
                        CommandText = "masmegusta",
                        CommandType = CommandType.StoredProcedure
                    };

                    var par1 = new SqlParameter("@idimagen", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Input,
                        Value = idimagen
                    };

                    command.Parameters.Add(par1);
                    command.ExecuteNonQuery();
                    result = true;
                }
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                _instance._client.Close();
            }
            return result;
        }

        public bool MenosMeGusta(int idimagen)
        {
            var result = false;
            try
            {
                if (_instance._client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Connection,
                        CommandText = "menosmegusta",
                        CommandType = CommandType.StoredProcedure
                    };

                    var par1 = new SqlParameter("@idimagen", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Input,
                        Value = idimagen
                    };

                    command.Parameters.Add(par1);
                    command.ExecuteNonQuery();
                    result = true;
                }
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                _instance._client.Close();
            }
            return result;
        }

        public int GetSigoATal(int idusuario, int idsigoatal)
        {
            var result = 0;
            try
            {
                if (_instance._client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Connection,
                        CommandText = "getsigoatal",
                        CommandType = CommandType.StoredProcedure
                    };

                    var par1 = new SqlParameter("@idusuario", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Input,
                        Value = idusuario
                    };

                    var par2 = new SqlParameter("@idalquesigo", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Input,
                        Value = idsigoatal
                    };

                    command.Parameters.Add(par1);
                    command.Parameters.Add(par2);
                    var dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        result = Convert.ToInt32(dataReader["idusuario"].ToString());
                    }
                }
            }
            catch
            {

            }
            finally
            {
                _instance._client.Close();
            }
            return result;
        }

        public bool SeguiPerfil(int idusuario, int idsigoatal)
        {
            var result = false;
            try
            {
                if (_instance._client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Connection,
                        CommandText = "seguirperfil",
                        CommandType = CommandType.StoredProcedure
                    };

                    var par1 = new SqlParameter("@idcorriendo", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Input,
                        Value = idusuario
                    };

                    var par2 = new SqlParameter("@idperfilaseguir", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Input,
                        Value = idsigoatal
                    };

                    var par3 = new SqlParameter("@haserror", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(par1);
                    command.Parameters.Add(par2);
                    command.Parameters.Add(par3);

                    command.ExecuteNonQuery();

                    result = !Convert.ToBoolean(command.Parameters["@haserror"].Value.ToString());
                }
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                _instance._client.Close();
            }
            return result;
        }

        public bool DejarDeSeguir(int idusuario, int idsigoatal)
        {
            var result = false;
            try
            {
                if (_instance._client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Connection,
                        CommandText = "dejardeseguir",
                        CommandType = CommandType.StoredProcedure
                    };

                    var par1 = new SqlParameter("@idcorriendo", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Input,
                        Value = idusuario
                    };

                    var par2 = new SqlParameter("@idperfilaseguir", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Input,
                        Value = idsigoatal
                    };

                    var par3 = new SqlParameter("@haserror", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(par1);
                    command.Parameters.Add(par2);
                    command.Parameters.Add(par3);

                    command.ExecuteNonQuery();

                    result = !Convert.ToBoolean(command.Parameters["@haserror"].Value.ToString());
                }
            }
            catch (Exception e)
            {
                string he = e.ToString();
                result = false;
            }
            finally
            {
                _instance._client.Close();
            }
            return result;
        }

        public List<Perfil> GetAllPerfiles(int idusuario, string cadena)
        {
            var result = new List<Perfil>();
            try
            {
                if (_instance._client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Connection,
                        CommandText = "getallperfiles",
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

                    var par1 = new SqlParameter("@idusuario", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Input,
                        Value = idusuario
                    };

                    var par2 = new SqlParameter("@cadena", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = cadena
                    };

                    command.Parameters.Add(par1);
                    command.Parameters.Add(par2);

                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        var perfil = new Perfil
                        {
                            nombre = dataReader["nombre"].ToString(),
                            nombreusuario = dataReader["nombreusuario"].ToString(),
                            idusuario = Convert.ToInt32(dataReader["idusuario"].ToString()),
                            genero = dataReader["genero"].ToString(),
                        };
                        result.Add(perfil);
                    }
                }
            }
            catch
            {

            }
            finally
            {
                _instance._client.Close();
            }
            return result;
        }

        public bool AddHistoria(string urlimagen, int idusuario)
        {
            var result = false;
            try
            {
                if (_instance._client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Connection,
                        CommandText = "addhistoria",
                        CommandType = CommandType.StoredProcedure
                    };

                    var par1 = new SqlParameter("@urlimagen", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = urlimagen
                    };

                    var par2 = new SqlParameter("@idusuario", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Input,
                        Value = idusuario
                    };

                    var par3 = new SqlParameter("@haserror", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(par1);
                    command.Parameters.Add(par2);
                    command.Parameters.Add(par3);

                    command.ExecuteNonQuery();

                    result = !Convert.ToBoolean(command.Parameters["@haserror"].Value.ToString());
                }
            }
            catch (Exception e)
            {
                string he = e.ToString();
                result = false;
            }
            finally
            {
                _instance._client.Close();
            }
            return result;
        }

        public List<Perfil> GetPerfilesSiguiendo(int idusuario)
        {
            var result = new List<Perfil>();
            try
            {
                if (_instance._client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Connection,
                        CommandText = "getperfilessiguiendo",
                        CommandType = CommandType.StoredProcedure
                    };

                    var par1 = new SqlParameter("@idusuario", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Input,
                        Value = idusuario
                    };

                    command.Parameters.Add(par1);
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        var perfil = new Perfil
                        {
                            nombre = dataReader["nombre"].ToString(),
                            nombreusuario = dataReader["nombreusuario"].ToString(),
                            idusuario = Convert.ToInt32(dataReader["idusuario"].ToString()),
                            genero = dataReader["genero"].ToString()
                        };
                        result.Add(perfil);
                    }
                }
            }
            catch
            {

            }
            finally
            {
                _instance._client.Close();
            }
            return result;
        }

        public List<Historia> GetHistorias(int idusuario)
        {
            var result = new List<Historia>();
            try
            {
                if (_instance._client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Connection,
                        CommandText = "gethistorias",
                        CommandType = CommandType.StoredProcedure
                    };

                    var par1 = new SqlParameter("@idusuario", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Input,
                        Value = idusuario
                    };

                    command.Parameters.Add(par1);
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        var historia = new Historia
                        {
                            idhistoria = Convert.ToInt32(dataReader["idhistoria"].ToString()),
                            urlimagen = dataReader["urlimagen"].ToString(),
                            fecha = Convert.ToDateTime(dataReader["fecha"].ToString()),
                            idusuario = Convert.ToInt32(dataReader["idusuario"].ToString())
                        };
                        result.Add(historia);
                    }
                }
            }
            catch
            {

            }
            finally
            {
                _instance._client.Close();
            }
            return result;
        }

        public bool AddHistoria(Historia h)
        {
            var result = false;
            try
            {
                if (_instance._client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Connection,
                        CommandText = "addhistoria",
                        CommandType = CommandType.StoredProcedure
                    };

                    var par1 = new SqlParameter("@urlimagen", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = h.urlimagen
                    };

                    var par2 = new SqlParameter("@fecha", SqlDbType.DateTime)
                    {
                        Direction = ParameterDirection.Input,
                        Value = h.fecha
                    };

                    var par3 = new SqlParameter("@idusuario", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Input,
                        Value = h.idusuario
                    };
                    var par4 = new SqlParameter("@haserror", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(par1);
                    command.Parameters.Add(par2);
                    command.Parameters.Add(par3);
                    command.Parameters.Add(par4);

                    command.ExecuteNonQuery();

                    result = !Convert.ToBoolean(command.Parameters["@haserror"].Value.ToString());
                }
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                _instance._client.Close();
            }
            return result;
        }

        public bool DeleteHistoria(Historia h)
        {
            var result = false;
            try
            {
                if (_instance._client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Connection,
                        CommandText = "deletehistoria",
                        CommandType = CommandType.StoredProcedure
                    };

                    var par1 = new SqlParameter("@idhistoria", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = h.idhistoria
                    };

                    var par2 = new SqlParameter("@haserror", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(par1);
                    command.Parameters.Add(par2);

                    command.ExecuteNonQuery();

                    result = !Convert.ToBoolean(command.Parameters["@haserror"].Value.ToString());
                }
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                _instance._client.Close();
            }
            return result;
        }

        public bool AddImagen(string urlimagen, int idusuario)
        {
            var result = false;
            try
            {
                if (_instance._client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Connection,
                        CommandText = "addimagen",
                        CommandType = CommandType.StoredProcedure
                    };

                    var par1 = new SqlParameter("@urlimagen", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = urlimagen
                    };

                    var par2 = new SqlParameter("@idusuario", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Input,
                        Value = idusuario
                    };

                    var par3 = new SqlParameter("@haserror", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(par1);
                    command.Parameters.Add(par2);
                    command.Parameters.Add(par3);

                    command.ExecuteNonQuery();

                    result = !Convert.ToBoolean(command.Parameters["@haserror"].Value.ToString());
                }
            }
            catch (Exception e)
            {
                string he = e.ToString();
                result = false;
            }
            finally
            {
                _instance._client.Close();
            }
            return result;
        }

        public bool AddComentario(Comentario comentario)
        {
            var result = false;
            try
            {
                if (_instance._client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Connection,
                        CommandText = "addcomentario",
                        CommandType = CommandType.StoredProcedure
                    };

                    var par1 = new SqlParameter("@idimagen", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Input,
                        Value = comentario.idimagen
                    };

                    var par2 = new SqlParameter("@texto", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = comentario.texto
                    };

                    var par3 = new SqlParameter("@idusuarioquecomento", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Input,
                        Value = comentario.idusuarioquecomento
                    };

                    var par4 = new SqlParameter("@haserror", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(par1);
                    command.Parameters.Add(par2);
                    command.Parameters.Add(par3);
                    command.Parameters.Add(par4);

                    command.ExecuteNonQuery();

                    result = !Convert.ToBoolean(command.Parameters["@haserror"].Value.ToString());
                }
            }
            catch (Exception e)
            {
                string he = e.ToString();
                result = false;
            }
            finally
            {
                _instance._client.Close();
            }
            return result;
        }

        public List<Comentario> GetComentarios(int idimagen)
        {
            var result = new List<Comentario>();
            try
            {
                if (_instance._client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Connection,
                        CommandText = "getcomentarios",
                        CommandType = CommandType.StoredProcedure
                    };

                    var par1 = new SqlParameter("@idimagen", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Input,
                        Value = idimagen
                    };

                    command.Parameters.Add(par1);
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        var comentario = new Comentario
                        {
                            idcomentario = Convert.ToInt32(dataReader["idcomentario"].ToString()),
                            idimagen = Convert.ToInt32(dataReader["idimagen"].ToString()),
                            texto = dataReader["texto"].ToString(),
                            idusuarioquecomento = Convert.ToInt32(dataReader["idusuarioquecomento"].ToString())
                        };
                        result.Add(comentario);
                    }
                }
            }
            catch
            {

            }
            finally
            {
                _instance._client.Close();
            }
            return result;
        }
    }
}
