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
    public class SubmoduloController : BaseControllerAPi
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SubmoduloController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<SubmoduloDto>>>Get()
        {
            var submodulos = await _unitOfWork.Submodulos.GetAllAsync();
            return _mapper.Map<List<SubmoduloDto>>(submodulos);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SubmoduloDto>>Get(int id)
        {
            var submodulo = await _unitOfWork.Submodulos.GetByIdAsync(id);
            if(submodulo == null)
            {
                return NotFound();
            }
            return _mapper.Map<SubmoduloDto>(submodulo);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SubmoduloDto>>Post(SubmoduloDto submoduloDto)
        {
            var submodulo = _mapper.Map<Submodulo>(submoduloDto);

            if(submoduloDto.FechaCreacion == DateTime.MinValue)
            {
                submoduloDto.FechaCreacion = DateTime.Now; 
            }
            if(submoduloDto.FechaModificacion == DateTime.MinValue)
            {
                submoduloDto.FechaModificacion = DateTime.Now; 
            }
            this._unitOfWork.Submodulos.Add(submodulo);
            await _unitOfWork.SaveAsync();
            
            if(submodulo == null)
            {
                return BadRequest();
            }
            submoduloDto.Id = submodulo.Id;
            return CreatedAtAction(nameof(Post), new {id = submoduloDto.Id}, submoduloDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SubmoduloDto>> Put(int id, [FromBody] SubmoduloDto submoduloDto)
        {
            if(submoduloDto == null)
            {
                return NotFound();
            }
            var submodulos = _mapper.Map<Submodulo>(submoduloDto);
            _unitOfWork.Submodulos.Update(submodulos);
            await _unitOfWork.SaveAsync();
            return submoduloDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult>Delete(int id)
        {
            var submodulo = await _unitOfWork.Submodulos.GetByIdAsync(id);
            if(submodulo == null)
            {
                return NotFound();
            }
            _unitOfWork.Submodulos.Remove(submodulo);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}