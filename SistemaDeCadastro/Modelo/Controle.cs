using SistemaDeCadastro.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeCadastro.Modelo
{
    public class Controle
    {
        public bool tem;
        public String mensagem = "";

        public bool acessar(String login, String senha)
        {
            LoginDaoComandos LoginDao = new LoginDaoComandos();
            tem = LoginDao.verificarLogin(login, senha);
            if(!LoginDao.mensagem.Equals(""))
            {
                //Comparação para vê se as informações estão no banco de dados
                this.mensagem = LoginDao.mensagem;
            }
            return tem;
        }
        public String cadastrar(String nome, String email, String senha)
        {
            LoginDaoComandos loginDao = new LoginDaoComandos();
            this.mensagem = loginDao.cadastrar(nome, email, senha);
            if(loginDao.tem)
            {
                this.tem = true;
            }
            return mensagem;
        }
        public String buscar(String nome)
        {
            LoginDaoComandos loginDao = new LoginDaoComandos();
            this.mensagem = loginDao.buscar(nome);
            if (loginDao.tem)
            {
                this.tem = true;
            }
            return mensagem;
        }
        public String atualizar(String nome, String email, String senha)
        {
            LoginDaoComandos loginDao = new LoginDaoComandos();
            this.mensagem = loginDao.atualizar(nome, email, senha);
            return mensagem;
        }
        public String deletar(String nome)
        {
            LoginDaoComandos loginDao = new LoginDaoComandos();
            this.mensagem = loginDao.deletar(nome);
            return mensagem;
        }

    }
}
