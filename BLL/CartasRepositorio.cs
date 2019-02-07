using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    class CartasRepositorio:  RepositorioBase<Cartas>
    {
        public bool Guardar(Cartas entity)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                if (contexto.Cartas.Add(entity) != null)
                {

                    var carta = contexto.Destinatarios.Find(entity.DestinatarioId);         
                    carta.Cantidad += 1;


                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();

            }
            catch (Exception) { throw; }

            return paso;
        }

        public bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                Cartas cartas = contexto.Cartas.Find(id);

                if (cartas != null)
                {
                    var destinario = contexto.Destinatarios.Find(cartas.DestinatarioId); 
                    destinario.Cantidad -= 1;
                    contexto.Entry(destinario).State = EntityState.Deleted;
                }

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                    contexto.Dispose();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }


        public override bool Modificar(Cartas entity)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            RepositorioBase<Cartas> repositorio = new RepositorioBase<Cartas>();
            try
            {

                var depositosanterior = repositorio.Buscar(entity.IdCarta);

                var destinatario = contexto.Destinatarios.Find(entity.DestinatarioId);
                var Cuentasanterior = contexto.Destinatarios.Find(depositosanterior.DestinatarioId);

                if (entity.DestinatarioId != depositosanterior.DestinatarioId)
                {
                    destinatario.Cantidad += 1;
                    Cuentasanterior.Cantidad -= 1;
                }

                contexto.Entry(entity).State = EntityState.Modified;

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();

            }
            catch (Exception) { throw; }

            return paso;
        }
    }

}
