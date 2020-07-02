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

namespace cadastro
{
    public partial class redefinir : Form
    {
        Thread t;
        public redefinir()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conexao = new MySqlConnection("server=localhost;port=3306;User Id=root;database=usuarios;password= Lima3463#");
                conexao.Open();
                MySqlCommand comando = new MySqlCommand("select login from dados where login = ?", conexao);
                comando.Parameters.Add("@login", MySqlDbType.VarChar, 30).Value = tb_user.Text;
                comando.CommandType = CommandType.Text;
                MySqlDataReader logg;
                logg = comando.ExecuteReader();
                logg.Read();
                
                if (logg.GetString(0).ToString() == tb_user.Text.ToString())
                {


                    try
                    {
                        MySqlConnection conexao2 = new MySqlConnection("server=localhost;port=3306;User Id=root;database=usuarios;password= Lima3463#");
                        conexao2.Open();
                        MySqlCommand comando2 = new MySqlCommand("update dados set senha = ?, cpf = ?, nasc = ? where login = ?", conexao2);
                        comando2.Parameters.Add("@senha", MySqlDbType.VarChar, 8).Value = tb_senha.Text;
                        comando2.Parameters.Add("@cpf", MySqlDbType.VarChar, 11).Value = tb_cpf.Text;
                        comando2.Parameters.Add("@nasc", MySqlDbType.VarChar, 10).Value = tb_nasc.Text;
                        comando2.Parameters.Add("@login", MySqlDbType.VarChar, 30).Value = tb_user.Text;
                        comando2.CommandType = CommandType.Text;
                        comando2.ExecuteNonQuery();
                        conexao2.Close();
                        conexao.Close();
                        MessageBox.Show("Senha redefinida!", "Concluido", MessageBoxButtons.OK);
                        this.Close();
                        t = new Thread(abrirJanela);
                        t.SetApartmentState(ApartmentState.STA);
                        t.Start();

                    }

                    catch
                    {
                        MessageBox.Show("Algo deu errado, tente novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                else
                {
                    MessageBox.Show("Algo deu errado! Tente mais uma vez.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Login não encontrado nos registros!", "Login não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            

        }
        private void abrirJanela(object obj)
        {
            Application.Run(new Form1());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            t = new Thread(homep);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }
        private void homep(object obj)
        {
            Application.Run(new Form1());
        }
    }
}
