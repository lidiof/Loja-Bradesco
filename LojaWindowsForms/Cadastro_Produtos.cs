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
    public partial class Cadastro_Produtos : Form
    {
        private string modo = " ";
        private int codPodSelecionado = -1;
        public Cadastro_Produtos()
        {
            InitializeComponent();
        }

        private void btnNOVO_Click(object sender, EventArgs e)
        {
            limpar_campos();
            modo = "novo";

        }

        private void Cadastro_Produtos_Load(object sender, EventArgs e)
        {
            carregaGrid();
        }
        private void carregaGrid()
        {
            try
            {
                IList<Produto_DTO> listProduto_DTO = new List<Produto_DTO>();
                listProduto_DTO = new Produto_BLL().cargaProduto();
                
                dataGridView1.DataSource = listProduto_DTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void limpar_campos()
        {
            txtNome_Produto.Text = "";
            txtNome_Fabrica.Text = "";
            txtEndereco.Text = "";
           
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (modo == "novo")
            {
                try
                {
                    
                    Produto_DTO USU = new Produto_DTO();
                    USU.nome_produtos = txtNome_Produto.Text;
                    USU.nome_fabrica = txtNome_Fabrica.Text;
                    USU.Endereco = txtEndereco.Text;
                   
                    int x = new Produto_BLL().insereProduto(USU);
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
                    if (codPodSelecionado < 0)
                    {
                        
                        MessageBox.Show("Selecione um usuario antes de prosseguir");
                        return;
                    }

                    Produto_DTO USU = new Produto_DTO();
                    USU.cod_produtos = codPodSelecionado;
                    USU.nome_produtos = txtNome_Produto.Text;
                    USU.nome_fabrica = txtNome_Fabrica.Text;
                    USU.Endereco = txtEndereco.Text;
                    
                    int x = new Produto_BLL().editaProduto(USU);
                    
                    if (x > 0)
                    {
                        MessageBox.Show("Alterado com Sucesso!");
                    }
                    
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
                    if (codPodSelecionado < 0)
                    {
                        //lblMensagem.Text = "Selecione um usuario antes de prosseguir";
                        return;
                    }
                    Produto_DTO USU = new Produto_DTO();
                    USU.cod_produtos = codPodSelecionado;
                    int x = new Produto_BLL().deletaProduto(USU);
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

            modo = " ";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int sel = dataGridView1.CurrentRow.Index;
            
            txtNome_Produto.Text = Convert.ToString(dataGridView1["nome_produtos", sel].Value);
            txtNome_Fabrica.Text = Convert.ToString(dataGridView1["nome_fabrica", sel].Value);
            txtEndereco.Text = Convert.ToString(dataGridView1["Endereco", sel].Value);
            
            codPodSelecionado = Convert.ToInt32(dataGridView1["cod_produtos", sel].Value);
                       
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (codPodSelecionado < 0)
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
            if (codPodSelecionado < 0)
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
