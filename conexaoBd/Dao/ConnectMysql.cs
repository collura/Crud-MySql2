
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace Dao
{
    class ConnectMysql : Form
    {
            
            
            String server;
            String dataBase;
            String uid;
            String password;
            String connectionString;
            MySqlConnection conn;

            protected String sql;
            protected bool success = false;
            protected MySqlCommand cmd;


        public ConnectMysql()
        {
            server = "localhost";
            dataBase = "sisoo";
            uid = "root";
            password = "";
            connectionString = "SERVER = " + server + ";" + "DATABASE = " + dataBase + ";" + "UID = " + uid + ";" + "PASSWORD = " + password + ";";            
        }


        protected MySqlConnection open() { 
            
            conn = new MySqlConnection(this.connectionString);
            if (conn.State != ConnectionState.Open) {
                try
                {
                    conn.Open();
                    success = true;
                }
                catch (MySqlException ex) {
                     switch (ex.Number) {   
                         case 0 :
                             MessageBox.Show("Não Foi Possível a conexão com o Servidor");
                             break;
                         case 1045:
                             MessageBox.Show("Login ou Senha inválidos");
                             break;
                          default:
                             MessageBox.Show("Erro no acesso ao Banco de dados");
                             break;                
                     }               
                }                                               
            }
            return conn; ;
        }
                 
                      
           
        

        
        protected void close() {
            if (conn.State != ConnectionState.Closed) {
                conn.Close();            
            }    
    

        }        
    }
}
