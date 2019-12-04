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
    public partial class FormVerPerfil : Form
    {
        public UsuarioService service;
        Perfil perfil;
        PerfilBuilder pp;
        PerfilDecorator pd;
        List<ImagenPropiaBuilder> imagenes = new List<ImagenPropiaBuilder>();
        int indeximagenes = 0;
        public FormVerPerfil(Perfil p)
        {
            InitializeComponent();
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SQLConnection"].ToString();
            service = new UsuarioService(connectionString);
            //FOTO CIRCULAR
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pictureBox1.Width - 3, pictureBox1.Height - 3);
            Region rg = new Region(gp);
            pictureBox1.Region = rg;

            perfil = p;
            label2.Text = perfil.nombreusuario;
            pp = service.GetImagenPerfil(perfil.idusuario);
            //SET IMAGEN DE PERFIL
            if (pp != null)
                pictureBox1.ImageLocation = pp._imagen.urlimagen;
            if (p.genero == "Hombre")
                pd = new PerfilHombre(p);
            else if (p.genero == "Mujer") pd = new PerfilMujer(p);
            else pd = new PerfilIndefinido(p);
            label1.Text = pd.Descripcion();

            label5.Text = (service.GetSeguidores(perfil.idusuario)).ToString() + " seguidores";
            label6.Text = (service.GetSiguiendo(perfil.idusuario)).ToString() + " siguiendo";
            //GET LISTA DE IMAGENES
            imagenes = service.GetImagenesPropias(perfil.idusuario);
            if (imagenes.Count == 0)
            {
                pictureBox2.Visible = true;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                pictureBox5.Visible = false;
                pictureBox6.Visible = false;
                pictureBox7.Visible = false;
            }
            else
            {
                pictureBox2.Visible = false;
                if (imagenes.Count >= 3)
                {
                    pictureBox3.Visible = true;
                    pictureBox4.Visible = true;
                    pictureBox5.Visible = true;
                    pictureBox3.ImageLocation = imagenes[0]._imagen.urlimagen;
                    pictureBox4.ImageLocation = imagenes[1]._imagen.urlimagen;
                    pictureBox5.ImageLocation = imagenes[2]._imagen.urlimagen;
                    indeximagenes += 3;
                    pictureBox6.Visible = true;
                    pictureBox7.Visible = true;
                }
                
                if(imagenes.Count == 2)
                {
                    pictureBox3.Visible = true;
                    pictureBox4.Visible = true;
                    pictureBox3.ImageLocation = imagenes[0]._imagen.urlimagen;
                    pictureBox4.ImageLocation = imagenes[1]._imagen.urlimagen;
                }

                if (imagenes.Count == 1)
                {
                    pictureBox3.Visible = true;
                    pictureBox3.ImageLocation = imagenes[0]._imagen.urlimagen;
                }
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if(result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                pp._imagen.urlimagen = file;
                pp._imagen.fecha = DateTime.Now;
                pp._imagen.idusuario = perfil.idusuario;
                bool b = service.SetImagenPerfil(pp);
                if(b == true)
                    pictureBox1.ImageLocation = pp._imagen.urlimagen;
            }
        }

        private void FormVerPerfil_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormPaginaPrincipal fp = new FormPaginaPrincipal(perfil);
            indeximagenes = 0;
            fp.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            perfil.setOfline();
            foreach (Form f in Application.OpenForms)
            {
                    f.Hide();
            }
            FormIniciodeSesion fp = new FormIniciodeSesion();
            fp.Show();
            //this.Hide();
        }
    }
}
