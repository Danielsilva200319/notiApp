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
    public class ModuloMaestroController : BaseControllerAPi
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ModuloMaestroController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ModuloMaestroDto>>>Get()
        {
            var moduloMaestros = await _unitOfWork.ModulosMaestros.GetAllAsync();
            return _mapper.Map<List<ModuloMaestroDto>>(moduloMaestros);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ModuloMaestroDto>>Get(int id)
        {
            var moduloMaestro = await _unitOfWork.ModulosMaestros.GetByIdAsync(id);
            if(moduloMaestro == null)
            {
                return NotFound();
            }
            return _mapper.Map<ModuloMaestroDto>(moduloMaestro);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ModuloMaestroDto>>Post(ModuloMaestroDto moduloMaestroDto)
        {
            var moduloMaestro = _mapper.Map<ModuloMaestro>(moduloMaestroDto);

            if(moduloMaestroDto.FechaCreacion == DateTime.MinValue)
            {
                moduloMaestroDto.FechaCreacion = DateTime.Now; 
            }
            if(moduloMaestroDto.FechaModificacion == DateTime.MinValue)
            {
                moduloMaestroDto.FechaModificacion = DateTime.Now; 
            }
            this._unitOfWork.ModulosMaestros.Add(moduloMaestro);
            await _unitOfWork.SaveAsync();
            
            if(moduloMaestro == null)
            {
                return BadRequest();
            }
            moduloMaestroDto.Id = moduloMaestro.Id;
            return CreatedAtAction(nameof(Post), new {id = moduloMaestroDto.Id}, moduloMaestroDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ModuloMaestroDto>> Put(int id, [FromBody] ModuloMaestroDto moduloMaestroDto)
        {
            if(moduloMaestroDto == null)
            {
                return NotFound();
            }
            var moduloMaestros = _mapper.Map<ModuloMaestro>(moduloMaestroDto);
            _unitOfWork.ModulosMaestros.Update(moduloMaestros);
            await _unitOfWork.SaveAsync();
            return moduloMaestroDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult>Delete(int id)
        {
            var moduloMaestro = await _unitOfWork.ModulosMaestros.GetByIdAsync(id);
            if(moduloMaestro == null)
            {
                return NotFound();
            }
            _unitOfWork.ModulosMaestros.Remove(moduloMaestro);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}