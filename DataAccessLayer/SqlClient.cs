using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class SqlClient
    {
        public SqlConnection Connection { get; }

        public SqlClient(string connectionString)
        {
            Connection = new SqlConnection(connectionString);
        }

        public bool Open()
        {
            try
            {
                Connection.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Close()
        {
            try
            {
                if (Connection.State == System.Data.ConnectionState.Open)
                    Connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
