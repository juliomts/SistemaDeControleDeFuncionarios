using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeCadastro.DAL
{
    class LoginDaoComandos
    {
        public bool tem = false;
        public string mensagem = "";
        SqlCommand cmd = new SqlCommand();
        Conexao con = new Conexao();
        SqlDataReader dr;
        public bool verificarLogin(String login, String senha)
        {
            //procurar no banco de dados esse login e senha
            cmd.CommandText = "select * from CadastroTable where Email = @login and Senha = @senha";
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@senha", senha);
            try
            {
                cmd.Connection = con.conectar();
                dr = cmd.ExecuteReader(); //procurar no banco de dados
                if(dr.HasRows) //Se foi encontrado
                {
                    tem = true;
                }
                con.desconectar();
                dr.Close();
            }
            catch (SqlException)
            {
                this.mensagem = "Erro com o Banco de Dados";
            }
            return tem;
        }
        
        public String cadastrar(String nome, String email, String senha)
        {
            cmd.CommandText = "insert into CadastroTable values(@N, @E, @S);";
            cmd.Parameters.AddWithValue("@N", nome);
            cmd.Parameters.AddWithValue("@E", email);
            cmd.Parameters.AddWithValue("@S", senha);
            tem = false;
            try
            {
                cmd.Connection = con.conectar();
                cmd.ExecuteNonQuery();
                con.desconectar();
                this.mensagem = "Cadastrado com sucesso";
                tem = true;

            }
            catch (SqlException)
            {

                this.mensagem = "Erro com o Banco de Dados";
            }
            return mensagem;
        }

        public String buscar (String nome)
        {
            cmd.CommandText = "select * from CadastroTable where Nome = @pesquisar";
            cmd.Parameters.AddWithValue("@pesquisar", nome);
            tem = false;
            try
            {
                cmd.Connection = con.conectar();
                dr = cmd.ExecuteReader(); //procurar no banco de dados
                if (dr.HasRows) //Se foi encontrado
                {
                    this.mensagem = "Pessoa encontrada";
                    tem = true;
                    con.desconectar();
                    dr.Close();
                }
            }
            catch (SqlException)
            {
                this.mensagem = "Pessoa nao encontrada";
            }

            return mensagem;

        }
        public String atualizar (String nome, String email, String senha)
        {
            cmd.CommandText = "update CadastroTable set Email = @E, Senha = @S where Nome = @N";
            cmd.Parameters.AddWithValue("@N", nome);
            cmd.Parameters.AddWithValue("@E", email);
            cmd.Parameters.AddWithValue("@S", senha);
            try
            {
                cmd.Connection = con.conectar();
                dr = cmd.ExecuteReader();
                con.desconectar();
                dr.Close();
                this.mensagem = "Dados atualizados";
            }
            catch (SqlException)
            {
                this.mensagem = "Erro com o Banco de Dados";
            }

            return mensagem;
        }
        public String deletar(String nome)
        {
            cmd.CommandText = "Delete CadastroTable where Nome = @N";
            cmd.Parameters.AddWithValue("@N", nome);
            try
            {
                cmd.Connection = con.conectar();
                dr = cmd.ExecuteReader();
                con.desconectar();
                dr.Close();
                this.mensagem = "Dados deletados";
            }
            catch (SqlException)
            {
                this.mensagem = "Erro com o Banco de Dados";
            }

            return mensagem;
        }
    }
}
