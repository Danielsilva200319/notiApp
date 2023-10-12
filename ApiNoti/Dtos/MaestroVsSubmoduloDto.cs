using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoti.Dtos
{
    public class MaestroVsSubmoduloDto
    {
        public int Id { get; set; }
        public int IdModuloMaestro { get; set; }
        public int IdSubmodulo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}