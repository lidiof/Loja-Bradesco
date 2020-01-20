using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loja.DAL;
using Loja.DTO;

namespace Loja.BLL
{
    public class Usuario_BLL
    {
        public IList<Usuario_DTO> cargaUsuario()
        {
            try
            {
                return new Usuario_DAL().cargaUsuario();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insereUsuario(Usuario_DTO USU)
        {
            /*Insere usuario será criado na DAL*/
            try
            {
                return new Usuario_DAL().insereUsuario(USU);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int editaUsuario(Usuario_DTO USU)
        {
            try
            {
                return new Usuario_DAL().editaUsuario(USU);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int deletaUsuario(Usuario_DTO USU)
        {
            try
            {
                return new Usuario_DAL().deletaUsuario(USU);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
