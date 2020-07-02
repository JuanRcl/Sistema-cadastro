using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading;
using System.Drawing.Text;
using System.Linq.Expressions;

namespace cadastro
{
    public partial class cadastrar : Form
    {
        Thread tr;
        public cadastrar()
        {
            InitializeComponent();
        }

        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            try
            {

                MySqlConnection conexao = new MySqlConnection("server=localhost;port=3306;User Id=root;database=usuarios;password= Lima3463#");
                conexao.Open();
                MySqlCommand comando = new MySqlCommand("insert into dados values (?, ?, ?, ?, ?)", conexao);
                comando.Parameters.Add("@nome", MySqlDbType.VarChar, 70).Value = tb_nome.Text;
                comando.Parameters.Add("@login", MySqlDbType.VarChar, 30).Value = tb_login.Text;
                comando.Parameters.Add("@senha", MySqlDbType.VarChar, 8).Value = tb_senha.Text;
                comando.Parameters.Add("@cpf", MySqlDbType.VarChar, 11).Value = tb_cpf.Text;
                comando.Parameters.Add("@nasc", MySqlDbType.VarChar, 10).Value = tb_nasc.Text;
                if (tb_login.Text.Length > 30 || tb_cpf.Text.Length < 11 || tb_cpf.Text.Length > 11 || tb_nasc.Text.Length > 10 || tb_nasc.Text.Length<10)
                {
                    MessageBox.Show("Algo deu errado, verifique os campos preechidos e tente novamente!", "Campo(os) Inválido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (tb_senha.Text.Length < 8)
                {
                    MessageBox.Show("Senha com menos de 8 caracteres!", "Senha inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    comando.ExecuteNonQuery();
                    conexao.Close();
                    MessageBox.Show("Cadastro realizado com sucesso!", "Cadastro realizado!", MessageBoxButtons.OK);
                    this.Close();
                    tr = new Thread(abrirJanela);
                    tr.SetApartmentState(ApartmentState.STA);
                    tr.Start();

                }
            }
            catch
            {
                MessageBox.Show("Algo deu errado, tente novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 
        private void abrirJanela(object obj)
        {
            Application.Run(new Form1());
        }

        private void btn_voltar_Click(object sender, EventArgs e)
        {
            this.Close();
            tr = new Thread(login);
            tr.SetApartmentState(ApartmentState.STA);
            tr.Start();
        }
        private void login(object obj)
        {
            Application.Run(new Form1());
        }
    }
}
