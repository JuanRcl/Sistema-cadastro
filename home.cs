﻿using System;
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
    public partial class home : Form
    {
        Thread t;
        public home()
        {
            InitializeComponent();
        }

        private void tbn_cadastrar_Click(object sender, EventArgs e)
        {
            this.Close();
            t = new Thread(abrirJanela);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }
        private void abrirJanela(object obj)
        {
            Application.Run(new Form2());
        }

        private void tbn_deletar_Click(object sender, EventArgs e)
        {
            this.Close();
            t = new Thread(abrirJanela2);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }
        private void abrirJanela2(object obj)
        {
            Application.Run(new Form3());
        }

        private void btn_atualizar_Click(object sender, EventArgs e)
        {
            this.Close();
            t = new Thread(tatualizar);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }
        private void tatualizar(object obj)
        {
            Application.Run(new atualizar());
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

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            t = new Thread(acesso);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }
        private void acesso(object obj)
        {
            Application.Run(new Form1());
        }
        private void btn_pesquisar_Click(object sender, EventArgs e)
        {
            this.Close();
            t = new Thread(pesquisar);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }
        private void pesquisar(object obj)
        {
            Application.Run(new pesquisa());
        }
    }
}
