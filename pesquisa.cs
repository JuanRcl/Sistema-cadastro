using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using MySql.Data.MySqlClient;

namespace cadastro
{
    public partial class pesquisa : Form
    {
        Thread t;
        public pesquisa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conexao = new MySqlConnection("server=localhost;port=3306;User Id=root;database=cadastro;password= Lima3463#");
                conexao.Open();
                MySqlCommand comando = new MySqlCommand("select nome, email, cpf, estado from dados_pessoais where cpf = ?",conexao);
                comando.Parameters.Add("@cpf", MySqlDbType.VarChar, 11).Value = tb_cpf.Text;
                comando.CommandType = CommandType.Text;
                MySqlDataReader res;
                res = comando.ExecuteReader();
                res.Read();
                if(res.GetString(2) == tb_cpf.Text)
                {
                    lb_nome.Text = res.GetString(0);
                    lb_email.Text = res.GetString(1);
                    lb_cpf.Text = res.GetString(2);
                    lb_estado.Text = res.GetString(3);
                    conexao.Close();
                }
                else
                {
                    MessageBox.Show("Cliente encontrado, mas houve um erro!", "Erro inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("CPF não localizado ou falha da conexão, tente novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lb_nome.Text = "";
            lb_email.Text = "";
            lb_cpf.Text = "";
            lb_estado.Text = "";
            tb_cpf.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            t = new Thread(abrirJanela);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }
        private void abrirJanela(object obj)
        {
            Application.Run(new home());
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            t = new Thread(login);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }
        private void login(object obj)
        {
            Application.Run(new Form1());
        }
    }
}
