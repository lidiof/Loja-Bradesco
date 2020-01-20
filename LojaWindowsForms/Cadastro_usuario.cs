using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Loja.BLL;
using Loja.DTO;

namespace LojaWindowsForms
{
    public partial class Cadastro_usuario : Form
    {
        private string modo = " ";
        private int codUsuSelecionado = -1;

        public Cadastro_usuario()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*Linha atual que estiver selecionada aparecerá nos campos (textbox)
 * acima do dataGrid*/
            int sel = dataGridView1.CurrentRow.Index;
            /*Valor de cada datagrid será enviado ao seu respectivo texbox*/
            txtNome.Text = Convert.ToString(dataGridView1["nome", sel].Value);
            txtLogin.Text = Convert.ToString(dataGridView1["login", sel].Value);
            txtEmail.Text = Convert.ToString(dataGridView1["email", sel].Value);
            txtSenha.Text = Convert.ToString(dataGridView1["senha", sel].Value);
            txtCadastro.Text = Convert.ToString(dataGridView1["cadastro", sel].Value);
            // selecionar usuario
            codUsuSelecionado = Convert.ToInt32(dataGridView1["cod_usuario", sel].Value);

            /*Condição se a situação for igual a "A" então o combobox ficará
            * Ativo senao "Inativo" */
            if (Convert.ToString(dataGridView1["situacao", sel].Value) == "A")
            {
                cboSituacao.Text = "Ativo";
            }
            else
            {
                cboSituacao.Text = "Inativo";
                
            }
            int x = Convert.ToInt32(dataGridView1["perfil", sel].Value);
            switch (x)
            {
                case 1:
                    cboPerfil.Text = "Administrador";
                    break;
                case 2:
                    cboPerfil.Text = "Operador";
                    break;
                case 3:
                    cboPerfil.Text = "Gerencial";
                    break;
                default:
                    break;
            }

            
        }

        private void Cadastro_usuario_Load(object sender, EventArgs e)     
          {
                carregaGrid();
          }
         
        private void carregaGrid() { 
            try
            {
                IList<Usuario_DTO> listUsuario_DTO = new List<Usuario_DTO>();
                listUsuario_DTO = new Usuario_BLL().cargaUsuario();
                /*Preencher dados no DataGridView*/
                dataGridView1.DataSource = listUsuario_DTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            limpar_campos();            
            txtCadastro.Text = Convert.ToString(System.DateTime.Now);
            modo = "novo";
        }
        private void limpar_campos()
        {
            txtNome.Text = "";
            txtLogin.Text = "";
            txtEmail.Text = "";
            txtSenha.Text = "";
            txtCadastro.Text = "";
            cboPerfil.Text = "";
            cboSituacao.Text = "";
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (modo == "novo")
            {               
                try
                {
                    /*Método insere usuário na classe UsuarioBLL*/
                    Usuario_DTO USU = new Usuario_DTO();
                    USU.nome = txtNome.Text;
                    USU.login = txtLogin.Text;
                    USU.email = txtEmail.Text;
                    USU.cadastro = System.DateTime.Now;
                    USU.senha = txtSenha.Text;
                    if (cboSituacao.Text == "Ativo")
                    {
                        USU.situacao = "A";
                    }
                    else
                    {
                        USU.situacao = "I";
                    }
                    switch (cboPerfil.Text)
                    {
                        case "Administrador":
                            USU.perfil = 1;
                            break;
                        case "Operador":
                            USU.perfil = 2;
                            break;
                        case "Gerencial":
                            USU.perfil = 3;
                            break;
                    }
                    int x = new Usuario_BLL().insereUsuario(USU);
                    if (x > 0)
                    {
                        MessageBox.Show("Gravado com Sucesso!");
                    }
                    carregaGrid();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro inesperado" + ex.Message);
                }
            }

            if (modo == "editar")
            {
               
                try
                {
                    if (codUsuSelecionado < 0)
                    {
                        //lblMensagem.Text = "Selecione um usuario antes de prosseguir";
                        MessageBox.Show("Selecione um usuario antes de prosseguir");
                        return;
                    }
                   
                    Usuario_DTO USU = new Usuario_DTO();
                    USU.cod_usuario = codUsuSelecionado;
                    USU.nome = txtNome.Text;
                    USU.login = txtLogin.Text;
                    USU.email = txtEmail.Text;
                    USU.cadastro = System.DateTime.Now;
                    USU.senha = txtSenha.Text;
                    if (cboSituacao.Text == "Ativo")
                    {
                        USU.situacao = "A";
                    }
                    else
                    {
                        USU.situacao = "I";
                    }
                    switch (cboPerfil.Text)
                    {
                        case "Administrador":
                            USU.perfil = 1;
                            break;
                        case "Operador":
                            USU.perfil = 2;
                            break;
                        case "Gerencial":
                            USU.perfil = 3;
                            break;
                    }
                    int x = new Usuario_BLL().editaUsuario(USU);
                    /*Verifica se houve alguma gravação*/
                    if (x > 0)
                    {
                        MessageBox.Show("Alterado com Sucesso!");
                    }
                    /*Recarrega o Grid após os dados serem gravados*/
                    carregaGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro inesperado" + ex.Message);
                }
            }

            if (modo == "deletar")
            {
                try
                {
                    if (codUsuSelecionado < 0)
                    {
                        //lblMensagem.Text = "Selecione um usuario antes de prosseguir";
                        return;
                    }
                    Usuario_DTO USU = new Usuario_DTO();
                    USU.cod_usuario = codUsuSelecionado;
                    int x = new Usuario_BLL().deletaUsuario(USU);
                    if (x > 0)
                    {
                        MessageBox.Show("Excluido com Sucesso!");
                    }
                    /*Recarrega o Grid após os dados serem gravados*/
                    carregaGrid();
                    limpar_campos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro inesperado" + ex.Message);
                }
            }

            modo = "";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (codUsuSelecionado < 0)
            {
                MessageBox.Show("Selecione um usuario antes");
                return;
            }
            else
            {
                
                modo = "editar";
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (codUsuSelecionado < 0)
            {
                MessageBox.Show("Selecione um usuario antes");
                return;
            }
            else
            {
                
                modo = "deletar";
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            modo = "";
            limpar_campos();
        }
    }
}
