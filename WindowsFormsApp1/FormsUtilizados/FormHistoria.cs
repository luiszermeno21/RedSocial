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
    public partial class FormHistoria : Form
    {
        public UsuarioService service;
        Historia historia;
        Perfil perfil;
        Timer dataTimer = new Timer();
        public FormHistoria(Historia h,Perfil p)
        {
            InitializeComponent();
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SQLConnection"].ToString();
            service = new UsuarioService(connectionString);
            historia = h;
            perfil = p;
            pictureBox1.ImageLocation = h.urlimagen;

            
            dataTimer.Tick += new EventHandler(loadData);
            dataTimer.Interval = 3000;
            dataTimer.Start();
        }

        private void loadData(object sender, EventArgs e)
        {
            bool b = service.DeleteHistoria(historia);
            FormPaginaPrincipal fp = new FormPaginaPrincipal(perfil);
            fp.Show();
            dataTimer.Stop();
            this.Hide();
            
            //historias = service.GetHistorias(p.idusuario);
            //ActualizarHistorias(historias);
        }
    }
}
