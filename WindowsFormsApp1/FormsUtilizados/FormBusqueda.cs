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
    public partial class FormBusqueda : Form
    {
        public UsuarioService service;
        public Perfil perfil;
        public List<Perfil> lista;
        public List<PerfilBuilder> listaimagenesperfil;
        public int indexperfila = 0;
        public int indexperfilb = 1;
        public int indexperfilc = 2;
        public int indexperfild = 3;

        public FormBusqueda(Perfil p, List<Perfil> l)
        {
            InitializeComponent();
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SQLConnection"].ToString();
            service = new UsuarioService(connectionString);
            perfil = p;
            lista = l;
            listaimagenesperfil = new List<PerfilBuilder>();
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pictureBox1.Width - 3, pictureBox1.Height - 3);
            Region rg = new Region(gp);
            pictureBox1.Region = rg;
            pictureBox2.Region = rg;
            pictureBox3.Region = rg;
            pictureBox4.Region = rg;
            // GET IMAGENES DE PERFILES
            foreach(Perfil aux in lista)
            {
                listaimagenesperfil.Add(service.GetImagenPerfil(aux.idusuario));
            }
            if(lista.Count != 0)
            {
                if (lista.Count >= 4)
                {
                    if(lista.Count > 4)
                    {
                        pictureBox5.Visible = true;
                        pictureBox6.Visible = true;
                    }

                    pictureBox1.Visible = true;
                    label1.Visible = true;
                    pictureBox2.Visible = true;
                    label2.Visible = true;
                    pictureBox3.Visible = true;
                    label3.Visible = true;
                    pictureBox4.Visible = true;
                    label4.Visible = true;
                    label5.Visible = false;
                    
                    pictureBox1.ImageLocation = listaimagenesperfil[indexperfila]._imagen.urlimagen;
                    label1.Text = lista[indexperfila].nombreusuario;

                    pictureBox2.ImageLocation = listaimagenesperfil[indexperfilb]._imagen.urlimagen;
                    label2.Text = lista[indexperfilb].nombreusuario;

                    pictureBox3.ImageLocation = listaimagenesperfil[indexperfilc]._imagen.urlimagen;
                    label3.Text = lista[indexperfilc].nombreusuario;

                    pictureBox4.ImageLocation = listaimagenesperfil[indexperfild]._imagen.urlimagen;
                    label4.Text = lista[indexperfild].nombreusuario;
                }
                else if(lista.Count == 3)
                {
                    pictureBox1.Visible = true;
                    label1.Visible = true;
                    pictureBox2.Visible = true;
                    label2.Visible = true;
                    pictureBox3.Visible = true;
                    label3.Visible = true;
                    label5.Visible = false;

                    pictureBox1.ImageLocation = listaimagenesperfil[indexperfila]._imagen.urlimagen;
                    label1.Text = lista[indexperfila].nombreusuario;

                    pictureBox2.ImageLocation = listaimagenesperfil[indexperfilb]._imagen.urlimagen;
                    label2.Text = lista[indexperfilb].nombreusuario;

                    pictureBox3.ImageLocation = listaimagenesperfil[indexperfilc]._imagen.urlimagen;
                    label3.Text = lista[indexperfilc].nombreusuario;
                }
                else if(lista.Count == 2)
                {
                    pictureBox1.Visible = true;
                    label1.Visible = true;
                    pictureBox2.Visible = true;
                    label2.Visible = true;
                    label5.Visible = false;

                    pictureBox1.ImageLocation = listaimagenesperfil[indexperfila]._imagen.urlimagen;
                    label1.Text = lista[indexperfila].nombreusuario;

                    pictureBox2.ImageLocation = listaimagenesperfil[indexperfilb]._imagen.urlimagen;
                    label2.Text = lista[indexperfilb].nombreusuario;
                }
                else
                {
                    pictureBox1.Visible = true;
                    label1.Visible = true;
                    label5.Visible = false;

                    pictureBox1.ImageLocation = listaimagenesperfil[indexperfila]._imagen.urlimagen;
                    label1.Text = lista[indexperfila].nombreusuario;
                }
            }
            else
            {
                label5.Visible = true;
            }
        }

        private void FormBusqueda_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if(indexperfild + 4 <= listaimagenesperfil.Count)
            {
                indexperfila += 4;
                indexperfilb += 4;
                indexperfilc += 4;
                indexperfild += 4;
                pictureBox1.ImageLocation = listaimagenesperfil[indexperfila]._imagen.urlimagen;
                label1.Text = lista[indexperfila].nombreusuario;

                pictureBox2.ImageLocation = listaimagenesperfil[indexperfilb]._imagen.urlimagen;
                label2.Text = lista[indexperfilb].nombreusuario;

                pictureBox3.ImageLocation = listaimagenesperfil[indexperfilc]._imagen.urlimagen;
                label3.Text = lista[indexperfilc].nombreusuario;

                pictureBox4.ImageLocation = listaimagenesperfil[indexperfild]._imagen.urlimagen;
                label4.Text = lista[indexperfild].nombreusuario;
            }
            else if(indexperfilc + 4 <= listaimagenesperfil.Count)
            {
                indexperfila += 4;
                indexperfilb += 4;
                indexperfilc += 4;
                pictureBox1.ImageLocation = listaimagenesperfil[indexperfila]._imagen.urlimagen;
                label1.Text = lista[indexperfila].nombreusuario;

                pictureBox2.ImageLocation = listaimagenesperfil[indexperfilb]._imagen.urlimagen;
                label2.Text = lista[indexperfilb].nombreusuario;

                pictureBox3.ImageLocation = listaimagenesperfil[indexperfilc]._imagen.urlimagen;
                label3.Text = lista[indexperfilc].nombreusuario;
            }
            else if(indexperfilb + 4 == listaimagenesperfil.Count)
            {
                indexperfila += 4;
                indexperfilb += 4;
                pictureBox1.ImageLocation = listaimagenesperfil[indexperfila]._imagen.urlimagen;
                label1.Text = lista[indexperfila].nombreusuario;

                pictureBox2.ImageLocation = listaimagenesperfil[indexperfilb]._imagen.urlimagen;
                label2.Text = lista[indexperfilb].nombreusuario;
            }
            else
            {
                indexperfila += 4;
                pictureBox1.ImageLocation = listaimagenesperfil[indexperfila]._imagen.urlimagen;
                label1.Text = lista[indexperfila].nombreusuario;
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (indexperfild - 4 >= 4)
            {
                indexperfila -= 4;
                indexperfilb -= 4;
                indexperfilc -= 4;
                indexperfild -= 4;
                pictureBox1.ImageLocation = listaimagenesperfil[indexperfila]._imagen.urlimagen;
                label1.Text = lista[indexperfila].nombreusuario;

                pictureBox2.ImageLocation = listaimagenesperfil[indexperfilb]._imagen.urlimagen;
                label2.Text = lista[indexperfilb].nombreusuario;

                pictureBox3.ImageLocation = listaimagenesperfil[indexperfilc]._imagen.urlimagen;
                label3.Text = lista[indexperfilc].nombreusuario;

                pictureBox4.ImageLocation = listaimagenesperfil[indexperfild]._imagen.urlimagen;
                label4.Text = lista[indexperfild].nombreusuario;
            }
            else if (indexperfilc - 4 >= 3)
            {
                indexperfila -= 4;
                indexperfilb -= 4;
                indexperfilc -= 4;
                pictureBox1.ImageLocation = listaimagenesperfil[indexperfila]._imagen.urlimagen;
                label1.Text = lista[indexperfila].nombreusuario;

                pictureBox2.ImageLocation = listaimagenesperfil[indexperfilb]._imagen.urlimagen;
                label2.Text = lista[indexperfilb].nombreusuario;

                pictureBox3.ImageLocation = listaimagenesperfil[indexperfilc]._imagen.urlimagen;
                label3.Text = lista[indexperfilc].nombreusuario;
            }
            else if(indexperfilc - 4 == 2)
            {
                indexperfila -= 4;
                indexperfilb -= 4;
                pictureBox1.ImageLocation = listaimagenesperfil[indexperfila]._imagen.urlimagen;
                label1.Text = lista[indexperfila].nombreusuario;

                pictureBox2.ImageLocation = listaimagenesperfil[indexperfilb]._imagen.urlimagen;
                label2.Text = lista[indexperfilb].nombreusuario;
            }
            else
            {
                indexperfila -= 4;
                pictureBox1.ImageLocation = listaimagenesperfil[indexperfila]._imagen.urlimagen;
                label1.Text = lista[indexperfila].nombreusuario;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            FromVerPerfilDeOtro fv = new FromVerPerfilDeOtro(service.GetPerfilConId(lista[indexperfila].idusuario), perfil);
            fv.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            FromVerPerfilDeOtro fv = new FromVerPerfilDeOtro(service.GetPerfilConId(lista[indexperfilb].idusuario), perfil);
            fv.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            FromVerPerfilDeOtro fv = new FromVerPerfilDeOtro(service.GetPerfilConId(lista[indexperfilc].idusuario), perfil);
            fv.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            FromVerPerfilDeOtro fv = new FromVerPerfilDeOtro(service.GetPerfilConId(lista[indexperfild].idusuario), perfil);
            fv.Show();
            this.Hide();
        }
    }
}
