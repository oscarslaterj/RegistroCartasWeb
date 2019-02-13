using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class Destinatarios
    {
        [Key]
        public DateTime Fecha { get; set; }
        public int DestinatarioID { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }

        public Destinatarios()
        {
            Fecha = DateTime.Now;
            DestinatarioID = 0;
            Nombre = string.Empty;
            Cantidad = 0;
        }

    }
}
