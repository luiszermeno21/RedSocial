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
    public partial class FormPaginaPrincipal : Form
    {
        public UsuarioService service;
        Perfil p;
        List<ImagenSeguidorBuilder> imagenes = new List<ImagenSeguidorBuilder>();
        int indexperfila = 0;
        int indexperfilb = 1;
        int index = 0;
        List<Historia> historias;
        public FormPaginaPrincipal(Perfil perfil)
        {
            InitializeComponent();
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SQLConnection"].ToString();
            service = new UsuarioService(connectionString);
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            p = perfil;
            label1.Text = p.nombre;
            label2.Text = "@" + p.nombreusuario;
            p.setOnline();
            label3.Text = p.setOnline();

            //FOTO CIRCULAR
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pictureBox7.Width - 3, pictureBox7.Height - 3);
            Region rg = new Region(gp);
            pictureBox7.Region = rg;
            pictureBox8.Region = rg;
            System.Drawing.Drawing2D.GraphicsPath gp1 = new System.Drawing.Drawing2D.GraphicsPath();
            gp1.AddEllipse(0, 0, pictureBox16.Width - 3, pictureBox16.Height - 3);
            Region rg1 = new Region(gp1);
            pictureBox16.Region = rg1;
            pictureBox16.Visible = true;
            pictureBox17.Region = rg1;
            pictureBox17.Visible = true;
            pictureBox18.Region = rg1;
            pictureBox18.Visible = true;

            //Get Imagenes de usuarios seguidos
            imagenes = service.GetImagenesSiguiendo(p.idusuario);

            if (imagenes.Count == 0)
            {
                ocultarTodo();
            }
            else
            {
                if (imagenes.Count > 2)
                {
                    activarFlechas();
                }
                if (imagenes.Count >= 2)
                {
                    ponerImagenA(index);
                    ponerImagenB(index);
                }

                else
                {
                    ponerImagenA(index);
                }
            }

            //historias
            historias = service.GetHistorias(perfil.idusuario);
            ActualizarHistorias(historias);
            label8.Visible = true;
        }

        private void FormPaginaPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FormVerPerfil v = new FormVerPerfil(p);
            v.Show();
            this.Hide();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            string nomegusta = "C:\\Users\\Luis Zermeño\\source\\repos\\ProyectoFinal\\RedSocial\\WindowsFormsApp1\\nomegusta.png";
            string megusta = "C:\\Users\\Luis Zermeño\\source\\repos\\ProyectoFinal\\RedSocial\\WindowsFormsApp1\\megusta.png";
            string ads = pictureBox12.ImageLocation;
            if (pictureBox12.ImageLocation == nomegusta)
            {
                bool b = service.MasMeGusta(imagenes[index-2]._imagen.idimagen);
                pictureBox12.ImageLocation = megusta;
                imagenes[index-2]._imagen.likes += 1;
                label6.Text = imagenes[index-2]._imagen.likes.ToString() + " Me gusta";
            }
            else
            {
                bool b = service.MenosMeGusta(imagenes[index-2]._imagen.idimagen);
                imagenes[index-2]._imagen.likes -= 1;
                pictureBox12.ImageLocation = nomegusta;
                label6.Text = imagenes[index-2]._imagen.likes.ToString() + " Me gusta";
            }
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            string nomegusta = "C:\\Users\\Luis Zermeño\\source\\repos\\ProyectoFinal\\RedSocial\\WindowsFormsApp1\\nomegusta.png";
            string megusta = "C:\\Users\\Luis Zermeño\\source\\repos\\ProyectoFinal\\RedSocial\\WindowsFormsApp1\\megusta.png";
            if (pictureBox12.ImageLocation == nomegusta)
            {
                bool b = service.MasMeGusta(imagenes[index-1]._imagen.idimagen);
                imagenes[index-1]._imagen.likes += 1;
                if (b)
                    pictureBox13.ImageLocation = megusta;
                label7.Text = imagenes[index-1]._imagen.likes.ToString() + " Me gusta";
            }
            else
            {
                bool b = service.MenosMeGusta(imagenes[index-1]._imagen.idimagen);
                imagenes[index-1]._imagen.likes -= 1;
                if (b)
                    pictureBox13.ImageLocation = nomegusta;
                label7.Text = imagenes[index-1]._imagen.likes.ToString() + " Me gusta";
            }
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            if(imagenes.Count > 2)
            {
                if (index - 2 >= 0)
                {
                    index -= 2;
                    ponerImagenA(index);
                    ponerImagenB(index);
                }
                else
                {
                    index = 0;
                    ponerImagenA(index);
                    ponerImagenB(index);
                    pictureBox15.Visible = false;
                }
                
            }
            if(imagenes.Count <= 2 && index%2 != 0 )
            {
                if(index-2 >=0)
                {
                    index -= 2;
                    ponerImagenA(index);
                    ponerImagenB(index);
                }
                index = 0;
                ponerImagenA(index);
                ponerImagenB(index);
                pictureBox15.Visible = false;
            }
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            if(imagenes.Count > index && index%2 == 0)
            {
                ponerImagenA(index);
                if (imagenes.Count > 3 && index % 2 != 0)
                    ponerImagenB(index);
                else desactivarImagenB();
            }
            
            
        }

        private void label4_Click(object sender, EventArgs e)
        {
            FromVerPerfilDeOtro fr = new FromVerPerfilDeOtro(service.GetPerfilConId(imagenes[index-1]._imagen.idusuario),p);
            fr.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            FromVerPerfilDeOtro fr = new FromVerPerfilDeOtro(service.GetPerfilConId(imagenes[index-2]._imagen.idusuario), p);
            fr.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Perfil> lista = service.GetAllPerfiles(textBox1.Text, p.idusuario);
            FormBusqueda fb = new FormBusqueda(p, lista);
            fb.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                Historia h = new Historia();
                string file = openFileDialog1.FileName;
                h.urlimagen = file;
                h.fecha = DateTime.Now;
                h.idusuario = p.idusuario;

                bool b = service.AddHistoria(h);
                historias = service.GetHistorias(p.idusuario);
                ActualizarHistorias(historias);
                
            }
        }

        public void ActualizarHistorias(List<Historia> his)
        {
            if (his.Count == 0)
            {
                pictureBox17.Visible = false;
                label9.Visible = false;
                pictureBox18.Visible = false;
                label10.Visible = false;
            }
            else
            {
                if (his.Count > 2)
                {
                    pictureBox17.Visible = true;
                    label9.Visible = true;
                    pictureBox18.Visible = true;
                    label10.Visible = true;
                }

                else if (his.Count == 2)
                {
                    pictureBox17.Visible = true;
                    label9.Visible = true;
                    pictureBox18.Visible = true;
                    label10.Visible = true;
                    pictureBox17.ImageLocation = service.GetImagenPerfil(his[indexperfila].idusuario)._imagen.urlimagen;
                    label9.Text = service.GetPerfilConId(his[indexperfila].idusuario).nombreusuario;
                    pictureBox18.ImageLocation = service.GetImagenPerfil(his[indexperfilb].idusuario)._imagen.urlimagen;
                    label10.Text = service.GetPerfilConId(his[indexperfilb].idusuario).nombreusuario;
                }
                else
                {
                    pictureBox17.Visible = true;
                    label9.Visible = true;
                    pictureBox18.Visible = false;
                    label10.Visible = false;
                    pictureBox17.ImageLocation = service.GetImagenPerfil(his[indexperfila].idusuario)._imagen.urlimagen;
                    label9.Text = service.GetPerfilConId(his[indexperfila].idusuario).nombreusuario;
                }
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            FormHistoria fh = new FormHistoria(historias[indexperfila],p);
            fh.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            FormHistoria fh = new FormHistoria(historias[indexperfilb],p);
            fh.Show();
            this.Hide();
        }

        public void ponerImagenA(int i)
        {
            pictureBox4.Visible = true;
            pictureBox7.Visible = true;
            pictureBox6.Visible = true;
            label4.Visible = true;
            pictureBox10.Visible = true;
            pictureBox12.Visible = true;
            label6.Visible = true;
            pictureBox20.Visible = true;

            pictureBox4.ImageLocation = imagenes[i]._imagen.urlimagen;
            Perfil aux = service.GetPerfilConId(imagenes[i]._imagen.idusuario);
            pictureBox6.Visible = true;
            label4.Text = aux.nombreusuario;
            PerfilBuilder ip2 = service.GetImagenPerfil(imagenes[i]._imagen.idusuario);
            ip2._imagen.idusuario = imagenes[i]._imagen.idusuario;
            pictureBox7.Visible = true;
            pictureBox7.ImageLocation = ip2._imagen.urlimagen;
            label6.Text = imagenes[i]._imagen.likes.ToString() + " Me gusta";
            
            i++;
            index = i;
        }

        public void ponerImagenB(int i)
        {
            pictureBox5.Visible = true;
            pictureBox8.Visible = true;
            pictureBox9.Visible = true;
            label5.Visible = true;
            pictureBox11.Visible = true;
            pictureBox13.Visible = true;
            label7.Visible = true;
            pictureBox21.Visible = true;

            pictureBox5.ImageLocation = imagenes[i]._imagen.urlimagen;
            Perfil aux2 = service.GetPerfilConId(imagenes[i]._imagen.idusuario);
            pictureBox9.Visible = true;
            label5.Text = aux2.nombreusuario;
            PerfilBuilder ip3 = service.GetImagenPerfil(imagenes[i]._imagen.idusuario);
            ip3._imagen.idusuario = imagenes[i]._imagen.idusuario;
            pictureBox8.Visible = true;
            pictureBox8.ImageLocation = ip3._imagen.urlimagen;
            pictureBox8.Visible = true;
            pictureBox8.ImageLocation = ip3._imagen.urlimagen;
            label7.Text = imagenes[i]._imagen.likes.ToString() + " Me gusta";
            i++;
            index = i;
            
        }

        public void activarFlechas()
        {
            pictureBox15.Visible = true;
            pictureBox14.Visible = true;
        }

        public void ocultarTodo()
        {
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            pictureBox10.Visible = false;
            pictureBox11.Visible = false;
            pictureBox12.Visible = false;
            pictureBox13.Visible = false;
            pictureBox14.Visible = false;
            pictureBox15.Visible = false;
            pictureBox20.Visible = false;
            pictureBox21.Visible = false;
        }

        public void desactivarImagenB()
        {
            pictureBox5.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            label5.Visible = false;
            pictureBox11.Visible = false;
            pictureBox13.Visible = false;
            pictureBox14.Visible = false;
            label7.Visible = false;
            pictureBox21.Visible = false;
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                 
                string file = openFileDialog1.FileName;
                bool b = service.AddImagen(file,p.idusuario);
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {

                string file = openFileDialog1.FileName;
                bool b = service.AddImagen(file, p.idusuario);
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                Historia h = new Historia();
                string file = openFileDialog1.FileName;
                h.urlimagen = file;
                h.fecha = DateTime.Now;
                h.idusuario = p.idusuario;

                bool b = service.AddHistoria(h);
                historias = service.GetHistorias(p.idusuario);
                ActualizarHistorias(historias);

            }
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            if (imagenes.Count - 2 < 0)
                index = 0;
            else index -= 2;
            string megusta = "C:\\Users\\Luis Zermeño\\source\\repos\\ProyectoFinal\\RedSocial\\WindowsFormsApp1\\megusta.png";
            bool a = false;
            if (pictureBox12.ImageLocation == megusta)
                a = true;
            FormComentarios fc = new FormComentarios(p, service.GetPerfilConId(imagenes[index]._imagen.idusuario), imagenes[index], a);
            fc.Show();
            this.Hide();
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            if (imagenes.Count - 1 < 1)
                index = 1;
            else index -= 1;
            string megusta = "C:\\Users\\Luis Zermeño\\source\\repos\\ProyectoFinal\\RedSocial\\WindowsFormsApp1\\megusta.png";
            bool a = false;
            if (pictureBox13.ImageLocation == megusta)
                a = true;
            FormComentarios fc = new FormComentarios(p, service.GetPerfilConId(imagenes[index-1]._imagen.idusuario), imagenes[index-1], a);
            fc.Show();
            this.Hide();
        }
    }
}
