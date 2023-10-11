using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class GenericoVsSubmodulo : BaseEntity
    {
        public PermisoGenerico PermisosGenericos { get; set; }
        public int IdGenerico { get; set; }
        public Submodulo Submodulos { get; set; }
        public int IdSubmodulo { get; set; }
        public Rol Roles{ get; set; }
        public int IdRol { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}