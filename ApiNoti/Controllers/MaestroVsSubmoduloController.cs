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
    public class MaestroVsSubmoduloController : BaseControllerAPi
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MaestroVsSubmoduloController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<MaestroVsSubmoduloDto>>>Get()
        {
            var maestroVsSubmodulos = await _unitOfWork.MaestroVsSubmodulos.GetAllAsync();
            return _mapper.Map<List<MaestroVsSubmoduloDto>>(maestroVsSubmodulos);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MaestroVsSubmoduloDto>>Get(int id)
        {
            var maestroVsSubmodulo = await _unitOfWork.MaestroVsSubmodulos.GetByIdAsync(id);
            if(maestroVsSubmodulo == null)
            {
                return NotFound();
            }
            return _mapper.Map<MaestroVsSubmoduloDto>(maestroVsSubmodulo);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MaestroVsSubmoduloDto>>Post(MaestroVsSubmoduloDto maestroVsSubmoduloDto)
        {
            var maestroVsSubmodulo = _mapper.Map<MaestroVsSubmodulo>(maestroVsSubmoduloDto);

            if(maestroVsSubmoduloDto.FechaCreacion == DateTime.MinValue)
            {
                maestroVsSubmoduloDto.FechaCreacion = DateTime.Now; 
            }
            if(maestroVsSubmoduloDto.FechaModificacion == DateTime.MinValue)
            {
                maestroVsSubmoduloDto.FechaModificacion = DateTime.Now; 
            }
            this._unitOfWork.MaestroVsSubmodulos.Add(maestroVsSubmodulo);
            await _unitOfWork.SaveAsync();
            
            if(maestroVsSubmodulo == null)
            {
                return BadRequest();
            }
            maestroVsSubmoduloDto.Id = maestroVsSubmodulo.Id;
            return CreatedAtAction(nameof(Post), new {id = maestroVsSubmoduloDto.Id}, maestroVsSubmoduloDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MaestroVsSubmoduloDto>> Put(int id, [FromBody] MaestroVsSubmoduloDto maestroVsSubmoduloDto)
        {
            if(maestroVsSubmoduloDto == null)
            {
                return NotFound();
            }
            var mascotas = _mapper.Map<MaestroVsSubmodulo>(maestroVsSubmoduloDto);
            _unitOfWork.MaestroVsSubmodulos.Update(mascotas);
            await _unitOfWork.SaveAsync();
            return maestroVsSubmoduloDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult>Delete(int id)
        {
            var maestroVsSubmodulo = await _unitOfWork.MaestroVsSubmodulos.GetByIdAsync(id);
            if(maestroVsSubmodulo == null)
            {
                return NotFound();
            }
            _unitOfWork.MaestroVsSubmodulos.Remove(maestroVsSubmodulo);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}