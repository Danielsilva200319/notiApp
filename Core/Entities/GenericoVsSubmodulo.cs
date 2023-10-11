using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class GenericoVsSubmodulo : BaseEntity
    {
        public int IdPermisoGenerico { get; set; }
        public PermisoGenerico PermisosGenericos { get; set; }
        public int IdMaestroVsSubmodulos { get; set; }
        public MaestroVsSubmodulo MaestroVsSubmodulos { get; set; }
        public int IdRol { get; set; }
        public Rol Roles { get; set; }
    }
}