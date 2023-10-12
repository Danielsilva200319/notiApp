using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoti.Dtos
{
    public class AuditoriaDto
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public int DesAccion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}