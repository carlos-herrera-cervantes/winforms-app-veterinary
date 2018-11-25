using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Veterinaria.Views.Home;

namespace Veterinaria
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frmLogin frmLogin = new frmLogin();
            frmLogin.ShowDialog();

            if (frmLogin.DialogResult == DialogResult.OK)
            {
                string tipoUsuario = frmLogin.GetTipoUsuario;

                Application.Run(new frmPrincipal(tipoUsuario));
            }
        }
    }
}
