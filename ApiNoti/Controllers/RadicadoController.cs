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
    public class RadicadoController : BaseControllerAPi
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RadicadoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<RadicadoDto>>>Get()
        {
            var radicados = await _unitOfWork.Radicados.GetAllAsync();
            return _mapper.Map<List<RadicadoDto>>(radicados);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RadicadoDto>>Get(int id)
        {
            var radicado = await _unitOfWork.Radicados.GetByIdAsync(id);
            if(radicado == null)
            {
                return NotFound();
            }
            return _mapper.Map<RadicadoDto>(radicado);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RadicadoDto>>Post(RadicadoDto radicadoDto)
        {
            var radicado = _mapper.Map<Radicado>(radicadoDto);

            if(radicadoDto.FechaCreacion == DateTime.MinValue)
            {
                radicadoDto.FechaCreacion = DateTime.Now; 
            }
            if(radicadoDto.FechaModificacion == DateTime.MinValue)
            {
                radicadoDto.FechaModificacion = DateTime.Now; 
            }
            this._unitOfWork.Radicados.Add(radicado);
            await _unitOfWork.SaveAsync();
            
            if(radicado == null)
            {
                return BadRequest();
            }
            radicadoDto.Id = radicado.Id;
            return CreatedAtAction(nameof(Post), new {id = radicadoDto.Id}, radicadoDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RadicadoDto>> Put(int id, [FromBody] RadicadoDto radicadoDto)
        {
            if(radicadoDto == null)
            {
                return NotFound();
            }
            var radicados = _mapper.Map<Radicado>(radicadoDto);
            _unitOfWork.Radicados.Update(radicados);
            await _unitOfWork.SaveAsync();
            return radicadoDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult>Delete(int id)
        {
            var radicado = await _unitOfWork.Radicados.GetByIdAsync(id);
            if(radicado == null)
            {
                return NotFound();
            }
            _unitOfWork.Radicados.Remove(radicado);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}