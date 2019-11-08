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
                            id = Convert.ToInt32(dataReader["idamigo"].ToString()),
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
                if(_instance._client.Open())
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

                    if(dataReader.Read())
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
                        result = Convert.ToInt32(dataReader["contraseña"].ToString());
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

        public bool AddPerfil(Perfil perfil)
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

                    var par1 = new SqlParameter("@correo", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = perfil.nombre
                    };

                    var par2 = new SqlParameter("@contraseña", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = perfil.nombreusuario
                    };
                    var par3 = new SqlParameter("@idusuario", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = perfil.idusuario
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
    }


}
