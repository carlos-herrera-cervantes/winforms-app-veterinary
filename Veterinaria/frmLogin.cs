using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Veterinaria.Controllers;
using Veterinaria.Views.Home;

namespace Veterinaria
{
    public partial class frmLogin : Form
    {
        #region snippet_Instances
        private LoginController loginController = new LoginController();
        private EmpleadosController empleadoController = new EmpleadosController();
        private AlertasController alertaController = new AlertasController();
        #endregion

        #region snippet_Properties
        private string TipoUsuario;
        #endregion

        #region snippet_GetTipoUsuario
        public string GetTipoUsuario
        {
            get
            {
                return TipoUsuario;
            }
        }
        #endregion

        #region snippet_Constructor
        public frmLogin()
        {
            InitializeComponent();
            IsRememberMyInfo();
        }
        #endregion

        //<sumary>
        //For window application
        //</sumary>
        #region snippet_EventExitApplication
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region snippet_EventMinimizeApplication
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
        //For remember user info
        //</sumary>
        #region snippet_EVENT_RememberMyInfo
        private void ckbRecordarme_CheckStateChanged(object sender, EventArgs e)
        {
            RemeberMyInfo();
        }
        #endregion

        #region snippet_METHOD_RemeberMyInfo
        public void RemeberMyInfo()
        {
            if (ckbRecordarme.Checked == true)
            {
                if (txtUsuario.Text != string.Empty && txtContrasena.Text != string.Empty)
                {
                    Properties.Settings.Default.NoEmpleado = int.Parse(txtUsuario.Text);
                    Properties.Settings.Default.Contrasena = txtContrasena.Text;
                    Properties.Settings.Default.flag = 1;
                    Properties.Settings.Default.Save();
                }
            }
            else
            {
                Properties.Settings.Default.NoEmpleado = 0;
                Properties.Settings.Default.Contrasena = "vacio";
                Properties.Settings.Default.flag = 0;
                Properties.Settings.Default.Save();
            }
        }
        #endregion

        #region snippet_METHOD_IsRememberMyInfo
        public void IsRememberMyInfo()
        {
            if (Properties.Settings.Default.flag == 1)
            {
                ckbRecordarme.Checked = true;
                txtUsuario.Text = Properties.Settings.Default.NoEmpleado.ToString();
                txtContrasena.Text = Properties.Settings.Default.Contrasena;
            }
            else
            {
                ckbRecordarme.Checked = false;
            }
        }
        #endregion

        //<sumary>
        //For login
        //</sumary>
        #region snippet_EVENT_Loguearse
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Loguearse();
        }
        #endregion

        #region snippet_METHOD_Loguearse
        public void Loguearse()
        {
            try
            {
                if (txtUsuario.Text != string.Empty && txtContrasena.Text != string.Empty)
                {
                    if (loginController.GetIdEmpleado(int.Parse(txtUsuario.Text)) == true)
                    {
                        if (loginController.GetContrasenaEmpleado(txtContrasena.Text) == true)
                        {
                            TipoUsuario = empleadoController.GetTipoUsuario(int.Parse(txtUsuario.Text));
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            alertaController.MostrarAlerta("danger", "La contraseña es incorrecta");
                        }
                    }
                    else
                    {
                        alertaController.MostrarAlerta("danger", "El empleado no existe");
                    }
                }
                else
                {
                    alertaController.MostrarAlerta("danger", "Los campos están vacíos");
                }
            }
            catch (Exception /*dex*/)
            {
                alertaController.MostrarAlerta("danger", "No fue posible conectarse al servidor. Intente de nuevo," + "\n" + "si el problema persiste contacte a su administrador.");
            }
}
        #endregion

        //<sumary>
        //For register employees
        //</sumary>
        #region snippet_EVENT_MostrarFormRegistro
        private void hlcRegistrar_Click(object sender, EventArgs e)
        {
            MostrarFormRegistro();
        }
        #endregion

        #region snippet_METHOD_MostrarFormRegistro
        public void MostrarFormRegistro()
        {
            var frmRegistro = new frmRegistrarEmpleado();
            this.WindowState = FormWindowState.Minimized;
            frmRegistro.ShowDialog();
        }
        #endregion

        #region snippet_EVENT_MostrarFormCambiarContrasena
        private void hlcCambiarContrasena_Click(object sender, EventArgs e)
        {
            MostrarFormCambiarContrasena();
        }
        #endregion

        #region snippet_METHOD_MostrarFormCambiarContrasena
        public void MostrarFormCambiarContrasena()
        {
            var frmNuevaContrasena = new frmCambiarContrasena();
            this.WindowState = FormWindowState.Minimized;
            frmNuevaContrasena.ShowDialog();
        }
        #endregion
    }
}
