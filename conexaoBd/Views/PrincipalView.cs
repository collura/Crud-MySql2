using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using Controls;


namespace Views

{
    public partial class PrincipalView : Form
    {

        private UsuarioModel model = new UsuarioModel();
        private UsuarioControl control;
        private Boolean success;

        public PrincipalView()
        {
            InitializeComponent();
        }

        private void PrincipalView_Load(object sender, EventArgs e)
        {
            recarregaGrid();
        }


        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if(
            txtNome.Text == String.Empty ||
            txtLogin.Text == String.Empty ||
            txtSenha.Text == String.Empty ||
            txtConfSenha.Text == String.Empty ||
            txtEmail.Text == String.Empty ||
            txtNivel.Text == String.Empty)
            {
              MessageBox.Show("Preencha todos os campos");            
            }
            else {             
            
            model.nome = txtNome.Text;
            model.login = txtLogin.Text;
            model.senha = txtSenha.Text;
            model.email = txtEmail.Text;
            model.nivel = txtNivel.Text;
            control = new UsuarioControl(model);
            if (control.cadastrar())
            {
                    MessageBox.Show("Cadastrado com sucesso !");
                    txtNome.Text = "";
                    txtLogin.Text = "";
                    txtSenha.Text = "";
                    txtConfSenha.Text = "";
                    txtEmail.Text = "";
                    txtNivel.Text = "";
                    txtNome.Focus();

                    grid.DataSource = control.retornarTodos();
                 }

            }
        }


        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            model.id = txtIdUsuario.Text;
            model.nome = txtNome.Text;
            model.login = txtLogin.Text;
            model.senha = txtSenha.Text;
            model.email = txtEmail.Text;
            model.nivel = txtNivel.Text;

            control = new UsuarioControl(model);
            success = control.atualizar();
            if (success)
            {
                MessageBox.Show("Registro alterado com sucesso !");
            }
            recarregaGrid();
            limpa();
            btnExcluir.Enabled = false;
            btnCadastrar.Enabled = true;
            btnAtualizar.Enabled = false;
        }     
                  


        private void btnExcluir_Click(object sender, EventArgs e)
        {         
            model.id = txtIdUsuario.Text;
            control = new UsuarioControl(model);
            success = control.excluiUsuario();
            if (success) { 
                MessageBox.Show("Registro excluido com sucesso !");
            }
            recarregaGrid();
            limpa();
            btnExcluir.Enabled = false;
            btnCadastrar.Enabled = true;
            btnAtualizar.Enabled = false;

        }

        private void grid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ( int.Parse(grid.CurrentRow.Cells["Id"].Value.ToString()) > 0)
            {

                btnExcluir.Enabled = true;
                btnCadastrar.Enabled = false;
                btnAtualizar.Enabled = true;
                txtIdUsuario.Text = grid.CurrentRow.Cells["Id"].Value.ToString();

                txtNome.Text = grid.CurrentRow.Cells["Nome"].Value.ToString();
                txtLogin.Text = grid.CurrentRow.Cells["Login"].Value.ToString();
                txtSenha.Text = grid.CurrentRow.Cells["Senha"].Value.ToString();
                txtEmail.Text = grid.CurrentRow.Cells["E-Mail"].Value.ToString();
                txtNivel.Text = grid.CurrentRow.Cells["Privilegio"].Value.ToString();
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            Dispose();
        }


        private void limpa() {
            txtNome.Text = "";
            txtLogin.Text = "";
            txtSenha.Text = "";
            txtConfSenha.Text = "";
            txtEmail.Text = "";
            txtNivel.Text = "";               
        }


        private void recarregaGrid() {
            control = new UsuarioControl(model);          
            grid.DataSource = control.retornarTodos();
        }

       
    }
}
