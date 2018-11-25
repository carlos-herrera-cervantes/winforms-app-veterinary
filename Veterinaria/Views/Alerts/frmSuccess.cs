using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Veterinaria.Views.Alerts
{
    public partial class frmSuccess : Form
    {
        private string Mensaje { get; set; }

        #region Constructores
        public frmSuccess()
        {
            InitializeComponent();
        }

        public frmSuccess(string mensaje) : this()
        {
            Mensaje = mensaje;
            MostrarMensaje();
        }
        #endregion

        #region Eventos
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Métodos
        public void MostrarMensaje()
        {
            lblMensaje.Text = Mensaje;
        }
        #endregion
    }
}
