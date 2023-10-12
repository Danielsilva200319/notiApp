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
    public class HiloRespuestaController : BaseControllerAPi
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HiloRespuestaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<HiloRespuestaDto>>>Get()
        {
            var hiloRespuestas = await _unitOfWork.HiloRespuestas.GetAllAsync();
            return _mapper.Map<List<HiloRespuestaDto>>(hiloRespuestas);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<HiloRespuestaDto>>Get(int id)
        {
            var hiloRespuesta = await _unitOfWork.HiloRespuestas.GetByIdAsync(id);
            if(hiloRespuesta == null)
            {
                return NotFound();
            }
            return _mapper.Map<HiloRespuestaDto>(hiloRespuesta);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<HiloRespuestaDto>>Post(HiloRespuestaDto hiloRespuestaDto)
        {
            var hiloRepuesta = _mapper.Map<HiloRespuesta>(hiloRespuestaDto);

            if(hiloRespuestaDto.FechaCreacion == DateTime.MinValue)
            {
                hiloRespuestaDto.FechaCreacion = DateTime.Now; 
            }
            if(hiloRespuestaDto.FechaModificacion == DateTime.MinValue)
            {
                hiloRespuestaDto.FechaModificacion = DateTime.Now; 
            }
            this._unitOfWork.HiloRespuestas.Add(hiloRepuesta);
            await _unitOfWork.SaveAsync();
            
            if(hiloRepuesta == null)
            {
                return BadRequest();
            }
            hiloRespuestaDto.Id = hiloRepuesta.Id;
            return CreatedAtAction(nameof(Post), new {id = hiloRespuestaDto.Id}, hiloRespuestaDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<HiloRespuestaDto>> Put(int id, [FromBody] HiloRespuestaDto hiloRespuestaDto)
        {
            if(hiloRespuestaDto == null)
            {
                return NotFound();
            }
            var mascotas = _mapper.Map<HiloRespuesta>(hiloRespuestaDto);
            _unitOfWork.HiloRespuestas.Update(mascotas);
            await _unitOfWork.SaveAsync();
            return hiloRespuestaDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult>Delete(int id)
        {
            var hiloRespuesta = await _unitOfWork.HiloRespuestas.GetByIdAsync(id);
            if(hiloRespuesta == null)
            {
                return NotFound();
            }
            _unitOfWork.HiloRespuestas.Remove(hiloRespuesta);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}