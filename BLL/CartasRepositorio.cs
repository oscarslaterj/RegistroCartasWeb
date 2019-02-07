using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    class CartasRepositorio: RepositorioBase<Cartas>
    {
        public override bool Guardar(Cartas entity)
        {
            bool paso = false;
            try
            {
                if (_contexto.Set<Cartas>().Add(entity) != null)
                {
                    _contexto.Destinatarios.Find(entity.DestinatarioId).DestinatarioID += entity.IdCarta;
                    _contexto.SaveChanges();
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public override bool Eliminar(int id)
        {
            bool paso = false;
            try
            {
                Cartas entity = _contexto.Set<Cartas>().Find(id);
                _contexto.Destinatarios.Find(entity.DestinatarioId).DestinatarioID -= entity.IdCarta;
                _contexto.Set<Cartas>().Remove(entity);

                if (_contexto.SaveChanges() > 0)
                    paso = true;

                _contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

}
    
}
