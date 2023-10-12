using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoti.Dtos
{
    public class HiloRespuestaDto
    {
        public int Id { get; set; }
        public string NombreTipo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}