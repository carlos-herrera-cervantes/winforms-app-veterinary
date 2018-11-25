using System;
using System.Windows.Forms;
using Veterinaria.Models;
using Veterinaria.Controllers;
using System.Collections.Generic;
using Telerik.WinControls.UI;
using System.Linq;

namespace Veterinaria.Views.Home
{
    public partial class frmPrincipal : Form
    {
        #region snippet_InstanciasControllers
        private EmpleadosController empleadoController = new EmpleadosController();
        private ClientesController clienteController = new ClientesController();
        private MascotasController mascotaController = new MascotasController();
        private TratamientosController tratamientoController = new TratamientosController();
        private ConsultasController consultaController = new ConsultasController();
        private DocumentoController documentoController = new DocumentoController();
        private CertificadosController certificadoController = new CertificadosController();
        private ServiciosController servicioController = new ServiciosController();
        private CatalogoServicioController catalogoServicioController = new CatalogoServicioController();
        private CatalogoProductosController catalogoProductosController = new CatalogoProductosController();
        private VentasController ventaController = new VentasController();
        private DetalleVentaController detalleVentaController = new DetalleVentaController();
        private AlertasController alerta = new AlertasController();
        #endregion

        #region snippet_Properties
        private string TipoUsuario;
        #endregion

        #region snippet_Constructors
        public frmPrincipal()
        {
            
        }

        public frmPrincipal(string tipoUsuario)
        {
            InitializeComponent();
            GetEmpleados();
            GetClientes();
            GetMascotas();
            GetRecetas();
            GetCertificados();
            GetProductos();
            GetVentas();
            GetNombreProductoForVentas();
            GetNombreServicio();
            GetAllServicios();
            GetAllNoServicios();
            txtFechaTratamientoReceta.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtFechaCertificado.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtFechaRegistroServicios.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtFechaVentaRVVentas.Text = DateTime.Now.ToString("dd-MM-yyyy");
            TipoUsuario = tipoUsuario;
            IsAdminOrStandard();
        }
        #endregion

        //<sumary>
        //For window application
        //</sumary>
        #region snippet_EVENT_CloseWindow
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region snippet_EVENT_Minimize
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
        //For users system
        //</sumary>
        #region snippet_METHOD_IsAdminOrStandard
        public void IsAdminOrStandard()
        {
            if (TipoUsuario != "ADMINISTRADOR")
            {
                pnlAltaEmpleados.Visible = false;
                pnlBajaEmpleados.Visible = false;
                pnlBajaClientes.Visible = false;
                pnlEliminarMascota.Visible = false;
                pnlAgregarServicio.Visible = false;
                pnlAgregarProducto.Visible = false;
                pnlEliminarProducto.Visible = false;
            }
        }
        #endregion

        //<sumary>
        //For Employees
        //</sumary>
        #region snippet_EVENT_CreateEmpleado
        private void btnGuadarEmpleado_Click(object sender, EventArgs e)
        {
            IsUpdateOrCreateEmpleado();
            GetEmpleados();
            CleanEmpleados();
        }
        #endregion

        #region snippet_METHOD_CreateEmpleado
        public void CreateEmpleado()
        {
            try
            {
                if (txtNombreEmpelado.Text != string.Empty && txtApellidoEmpleado.Text != string.Empty 
                    && txtEdadEmpleado.Text != string.Empty && txtTelEmpleado.Text != string.Empty 
                    && txtDirEmpleado.Text != string.Empty && ddlSexoEmpleado.Text != "Seleccionar"
                    && ddlTipoUsuario.Text != "Seleccionar")
                {
                    var empleado = new Empleados(
                        empleadoController.CreateId(), txtNombreEmpelado.Text, txtApellidoEmpleado.Text,
                        ddlSexoEmpleado.Text, txtTelEmpleado.Text, txtDirEmpleado.Text,
                        ddlTipoUsuario.Text, Convert.ToInt32(txtEdadEmpleado.Text), DateTime.Now.ToString("yyyy-MM-dd"), "9999"
                    );

                    empleadoController.Create(empleado);
                    alerta.MostrarAlerta("success", "Empleado creado correctamente");
                }
                else
                {
                    alerta.MostrarAlerta("danger", "Establece un valor para todos los campos");
                }
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible realizar la operación. Intente de nuevo," +
                    "\n" + "si el problema persiste contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_EVENT_GetEmpleadoByName
        private void txtApellidoEmpleadoMEEmpleados_TextChanged(object sender, EventArgs e)
        {
            GetEmpleadoByName();
        }
        #endregion

        #region snippet_METHOD_GetEmpleadoByName
        public void GetEmpleadoByName()
        {
            try
            {
                if (txtNombreEmpleadoMEEmpleados.Text != string.Empty && txtApellidoEmpleadoMEEmpleados.Text != string.Empty)
                {
                    string nombreEmpleado = txtNombreEmpleadoMEEmpleados.Text;
                    string apellidoEmpleado = txtApellidoEmpleadoMEEmpleados.Text;

                    Empleados empleado = empleadoController.GetByName(nombreEmpleado, apellidoEmpleado);

                    txtIdEmpleadoMEEmpleados.Text = empleado.GetIdEmpleado.ToString();
                    txtNombreEmpelado.Text = empleado.GetNombreEmpleado;
                    txtApellidoEmpleado.Text = empleado.GetApellidoEmpleado;
                    txtEdadEmpleado.Text = empleado.GetEdadEmpleado.ToString();
                    txtTelEmpleado.Text = empleado.GetTelefonoEmpleado;
                    ddlSexoEmpleado.Text = empleado.GetSexoEmpleado;
                    ddlTipoUsuario.Text = empleado.GetTipoUsuario;
                    txtDirEmpleado.Text = empleado.GetDireccionEmpleado;
                }
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible obtener la información del empleado " + txtNombreEmpleadoMEEmpleados.Text +
                    " " + txtApellidoEmpleadoMEEmpleados.Text + ". Intente de nuevo," +
                    "\n" + "si el problema persiste contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_EVENT_GetEmpleadoById
        private void txtIdEmpleadoBaja_TextChanged(object sender, EventArgs e)
        {
            GetEmpleadoById();
        }
        #endregion

        #region snippet_METHOD_GetEmpleadoById
        public void GetEmpleadoById()
        {
            try
            {
                if (txtIdEmpleadoBaja.Text.Length == 6)
                {
                    var id = int.Parse(txtIdEmpleadoBaja.Text);
                    var empleado = empleadoController.GetById(id);

                    lblValueIdEmpleado.Text = empleado.GetIdEmpleado.ToString();
                    lblValueNombreEmpleado.Text = empleado.GetNombreEmpleado;
                    lblValueApellidoEmpleado.Text = empleado.GetApellidoEmpleado;
                    lblValueSexoEmpleado.Text = empleado.GetSexoEmpleado;
                    lblValueTelefonoEmpleado.Text = empleado.GetTelefonoEmpleado;
                    lblValueDireccionEmpleado.Text = empleado.GetDireccionEmpleado;
                    lblValueEdadEmpleado.Text = empleado.GetEdadEmpleado.ToString();
                    lblValueFechaIngreso.Text = empleado.GetFechaIngreso;
                    lblValueTipoUsuario.Text = empleado.GetTipoUsuario;
                }
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible realizar la operación. Intente de nuevo," +
                    "\n" + "si el problema persiste contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_EVENT_IsUpdateEmpleado
        private void rtsIsUpdateEmpleados_ValueChanged(object sender, EventArgs e)
        {
            IsUpdateEmpleado();
        }
        #endregion

        #region snippet_METHOD_IsUpdateEmpleado
        public bool IsUpdateEmpleado()
        {
            bool resultado = false;

            if (rtsIsUpdateEmpleados.Value == true)
            {
                lbNombreEmpleadoMEEmpleados.Visible = true;
                lblApellidoEmpleadoMEEmpleados.Visible = true;
                txtNombreEmpleadoMEEmpleados.Visible = true;
                txtApellidoEmpleadoMEEmpleados.Visible = true;
                resultado = true;
                return resultado;
            }
            else
            {
                lbNombreEmpleadoMEEmpleados.Visible = false;
                lblApellidoEmpleadoMEEmpleados.Visible = false;
                txtNombreEmpleadoMEEmpleados.Visible = false;
                txtApellidoEmpleadoMEEmpleados.Visible = false;
                return resultado;
            }
        }
        #endregion        

        #region snippet_METHOD_UpdateEmpleado
        public void UpdateEmpleado()
        {
            try
            {
                if (txtNombreEmpelado.Text != string.Empty && txtApellidoEmpleado.Text != string.Empty 
                    && txtEdadEmpleado.Text != string.Empty && txtTelEmpleado.Text != string.Empty 
                    && txtDirEmpleado.Text != string.Empty && ddlSexoEmpleado.Text != "Seleccionar"
                    && ddlTipoUsuario.Text != "Seleccionar")
                {
                    var empleado = new Empleados(
                        int.Parse(txtIdEmpleadoMEEmpleados.Text), txtNombreEmpelado.Text, txtApellidoEmpleado.Text,
                        ddlSexoEmpleado.Text, txtTelEmpleado.Text, txtDirEmpleado.Text,
                        ddlTipoUsuario.Text, Convert.ToInt32(txtEdadEmpleado.Text), DateTime.Now.ToString("yyyy-MM-dd"), "9999"
                    );

                    empleadoController.Update(empleado);
                    alerta.MostrarAlerta("success", "Empleado actualizado correctamente");
                }
                else
                {
                    alerta.MostrarAlerta("danger", "Establece un valor para todos los campos");
                }
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible actualizar al empleado " + txtNombreEmpleadoMEEmpleados.Text + 
                    " " + txtApellidoEmpleadoMEEmpleados.Text + ". Intente de nuevo," +
                    "\n" + "si el problema persiste contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_METHOD_IsUpdateOrCreateEmpleado
        public void IsUpdateOrCreateEmpleado()
        {
            if (IsUpdateEmpleado() == true)
            {
                UpdateEmpleado();
            }
            else
            {
                CreateEmpleado();
            }
        }
        #endregion

        #region snippet_EVENT_DeleteEmpleado
        private void btnBajaEmpleados_Click(object sender, EventArgs e)
        {
            DeleteEmpleado();
            GetEmpleados();
            CleanEmpleados();
        }
        #endregion

        #region snippet_METHOD_DeleteEmpleado
        public void DeleteEmpleado()
        {
            try
            {
                if (txtIdEmpleadoBaja.Text != string.Empty)
                {
                    int id = int.Parse(txtIdEmpleadoBaja.Text);
                    empleadoController.Delete(id);
                    alerta.MostrarAlerta("success", "Empleado eliminado correctamente");
                }
                else
                {
                    alerta.MostrarAlerta("danger", "Indica el ID del empleado");
                }
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible eliminar al empleado: " + txtIdEmpleadoBaja.Text
                    + "intente de nuevo\n si el problema persiste, contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_METHOD_GetEmpleados
        public void GetEmpleados()
        {
            try
            {
                List<Empleados> empleados = empleadoController.GetAll();
                rgvConsultaEmpleados.Rows.Clear();
                foreach (var empleado in empleados)
                {
                    rgvConsultaEmpleados.Rows.Add(
                            empleado.GetIdEmpleado, empleado.GetNombreEmpleado, empleado.GetApellidoEmpleado,
                            empleado.GetTelefonoEmpleado, empleado.GetEdadEmpleado, empleado.GetTipoUsuario
                        );
                }
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible posible obtener la lista de empleados." + "\n" + " [RUTA: Empleados/Consulta de empleados]" +
                    "\n" + "Si el problema persiste contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_METHOD_CleanEmpleados
        public void CleanEmpleados()
        {
            RadLabel[] labels =
                {
                    lblValueIdEmpleado,
                    lblValueNombreEmpleado,
                    lblValueApellidoEmpleado,
                    lblValueSexoEmpleado,
                    lblValueTelefonoEmpleado,
                    lblValueDireccionEmpleado,
                    lblValueEdadEmpleado,
                    lblValueFechaIngreso,
                    lblValueTipoUsuario
                };

            for (int i = 0; i < labels.Length; i++)
            {
                labels[i].Text = "No definido";
            }

            RadTextBox[] textboxs =
                {
                    txtNombreEmpelado,
                    txtApellidoEmpleado,
                    txtEdadEmpleado,
                    txtTelEmpleado,
                    txtDirEmpleado
                };

            for (int i = 0; i < textboxs.Length; i++)
            {
                textboxs[i].Text = string.Empty;
            }

            ddlSexoEmpleado.Text = "Seleccionar";
            ddlTipoUsuario.Text = "Seleccionar";
        }
        #endregion

        //<sumary>
        //For customers
        //</sumary>
        #region snippet_EVENT_CreateCliente
        private void btnGuardarCliente_Click(object sender, EventArgs e)
        {
            IsUpdateOrCreateCliente();
            GetClientes();
            CleanClientes();
        }
        #endregion

        #region snippet_METHOD_CreateCliente
        public void CreateCliente()
        {
            try
            {
                if (txtNombreCliente.Text != string.Empty && txtApellidoCliente.Text != string.Empty 
                    && txtEdadCliente.Text != string.Empty && txtTelefonoCliente.Text != string.Empty 
                    && txtCorreoCliente.Text != string.Empty && txtDireccionCliente.Text != string.Empty
                    && ddlSexoCliente.Text != "Seleccionar")
                {
                    var cliente = new Clientes(
                        clienteController.CreateId(), txtNombreCliente.Text, txtApellidoCliente.Text, ddlSexoCliente.Text,
                        txtTelefonoCliente.Text, txtDireccionCliente.Text, txtCorreoCliente.Text, int.Parse(txtEdadCliente.Text),
                        DateTime.Now.ToString("yyyy-MM-dd")
                    );

                    clienteController.Create(cliente);
                    alerta.MostrarAlerta("success", "Cliente agregado correctamente");
                }
                else
                {
                    alerta.MostrarAlerta("danger", "Establece un valor para todos los campos");
                }
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible realizar la operación. Intente de nuevo," +
                    "\n" + "si el problema persiste contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_EVENT_GetClienteById
        private void txtIdClienteBaja_TextChanged(object sender, EventArgs e)
        {
            GetClienteById();
        }
        #endregion

        #region snippet_METHOD_GetClienteById
        public void GetClienteById()
        {
            try
            {
                if (txtIdClienteBaja.Text.Length == 6)
                {
                    int id = int.Parse(txtIdClienteBaja.Text);
                    var cliente = clienteController.GetById(id);

                    lblValueIdCliente.Text = cliente.GetIdCliente.ToString();
                    lblValueNombreCliente.Text = cliente.GetNombreCliente;
                    lblValueApellidoCliente.Text = cliente.GetApellidoCliente;
                    lblValueSexoCliente.Text = cliente.GetSexoCliente;
                    lblValueTelCliente.Text = cliente.GetTelefonoCliente;
                    lblValueDirCliente.Text = cliente.GetDireccionCliente;
                    lblValueEdadCliente.Text = cliente.GetEdadCliente.ToString();
                    lblValueFechaRegistroCliente.Text = cliente.GetFechaRegistro;
                    lblValueCorreoCliente.Text = cliente.GetCorreoCliente;
                }
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible realizar la operación. Intente de nuevo," +
                    "\n" + "si el problema persiste contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_EVENT_DeleteCliente
        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            DeleteCliente();
            GetClientes();
            GetMascotas();
            CleanClientes();
        }
        #endregion

        #region snippet_METHOD_DeleteCliente
        public void DeleteCliente()
        {
            try
            {
                if (txtIdClienteBaja.Text != string.Empty)
                {
                    int id = int.Parse(txtIdClienteBaja.Text);
                    clienteController.Delete(id);
                    dgvMascotasClienteConsulta.Rows.Clear();
                    alerta.MostrarAlerta("success", "Datos actualizados correctamente");
                }
                else
                {
                    alerta.MostrarAlerta("danger", "Indica el ID del cliente");
                }
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible eliminar el cliente: " + txtIdClienteBaja.Text + ". \nIntente de nuevo," +
                    "\n" + "si el problema persiste contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_EventGetMascotaByClienteId
        private void dgvClientesConsulta_CellClick(object sender, GridViewCellEventArgs e)
        {
            GetMascotaByClienteId(sender, e);
        }
        #endregion

        #region snippet_METHOD_GetMascotaByClienteId
        public void GetMascotaByClienteId(object sender, GridViewCellEventArgs e)
        {
            try
            {
                int id = int.Parse(dgvClientesConsulta.Rows[e.RowIndex].Cells[0].Value.ToString());
                List<Mascotas> mascotas = mascotaController.GetByClienteId(id);
                dgvMascotasClienteConsulta.Rows.Clear();

                foreach (var mascota in mascotas)
                {
                    dgvMascotasClienteConsulta.Rows.Add(
                            mascota.GetIdMascota, mascota.GetNombreMascota, mascota.GetEspecie,
                            mascota.GetRaza, mascota.GetEdadMascota, mascota.GetSexoMascota
                        );
                }
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible realizar la operación. Intente de nuevo," +
                    "\n" + "si el problema persiste contacte a su administrador.");
            }

        }
        #endregion

        #region snippet_EventGetClienteByName
        private void txtApellidoClienteMCClientes_TextChanged(object sender, EventArgs e)
        {
            GetClienteByName();
        }
        #endregion

        #region snippet_METHOD_GetClienteByName
        public void GetClienteByName()
        {
            try
            {
                if (txtNombreClienteMCClientes.Text != string.Empty && txtApellidoClienteMCClientes.Text != string.Empty)
                {
                    string nombreCliente = txtNombreClienteMCClientes.Text;
                    string apellidoCliente = txtApellidoClienteMCClientes.Text;

                    Clientes cliente = clienteController.GetByName(nombreCliente, apellidoCliente);

                    txtIdClienteMCClientes.Text = cliente.GetIdCliente.ToString();
                    txtNombreCliente.Text = cliente.GetNombreCliente;
                    txtApellidoCliente.Text = cliente.GetApellidoCliente;
                    txtEdadCliente.Text = cliente.GetEdadCliente.ToString();
                    txtTelefonoCliente.Text = cliente.GetTelefonoCliente;
                    ddlSexoCliente.Text = cliente.GetSexoCliente;
                    txtCorreoCliente.Text = cliente.GetCorreoCliente;
                    txtDireccionCliente.Text = cliente.GetDireccionCliente;
                }
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible consultar los datos del cliente. Intente de nuevo," +
                    "\n" + "si el problema persiste contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_EVENT_IsUpdateCliente
        private void rtsIsUpdate_ValueChanged(object sender, EventArgs e)
        {
            IsUpdateCliente();
        }
        #endregion

        #region snippet_METHOD_IsUpdateCliente
        public bool IsUpdateCliente()
        {
            bool resultado = false;
            if (rtsIsUpdateClientes.Value == true)
            {
                lblNombreClienteMCClientes.Visible = true;
                lblApellidoClienteMCClientes.Visible = true;
                txtNombreClienteMCClientes.Visible = true;
                txtApellidoClienteMCClientes.Visible = true;
                resultado = true;
                return resultado;
            }
            else
            {
                lblNombreClienteMCClientes.Visible = false;
                lblApellidoClienteMCClientes.Visible = false;
                txtNombreClienteMCClientes.Visible = false;
                txtApellidoClienteMCClientes.Visible = false;
                return resultado;
            }
        }
        #endregion

        #region snippet_METHOD_GetClientes
        public void GetClientes()
        {
            try
            {
                List<Clientes> clientes = clienteController.GetAll();
                dgvClientesConsulta.Rows.Clear();

                foreach (var cliente in clientes)
                {
                    dgvClientesConsulta.Rows.Add(
                            cliente.GetIdCliente, cliente.GetNombreCliente, 
                            cliente.GetApellidoCliente, cliente.GetTelefonoCliente,
                            cliente.GetCorreoCliente, cliente.GetEdadCliente
                        );
                }
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible realizar la operación. Intente de nuevo," +
                    "\n" + "si el problema persiste contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_METHOD_UpdateCliente
        public void UpdateCliente()
        {
            try
            {
                if (txtNombreCliente.Text != string.Empty && txtApellidoCliente.Text != string.Empty 
                    && txtEdadCliente.Text != string.Empty && txtTelefonoCliente.Text != string.Empty 
                    && txtCorreoCliente.Text != string.Empty && txtDireccionCliente.Text != string.Empty
                    && ddlSexoCliente.Text != "Seleccionar")
                {
                    var cliente = new Clientes(
                        int.Parse(txtIdClienteMCClientes.Text), txtNombreCliente.Text, txtApellidoCliente.Text, ddlSexoCliente.Text,
                        txtTelefonoCliente.Text, txtDireccionCliente.Text, txtCorreoCliente.Text, int.Parse(txtEdadCliente.Text),
                        DateTime.Now.ToString("yyyy-MM-dd")
                    );

                    clienteController.Update(cliente);
                    alerta.MostrarAlerta("success", "Cliente actualizado correctamente");
                }
                else
                {
                    alerta.MostrarAlerta("danger", "Establece un valor para todos los campos");
                }
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible actualizar al cliente " + txtNombreClienteMCClientes.Text +
                    " " + txtApellidoClienteMCClientes.Text + ". Intente de nuevo," +
                    "\n" + "si el problema persiste contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_METHOD_IsUpdateOrCreateCliente
        public void IsUpdateOrCreateCliente()
        {
            if (IsUpdateCliente() == true)
            {
                UpdateCliente();
            }
            else
            {
                CreateCliente();
            }
        }
        #endregion

        #region snippet_METHOD_CleanClientes
        public void CleanClientes()
        {
            RadTextBox[] textboxs =
            {
                txtNombreCliente,
                txtApellidoCliente,
                txtEdadCliente,
                txtTelefonoCliente,
                txtDireccionCliente,
                txtCorreoCliente
            };

            for (int i = 0; i < textboxs.Length; i++)
            {
                textboxs[i].Text = string.Empty;
            }

            ddlSexoCliente.Text = "Seleccionar";

            RadLabel[] labels =
                {
                    lblValueIdCliente,
                    lblValueNombreCliente,
                    lblValueApellidoCliente,
                    lblValueSexoCliente,
                    lblValueTelCliente,
                    lblValueDirCliente,
                    lblValueEdadCliente,
                    lblValueFechaRegistroCliente,
                    lblValueCorreoCliente
                };

            for (int i = 0; i < labels.Length; i++)
            {
                labels[i].Text = "No definido";
            }
        }
        #endregion

        //<sumary>
        //For pets
        //</sumary>
        #region snippet_EVENT_CreateMascota
        private void btnGuardarMascota_Click(object sender, EventArgs e)
        {
            IsUpdateOrCreateMascota();
            GetMascotas();
            CleanMascotas();
        }
        #endregion

        #region snippet_METHOD_CreateMascota
        public void CreateMascota()
        {
            try
            {
                if (txtNombreMascota.Text != string.Empty && txtEspecie.Text != string.Empty 
                    && txtRaza.Text != string.Empty && txtColor.Text != string.Empty 
                    && txtPesoMascota.Text != string.Empty && txtEdadMascota.Text != string.Empty
                    && ddlSexoMascota.Text != "Seleccionar")
                {
                    var mascota = new Mascotas(
                        mascotaController.CreateId(), 
                        txtNombreMascota.Text, 
                        txtEspecie.Text, txtRaza.Text, 
                        int.Parse(txtEdadMascota.Text),
                        ddlSexoMascota.Text, 
                        txtColor.Text, 
                        float.Parse(txtPesoMascota.Text), 
                        dtpFechaNacimiento.Value.ToString().Substring(0, 10),
                        DateTime.Now.ToString("yyyy-MM-dd"), int.Parse(lblIdClienteAMMascotas.Text)
                    );

                    mascotaController.Create(mascota);
                    alerta.MostrarAlerta("success", "Datos actualizados correctamente.");
                }
                else
                {
                    alerta.MostrarAlerta("danger", "Establece un valor para todos los campos");
                }
                
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible realizar la operación. Intente de nuevo," +
                    "\n" + "si el problema persiste contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_EVENT_UpdateMascota
        private void btnActualizarMascota_Click(object sender, EventArgs e)
        {
            UpdateMascota();
            GetMascotas();
            CleanMascotas();
        }
        #endregion

        #region snippet_METHOD_UpdateMascota
        public void UpdateMascota()
        {
            try
            {
                if (txtNombreMascota.Text != string.Empty && txtEspecie.Text != string.Empty 
                    && txtRaza.Text != string.Empty && txtColor.Text != string.Empty 
                    && txtPesoMascota.Text != string.Empty && txtEdadMascota.Text != string.Empty
                    && ddlSexoMascota.Text != "Seleccionar")
                {
                    var mascota = new Mascotas(
                        int.Parse(txtIdMascotaMMMascotas.Text), 
                        txtNombreMascota.Text, txtEspecie.Text, 
                        txtRaza.Text, 
                        int.Parse(txtEdadMascota.Text),
                        ddlSexoMascota.Text, 
                        txtColor.Text, 
                        float.Parse(txtPesoMascota.Text), 
                        dtpFechaNacimiento.Value.ToString().Substring(0, 10)
                    );

                    mascotaController.Update(mascota);
                    alerta.MostrarAlerta("success", "Datos actualizados correctamente.");
                }
                else
                {
                    alerta.MostrarAlerta("danger", "Establece un valor para todos los campos");
                }
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible actualizar la información de la mascota " + txtNombreMascotaMMMascotas.Text +
                    ". Intente de nuevo," + "\n" + "si el problema persiste contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_EVENT_GetMascotaById
        private void txtIdMascota_TextChanged(object sender, EventArgs e)
        {
            GetMascotaById();
        }
        #endregion

        #region snippet_METHOD_GetMascotaById
        public void GetMascotaById()
        {
            try
            {
                if (txtIdMascota.Text.Length == 6)
                {
                    int id = int.Parse(txtIdMascota.Text);
                    var mascota = mascotaController.GetById(id);

                    lblValueIdMascota.Text = mascota.GetIdMascota.ToString();
                    lblValueNombreMascota.Text = mascota.GetNombreMascota;
                    lblValueEspecie.Text = mascota.GetEspecie;
                    lblValueRaza.Text = mascota.GetRaza;
                    lblValueEdadMascota.Text = mascota.GetEdadMascota.ToString();
                    lblValueSexoMascota.Text = mascota.GetSexoMascota;
                    lblValueColor.Text = mascota.GetColor;
                    lblValuePesoMascota.Text = mascota.GetPeso.ToString();
                    lblValueFechaNacimiento.Text = mascota.GetFechaNacimiento;
                    lblValueIdClienteMascota.Text = mascota.GetIdCliente.ToString();
                    lblValueFechaRegistroMascota.Text = mascota.GetFechaRegistro;
                }
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible realizar la operación. Intente de nuevo," +
                    "\n" + "si el problema persiste contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_EVENT_GetMascotaByNameForMascotas
        private void txtNombreMascotaMMMascotas_TextChanged(object sender, EventArgs e)
        {
            GetMascotaByNameForMascotas();
        }
        #endregion

        #region snippet_METHOD_GetMascotaByNameForMascotas
        public void GetMascotaByNameForMascotas()
        {
            try
            {
                if (txtNombreMascotaMMMascotas.Text != string.Empty)
                {
                    string nombreMascota = txtNombreMascotaMMMascotas.Text;
                    Mascotas mascota = mascotaController.GetByName(nombreMascota);

                    txtIdMascotaMMMascotas.Text = mascota.GetIdMascota.ToString();
                    txtNombreMascota.Text = mascota.GetNombreMascota;
                    txtEspecie.Text = mascota.GetEspecie;
                    txtRaza.Text = mascota.GetRaza;
                    txtColor.Text = mascota.GetColor;
                    txtPesoMascota.Text = mascota.GetPeso.ToString();
                    txtEdadMascota.Text = mascota.GetEdadMascota.ToString();
                    ddlSexoMascota.Text = mascota.GetSexoMascota;
                    dtpFechaNacimiento.Text = mascota.GetFechaNacimiento;
                }
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible obtener la información de" + txtNombreMascotaMMMascotas.Text + ". Intente de nuevo," +
                    "\n" + "si el problema persiste contacte a su administrador.");
            }
        }
        #endregion

        #region snippeT_EVENT_GetClienteByNameForMascotas
        private void txtApellidoClienteAMMascotas_TextChanged(object sender, EventArgs e)
        {
            GetClienteByNameForMascotas();
        }
        #endregion

        #region snippet_METHOD_GetClienteByNameForMascotas
        public void GetClienteByNameForMascotas()
        {
            try
            {
                if (txtNombreClienteAMMascotas.Text != string.Empty && txtApellidoClienteAMMascotas.Text != string.Empty)
                {
                    string nombreCliente = txtNombreClienteAMMascotas.Text;
                    string apellidoCliente = txtApellidoClienteAMMascotas.Text;

                    Clientes cliente = clienteController.GetByName(nombreCliente, apellidoCliente);

                    lblIdClienteAMMascotas.Text = cliente.GetIdCliente.ToString();
                    lblNombreClienteAMMascotas.Text = cliente.GetNombreCliente;
                    lblApellidoClienteAMMascotas.Text = cliente.GetApellidoCliente;
                    lblTelClienteAMMascotas.Text = cliente.GetTelefonoCliente;
                    lblDirClienteAMMascotas.Text = cliente.GetDireccionCliente;
                    lblEdadClienteAMMascotas.Text = cliente.GetEdadCliente.ToString();
                    lblEmailClienteAMMascotas.Text = cliente.GetCorreoCliente;
                }
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible realizar la operación. Intente de nuevo," +
                    "\n" + "si el problema persiste contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_EVENT_DeleteMascota
        private void btnEliminarMascota_Click(object sender, EventArgs e)
        {
            DeleteMascota();
            GetMascotas();
            CleanMascotas();
        }
        #endregion

        #region snippet_METHOD_DeleteMascota
        public void DeleteMascota()
        {
            try
            {
                if (txtIdMascota.Text != string.Empty)
                {
                    int id = int.Parse(txtIdMascota.Text);
                    mascotaController.Delete(id);
                    alerta.MostrarAlerta("success", "Datos actualizados correctamente.");
                }
                else
                {
                    alerta.MostrarAlerta("danger", "Indica el ID de la mascota");
                }
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible eliminar la mascota : " + txtIdMascota.Text + ". \nIntente de nuevo," +
                    "\n" + "si el problema persiste contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_EVENT_IsUpdateMascota
        private void rtsIsUpdateMascota_ValueChanged(object sender, EventArgs e)
        {
            IsUpdateMascota();
        }
        #endregion

        #region snippet_METHOD_IsUpdateMascota
        public bool IsUpdateMascota()
        {
            bool resultado = false;
            if (rtsIsUpdateMascota.Value == true)
            {
                lblNombreMascotaMMMascotas.Visible = true;
                txtNombreMascotaMMMascotas.Visible = true;
                btnActualizarMascota.Visible = true;
                resultado = true;
                return resultado;
            }
            else
            {
                lblNombreMascotaMMMascotas.Visible = false;
                txtNombreMascotaMMMascotas.Visible = false;
                btnActualizarMascota.Visible = false;
                return resultado;
            }
        }
        #endregion

        #region snippet_METHOD_GetMascotas
        public void GetMascotas()
        {
            try
            {
                List<Mascotas> mascotas = mascotaController.GetAll();
                dgvMascotasConsulta.Rows.Clear();
                foreach (var mascota in mascotas)
                {
                    dgvMascotasConsulta.Rows.Add(
                            mascota.GetIdCliente, mascota.GetIdMascota, 
                            mascota.GetNombreMascota, mascota.GetEspecie,
                            mascota.GetRaza, mascota.GetEdadMascota, 
                            mascota.GetPeso, mascota.GetSexoMascota, 
                            mascota.GetFechaNacimiento
                        );
                }
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible realizar la operación. Intente de nuevo," +
                    "\n" + "si el problema persiste contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_METHOD_IsUpdateOrCreateMascota
        public void IsUpdateOrCreateMascota()
        {
            if (IsUpdateMascota() == true)
            {
                UpdateMascota();
            }
            else
            {
                CreateMascota();
            }
        }
        #endregion

        #region snippet_METHOD_CleanMascotas
        public void CleanMascotas()
        {
            RadTextBox[] textboxs =
                {
                    txtNombreMascota,
                    txtEspecie,
                    txtRaza,
                    txtColor,
                    txtPesoMascota,
                    txtEdadMascota
                };

            for (int i = 0; i < textboxs.Length; i++)
            {
                textboxs[i].Text = string.Empty;
            }

            ddlSexoMascota.Text = "Seleccionar";

            RadLabel[] labels =
                {
                    lblValueIdMascota,
                    lblValueNombreMascota,
                    lblValueEspecie,
                    lblValueRaza,
                    lblValueEdadMascota,
                    lblValueSexoMascota,
                    lblValueColor,
                    lblValuePesoMascota,
                    lblValueFechaNacimiento,
                    lblValueIdClienteMascota,
                    lblValueFechaRegistroMascota
                };

            for (int i = 0; i < labels.Length; i++)
            {
                labels[i].Text = "No definido";
            }
        }
        #endregion

        //<sumary>
        //For prescriptions
        //<sumary>
        #region snippet_EVENT_CreateTratamiento
        private void btnGuardarReceta_Click(object sender, EventArgs e)
        {
            CreateDocumentoReceta();
            PrintDoucumentoReceta();
            CreateTratamiento();
            GetRecetas();
            CleanRecetas();
        }
        #endregion

        #region snippet_METHOD_CreateTratamiento
        public void CreateTratamiento()
        {
            try
            {
                if (txtNombreMascotaReceta.Text != string.Empty && txtPesoMascotaReceta.Text != string.Empty 
                    && txtFechaTratamientoReceta.Text != string.Empty && txtClienteMascotaReceta.Text != string.Empty 
                    && txtTratamientoReceta.Text != string.Empty)
                {
                    if (IsClienteForRecetas() == true)
                    {
                        var tratamiento = new Tratamientos(
                            tratamientoController.CreateId(), txtNombreMascotaReceta.Text, float.Parse(txtPesoMascotaReceta.Text),
                            txtClienteMascotaReceta.Text, txtTratamientoReceta.Text, txtFechaTratamientoReceta.Text,
                            int.Parse(txtIdMascotaReceta.Text)
                        );

                        tratamientoController.Create(tratamiento);
                        alerta.MostrarAlerta("success", "Datos actualizados correctamente.");
                    }
                }
                else
                {
                    alerta.MostrarAlerta("danger", "Indique un valor para todos los campos");
                }
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible crear el tratamiento. Intente de nuevo," +
                    "\n" + "si el problema persiste contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_EVENT_GetMascotaAndClienteByNameForRecetas
        private void txtNombreMascotaReceta_TextChanged(object sender, EventArgs e)
        {
            GetMascotaByNameForRecetas();
            GetClienteByNameForRecetas();
        }
        #endregion        

        #region snippet_METHOD_GetMascotaByNameForRecetas
        public void GetMascotaByNameForRecetas()
        {
            try
            {
                if (IsClienteForRecetas() == true)
                {
                    string nombreMascota = txtNombreMascotaReceta.Text;
                    Mascotas mascota = mascotaController.GetByName(nombreMascota);

                    txtIdMascotaReceta.Text = mascota.GetIdMascota.ToString();
                    txtPesoMascotaReceta.Text = mascota.GetPeso.ToString();
                }
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible obtener los datos de la mascota\n" + txtNombreMascotaReceta.Text + 
                    ". Intente de nuevo, si el problema persiste \ncontacte a su administrador.");
            }
        }
        #endregion

        #region snippet_METHOD_GetClienteByNameForRecetas
        public void GetClienteByNameForRecetas()
        {
            try
            {
                if (IsClienteForRecetas() == true)
                {
                    string nombreMascota = txtNombreMascotaReceta.Text;
                    Clientes cliente = clienteController.GetByNombreMascota(nombreMascota);

                    txtClienteMascotaReceta.Text = cliente.GetNombreCliente + " " + cliente.GetApellidoCliente;
                }
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible obtener los datos de la mascota\n" + txtNombreMascotaReceta.Text +
                    ". Intente de nuevo, si el problema persiste \ncontacte a su administrador.");
            }
        }
        #endregion

        #region snippet_METHOD_CreateDocumentoReceta
        public void CreateDocumentoReceta()
        {
            try
            {
                if (txtNombreMascotaReceta.Text != string.Empty && txtPesoMascotaReceta.Text != string.Empty 
                    && txtFechaTratamientoReceta.Text != string.Empty && txtClienteMascotaReceta.Text != string.Empty 
                    && txtTratamientoReceta.Text != string.Empty)
                {
                    var ruta = documentoController.Generate(tratamientoController.CreateId(), "Prescriptions", "receta");

                    RadTextBox[] textboxs =
                    {
                        txtNombreMascotaReceta,
                        txtPesoMascotaReceta,
                        txtFechaTratamientoReceta,
                        txtClienteMascotaReceta,
                        txtTratamientoReceta
                    };

                    String[] cadenas =
                    {
                        "nombreMascota",
                        "pesoMascota",
                        "fechaReceta",
                        "nombrePropietario",
                        "instruccionesMedicamentos"
                    };

                    for (int i = 0; i < textboxs.Count(); i++)
                    {
                        string cadenaFinal = textboxs[i].Text;
                        string cadenaInicial = cadenas[i];

                        var receta = new Documento(cadenaInicial, cadenaFinal, ruta);
                        documentoController.Write(receta);
                    }
                }
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible escribir los datos en la receta. Intente de nuevo," +
                    "\n" + "si el problema persiste contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_METHOD_PrintDocumentoReceta
        public void PrintDoucumentoReceta()
        {
            try
            {
                if (txtNombreMascotaReceta.Text != string.Empty && txtPesoMascotaReceta.Text != string.Empty 
                    && txtFechaTratamientoReceta.Text != string.Empty && txtClienteMascotaReceta.Text != string.Empty 
                    && txtTratamientoReceta.Text != string.Empty)
                {
                    int id = tratamientoController.CreateId();
                    documentoController.Print(id, "Prescriptions");
                }
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible imprimir el documento. Intente de nuevo," +
                    "\n" + "si el problema persiste contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_METHOD_GetRecetas
        public void GetRecetas()
        {
            try
            {
                List<Tratamientos> tratamientos = tratamientoController.GetAll();

                rgvConsultaRecetas.Rows.Clear();

                foreach (var tratamiento in tratamientos)
                {
                    rgvConsultaRecetas.Rows.Add(
                            tratamiento.GetIdTratamiento,
                            tratamiento.GetNombreMascota,
                            tratamiento.GetPesoMascota,
                            tratamiento.GetNombreCliente,
                            tratamiento.GetFechaTratamiento,
                            tratamiento.GetTratamiento
                    );
                }
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible obtener la lista de recetas. Reinicie la aplicación\n"
                    + "si el problema persiste contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_EVENT_IsClienteForRecetas
        private void rtsIsClienteExpedirRecetas_ValueChanged(object sender, EventArgs e)
        {
            IsClienteForRecetas();
        }
        #endregion

        #region snippet_METHOD_IsClienteForRecetas
        public bool IsClienteForRecetas()
        {
            bool resultado = false;
            if (rtsIsClienteExpedirRecetas.Value == true)
            {
                pcbAnimationExpedirReceta.Visible = true;
                lblInstructivoExpedirReceta.Visible = true;
                resultado = true;
                return resultado;
            }
            else
            {
                pcbAnimationExpedirReceta.Visible = false;
                lblInstructivoExpedirReceta.Visible = false;
                return resultado;
            }
        }
        #endregion

        #region snippet_METHOD_CleanRecetas
        public void CleanRecetas()
        {
            RadTextBox[] textboxs =
                {
                    txtIdMascotaReceta,
                    txtNombreMascotaReceta,
                    txtPesoMascotaReceta,
                    txtClienteMascotaReceta,
                    txtTratamientoReceta
                };

            for (int i = 0; i < textboxs.Length; i++)
            {
                textboxs[i].Text = string.Empty;
            }
        }
        #endregion

        //<sumary>
        //For certificates
        //<sumary>
        #region snippet_EVENT_CreateCertificado
        private void btnGuardarCertificado_Click(object sender, EventArgs e)
        {
            CreateDocumentoCertificado();
            PrintDocumentoCertificado();
            CreateCertificado();
            GetCertificados();
            CleanCertificados();
        }
        #endregion

        #region snippet_METHOD_CreateCertificado
        public void CreateCertificado()
        {
            try
            {
                if (txtFechaCertificado.Text != string.Empty && txtNombreMascotaCertiicado.Text != string.Empty 
                    && txtEspecieMascotaCertificado.Text != string.Empty && txtRazaMascotaCertificado.Text != string.Empty 
                    && txtEdadMascotaCertificado.Text != string.Empty && txtColorMascotaCertificado.Text != string.Empty 
                    && txtNombreClienteCertificado.Text != string.Empty && txtDirClienteCertificado.Text != string.Empty 
                    && txtTelClienteCertificado.Text != string.Empty)
                {
                    if (IsClienteForCertificados() == true)
                    {
                        var certificado = new Certificados(
                            certificadoController.CreateId(), txtNombreMascotaCertiicado.Text, txtEspecieMascotaCertificado.Text,
                            txtRazaMascotaCertificado.Text, dtpFechaNacimientoCertificado.Value.ToString().Substring(0, 10),
                            int.Parse(txtEdadMascotaCertificado.Text), txtColorMascotaCertificado.Text, ddlSexoMascotaCertificado.Text,
                            txtNombreClienteCertificado.Text, txtDirClienteCertificado.Text, txtTelClienteCertificado.Text,
                            txtFechaCertificado.Text, int.Parse(txtIdMascotaCertificado.Text)
                        );

                        certificadoController.Create(certificado);
                        alerta.MostrarAlerta("success", "Datos actualizados correctamente.");
                    }
                }
                else
                {
                    alerta.MostrarAlerta("danger", "Indica un valor para todos los campos");
                }
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible registrar el certificado. Intente de nuevo," +
                    "\n" + "si el problema persiste contacte a su administrador.");
            }
}
        #endregion

        #region snippet_EVENT_GetMascotaAndClienteByNameForCertificados
        private void txtNombreMascotaCertificado_TextChanged(object sender, EventArgs e)
        {
            GetMascotaByNameForCertificados();
            GetClienteByNameForCertificados();
        }
        #endregion

        #region snippet_METHOD_GetMascotaByNameForCertificados
        public void GetMascotaByNameForCertificados()
        {
            try
            {
                string nombreMascota = txtNombreMascotaCertiicado.Text;
                Mascotas mascota = mascotaController.GetByName(nombreMascota);

                txtIdMascotaCertificado.Text = mascota.GetIdMascota.ToString();
                txtEspecieMascotaCertificado.Text = mascota.GetEspecie;
                txtRazaMascotaCertificado.Text = mascota.GetRaza;
                txtColorMascotaCertificado.Text = mascota.GetColor;
                dtpFechaNacimientoCertificado.Text = mascota.GetFechaNacimiento;
                txtEdadMascotaCertificado.Text = mascota.GetEdadMascota.ToString();
                ddlSexoMascotaCertificado.Text = mascota.GetSexoMascota;
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible obtener los datos para la mascota " + txtNombreMascotaCertiicado.Text +
                    "\n. Intente de nuevo, si no es posible, contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_METHOD_GetClienteByNameForCertificados
        public void GetClienteByNameForCertificados()
        {
            try
            {
                string nombreMascota = txtNombreMascotaCertiicado.Text;
                Clientes cliente = clienteController.GetByNombreMascota(nombreMascota);

                txtNombreClienteCertificado.Text = cliente.GetNombreCliente + " " + cliente.GetApellidoCliente;
                txtTelClienteCertificado.Text = cliente.GetTelefonoCliente;
                txtDirClienteCertificado.Text = cliente.GetDireccionCliente;
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible obtener los datos del dueño de la mascota " + txtNombreMascotaCertiicado.Text +
                    "\n. Intente de nuevo, si el problema persiste, contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_METHOD_CreateDocumentoCertificado
        public void CreateDocumentoCertificado()
        {
            try
            {
                if (txtFechaCertificado.Text != string.Empty && txtNombreMascotaCertiicado.Text != string.Empty 
                    && txtEspecieMascotaCertificado.Text != string.Empty && txtRazaMascotaCertificado.Text != string.Empty 
                    && txtEdadMascotaCertificado.Text != string.Empty && txtColorMascotaCertificado.Text != string.Empty 
                    && txtNombreClienteCertificado.Text != string.Empty && txtDirClienteCertificado.Text != string.Empty 
                    && txtTelClienteCertificado.Text != string.Empty)
                {
                    var ruta = documentoController.Generate(certificadoController.CreateId(), "Certificates", "certificado");

                    RadTextBox[] textboxs =
                    {
                    txtFechaCertificado,
                    txtNombreMascotaCertiicado,
                    txtEspecieMascotaCertificado,
                    txtRazaMascotaCertificado,
                    txtEdadMascotaCertificado,
                    txtColorMascotaCertificado,
                    txtNombreClienteCertificado,
                    txtDirClienteCertificado,
                    txtTelClienteCertificado
                };

                    String[] cadenas =
                    {
                    "fechaCertificado",
                    "pet",
                    "#especie",
                    "#raza",
                    "#edad",
                    "#color",
                    "prop",
                    "dir",
                    "myNumber"
                };

                    var certificado = new Documento();
                    for (int i = 0; i < textboxs.Length; i++)
                    {
                        string cadenaFinal = textboxs[i].Text;
                        string cadenaInicial = cadenas[i];

                        certificado = new Documento(cadenaInicial, cadenaFinal, ruta);
                        documentoController.Write(certificado);
                    }

                    certificado = new Documento("nac", dtpFechaNacimientoCertificado.Value.ToString().Substring(0, 10), ruta);
                    documentoController.Write(certificado);
                    certificado = new Documento("#sex", ddlSexoMascotaCertificado.Text, ruta);
                    documentoController.Write(certificado);
                }
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible escribir los datos en el certificado. Intente de nuevo," +
                    "\n" + "si el problema persiste contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_METHOD_PrintDocumentoCertificado
        public void PrintDocumentoCertificado()
        {
            try
            {
                if (txtFechaCertificado.Text != string.Empty && txtNombreMascotaCertiicado.Text != string.Empty 
                    && txtEspecieMascotaCertificado.Text != string.Empty && txtRazaMascotaCertificado.Text != string.Empty 
                    && txtEdadMascotaCertificado.Text != string.Empty && txtColorMascotaCertificado.Text != string.Empty 
                    && txtNombreClienteCertificado.Text != string.Empty && txtDirClienteCertificado.Text != string.Empty 
                    && txtTelClienteCertificado.Text != string.Empty)
                {
                    int id = certificadoController.CreateId();
                    documentoController.Print(id, "Certificates");
                }
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible imprimir el documento. Intente de nuevo," +
                    "\n" + "si el problema persiste contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_METHOD_GetCertificados
        public void GetCertificados()
        {
            try
            {
                List<Certificados> certificados = certificadoController.GetAll();

                rgvConsutaCertificados.Rows.Clear();

                foreach (var certificado in certificados)
                {
                    rgvConsutaCertificados.Rows.Add(
                        certificado.GetFolio,
                        certificado.GetNombreMascota,
                        certificado.GetEspecie,
                        certificado.GetRaza,
                        certificado.GetEdad,
                        certificado.GetSexo,
                        certificado.GetNombreCliente,
                        certificado.GetFechaCertificado
                    );
                }
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible obtener la lista de los certificados. Reinicia la aplicación\n"
                    + "si el problema persiste, contacta a tu administrador.");
            }
        }
        #endregion

        #region snippet_EVENT_IsClienteForCertificados
        private void rtsIsClienteExpedirCertificados_ValueChanged(object sender, EventArgs e)
        {
            IsClienteForCertificados();
        }
        #endregion

        #region snippet_METHOD_IsClienteForCertificados
        public bool IsClienteForCertificados()
        {
            bool resultado = false;
            if (rtsIsClienteExpedirCertificados.Value == true)
            {
                pcbAnimationExpedirCertificado.Visible = true;
                lblInstructivoExpedirCertificado.Visible = true;
                resultado = true;
                return resultado;
            }
            else
            {
                pcbAnimationExpedirCertificado.Visible = false;
                lblInstructivoExpedirCertificado.Visible = false;
                return resultado;
            }
        }
        #endregion

        #region snippet_METHOD_CleanCertificados
        public void CleanCertificados()
        {
            RadTextBox[] textboxs =
                {
                    txtNombreMascotaCertiicado,
                    txtEspecieMascotaCertificado,
                    txtRazaMascotaCertificado,
                    txtEdadMascotaCertificado,
                    txtColorMascotaCertificado,
                    txtNombreClienteCertificado,
                    txtDirClienteCertificado,
                    txtTelClienteCertificado
                };

            for (int i = 0; i < textboxs.Length; i++)
            {
                textboxs[i].Text = string.Empty;
            }

            ddlSexoMascotaCertificado.Text = "Seleccionar";
        }
        #endregion

        //<sumary>
        //For services
        //</sumary>
        #region snippet_EVENT_CreateServicio
        private void btnRegistrarServicio_Click(object sender, EventArgs e)
        {
            CreateServicio();
            CleanServicios();
            GetAllServicios();
            GetAllNoServicios();
        }
        #endregion

        #region snippet_METHOD_CreateServicio
        public void CreateServicio()
        {
            try
            {
                if (txtDetalleServicioServicios.Text != string.Empty && txtDetalleCostoAdicional.Text != string.Empty
                    && txtCostoServicio.Text != string.Empty && txtCostoAdicional.Text != string.Empty
                    && txtPagoServicio.Text != string.Empty && txtDescuentoServicio.Text != string.Empty
                    && ddlNombreServicioServicios.Text != "Seleccionar")
                {
                    int id = servicioController.CreateId();
                    var servicio = new Servicios(
                                id,
                                txtFechaRegistroServicios.Text,
                                txtDetalleServicioServicios.Text,
                                txtDetalleCostoAdicional.Text,
                                float.Parse(txtCostoServicio.Text),
                                float.Parse(txtDescuentoServicio.Text),
                                float.Parse(txtCostoAdicional.Text),
                                float.Parse(txtPagoServicio.Text),
                                float.Parse(lblCambioServicio.Text),
                                float.Parse(lblTotal.Text),
                                int.Parse(txtIdClienteServicios.Text),
                                int.Parse(txtIdMascotaServicios.Text),
                                int.Parse(txtIdServicioServicios.Text)
                            );

                    servicioController.Create(servicio);
                    alerta.MostrarAlerta("success", "Datos actualizados correctamente");
                }
                else
                {
                    alerta.MostrarAlerta("danger", "Indica un valor para todos los campos");
                }
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible registrar el servicio. Intente de nuevo," +
                    "\n" + "si el problema persiste contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_EVENT_GetMascotaByNameForServicios
        private void txtBuscarNombreMascotaServicios_TextChanged(object sender, EventArgs e)
        {
            GetMascotaByNameForServicios();
        }
        #endregion

        #region snippet_METHOD_GetMascotaByNameForServicios
        public void GetMascotaByNameForServicios()
        {
            try
            {
                string nombreMascota = txtBuscarNombreMascotaServicios.Text;
                var mascota = mascotaController.GetByName(nombreMascota);

                txtNombreNoMascotaServicios.Text = mascota.GetNombreMascota;
                txtEspecieNoMascotaServicios.Text = mascota.GetEspecie;
                txtRazaNoMascotaServicios.Text = mascota.GetRaza;
                txtColorNoMascotaServicios.Text = mascota.GetColor;
                txtEdadNoMascotaServicios.Text = mascota.GetEdadMascota.ToString();
                ddlSexoNoMascotaServicios.Text = mascota.GetSexoMascota;
                dtpFechaNacNoMascotaServicios.Text = mascota.GetFechaNacimiento;
                txtIdMascotaServicios.Text = mascota.GetIdMascota.ToString();

                var cliente = clienteController.GetByNombreMascota(nombreMascota);

                txtNombreNoClienteServicios.Text = cliente.GetNombreCliente;
                txtApellidoNoClienteServicios.Text = cliente.GetApellidoCliente;
                txtEdadNoClienteServicios.Text = cliente.GetEdadCliente.ToString();
                txtTelNoClienteServicios.Text = cliente.GetTelefonoCliente;
                ddlSexoNoClienteServicios.Text = cliente.GetSexoCliente;
                txtEmailNoClienteServicios.Text = cliente.GetCorreoCliente;
                txtDirNoClienteServicios.Text = cliente.GetDireccionCliente;
                txtIdClienteServicios.Text = cliente.GetIdCliente.ToString();
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible consultar los datos de la mascota. Intente de nuevo," +
                    "\n" + "si el problema persiste contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_EVENT_IsCliente
        private void rtsEsCliente_ValueChanged(object sender, EventArgs e)
        {
            IsCliente();
        }
        #endregion

        #region snippet_METHOD_IsCliente
        public bool IsCliente()
        {
            bool resultado = false;
            if (rtsEsCliente.Value == true)
            {
                lblNombreDeLaMascota.Visible = true;
                txtBuscarNombreMascotaServicios.Visible = true;
                pcbIconRegistrarServicioServicios.Visible = true;
                lblRegistrarServicioServicios.Visible = true;
                resultado = true;
                return resultado;
            }
            else
            {
                lblNombreDeLaMascota.Visible = false;
                txtBuscarNombreMascotaServicios.Visible = false;
                pcbIconRegistrarServicioServicios.Visible = false;
                lblRegistrarServicioServicios.Visible = false;
                return resultado;
            }
        }
        #endregion

        #region snippet_EVENT_GetClienteAndMascotaByIdOnServicios
        private void rgvServiciosClientes_CellClick(object sender, GridViewCellEventArgs e)
        {
            GetClienteByIdOnServicios(sender, e);
            GetMascotaByIdOnServicios(sender, e);
        }
        #endregion

        #region snippet_METHOD_GetClienteByIdOnServicios
        public void GetClienteByIdOnServicios(object sender, GridViewCellEventArgs e)
        {
            try
            {
                int id = int.Parse(rgvServiciosClientes.Rows[e.RowIndex].Cells[2].Value.ToString());
                Clientes cliente = clienteController.GetById(id);

                lblIdClienteServicios.Text = cliente.GetIdCliente.ToString();
                lblNombreClienteServicios.Text = cliente.GetNombreCliente;
                lblApellidoClienteServicios.Text = cliente.GetApellidoCliente;
                lblTelClienteServicios.Text = cliente.GetTelefonoCliente;
                lblDirClienteServicios.Text = cliente.GetDireccionCliente;
                lblEdadClienteServicios.Text = cliente.GetEdadCliente.ToString();
                lblEmailClienteServicios.Text = cliente.GetCorreoCliente;
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible recuperar los datos del cliente seleccionado. Intente de nuevo," +
                    "\n" + "si el problema persiste contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_METHOD_GetMascotaByIdOnServicios
        public void GetMascotaByIdOnServicios(object sender, GridViewCellEventArgs e)
        {
            try
            {
                int id = int.Parse(rgvServiciosClientes.Rows[e.RowIndex].Cells[3].Value.ToString());
                Mascotas mascota = mascotaController.GetById(id);

                lblIdMascotaServicios.Text = mascota.GetIdMascota.ToString();
                lblNombreMascotaServicios.Text = mascota.GetNombreMascota;
                lblEspecieMascotaServicios.Text = mascota.GetEspecie;
                lblRazaMascotaServicios.Text = mascota.GetRaza;
                lblEdadMascatoServicios.Text = mascota.GetEdadMascota.ToString();
                lblSexoMascotaServicios.Text = mascota.GetSexoMascota;
                lblColorMascotaServicios.Text = mascota.GetColor;
                lblFechaNaMascotaServicios.Text = mascota.GetFechaNacimiento;
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible recuperar los datos de la mascota seleccionada. Intente de nuevo," +
                    "\n" + "si el problema persiste contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_EVENT_GetDetalleServicioNoCliente
        private void rgvNoServicios_CellClick(object sender, GridViewCellEventArgs e)
        {
            GetDetalleServicioNoCliente(sender, e);
        }
        #endregion

        #region snippet_METHOD_GetDetalleServicioNoCliente
        public void GetDetalleServicioNoCliente(object sender, GridViewCellEventArgs e)
        {
            try
            {
                int id = int.Parse(rgvNoServcios.Rows[e.RowIndex].Cells[0].Value.ToString());
                Servicios servicio = servicioController.GetById(id);

                lblIdRegistroServiciosNoCliente.Text = servicio.GetIdRegistro.ToString();
                lblFechaServicioNoCliente.Text = servicio.GetFechaRegistro;
                lblDescripcionServicioNoCliente.Text = servicio.GetDescripionServicio;
                lblDescripcionCAServicioNoCliente.Text = servicio.GetDescripcionCostoAdicional;
                lblCostoServicioNoCliente.Text = servicio.GetCosto.ToString();
                lblDescuentoServicioNoCliente.Text = servicio.GetDescuento.ToString();
                lblCostoAdicionalServicioNoCliente.Text = servicio.GetCostoAdicional.ToString();
                lblPagoServicioNoCliente.Text = servicio.GetPago.ToString();
                lblCambioServicioNoCliente.Text = servicio.GetCambio.ToString();
                lblTotalServicioNoCliente.Text = servicio.GetTotal.ToString();
            }
            catch
            {
                alerta.MostrarAlerta("danger", "No fue posible obtener los datos del servicio seleccionado.\n"
                    + "Si el problema persiste, contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_EVENT_CalcularTotalServicio
        private void CalcularTotalServicio_TextChanged(object sender, EventArgs e)
        {
            CalcularTotalServicio();
        }
        #endregion

        #region snippet_METHOD_CalcularTotalServicio
        public void CalcularTotalServicio()
        {
            try
            {
                int totalDescuento = 0;
                int totalFinal = 0;

                int costo = int.Parse(txtCostoServicio.Text);
                int descuento = int.Parse(txtDescuentoServicio.Text);
                int costoAdicional = int.Parse(txtCostoAdicional.Text);

                int total = costo + costoAdicional;
                int pago = int.Parse(txtPagoServicio.Text);

                if (descuento != 0)
                {
                    totalDescuento = total / 100;
                    totalFinal = total - totalDescuento;
                }
                else
                {
                    totalFinal = total;
                }

                int cambio = pago - totalFinal;

                lblTotal.Text = totalFinal.ToString();
                lblCambioServicio.Text = cambio.ToString();
            }
            catch (Exception /*dex*/)
            {
                
            }
        }
        #endregion

        #region snippet_METHOD_GetAllServicios
        public void GetAllServicios()
        {
            try
            {
                List<Servicios> servicios = servicioController.GetAll();
                rgvServiciosClientes.Rows.Clear();
                foreach (var servicio in servicios)
                {
                    rgvServiciosClientes.Rows.Add(
                            servicio.GetIdRegistro, servicio.GetFechaRegistro, servicio.GetIdCliente,
                            servicio.GetIdMascota, servicio.GetDescripionServicio
                        );
                }
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible obtener la lista de servicios registrados. Cierre la aplicación e intente de nuevo," +
                    "\n" + "si el problema persiste contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_METHOD_GetAllNoServicios
        public void GetAllNoServicios()
        {
            try
            {
                List<Servicios> noServicios = servicioController.GetAllNoServicios();
                rgvNoServcios.Rows.Clear();
                foreach (var noServicio in noServicios)
                {
                    rgvNoServcios.Rows.Add(
                            noServicio.GetIdRegistro, noServicio.GetFechaRegistro, noServicio.GetDescripionServicio
                        );
                }
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible obtener la lista de servicios registrados. Cierre la aplicación e intente de nuevo," +
                    "\n" + "si el problema persiste contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_METHOD_CleanServicios
        public void CleanServicios()
        {
            RadTextBox[] textboxs =
            {
                txtDetalleServicioServicios,
                txtIdClienteServicios,
                txtIdMascotaServicios,
                txtIdServicioServicios,
                txtBuscarNombreMascotaServicios,
                txtNombreNoMascotaServicios,
                txtEspecieNoMascotaServicios,
                txtRazaNoMascotaServicios,
                txtColorNoMascotaServicios,
                txtEdadNoMascotaServicios,
                txtNombreNoClienteServicios,
                txtApellidoNoClienteServicios,
                txtEdadNoClienteServicios,
                txtTelNoClienteServicios,
                txtEmailNoClienteServicios,
                txtDirNoClienteServicios,
                txtDetalleServicioServicios,
                txtDetalleCostoAdicional,
            };

            for (int i = 0; i < textboxs.Length; i++)
            {
                textboxs[i].Text = string.Empty;
            }

            txtCostoServicio.Text = "0";
            txtPagoServicio.Text = "0";
            txtCostoAdicional.Text = "0";
            txtDescripcionServicio.Text = "0";

            ddlNombreServicioServicios.Text = "Seleccionar";
            ddlSexoNoMascotaServicios.Text = "Seleccionar";
            ddlSexoNoClienteServicios.Text = "Seleccionar";
            ddlNombreServicioServicios.Text = "Seleccionar";
            lblCambioServicio.Text = "0.00";
            lblTotal.Text = "0.00";
        }
        #endregion

        //<sumary>
        //For CatalogServicios
        //</sumary>
        #region snippet_EVENT_CreateCatalogoServicio
        private void btnGuardarServicio_Click(object sender, EventArgs e)
        {
            IsUpdateOrCreateServicio();
            GetNombreServicio();
            CleanCatalogoServicios();
        }
        #endregion

        #region snippet_METHOD_CreateCatalogoServicio
        public void CreateCatalogoServicio()
        {
            try
            {
                if (txtNombreServicio.Text != string.Empty && txtCostoServicioASServicios.Text != string.Empty
                && txtDescripcionServicio.Text != string.Empty)
                {
                    int id = catalogoServicioController.CreateId();
                    var catalogo = new CatalogoServicio(
                            id,
                            txtNombreServicio.Text,
                            txtDescripcionServicio.Text,
                            float.Parse(txtCostoServicioASServicios.Text)
                        );

                    catalogoServicioController.Create(catalogo);
                    alerta.MostrarAlerta("success", "Datos actualizados correctamente");
                }
                else
                {
                    alerta.MostrarAlerta("danger", "Indica un valor para los campos");
                }               
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible registrar el servicio. Intente de nuevo," +
                    "\n" + "si el problema persiste contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_EVENT_GetServicioByName
        private void txtNombreServicioMSServicios_TextChanged(object sender, EventArgs e)
        {
            GetServicioByName();
        }
        #endregion

        #region snippet_METHOD_GetServicioByName
        public void GetServicioByName()
        {
            try
            {
                if (txtNombreServicioMSServicios.Text != string.Empty)
                {
                    string nombreServicio = txtNombreServicioMSServicios.Text;

                    CatalogoServicio servicio = catalogoServicioController.GetByName(nombreServicio);

                    txtIdServicioMSServicios.Text = servicio.GetIdServicio.ToString();
                    txtNombreServicio.Text = servicio.GetNombreServicio;
                    txtCostoServicioASServicios.Text = servicio.GetCosto.ToString();
                    txtDescripcionServicio.Text = servicio.GetDescripcionServicio;
                }
            }
            catch
            {
                alerta.MostrarAlerta("danger", "No fue posible obtener los datos para el servicio: " + txtNombreServicioMSServicios.Text
                    + "\n intente de nuevo, si el problema persiste contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_EVENT_GetIdServicio
        private void ddlNombreServicioServicios_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            GetIdServicio();
        }
        #endregion

        #region snippet_METHOD_GetIdServicio
        public void GetIdServicio()
        {
            try
            {
                int id = catalogoServicioController.GetIdByName(ddlNombreServicioServicios.Text);
                txtIdServicioServicios.Text = id.ToString();

                CatalogoServicio servicio = catalogoServicioController.GetById(id);
                txtCostoServicio.Text = servicio.GetCosto.ToString();
            }
            catch(Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible obtener los datos del servicio. Intente de nuevo," +
                    "\n" + "si el problema persiste contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_METHOD_UpdateServicio
        public void UpdateServicio()
        {
            try
            {
                if (txtNombreServicio.Text != string.Empty && txtCostoServicioASServicios.Text != string.Empty
                && txtDescripcionServicio.Text != string.Empty)
                {
                    var catalogo = new CatalogoServicio(
                            int.Parse(txtIdServicioMSServicios.Text),
                            txtNombreServicio.Text,
                            txtDescripcionServicio.Text,
                            float.Parse(txtCostoServicioASServicios.Text)
                        );

                    catalogoServicioController.Update(catalogo);
                    alerta.MostrarAlerta("success", "Servicio actualizado correctamente");
                }
                else
                {
                    alerta.MostrarAlerta("danger", "Indica un valor para los campos");
                }
            }
            catch
            {
                alerta.MostrarAlerta("danger", "No fue posible actulizar el servicio: " + txtNombreServicioMSServicios.Text
                    + "\n intente de nuevo, si el problema persiste contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_METHOD_IsUpdateOrCreateServicio
        public void IsUpdateOrCreateServicio()
        {
            if (IsUpdateServicio() == true)
            {
                UpdateServicio();
            }
            else
            {
                CreateCatalogoServicio();
            }
        }
        #endregion

        #region snippet_EVENT_IsUpdateServicio
        private void rtsIsUpdateServicio_ValueChanged(object sender, EventArgs e)
        {
            IsUpdateServicio();
        }
        #endregion

        #region snippet_METHOD_IsUpdateServicio
        public bool IsUpdateServicio()
        {
            bool resultado = false;
            if (rtsIsUpdateServicio.Value == true)
            {
                lblNombreServicioMSServicios.Visible = true;
                txtNombreServicioMSServicios.Visible = true;
                resultado = true;
                return resultado;
            }
            else
            {
                lblNombreServicioMSServicios.Visible = false;
                txtNombreServicioMSServicios.Visible = false;
                return resultado;
            }
        }
        #endregion

        #region snippet_METHOD_GetNombreServicios
        public void GetNombreServicio()
        {
            try
            {
                List<CatalogoServicio> nombresServicios = catalogoServicioController.GetNombre();
                ddlNombreServicioServicios.Items.Clear();
                foreach (var nombreServicio in nombresServicios)
                {
                    ddlNombreServicioServicios.Items.Add(nombreServicio.GetNombreServicio);
                }
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible recuperar los nombres de los servicios. Intente de nuevo," +
                    "\n" + "si el problema persiste contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_METHOD_CleanCatalogoServicios
        public void CleanCatalogoServicios()
        {
            txtNombreServicio.Text = string.Empty;
            txtDescripcionServicio.Text = string.Empty;
            txtCostoServicioASServicios.Text = string.Empty;
        }
        #endregion

        //<sumary>
        //For CatalogoProducros
        //</sumary>
        #region snippet_EVENT_CreateProducto
        private void btnGuardarProducto_Click(object sender, EventArgs e)
        {
            IsCreateOrUpdateProducto();
            GetProductos();
            CleanProducto();
            GetNombreProductoForVentas();
        }
        #endregion

        #region snippet_METHOD_CreateProducto
        public void CreateProducto()
        {
            try
            {
                if (txtNombreProdcutoAPProductos.Text != string.Empty && txtPrecioCompraAPProductos.Text != string.Empty
                    && txtPrecioVentaAPProductos.Text != string.Empty && txtCantidadAGProductos.Text != string.Empty
                    && ddlMedidaAGProductos.Text != "Seleccionar")
                {
                    int id = catalogoProductosController.CreateId();
                    var producto = new CatalogoProductos(
                            id,
                            txtNombreProdcutoAPProductos.Text,
                            float.Parse(txtPrecioCompraAPProductos.Text),
                            float.Parse(txtPrecioVentaAPProductos.Text),
                            ddlMedidaAGProductos.Text,
                            float.Parse(txtCantidadAGProductos.Text)
                        );

                    catalogoProductosController.Create(producto);
                    alerta.MostrarAlerta("success", "Producto agregado correctamente");
                }
                else
                {
                    alerta.MostrarAlerta("danger", "Indica un valor para todos los campos");
                }
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("error", "No fue posible agregar el producto. Intente nuevamente\n"
                    + "si el problema persiste, contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_METHOD_UpdateProducto
        public void UpdateProducto()
        {
            try
            {
                if (txtNombreProdcutoAPProductos.Text != string.Empty && txtPrecioCompraAPProductos.Text != string.Empty
                    && txtPrecioVentaAPProductos.Text != string.Empty && txtCantidadAGProductos.Text != string.Empty
                    && ddlMedidaAGProductos.Text != "Seleccionar")
                {
                    int id = int.Parse(txtIdProductoMPProductos.Text);

                    var producto = new CatalogoProductos(
                        id,
                        txtNombreProdcutoAPProductos.Text,
                        float.Parse(txtPrecioCompraAPProductos.Text),
                        float.Parse(txtPrecioVentaAPProductos.Text),
                        ddlMedidaAGProductos.Text,
                        float.Parse(txtCantidadAGProductos.Text)
                    );
                    catalogoProductosController.Update(producto);
                    alerta.MostrarAlerta("success", "Producto actualizado correctamente");
                }
                else
                {
                    alerta.MostrarAlerta("danger", "Indica un valor para todos los campos");
                }
                    
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("error", "No fue posible actualizar el producto: "
                    + txtNombreProductoMPProductos + "\n intenté de nuevo, si el problema persiste"
                    + " contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_METHOD_GetProductos
        public void GetProductos()
        {
            try
            {
                List<CatalogoProductos> productos = catalogoProductosController.GetAll();
                rgvConsultaProductos.Rows.Clear();
                foreach (var producto in productos)
                {
                    rgvConsultaProductos.Rows.Add(
                            producto.GetIdProducto,
                            producto.GetNombreProducto,
                            producto.GetPrecioCompra,
                            producto.GetPrecioVenta,
                            producto.GetUnidad,
                            producto.GetCantidad
                        );
                }
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("error", "No fue posible obtener la lista de los productos\n registrados"
                    + " reinicie la aplicación, si el problema persiste contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_EVENT_GetById
        private void txtIdProductoEPProductos_TextChanged(object sender, EventArgs e)
        {
            GetProductoById();
        }
        #endregion

        #region snippet_METHOD_GetProductoById
        public void GetProductoById()
        {
            try
            {
                if (txtIdProductoEPProductos.Text != string.Empty)
                {
                    int id = int.Parse(txtIdProductoEPProductos.Text);
                    CatalogoProductos producto = catalogoProductosController.GetById(id);

                    lblIdProductoEPProductos.Text = producto.GetIdProducto.ToString();
                    lblNombreProductoEPProductos.Text = producto.GetNombreProducto;
                    lblPrecioCompraEPProductos.Text = producto.GetPrecioCompra.ToString();
                    lblPrecioVentaEPProductos.Text = producto.GetPrecioVenta.ToString();
                    lblUnidadEPProductos.Text = producto.GetUnidad;
                    lblCantidadEPProductos.Text = producto.GetCantidad.ToString();
                }
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("error", "No fue posible encontrar el producto con ID: " 
                    + txtIdProductoEPProductos.Text + "\n intente nuevamente, si el problema persiste"
                    + " contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_EVENT_DeleteProducto
        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            DeleteProducto();
            GetProductos();
            CleanProducto();
        }
        #endregion

        #region snippet_METHOD_DeleteProducto
        public void DeleteProducto()
        {
            try
            {
                if (txtIdProductoEPProductos.Text != string.Empty)
                {
                    int id = int.Parse(txtIdProductoEPProductos.Text);
                    catalogoProductosController.Delete(id);
                    alerta.MostrarAlerta("success", "Producto eliminado correctamente");
                }
                else
                {
                    alerta.MostrarAlerta("danger", "Indica un ID de producto");
                }
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("error", "No fue posible eliminar el producto: " + lblNombreProductoEPProductos.Text
                    + "\n intente de nuevo, si el problema persiste, contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_EVENT_GetProductoByName
        private void txtNombreProductoMPProductos_TextChanged(object sender, EventArgs e)
        {
            GetProductoByName();
        }
        #endregion

        #region snippet_METHOD_GetProductoByName
        public void GetProductoByName()
        {
            try
            {
                if (txtNombreProductoMPProductos.Text != string.Empty)
                {
                    string nombreProducto = txtNombreProductoMPProductos.Text;
                    CatalogoProductos producto = catalogoProductosController.GetByName(nombreProducto);

                    txtIdProductoMPProductos.Text = producto.GetIdProducto.ToString();
                    txtNombreProdcutoAPProductos.Text = producto.GetNombreProducto;
                    txtPrecioCompraAPProductos.Text = producto.GetPrecioCompra.ToString();
                    txtPrecioVentaAPProductos.Text = producto.GetPrecioVenta.ToString();
                    ddlMedidaAGProductos.Text = producto.GetUnidad;
                    txtCantidadAGProductos.Text = producto.GetCantidad.ToString();
                }
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("error", "No se pudo traer los datos para el producto: " 
                    + txtNombreProductoMPProductos.Text + "\n intente de nuevo, si el problema persiste"
                    + " contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_EVENT_IsUpdateProducto
        private void rtsIsUpdateProducto_ValueChanged(object sender, EventArgs e)
        {
            IsUpdateProducto();
        }
        #endregion

        #region snippet_METHOD_IsUpdateProducto
        public bool IsUpdateProducto()
        {
            bool resultado = false;
            if (rtsIsUpdateProducto.Value == true)
            {
                lblNombreProductoMPProductos.Visible = true;
                txtNombreProductoMPProductos.Visible = true;
                resultado = true;
                return resultado;
            }
            else
            {
                lblNombreProductoMPProductos.Visible = false;
                txtNombreProductoMPProductos.Visible = false;
                return resultado;
            }
        }
        #endregion

        #region snippet_METHOD_IsCreateOrUpdateProducto
        public void IsCreateOrUpdateProducto()
        {
            if (IsUpdateProducto() == true)
            {
                UpdateProducto();
            }
            else
            {
                CreateProducto();
            }
        }
        #endregion

        #region snippet_METHOD_CleanProducto
        public void CleanProducto()
        {
            RadTextBox[] textboxs =
            {
                txtNombreProdcutoAPProductos,
                txtPrecioCompraAPProductos,
                txtPrecioVentaAPProductos,
                txtCantidadAGProductos
            };

            for (int i = 0; i < textboxs.Length; i++)
            {
                textboxs[i].Text = string.Empty;
            }

            ddlMedidaAGProductos.Text = "Seleccionar";

            RadLabel[] labels =
            {
                lblIdProductoEPProductos,
                lblNombreProductoEPProductos,
                lblPrecioCompraEPProductos,
                lblPrecioVentaEPProductos,
                lblUnidadEPProductos,
                lblCantidadEPProductos
            };

            for (int i = 0; i < labels.Length; i++)
            {
                labels[i].Text = "No definido";
            }
        }
        #endregion

        //<sumary>
        //For ventas
        //</sumary>
        #region snippet_EVENT_CreateVenta
        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            CreateVenta();
            CreateDetalleVenta();
            GetVentas();
            CleanVenta();
        }
        #endregion

        #region snippet_METHOD_CreateVenta
        public void CreateVenta()
        {
            try
            {
                if (txtNoProductosRVVentas.Text != string.Empty && txtPagoRVVentas.Text != string.Empty 
                    && ddlNombreProductoRVVentas.Text != "Seleccionar")
                {
                    int id = ventaController.CreateId();

                    var venta = new Ventas(
                            id,
                            txtFechaVentaRVVentas.Text,
                            int.Parse(txtNoProductosRVVentas.Text),
                            float.Parse(lblTotalRVVentas.Text),
                            float.Parse(txtPagoRVVentas.Text),
                            float.Parse(lblCambioRVVentas.Text)
                        );

                    ventaController.Create(venta);
                    alerta.MostrarAlerta("success", "Venta completada correctamente.");
                }
                else
                {
                    alerta.MostrarAlerta("danger", "No se puede procesar una venta vacía");
                }
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible procesar la venta, intente de nuevo\n"
                    + "si el problema persiste contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_METHOD_CreateDetalleVenta
        public void CreateDetalleVenta()
        {
            try
            {
                if (rgvProductosVenta.Rows.Count != 0)
                {
                    int id = detalleVentaController.CreateId();

                    foreach (var producto in rgvProductosVenta.Rows)
                    {
                        var detalleVenta = new DetalleVenta(
                            id,
                            producto.Cells[1].Value.ToString(),
                            producto.Cells[3].Value.ToString(),
                            float.Parse(producto.Cells[4].Value.ToString()),
                            float.Parse(producto.Cells[2].Value.ToString()),
                            int.Parse(producto.Cells[0].Value.ToString())
                        );

                        detalleVentaController.Create(detalleVenta);
                    }
                }
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible cargar los productos a la venta, intente\n"
                    + "de nuevo, si el problema persiste contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_METHOD_GetVentas
        public void GetVentas()
        {
            try
            {
                List<Ventas> ventas = ventaController.GetAll();
                rgvConsultaVentas.Rows.Clear();

                foreach (var venta in ventas)
                {
                    rgvConsultaVentas.Rows.Add(
                            venta.GetIdVenta,
                            venta.GetFechaVenta,
                            venta.GetNoProductos,
                            venta.GetTotal,
                            venta.GetPago,
                            venta.GetCambio
                        );
                }
            }
            catch(Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible obtener el listado de ventas realizadas. Reinicie\n"
                    + "la aplicación, si el problema persiste contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_EVENT_GetDetalleVentas
        private void rgvConsultaVentas_CellClick(object sender, GridViewCellEventArgs e)
        {
            GetDetalleVentas(sender, e);
        }
        #endregion

        #region snippet_METHOD_GetDetalleVentas
        public void GetDetalleVentas(object sender, GridViewCellEventArgs e)
        {
            try
            {
                int id = int.Parse(rgvConsultaVentas.Rows[e.RowIndex].Cells[0].Value.ToString());

                List<DetalleVenta> detalleVentas = detalleVentaController.GetById(id);
                rgvConsultaDetalleVenta.Rows.Clear();

                foreach (var detalleVenta in detalleVentas)
                {
                    rgvConsultaDetalleVenta.Rows.Add(
                            detalleVenta.GetIdVenta,
                            detalleVenta.GetIdProducto,
                            detalleVenta.GetNomnreProducto,
                            detalleVenta.GetUnidad,
                            detalleVenta.GetCantidad,
                            detalleVenta.GetPrecio
                        );
                }
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible obtener el detalle de la venta seleccionada\n"
                    + "intente de nuevo, si el problema persiste contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_EVENT_GetProductoForVentas
        private void ddlNombreProductoRVVentas_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            GetProductoForVentas();
            CalcularTotal();
        }
        #endregion

        #region snippet_METHOD_GetProductoForVentas
        public void GetProductoForVentas()
        {
            try
            {
                string nombreProducto = ddlNombreProductoRVVentas.Text;
                CatalogoProductos producto = catalogoProductosController.GetByName(nombreProducto);

                rgvProductosVenta.Rows.Add(
                        producto.GetIdProducto,
                        producto.GetNombreProducto,
                        producto.GetPrecioVenta,
                        producto.GetUnidad,
                        producto.GetCantidad
                    );
            }
            catch
            {
                alerta.MostrarAlerta("danger", "No fue posible cargar el producto seleccionado en la lista\n"
                    + "de compras, intente de nuevo, si el error persist, contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_METHOD_GetNombreProductoForVentas
        public void GetNombreProductoForVentas()
        {
            try
            {
                List<CatalogoProductos> productos = catalogoProductosController.GetAll();
                ddlNombreProductoRVVentas.Items.Clear();

                foreach (var producto in productos)
                {
                    ddlNombreProductoRVVentas.Items.Add(
                            producto.GetNombreProducto
                        );
                }
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("error", "No fue posible cargar los nombre de los productos\n"
                    + "en la lista del carrito de compras. Contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_EVENT_GetProductoForAjustarPrecio
        private void rgvProductosVenta_CellClick(object sender, GridViewCellEventArgs e)
        {
            GetProductoForAjustarPrecio(sender, e);
        }
        #endregion

        #region snippet_METHOD_GetProductoForAjustarPrecio
        public void GetProductoForAjustarPrecio(object sender, GridViewCellEventArgs e)
        {
            int id = int.Parse(rgvProductosVenta.Rows[e.RowIndex].Cells[0].Value.ToString());

            CatalogoProductos producto = catalogoProductosController.GetById(id);

            txtPrecioVentaInicialRVVentas.Text = producto.GetPrecioVenta.ToString();
            txtCantidadInicialRVVentas.Text = producto.GetCantidad.ToString();
        }
        #endregion

        #region snippet_EVENT_AjustarPrecio
        private void rgvProductosVenta_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            AjustarPrecio(sender, e);
            CalcularTotal();
        }
        #endregion

        #region snippet_METHOD_AjustarPrecio
        public void AjustarPrecio(object sender, GridViewCellEventArgs e)
        {
            try
            {
                float cantidadFinal = int.Parse(rgvProductosVenta.Rows[e.RowIndex].Cells[4].Value.ToString());

                float cantidadInicial = float.Parse(txtPrecioVentaInicialRVVentas.Text);
                float precioVentaInicial = float.Parse(txtCantidadInicialRVVentas.Text);

                float valorBase = cantidadInicial / precioVentaInicial;
                float precioFinal = valorBase * cantidadFinal;

                rgvProductosVenta.Rows[e.RowIndex].Cells[2].Value = precioFinal.ToString();
            }
            catch (Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible realizar el ajuste de precio del producto.\n"
                    + "Intente de nuevo, si el problema persiste, contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_METHOD_CalcularTotal
        public void CalcularTotal()
        {
            try
            {
                int total = 0;

                foreach (var producto in rgvProductosVenta.Rows)
                {
                    total += int.Parse(producto.Cells[2].Value.ToString());
                }

                lblTotalRVVentas.Text = total.ToString();
                txtNoProductosRVVentas.Text = rgvProductosVenta.Rows.Count().ToString();
            }
            catch(Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible calcular el total de la venta, intente\n"
                    + "si el problema persiste contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_EVENT_CalcularCambio
        private void txtPagoRVVentas_TextChanged(object sender, EventArgs e)
        {
            CalcularCambio();
        }
        #endregion

        #region snippet_METHOD_CalcularCambio
        public void CalcularCambio()
        {
            try
            {
                if (txtPagoRVVentas.Text != string.Empty)
                {
                    int pago = int.Parse(txtPagoRVVentas.Text);
                    int total = int.Parse(lblTotalRVVentas.Text);

                    int cambio = pago - total;
                    lblCambioRVVentas.Text = cambio.ToString();
                }
                else
                {
                    lblCambioRVVentas.Text = "0.00";
                }
            }
            catch(Exception /*dex*/)
            {
                alerta.MostrarAlerta("danger", "No fue posible calcular el cambio del cliente\n"
                    + "intente de nuevo, si el problema persiste contacte a su administrador.");
            }
        }
        #endregion

        #region snippet_METHOD_CleanVenta
        public void CleanVenta()
        {
            RadTextBox[] textboxVenta =
            {
                txtPrecioVentaInicialRVVentas,
                txtCantidadInicialRVVentas,
                txtNoProductosRVVentas,
                txtPagoRVVentas
            };

            for (int i = 0; i < textboxVenta.Length; i++)
            {
                textboxVenta[i].Text = string.Empty;
            }

            ddlNombreProductoRVVentas.Text = "Seleccionar";
            lblTotalRVVentas.Text = "0.00";
            lblCambioRVVentas.Text = "0.00";
            rgvProductosVenta.Rows.Clear();
        }
        #endregion
    }
}