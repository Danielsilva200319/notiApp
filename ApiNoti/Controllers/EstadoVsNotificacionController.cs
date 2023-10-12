using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNoti.Dtos;
using AutoMapper;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiNoti.Controllers
{
    public class EstadoVsNotificacionController : BaseControllerAPi
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EstadoVsNotificacionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EstadoVsNotificacionDto>>>Get()
        {
            var estadoNotificaciones = await _unitOfWork.EstadoNotificaciones.GetAllAsync();
            return _mapper.Map<List<EstadoVsNotificacionDto>>(estadoNotificaciones);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EstadoVsNotificacionDto>>Get(int id)
        {
            var estadoNotificaciones = await _unitOfWork.EstadoNotificaciones.GetByIdAsync(id);
            if(estadoNotificaciones == null)
            {
                return NotFound();
            }
            return _mapper.Map<EstadoVsNotificacionDto>(estadoNotificaciones);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EstadoVsNotificacionDto>>Post(EstadoVsNotificacionDto estadoVsNotificacionDto)
        {
            var estadoNotificacion = _mapper.Map<EstadoVsNotificacionDto>(estadoVsNotificacionDto);

            if (estadoVsNotificacionDto.FechaCreacion == DateTime.MinValue)
            {
                estadoVsNotificacionDto.FechaCreacion = DateTime.Now; 
            }
            this._unitOfWork.EstadoNotificaciones.Add(EstadoNotificacion);
            await _unitOfWork.SaveAsync();
            
            if(estadoNotificacion == null)
            {
                return BadRequest();
            }
            estadoVsNotificacionDto.Id = estadoNotificacion.Id;
            return CreatedAtAction(nameof(Post), new {id = estadoVsNotificacionDto.Id}, estadoNotificacion);
        }
    }
}