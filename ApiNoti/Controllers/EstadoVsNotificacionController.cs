using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNoti.Dtos;
using AutoMapper;
using Core.Entities;
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
            var estadoVsNotificaciones = await _unitOfWork.EstadoVsNotificaciones.GetAllAsync();
            return _mapper.Map<List<EstadoVsNotificacionDto>>(estadoVsNotificaciones);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EstadoVsNotificacionDto>>Get(int id)
        {
            var estadoVsNotificaciones = await _unitOfWork.EstadoVsNotificaciones.GetByIdAsync(id);
            if(estadoVsNotificaciones == null)
            {
                return NotFound();
            }
            return _mapper.Map<EstadoVsNotificacionDto>(estadoVsNotificaciones);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EstadoVsNotificacionDto>>Post(EstadoVsNotificacionDto estadoVsNotificacionDto)
        {
            var estadoVsNotificacion = _mapper.Map<EstadoVsNotificacion>(estadoVsNotificacionDto);

            if(estadoVsNotificacionDto.FechaCreacion == DateTime.MinValue)
            {
                estadoVsNotificacionDto.FechaCreacion = DateTime.Now; 
            }
            if(estadoVsNotificacionDto.FechaModificacion == DateTime.MinValue)
            {
                estadoVsNotificacionDto.FechaModificacion = DateTime.Now; 
            }
            this._unitOfWork.EstadoVsNotificaciones.Add(estadoVsNotificacion);
            await _unitOfWork.SaveAsync();
            
            if(estadoVsNotificacion == null)
            {
                return BadRequest();
            }
            estadoVsNotificacionDto.Id = estadoVsNotificacion.Id;
            return CreatedAtAction(nameof(Post), new {id = estadoVsNotificacionDto.Id}, estadoVsNotificacionDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EstadoVsNotificacionDto>> Put(int id, [FromBody] EstadoVsNotificacionDto estadoVsNotificacionDto)
        {
            if(estadoVsNotificacionDto == null)
            {
                return NotFound();
            }
            var estadoVsNotificaciones = _mapper.Map<EstadoVsNotificacion>(estadoVsNotificacionDto);
            _unitOfWork.EstadoVsNotificaciones.Update(estadoVsNotificaciones);
            await _unitOfWork.SaveAsync();
            return estadoVsNotificacionDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult>Delete(int id)
        {
            var estadoVsNotificacion = await _unitOfWork.EstadoVsNotificaciones.GetByIdAsync(id);
            if(estadoVsNotificacion == null)
            {
                return NotFound();
            }
            _unitOfWork.EstadoVsNotificaciones.Remove(estadoVsNotificacion);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}