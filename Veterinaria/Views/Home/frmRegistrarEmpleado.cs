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
using Veterinaria.Models;
using Veterinaria.Controllers;

namespace Veterinaria.Views.Home
{
    public partial class frmRegistrarEmpleado : Form
    {
        #region snippet_Instances
        EmpleadosController empleadoController = new EmpleadosController();
        AlertasController alertaController = new AlertasController();
        #endregion

        #region snippet_Constructor
        public frmRegistrarEmpleado()
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

        #region snippet_METHOD_ValidaSoloLetras
        public void ValidaSoloLetras(object sender, KeyEventArgs e)
        {

            Keys[] keys = {
                Keys.A, Keys.B, Keys.C, Keys.D, Keys.E, Keys.F, Keys.G,
                Keys.H, Keys.I, Keys.J, Keys.K, Keys.L, Keys.M, Keys.N, Keys.O,
                Keys.P, Keys.Q, Keys.R, Keys.S, Keys.T, Keys.U, Keys.V, Keys.W,
                Keys.X, Keys.Y, Keys.Z, Keys.Back, Keys.Tab, Keys.Space
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
        #region snippet_EVENT_CreateEmpleado
        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            CreateEmpleado();
        }
        #endregion

        #region snippet_METHOD_CreateEmpleado
        public void CreateEmpleado()
        {
            try
            {
                if (txtNombreEmpelado.Text != string.Empty && txtApellidoEmpleado.Text != string.Empty
                    && txtTelEmpleado.Text != string.Empty && txtDirEmpleado.Text != string.Empty
                    && txtEdadEmpleado.Text != string.Empty && txtContrasena.Text != string.Empty
                    && txtRepetirContrasena.Text != string.Empty && ddlSexoEmpleado.Text != "Seleccionar")
                {
                    if (txtContrasena.Text == txtRepetirContrasena.Text)
                    {
                        int id = empleadoController.CreateId();

                        var empleado = new Empleados(
                                id,
                                txtNombreEmpelado.Text,
                                txtApellidoEmpleado.Text,
                                ddlSexoEmpleado.Text,
                                txtTelEmpleado.Text,
                                txtDirEmpleado.Text,
                                "ESTÁNDAR",
                                int.Parse(txtEdadEmpleado.Text),
                                DateTime.Now.ToString("yyyy-MM-dd"),
                                txtContrasena.Text
                            );

                        empleadoController.Create(empleado);

                        alertaController.MostrarAlerta("success", "Registro realizado correctamente. Tu No. de empleado es\n"
                            + id);

                        CleanEmpleado();
                    }
                    else
                    {
                        alertaController.MostrarAlerta("danger", "Las contraseñas no coinciden.");
                    }
                }
                else
                {
                    alertaController.MostrarAlerta("danger", "Establece un valor para todos los campos.");
                }
            }
            catch (Exception /*dex*/)
            {
                alertaController.MostrarAlerta("danger", "No fue posible registrarte, intenta de nuevo\n"
                    + "si el problema persiste contacta a tu administrador.");
            }
        }
        #endregion

        #region snippet_METHOD_CleanEmpleado
        public void CleanEmpleado()
        {
            txtNombreEmpelado.Text = string.Empty;
            txtApellidoEmpleado.Text = string.Empty;
            txtTelEmpleado.Text = string.Empty;
            txtDirEmpleado.Text = string.Empty;
            txtEdadEmpleado.Text = string.Empty;
            txtContrasena.Text = string.Empty;
            txtRepetirContrasena.Text = string.Empty;
            ddlSexoEmpleado.Text = "Seleccionar";
        }
        #endregion
    }
}
