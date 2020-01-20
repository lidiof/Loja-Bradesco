using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loja.DTO;
using System.Data.SqlClient;


namespace Loja.DAL
{
    public class Produto_DAL
    {
        public IList<Produto_DTO> cargaProduto()
        {
            try
            {
                
                SqlConnection CON = new SqlConnection();
                CON.ConnectionString = Properties.Settings.Default.CST;
                SqlCommand CM = new SqlCommand();
                CM.CommandType = System.Data.CommandType.Text;
                CM.CommandText = "SELECT*FROM tb_produtos";
                CM.Connection = CON;
                SqlDataReader ER;
                IList<Produto_DTO> listProdutoDTO = new List<Produto_DTO>();
                CON.Open();
                ER = CM.ExecuteReader();
                if (ER.HasRows)
                {
                    while (ER.Read())
                    {
                        Produto_DTO usu = new Produto_DTO();
                        
                        usu.cod_produtos = Convert.ToInt32(ER["cod_produtos"]);
                        usu.nome_produtos = Convert.ToString(ER["nome_produtos"]);
                        usu.nome_fabrica = Convert.ToString(ER["nome_fabrica"]);
                        usu.Endereco = Convert.ToString(ER["Endereco"]);
                        
                        listProdutoDTO.Add(usu);
                    }
                }
                return listProdutoDTO;           

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insereProduto(Produto_DTO USU)
        {
            try
            {                
                SqlConnection CON = new SqlConnection();
                CON.ConnectionString = Properties.Settings.Default.CST;
                SqlCommand CM = new SqlCommand();
                CM.CommandType = System.Data.CommandType.Text;
                CM.CommandText = "INSERT INTO tb_produtos (nome_produtos, nome_fabrica, Endereco)"
                    + "VALUES (@nome_produtos, @nome_fabrica, @Endereco)";
               
                CM.Parameters.Add("nome_produtos", System.Data.SqlDbType.VarChar).Value = USU.nome_produtos;
                CM.Parameters.Add("nome_fabrica", System.Data.SqlDbType.VarChar).Value = USU.nome_fabrica;
                CM.Parameters.Add("Endereco", System.Data.SqlDbType.VarChar).Value = USU.Endereco;
                
                CM.Connection = CON;
                CON.Open();
                int qtd = CM.ExecuteNonQuery();
                return qtd;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int editaProduto(Produto_DTO USU)
        {
            try
            {
                SqlConnection CON = new SqlConnection();
                CON.ConnectionString = Properties.Settings.Default.CST;
                SqlCommand CM = new SqlCommand();
                CM.CommandType = System.Data.CommandType.Text;
                
                CM.CommandText = "UPDATE tb_produtos SET nome_produtos=@nome_produtos," +
                "nome_fabrica=@nome_fabrica," + "Endereco=@Endereco " 
                + "WHERE cod_produtos=@cod_produtos";
                                
                CM.Parameters.Add("nome_produtos", System.Data.SqlDbType.VarChar).Value = USU.nome_produtos;
                CM.Parameters.Add("nome_fabrica", System.Data.SqlDbType.VarChar).Value = USU.nome_fabrica;
                CM.Parameters.Add("Endereco", System.Data.SqlDbType.VarChar).Value = USU.Endereco;                
                CM.Parameters.Add("cod_produtos", System.Data.SqlDbType.VarChar).Value = USU.cod_produtos;
                CM.Connection = CON;
                
                CON.Open();
                int qtd = CM.ExecuteNonQuery();
                return qtd;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int deletaProduto(Produto_DTO USU)
        {
            try
            {                
                SqlConnection CON = new SqlConnection();
                CON.ConnectionString = Properties.Settings.Default.CST;
                SqlCommand CM = new SqlCommand();
                CM.CommandType = System.Data.CommandType.Text;
                CM.CommandText = "DELETE tb_produtos WHERE cod_produtos = @cod_produtos";
                
                CM.Parameters.Add("cod_produtos", System.Data.SqlDbType.Int).Value = USU.cod_produtos;
                CM.Connection = CON;
                CON.Open();
                int qtd = CM.ExecuteNonQuery();
               
                return qtd;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
