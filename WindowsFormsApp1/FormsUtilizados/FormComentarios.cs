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
    public partial class FormComentarios : Form
    {
        public UsuarioService service;
        Perfil perfil;
        Perfil perfilcorriendo;
        ImagenSeguidorBuilder imagen;
        bool tienelike;
        List<Comentario> comentarios;
        int index = 0;
        public FormComentarios(Perfil pc, Perfil p, ImagenSeguidorBuilder im, bool t)
        {
            InitializeComponent();
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SQLConnection"].ToString();
            service = new UsuarioService(connectionString);

            perfilcorriendo = pc;
            perfil = p;
            imagen = im;
            tienelike = t;
            string megusta = "C:\\temp\\megusta.png";
            string nomegusta = "C:\\temp\\nomegusta.png";
            if (tienelike == true)
                pictureBox3.ImageLocation = megusta;
            pictureBox1.ImageLocation = imagen._imagen.urlimagen;
            label1.Text = p.nombreusuario;
            comentarios = service.GetComentarios(im._imagen.idimagen);
            actualizarTexto();
            
        }
        public void actualizarTexto()
        {
            if (comentarios.Count == 0)
            {
                ocultarTodo();
            }
            else
            {
                if (comentarios.Count >= 4)
                {
                    primerComentario(index);
                    segundoComentario(index);
                    tercerComentario(index);
                    cuartoComentario(index);
                }
                else if (comentarios.Count == 3)
                {
                    primerComentario(index);
                    segundoComentario(index);
                    tercerComentario(index);
                }
                else if (comentarios.Count == 2)
                {
                    primerComentario(index);
                    segundoComentario(index);
                }
                else primerComentario(index);
            }
        }
        public void ocultarTodo()
        {
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
        }

        public void cuartoComentario(int i)
        {
            label2.Visible = true;
            label6.Visible = true;
            label2.Text = service.GetPerfilConId(comentarios[i].idusuarioquecomento).nombreusuario;
            label6.Text = comentarios[i].texto;
            index = i +1;
        }

        public void tercerComentario(int i)
        {
            label3.Visible = true;
            label7.Visible = true;
            label3.Text = service.GetPerfilConId(comentarios[i].idusuarioquecomento).nombreusuario;
            label7.Text = comentarios[i].texto;
            index = i + 1;
        }

        public void segundoComentario(int i)
        {
            label4.Visible = true;
            label8.Visible = true;
            label4.Text = service.GetPerfilConId(comentarios[i].idusuarioquecomento).nombreusuario;
            label8.Text = comentarios[i].texto;
            index = i + 1;
        }

        public void primerComentario(int i)
        {
            label5.Visible = true;
            label9.Visible = true;
            label5.Text = service.GetPerfilConId(comentarios[i].idusuarioquecomento).nombreusuario;
            label9.Text = comentarios[i].texto;
            index = i + 1;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Comentario com = new Comentario
            {
                idimagen = imagen._imagen.idimagen,
                texto = textBox1.Text,
                idusuarioquecomento = perfilcorriendo.idusuario
            };
            service.AddComentario(com);
            comentarios = service.GetComentarios(imagen._imagen.idimagen);
            actualizarTexto();
        }

        private void FormComentarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormPaginaPrincipal fp = new FormPaginaPrincipal(perfilcorriendo);
            fp.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string nomegusta = "C:\\Users\\Luis Zermeño\\source\\repos\\ProyectoFinal\\RedSocial\\WindowsFormsApp1\\nomegusta.png";
            string megusta = "C:\\Users\\Luis Zermeño\\source\\repos\\ProyectoFinal\\RedSocial\\WindowsFormsApp1\\megusta.png";
            if (pictureBox3.ImageLocation == nomegusta)
            {
                bool b = service.MasMeGusta(imagen._imagen.idimagen);
                pictureBox3.ImageLocation = megusta;
                imagen._imagen.likes += 1;
                label10.Text = imagen._imagen.likes.ToString() + " Me gusta";
            }
            else
            {
                bool b = service.MenosMeGusta(imagen._imagen.idimagen);
                imagen._imagen.likes -= 1;
                pictureBox3.ImageLocation = nomegusta;
                label10.Text = imagen._imagen.likes.ToString() + " Me gusta";
            }
        }
    }
}
