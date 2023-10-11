using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class BlockChain : BaseEntity
    {
        public TipoNotificacion TiposNotificaciones { get; set; }
        public int IdTipoNotificacion { get; set; }
        public HiloRespuesta HilosRespuestas { get; set; }
        public int IdHiloRespuesta { get; set; }
        public Auditoria Auditorias { get; set; }
        public int IdAuditoria { get; set; }
        public string HashGenerado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}