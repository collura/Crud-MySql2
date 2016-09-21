using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;


namespace Dao
{
    class UsuarioDao : ConnectMysql
    {




        protected bool cadastrar(UsuarioModel model)
        {

            sql = "INSERT INTO usuario (nome, login, senha, email, nivel) " +
            "VALUES ('"+ model.nome + "','" + model.login + "','" + model.senha + "','" +  model.email + "','" + model.nivel + "');";

            open();
            cmd = new MySqlCommand(sql, open());
            try
            {
                cmd.ExecuteNonQuery();
                success = true;
            }
            catch (Exception ex) {
                throw new Exception("Erro ao tentar executar o cadastro no Banco de Dados.\n Detalhes do Erro: " + ex.Message);            
            }
            close();
            return success;
        }



           protected DataTable retornaTodos() {
               open();
                   sql = "select id_usuario as 'Id', nome as 'Nome', login as 'Login', senha as 'Senha', email as 'E-Mail', nivel as 'Privilegio' from usuario";
                   cmd = new MySqlCommand(sql, open());
                   MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                   DataTable dt = new DataTable();
                   da.Fill(dt);
               close();
               return dt;              
           }



           protected Boolean atualizar(UsuarioModel model)
           {
               open();
               sql = "UPDATE usuario " 
               + "SET nome = '" + model.nome + "',"
               + "login = '" + model.login + "',"
               + "senha = '" + model.senha + "',"
               + "email = '" + model.email + "',"
               + "nivel = '" + model.nivel + "' "
               + "WHERE id_usuario = " + model.id + ";";

               try
               {
                   cmd = new MySqlCommand(sql, open());
                   cmd.ExecuteNonQuery();
                   success = true;
               }
               catch (Exception ex)
               {
                   throw new Exception(ex.Message);
               }
               finally
               {
                   close();
               }
               return success;
           }       



           protected Boolean deletarUsuario(UsuarioModel model)
           {
               open();
               sql = "DELETE FROM usuario WHERE id_usuario = " + model.id + ";";
               try
               {
                   cmd = new MySqlCommand(sql, open());
                   cmd.ExecuteNonQuery();
                   success = true;
               }catch(Exception ex){
                   throw new Exception(ex.Message);
               }
               finally{
                    close();
               }
               return success;                     
           }       
    }
}
