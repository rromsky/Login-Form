using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_1_WF
{
    internal class DB
    {
        MySqlConnection connection = new MySqlConnection("server=db4free.net;port=3306;username=tomcuck;password=7k.DJ2m3WphU726;database=lolpop");
        public void openConnection()
        {
            if(connection.State == System.Data.ConnectionState.Closed) {
            connection.Open();
            }
        }
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public MySqlConnection GetConnection()
        {
            return connection;
        }
    }

}
