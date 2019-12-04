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
    public partial class FromVerPerfilDeOtro : Form
    {
        public UsuarioService service;
        Perfil perfil;
        Perfil perfilcorriendo;
        PerfilBuilder pp;
        PerfilDecorator pd;
        List<ImagenPropiaBuilder> imagenes = new List<ImagenPropiaBuilder>();
        int indeximagenes = 0;
        public FromVerPerfilDeOtro(Perfil p, Perfil pc)
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
            perfilcorriendo = pc;
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

                if (imagenes.Count == 2)
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

            if (service.GetSigoATal(perfilcorriendo.idusuario, perfil.idusuario) != 0)
            {
                button2.Visible = true;
                button1.Visible = false;
            }
            else
            {
                button1.Visible = true;
                button2.Visible = false;
            }
        }

        private void FromVerPerfilDeOtro_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormPaginaPrincipal fp = new FormPaginaPrincipal(perfilcorriendo);
            indeximagenes = 0;
            fp.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool a = service.SeguirPerfil(perfilcorriendo.idusuario, perfil.idusuario);
            if(a)
            {
                button2.Visible = true;
                button1.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool a = service.DejarDeSeguir(perfilcorriendo.idusuario, perfil.idusuario);
            if(a)
            {
                button2.Visible = false;
                button1.Visible = true;
            }
        }
    }
}
