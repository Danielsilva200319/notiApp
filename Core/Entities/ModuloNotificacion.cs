using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ModuloNotificacion : BaseEntity
    {
        public string AsuntoNotificacion { get; set; }
        public TipoNotificacion TiposNotificaciones { get; set; }
        public int IdTipoNotificacion { get; set; }
        public Radicado Radicados { get; set; }
        public int IdRadicado { get; set; }
        public EstadoNotificacion EstadosNotificaciones { get; set; }
        public int IdEstadoNotificacion { get; set; }
        public HiloRespuesta HilosRespuestas { get; set; }
        public int IdHiloRespuesta { get; set; }
        public Formato Formatos { get; set; }
        public int IdFormato { get; set; }
        public TipoRequerimiento TiposRequerimientos { get; set; }
        public int IdTipoRequerimiento { get; set; }
        public string TextoNotificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}