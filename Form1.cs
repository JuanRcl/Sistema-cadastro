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
using System.Runtime.CompilerServices;
using System.Linq.Expressions;

namespace cadastro
{
    public partial class Form1 : Form
    {
        Thread t;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                //Inicia a conexao
                MySqlConnection conexao = new MySqlConnection("server=localhost;port=3306;User Id=root;database=usuarios;password= Lima3463#");
                conexao.Open();
                //Isere o comando que vai pro bando de dados
                MySqlCommand comando = new MySqlCommand("select login, senha from dados where login = ?", conexao);
                //Passa os parametros do que vai ser enviado e recebido do bd
                comando.Parameters.Add("@login", MySqlDbType.VarChar, 30).Value = tb1.Text;
                comando.Parameters.Add("@senha", MySqlDbType.VarChar, 8).Value = tb2.Text;
                //Executa o comando
                comando.CommandType = CommandType.Text;
                //Recebe o conteudo que retorna do bd
                MySqlDataReader res;
                res = comando.ExecuteReader();
                res.Read();

                if (tb1.Text.ToString() == res.GetString(0) && tb2.Text.ToString() == res.GetString(1))  //VERIFICAR LOGIN E SENHA NO BANCO DE DADOS PARA TER ACESSO
                {
                    this.Close();
                    t = new Thread(abrirJanela);
                    t.SetApartmentState(ApartmentState.STA);
                    t.Start();
                    conexao.Close();



                }
                else
                {
                    MessageBox.Show("Usuário ou senha inválidos, tente novamente!", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Console.WriteLine("O login correta é {0} e a senha é {1}", res.GetString(0), res.GetString(1));
                   
                }
            }

            catch
            {
                MessageBox.Show("Usuário ou senha inválidos, tente novamente!", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            }

            }
        private void abrirJanela(object obj)
        {
            Application.Run(new home());
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            t = new Thread(abreJanela);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }
        private void abreJanela(object obj)
        {
            Application.Run(new cadastrar());
        }

        private void lb_redefinir_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            t = new Thread(openJanela);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }
        private void openJanela(object obj)
        {
            Application.Run(new redefinir());
        }
    }
}
