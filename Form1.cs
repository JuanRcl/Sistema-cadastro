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
           

            if (tb1.Text == "admin" && tb2.Text == "123")
            {
                this.Close();
                t = new Thread(abrirJanela);
                t.SetApartmentState(ApartmentState.STA);
                t.Start();
            }
            else
            {
                MessageBox.Show("Usuário ou senha inválidos, tente novamente!","Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void abrirJanela(object obj)
        {
            Application.Run(new Form2());
        }
        
       
    }
}
