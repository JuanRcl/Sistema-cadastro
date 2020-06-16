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
    public partial class atualizar : Form
    {
        Thread t;
        public atualizar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            void limpar()
            {
                tb_cpf.Text = "";
                tb_nome.Text = "";
                tb_email.Text = "";
                cb_estado.Text = "";
            }
            try
            {
                MySqlConnection conexao = new MySqlConnection("server=localhost;port=3306;User Id=root;database=cadastro;password= ");
                conexao.Open();
                MySqlCommand comando = new MySqlCommand("select cpf from dados_pessoais where cpf = ?", conexao);
                comando.Parameters.Add("@cpf", MySqlDbType.VarChar, 11).Value = tb_cpf.Text;
                comando.CommandType = CommandType.Text;
                MySqlDataReader res;
                res = comando.ExecuteReader();
                res.Read();
                if (res.GetString(0).ToString() == tb_cpf.Text.ToString())
                {
                    try {

                        MySqlConnection conexao2 = new MySqlConnection("server=localhost;port=3306;User Id=root;database=cadastro;password= ");
                        conexao2.Open();
                        MySqlCommand comando2 = new MySqlCommand("update dados_pessoais set nome = ?, email = ?, estado = ? where cpf = ?", conexao2);
                        comando2.Parameters.Add("@nome", MySqlDbType.VarChar, 50).Value = tb_nome.Text;
                        comando2.Parameters.Add("@email", MySqlDbType.VarChar, 20).Value = tb_email.Text;
                        comando2.Parameters.Add("@estado", MySqlDbType.VarChar, 2).Value = cb_estado.SelectedItem.ToString();
                        comando2.Parameters.Add("@cpf", MySqlDbType.VarChar, 11).Value = tb_cpf.Text;
                        comando2.CommandType = CommandType.Text;
                        comando2.ExecuteNonQuery();
                        conexao2.Close();
                        conexao.Close();
                        MessageBox.Show("Dados atualizados!", "Operação Concluída", MessageBoxButtons.OK);
                        limpar();

                    }
                    catch
                    {
                        MessageBox.Show("Cliente encontrado, mas a ação não foi realizada!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Algo deu errado, tente novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            tb_cpf.Text = "";
            tb_nome.Text = "";
            tb_email.Text = "";
            cb_estado.Text = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            t = new Thread(login);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }
        private void login(object obj)
        {
            Application.Run(new home());
        }
    }
}
