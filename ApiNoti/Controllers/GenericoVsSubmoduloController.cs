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
    public class GenericoVsSubmoduloController : BaseControllerAPi
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GenericoVsSubmoduloController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<GenericoVsSubmoduloDto>>>Get()
        {
            var genericoVsSubmodulos = await _unitOfWork.GenericoVsSubmodulos.GetAllAsync();
            return _mapper.Map<List<GenericoVsSubmoduloDto>>(genericoVsSubmodulos);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GenericoVsSubmoduloDto>>Get(int id)
        {
            var genericoVsSubmodulo = await _unitOfWork.GenericoVsSubmodulos.GetByIdAsync(id);
            if(genericoVsSubmodulo == null)
            {
                return NotFound();
            }
            return _mapper.Map<GenericoVsSubmoduloDto>(genericoVsSubmodulo);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GenericoVsSubmoduloDto>>Post(GenericoVsSubmoduloDto genericoVsSubmoduloDto)
        {
            var genericoVsSubmodulo = _mapper.Map<GenericoVsSubmodulo>(genericoVsSubmoduloDto);

            if(genericoVsSubmoduloDto.FechaCreacion == DateTime.MinValue)
            {
                genericoVsSubmoduloDto.FechaCreacion = DateTime.Now; 
            }
            if(genericoVsSubmoduloDto.FechaModificacion == DateTime.MinValue)
            {
                genericoVsSubmoduloDto.FechaModificacion = DateTime.Now; 
            }
            this._unitOfWork.GenericoVsSubmodulos.Add(genericoVsSubmodulo);
            await _unitOfWork.SaveAsync();
            
            if(genericoVsSubmodulo == null)
            {
                return BadRequest();
            }
            genericoVsSubmoduloDto.Id = genericoVsSubmodulo.Id;
            return CreatedAtAction(nameof(Post), new {id = genericoVsSubmoduloDto.Id}, genericoVsSubmoduloDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GenericoVsSubmoduloDto>> Put(int id, [FromBody] GenericoVsSubmoduloDto genericoVsSubmoduloDto)
        {
            if(genericoVsSubmoduloDto == null)
            {
                return NotFound();
            }
            var genericoVsSubmodulos = _mapper.Map<GenericoVsSubmodulo>(genericoVsSubmoduloDto);
            _unitOfWork.GenericoVsSubmodulos.Update(genericoVsSubmodulos);
            await _unitOfWork.SaveAsync();
            return genericoVsSubmoduloDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult>Delete(int id)
        {
            var genericoVsSubmodulo = await _unitOfWork.GenericoVsSubmodulos.GetByIdAsync(id);
            if(genericoVsSubmodulo == null)
            {
                return NotFound();
            }
            _unitOfWork.GenericoVsSubmodulos.Remove(genericoVsSubmodulo);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}