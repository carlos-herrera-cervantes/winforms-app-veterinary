using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Veterinaria.Controllers;

namespace Veterinaria.Views.Home
{
    public partial class frmCambiarContrasena : Form
    {
        #region snippet_Instances
        EmpleadosController empleadoController = new EmpleadosController();
        AlertasController alertaController = new AlertasController();
        #endregion

        #region snippet_Constructor
        public frmCambiarContrasena()
        {
            InitializeComponent();
        }
        #endregion

        //<sumary>
        //For window
        //</sumary>
        #region snippet_EVENT_CerrarVentana
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region snippet_EVENT_MinimizarVentana
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        //<sumary>
        //For Validations
        //</sumary>
        private bool nonType = false;

        #region snippet_EVENT_Validar
        private void TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonType != true)
            {
                e.Handled = true;
            }

            nonType = false;
        }
        #endregion

        #region snippet_METHOD_ValidaSoloNumeros
        public void ValidaSoloNumeros(object sender, KeyEventArgs e)
        {
            Keys[] keys = {
                Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D7,
                Keys.D8, Keys.D9, Keys.Decimal, Keys.NumPad0, Keys.NumPad1, Keys.NumPad2,
                Keys.NumPad3, Keys.NumPad4, Keys.NumPad5, Keys.NumPad6, Keys.NumPad7,
                Keys.NumPad8, Keys.NumPad9, Keys.Back, Keys.Tab
            };

            foreach (var key in keys)
            {
                if (e.KeyCode == key)
                {
                    nonType = true;
                }
            }
        }
        #endregion

        //<sumary>
        //For employees
        //</sumary>
        #region snippet_EVENT_UpdateContrasena
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            UpdateContrasena();
        }
        #endregion

        #region snippet_METHOD_UpdateContrasena
        public void UpdateContrasena()
        {
            try
            {
                if (txtIdEmpleado.Text != string.Empty && txtContrasenaActual.Text != string.Empty 
                    && txtNuevaContrasena.Text != string.Empty && txtRepetirNuevaContrasena.Text != string.Empty)
                {
                    if (empleadoController.IsId(int.Parse(txtIdEmpleado.Text)) == true)
                    {
                        if (empleadoController.IsContrasena(int.Parse(txtIdEmpleado.Text)) == txtContrasenaActual.Text)
                        {
                            if (txtNuevaContrasena.Text == txtRepetirNuevaContrasena.Text)
                            {
                                int id = int.Parse(txtIdEmpleado.Text);
                                string nuevaContrasena = txtNuevaContrasena.Text;

                                empleadoController.UpdateContrasena(id, nuevaContrasena);

                                alertaController.MostrarAlerta("success", "Contrasena actualizada correctamente.");

                                CleanEmpleado();
                            }
                            else
                            {
                                alertaController.MostrarAlerta("danger", "Las contraseñas no coinciden.");
                            }
                        }
                        else
                        {
                            alertaController.MostrarAlerta("danger", "La contraseña actual proporcionada no es la correcta.");
                        }
                    }
                    else
                    {
                        alertaController.MostrarAlerta("danger", "El no. de empleado no existe.");
                    }
                }
                else
                {
                    alertaController.MostrarAlerta("danger", "Indica un valor para los campos.");
                }
            }
            catch (Exception /*dex*/)
            {
                alertaController.MostrarAlerta("danger", "No fue posible actualizar la contraseña, intenta de nuevo\n"
                    + "si el problema persiste contacta a tu administrador.");
            }
        }
        #endregion

        #region snippet_METHOD_CleanEmpleado
        public void CleanEmpleado()
        {
            txtIdEmpleado.Text = string.Empty;
            txtContrasenaActual.Text = string.Empty;
            txtNuevaContrasena.Text = string.Empty;
            txtRepetirNuevaContrasena.Text = string.Empty;
        }
        #endregion
    }
}
