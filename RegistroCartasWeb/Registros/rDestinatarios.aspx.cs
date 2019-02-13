using BLL;
using Entities;
using RegistroCartasWeb.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistroCartasWeb.Registros
{
    public partial class rDestinatarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void Limpiar()
        {
           DestinatarioIDTextBox.Text = "0";
           FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
           NombresTextBox.Text = "";
           CartasEnviadasTextBox.Text = "0";
        }

        private Destinatarios LlenaClase()
        {
            Destinatarios destinatario = new Destinatarios();
            destinatario.DestinatarioID = Utils.ToInt(DestinatarioIDTextBox.Text);
            destinatario.Fecha = Utilitarios.Utils.ToDateTime(FechaTextBox.Text);
            destinatario.Nombre = NombresTextBox.Text;
            destinatario.Cantidad = Utils.ToInt(CartasEnviadasTextBox.Text);

            return destinatario;
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Destinatarios> repositorio = new RepositorioBase<Destinatarios>();
            int id = Utils.ToInt(DestinatarioIDTextBox.Text);
            var destinatario = repositorio.Buscar(id);

            if (destinatario != null)
            {
                FechaTextBox.Text = destinatario.Fecha.ToString();
                NombresTextBox.Text = destinatario.Nombre;
               CartasEnviadasTextBox.Text = destinatario.Cantidad.ToString();
                Utils.ShowToastr(this, "Busqueda exitosa", "Exito", "success");
            }
            else
                Utils.ShowToastr(this, "No existe", "Error", "error");
        }

        protected void BtnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Destinatarios> repositorio = new RepositorioBase<Destinatarios>();
            Destinatarios destinatario = new Destinatarios();

            bool paso = false;
            destinatario = LlenaClase();

            int id = Utils.ToInt(DestinatarioIDTextBox.Text);

            if (id == 0)
            {
                paso = repositorio.Guardar(destinatario);
                Utils.ShowToastr(this, "Guardado", "Exito", "success");
            }
            else
            {
                RepositorioBase<Destinatarios> repository = new RepositorioBase<Destinatarios>();
                int ids = Utils.ToInt(DestinatarioIDTextBox.Text);
                destinatario = repository.Buscar(ids);
                if (destinatario != null)
                {
                    paso = repositorio.Modificar(LlenaClase());
                    Utils.ShowToastr(this, "Modificado", "Exito", "success");
                }
                else
                    Utils.ShowToastr(this, "No existe", "Error", "error");
            }

            if (paso)
            {
                Limpiar();
            }
            else
                Utils.ShowToastr(this, "No se pudo guardar", "Error", "error");
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Destinatarios> repositorio = new RepositorioBase<Destinatarios>();
            int id = Utils.ToInt(DestinatarioIDTextBox.Text);
            var destinatario = repositorio.Buscar(id);
            bool paso = false;

            if (destinatario != null)
            {
                paso = repositorio.Eliminar(id);
                if (paso)
                    Utils.ShowToastr(this, "Eliminado", "Exito", "success");
                else
                    Utils.ShowToastr(this, "No se pudo eliminar", "Error", "error");
            }
            else
                Utils.ShowToastr(this, "No existe", "Error", "error");
        }
    }
    }
