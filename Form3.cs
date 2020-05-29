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

namespace cadastro
{
    public partial class Form3 : Form
    {
        Thread t2;
        public Form3()
        {
            InitializeComponent();
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {   
                int vericpf(){
                if(tb3.Text.Length != 11)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            void limpar()
            {
                tb3.Text = "";
            }
            try
            {
                //Conectando com o banco de dados, inserindo os dados do servidor e do banco de dados
                //A password(senha do servidor) esta vazia pois e a senha padrao do servidor XAMPP que eu uso, mas -
                //caso tenha senha é so colocar a senha no espaco vazio

                MySqlConnection conexao = new MySqlConnection("server=localhost;port=3306;User Id=root;database=cadastro;password= ");
                conexao.Open();

                MySqlCommand cmdDeletar = new MySqlCommand("delete from dados_pessoais where cpf = ?", conexao);    
                cmdDeletar.Parameters.Add("@cpf", MySqlDbType.VarChar, 11).Value = tb3.Text;
                cmdDeletar.CommandType = CommandType.Text;

                if (vericpf() == 1)
                {

                    MessageBox.Show("Campo CPF inválido, digite novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    limpar();
                }
                else
                {

                    if (MessageBox.Show("Tem certeza que deseja excluir o usuário permanentemente?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        cmdDeletar.ExecuteNonQuery();
                        conexao.Close();
                        MessageBox.Show("O usuário foi deletado com sucesso!", "Operação Concluída", MessageBoxButtons.OK);
                        limpar();
                    }
                    else
                    {
                        limpar();
                    }
                }

            }
            catch
            {
                MessageBox.Show("Operação NÃO concluída, tente novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
               
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
        private void linkVoltar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            Thread t2 = new Thread(abrirJanela);
            t2.SetApartmentState(ApartmentState.STA);
            t2.Start();
        }
        private void abrirJanela(object obj)
        {
            Application.Run(new Form2());
        }

        private void linkSair_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }
    }
}
