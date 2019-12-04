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
using WindowsFormsApp1.FormsUtilizados;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public UsuarioService service;
        public Form1()
        {
            InitializeComponent();
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            this.label3.ForeColor = Color.Red;
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SQLConnection"].ToString();
            service = new UsuarioService(connectionString);
            comboBox1.DataSource = Enum.GetValues(typeof(GeneroEnum));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
        }

        private void label2_Click(object sender, EventArgs e)
        {
            FormIniciodeSesion f1 = new FormIniciodeSesion();
            f1.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            label3.Visible = false;
            Usuario user = new Usuario { correo = textBox1.Text, contraseña = textBox4.Text };
            string h = service.AddUsuario(user);
            if (h != "Errror creating Usuario")
            {
                int a = service.GetUsuarioId(user.correo);
                string str = comboBox1.Text;
                Perfil perfil = new Perfil { nombre = textBox2.Text, nombreusuario = textBox3.Text, idusuario = a ,genero = str};
                service.AddPerfil(perfil);
                FormPaginaPrincipal f2 = new FormPaginaPrincipal(perfil);
                f2.Show();
                this.Hide();
            }
            else
            {
                label3.Visible = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
