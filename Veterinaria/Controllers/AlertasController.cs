using Veterinaria.Views.Alerts;

namespace Veterinaria.Controllers
{
    class AlertasController
    {
        public void MostrarAlerta(string tipo, string mensaje)
        {
            if (tipo == "success")
            {
                frmSuccess frmSuccess = new frmSuccess(mensaje);
                frmSuccess.ShowDialog();
            }
            else
            {
                frmDanger frmDanger = new frmDanger(mensaje);
                frmDanger.ShowDialog();
            }
        }
    }
}
