using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinnesLogicLayer.Services;
using DomainLayer.Models;

namespace WindowsFormsApp1.UserControls
{
    public partial class MenuRegistrar : UserControl
    {
        public UsuarioService service;

        public MenuRegistrar()
        {
            InitializeComponent();
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SQLConnection"].ToString();
            service = new UsuarioService(connectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            Usuario user = new Usuario { correo = textBox1.Text, contraseña = textBox4.Text };
            string h = service.AddUsuario(user);
            if (h != "Errror creating Usuario")
            {
                int a = service.GetUsuarioId(user.correo);
                Perfil perfil = new Perfil { nombre = textBox2.Text, nombreusuario = textBox3.Text, idusuario = a };
                service.AddPerfil(perfil);
            }
            else
            {
                label1.Visible = true;
                label1.Text = "Usuario o nombre de usuario ya existente";
            }
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
    }
}
