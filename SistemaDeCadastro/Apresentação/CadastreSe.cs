using SistemaDeCadastro.DAL;
using SistemaDeCadastro.Modelo;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaDeCadastro.Apresentação
{
    public partial class CadastreSe : Form
    {
        public CadastreSe()
        {
            InitializeComponent();
        }

        private void adicionar_Click(object sender, EventArgs e)
        {
            Controle controle = new Controle();
            String mensagem = controle.cadastrar(txbNome.Text, txbLogin.Text, txbSenha.Text);
            if(controle.tem)
            {
                MessageBox.Show(mensagem, "Cadastrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                Conexao con = new Conexao();
                con.conectar();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con.conectar();
                cmd.CommandText = "select * from CadastroTable";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else 
            {
                MessageBox.Show(controle.mensagem);
            }
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controle controle = new Controle();       
            String mensagem = controle.buscar(txbNome.Text);
            if (controle.tem)
            {
                MessageBox.Show(mensagem, "Usuário encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                Conexao con = new Conexao();
                con.conectar();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con.conectar();
                cmd.CommandText = "select * from CadastroTable where Nome = @N";
                cmd.Parameters.AddWithValue("@N ", Convert.ToString(txbNome.Text));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else 
            {
                MessageBox.Show(mensagem = "Não foi encontrado nenhum usuário", "Usuario não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CadastreSe_Load(object sender, EventArgs e)
        {
            Conexao con = new Conexao();
            con.conectar();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.conectar();
            cmd.CommandText = "select * from CadastroTable";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controle controle = new Controle();
            String mensagem = controle.atualizar(txbNome.Text, txbLogin.Text, txbSenha.Text);
            MessageBox.Show(mensagem, "Atualização", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Conexao con = new Conexao();
            con.conectar();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.conectar();
            cmd.CommandText = "select * from CadastroTable";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controle controle = new Controle();
            String mensagem = controle.deletar(txbNome.Text);
            MessageBox.Show(mensagem,"Atualização", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Conexao con = new Conexao();
            con.conectar();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.conectar();
            cmd.CommandText = "select * from CadastroTable";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}