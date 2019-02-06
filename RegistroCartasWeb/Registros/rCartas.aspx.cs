using BLL;
using Entities;
using RegistroCartasWeb.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistroCartasWeb
{
    public partial class rCartas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void Limpiar()
        {
            CartaIDTextBox.Text = "0";
            DestinatarioIDTextBox.Text = "0";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            CuerpoTextBox.Text = "";
           
        }

        private Cartas LlenaClase()
        {
            Cartas cr = new Cartas();

            cr.IdCarta = Utils.ToInt(CartaIDTextBox.Text);
            cr.Fecha = Convert.ToDateTime(FechaTextBox.Text).Date;
            cr.Cuerpo = CuerpoTextBox.Text;
            cr.DestinatarioId = Utils.ToInt(DestinatarioIDTextBox.Text);

            return cr;

        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {

            RepositorioBase<Cartas> repositoriobase = new RepositorioBase<Cartas>();
            Cartas cartas = repositoriobase.Buscar(Utils.ToInt(CartaIDTextBox.Text));
            if (cartas != null)
            {

                FechaTextBox.Text = cartas.Fecha.ToString();
                CuerpoTextBox.Text = cartas.Cuerpo;
                DestinatarioIDTextBox.Text = cartas.DestinatarioId.ToString();
            
                Utils.ShowToastr(this, "Busqueda exitosa", "Exito", "success");
            }
            else
            {
                Utils.ShowToastr(this, "No Hay Resultado", "Error", "error");
            }
        }

        protected void BtnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Cartas> repositorio = new RepositorioBase<Cartas>();
            Cartas cartas = new Cartas();
            bool paso = false;


            cartas = LlenaClase();

            if (cartas.IdCarta == 0)
            {
                paso = repositorio.Guardar(cartas);
                Utils.ShowToastr(this, "Guardado", "Exito", "success");
                Limpiar();
            }
            else
            {
                Cartas user = new Cartas();
                int id = Utils.ToInt(CartaIDTextBox.Text);
                RepositorioBase<Cartas> repository = new RepositorioBase<Cartas>();
                cartas = repository.Buscar(id);

                if (user != null)
                {
                    paso = repositorio.Modificar(LlenaClase());
                    Utils.ShowToastr(this, "Modificado", "Exito", "success");
                }
                else
                    Utils.ShowToastr(this, "Id no existe", "Error", "error");
            }

            if (paso)
            {
                Limpiar();
            }
            else
                Response.Write("<script>alert('No se pudo guardar');</script>");

        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Cartas> repositorio = new RepositorioBase<Cartas>();
            int id = Utils.ToInt(CartaIDTextBox.Text);

            var CuentasBancarias = repositorio.Buscar(id);

            if (CuentasBancarias != null)
            {
                if (repositorio.Eliminar(id))
                {
                    Utils.ShowToastr(this, "Eliminado", "Exito", "success");
                    Limpiar();
                }
                else
                    Utils.ShowToastr(this, "No se pudo eliminar", "Error", "error");
            }
            else
                Utils.ShowToastr(this, "No existe", "Error", "error");
        }
    }
    }
