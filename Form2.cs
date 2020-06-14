using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading;

namespace cadastro
{
    public partial class Form2 : Form
    {
        Thread t3;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            void limpar()
            {
                tb1.Text = "";
                tb2.Text = "";
                tb3.Text = "";
                cb1.Text = string.Empty;
            }
            int verifica_cpf()
            {
                if(tb3.Text.Length != 11)
                {
                  
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            try
            {
                MySqlConnection conexao = new MySqlConnection("server=localhost;port=3306;User Id=root;database=cadastro;password= ");
                conexao.Open();
                //DADOS DA TABELA: NOME, EMAIL, CPF, ESTADO
                MySqlCommand comando = new MySqlCommand("insert into dados_pessoais values(?, ?, ?, ?)", conexao);
                comando.Parameters.Add("@nome", MySqlDbType.VarChar, 50).Value = tb1.Text;
                comando.Parameters.Add("@email", MySqlDbType.VarChar, 2).Value = tb2.Text;
                comando.Parameters.Add("@cpf", MySqlDbType.VarChar, 11).Value = tb3.Text;
                comando.Parameters.Add("@estado", MySqlDbType.VarChar, 2).Value = cb1.SelectedItem.ToString();
                if (verifica_cpf() == 1)
                {
                    comando.ExecuteNonQuery();
                    conexao.Close();
                    MessageBox.Show("Cadastro realizado com sucesso!","Operação Concluída", MessageBoxButtons.OK);
                    limpar();
                   
                }
                else if(verifica_cpf() == 0)
                {
                    MessageBox.Show("O campo CPF está inválido, digite novamente!","Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tb3.Text = "";
                }
            }
            catch
            {
                MessageBox.Show("Cadastro NÃO realizado, tente novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

       
        private void abrirJanela(object obj)
        {
            Application.Run(new Form3());
        }

        private void linkSair_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }

        private void btn_voltar_Click(object sender, EventArgs e)
        {
            this.Close();
            t3 = new Thread(abrirJanela3);
            t3.SetApartmentState(ApartmentState.STA);
            t3.Start();
        }
        private void abrirJanela3(object obj)
        {
            Application.Run(new home());
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
