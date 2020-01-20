using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Loja.DAL;
using Loja.DTO;


namespace Loja.BLL
{
    public class Produto_BLL 
    {
        public IList<Produto_DTO> cargaProduto()
        {
            try
            {
                return new Produto_DAL().cargaProduto();
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
                return new Produto_DAL().insereProduto(USU);
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
                return new Produto_DAL().editaProduto(USU);
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
                return new Produto_DAL().deletaProduto(USU);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}