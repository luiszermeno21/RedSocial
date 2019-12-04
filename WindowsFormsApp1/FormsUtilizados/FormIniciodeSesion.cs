using BusinnesLogicLayer.Services;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.FormsUtilizados
{
    public partial class FormIniciodeSesion : Form
    {
        public UsuarioService service;
        public FormIniciodeSesion()
        {
            InitializeComponent();
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            this.label3.ForeColor = Color.Red;
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SQLConnection"].ToString();
            service = new UsuarioService(connectionString);
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
            Usuario user = new Usuario { correo = textBox1.Text, contraseña = textBox2.Text };
            string h = service.GetContraseña(user.correo,user.contraseña);
            if (h == "Bienvenido")
            {
                Perfil p = service.GetPerfil(user.correo);
                FormPaginaPrincipal f2 = new FormPaginaPrincipal(p);
                f2.Show();
                this.Hide();
            }
            else
            {
                label3.Visible = true;
            }
        }

        private void FormIniciodeSesion_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
