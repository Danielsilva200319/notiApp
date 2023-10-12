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
    public class TipoRequerimientoController : BaseControllerAPi
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TipoRequerimientoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TipoRequerimientoDto>>>Get()
        {
            var tipoRequerimientos = await _unitOfWork.TiposRequerimientos.GetAllAsync();
            return _mapper.Map<List<TipoRequerimientoDto>>(tipoRequerimientos);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipoRequerimientoDto>>Get(int id)
        {
            var tipoRequerimiento = await _unitOfWork.TiposRequerimientos.GetByIdAsync(id);
            if(tipoRequerimiento == null)
            {
                return NotFound();
            }
            return _mapper.Map<TipoRequerimientoDto >(tipoRequerimiento);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoRequerimientoDto>>Post(TipoRequerimientoDto tipoRequerimientoDto)
        {
            var tipoRequerimiento = _mapper.Map<TipoRequerimiento>(tipoRequerimientoDto);

            if(tipoRequerimientoDto.FechaCreacion == DateTime.MinValue)
            {
                tipoRequerimientoDto.FechaCreacion = DateTime.Now; 
            }
            if(tipoRequerimientoDto.FechaModificacion == DateTime.MinValue)
            {
                tipoRequerimientoDto.FechaModificacion = DateTime.Now; 
            }
            this._unitOfWork.TiposRequerimientos.Add(tipoRequerimiento);
            await _unitOfWork.SaveAsync();
            
            if(tipoRequerimiento == null)
            {
                return BadRequest();
            }
            tipoRequerimientoDto.Id = tipoRequerimiento.Id;
            return CreatedAtAction(nameof(Post), new {id = tipoRequerimientoDto.Id}, tipoRequerimientoDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipoRequerimientoDto>> Put(int id, [FromBody] TipoRequerimientoDto tipoRequerimientoDto)
        {
            if(tipoRequerimientoDto == null)
            {
                return NotFound();
            }
            var tipoRequerimientos = _mapper.Map<TipoRequerimiento>(tipoRequerimientoDto);
            _unitOfWork.TiposRequerimientos.Update(tipoRequerimientos);
            await _unitOfWork.SaveAsync();
            return tipoRequerimientoDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult>Delete(int id)
        {
            var tipoRequerimiento = await _unitOfWork.TiposRequerimientos.GetByIdAsync(id);
            if(tipoRequerimiento == null)
            {
                return NotFound();
            }
            _unitOfWork.TiposRequerimientos.Remove(tipoRequerimiento);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}