using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly notiAppContext _context;
        private AuditoriaRepository _auditorias;
        private BlockChainRepository _blockChains;
        private EstadoNotificacionRepository _estadoNotificaciones;
        private FormatoRepository _formatos;
        private GenericoVsSubmoduloRepository _genericoVsSubmodulos;
        private HiloRespuestaRepository _hiloRespuestas;
        private MaestroVsSubmoduloRepository _maestroVsSubmodulos;
        private ModuloMaestroRepository _modulosMaestros;
        private ModuloNotificacionRepository _modulosNotificaciones;
        private PermisoGenericoRepository _permisosGenericos;
        private RadicadoRepository _radicados;
        private RolRepository _roles;
        private RolVsMaestroRepository _rolVsMaestros;
        private SubmoduloRepository _submodulos;
        private TipoNotificacionRepository _tiposNotificaciones;
        private TipoRequerimientoRepository _tiposRequerimientos;

        public IAuditoriaRepository Auditorias
        {
            get 
            { 
                if(_auditorias == null)
                {
                    _auditorias = new AuditoriaRepository(_context);
                }
                return _auditorias;
            }
        }
        public IBlockChainRepository BlockChains
        {
            get 
            { 
                if(_blockChains == null)
                {
                    _blockChains = new BlockChainRepository(_context);
                }
                return _blockChains;
            }
        }
        public IEstadoNotificacionRepository EstadoNotificaciones
        {
            get 
            { 
                if(_estadoNotificaciones == null)
                {
                    _estadoNotificaciones = new EstadoNotificacionRepository(_context);
                }
                return _estadoNotificaciones;
            }
        }
        public IFormatoRepository Formatos
        {
            get 
            { 
                if(_formatos == null)
                {
                    _formatos = new FormatoRepository(_context);
                }
                return _formatos;
            }
        }
        public IGenericoVsSubmoduloRepository GenericoVsSubmodulos
        {
            get 
            { 
                if(_genericoVsSubmodulos == null)
                {
                    _genericoVsSubmodulos = new GenericoVsSubmoduloRepository(_context);
                }
                return _genericoVsSubmodulos;
            }
        }
        public IHiloRepuestaRepository HiloRepuestaS
        {
            get 
            { 
                if(_hiloRespuestas == null)
                {
                    _hiloRespuestas = new HiloRespuestaRepository(_context);
                }
                return _hiloRespuestas;
            }
        }
        public IMaestroVsSubmoduloRepository MaestroVsSubmodulos
        {
            get 
            { 
                if(_maestroVsSubmodulos == null)
                {
                    _maestroVsSubmodulos = new MaestroVsSubmoduloRepository(_context);
                }
                return _maestroVsSubmodulos;
            }
        }
        public IModuloMaestroRepository ModulosMaestros
        {
            get 
            { 
                if(_modulosMaestros == null)
                {
                    _modulosMaestros = new ModuloMaestroRepository(_context);
                }
                return _modulosMaestros;
            }
        }
        public IModuloNotificacionRepository ModulosNotificaciones
        {
            get 
            { 
                if(_modulosNotificaciones == null)
                {
                    _modulosNotificaciones = new ModuloNotificacionRepository(_context);
                }
                return _modulosNotificaciones;
            }
        }
        public IPermisoGenericoRepository PermisosGenericos
        {
            get 
            { 
                if(_permisosGenericos == null)
                {
                    _permisosGenericos = new PermisoGenericoRepository(_context);
                }
                return _permisosGenericos;
            }
        }
        public IRadicadoRepository Radicados
        {
            get 
            { 
                if(_radicados == null)
                {
                    _radicados = new RadicadoRepository(_context);
                }
                return _radicados;
            }
        }
        public IRolRepository Roles
        {
            get 
            { 
                if(_roles == null)
                {
                    _roles = new RolRepository(_context);
                }
                return _roles;
            }
        }
        public IRolVsMaestroRepository RolVsMaestros
        {
            get 
            { 
                if(_rolVsMaestros == null)
                {
                    _rolVsMaestros = new RolVsMaestroRepository(_context);
                }
                return _rolVsMaestros;
            }
        }
        public ISubmoduloRepository Submodulos
        {
            get 
            { 
                if(_submodulos == null)
                {
                    _submodulos = new SubmoduloRepository(_context);
                }
                return _submodulos;
            }
        }
        public ITipoNotificacionRepository TiposNotificaciones
        {
            get 
            { 
                if(_tiposNotificaciones == null)
                {
                    _tiposNotificaciones = new TipoNotificacionRepository(_context);
                }
                return _tiposNotificaciones;
            }
        }
        public ITipoRequerimientoRepository TiposRequerimientos
        {
            get 
            { 
                if(_tiposRequerimientos == null)
                {
                    _tiposRequerimientos = new TipoRequerimientoRepository(_context);
                }
                return _tiposRequerimientos;
            }
        }

        public UnitOfWork(notiAppContext context)
        {
            _context = context;
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}