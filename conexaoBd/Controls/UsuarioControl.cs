using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Dao;
using System.Data;

namespace Controls

{
    class UsuarioControl : UsuarioDao
    {


        private UsuarioModel model;
        public UsuarioControl(UsuarioModel model)
        {
            this.model = model;        
        }

        public Boolean excluiUsuario()
        {
            return deletarUsuario(this.model);
        }


        public bool cadastrar() {
            return cadastrar(model);        
        }

        public bool atualizar()
        {
            return atualizar(model);
        }


        public DataTable retornarTodos()
        {
            return retornaTodos();
        }
    }
}
