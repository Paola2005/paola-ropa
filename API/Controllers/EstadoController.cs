using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class EstadoController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EstadoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Estado>>> Get()
        {
            var Estadoes = await _unitOfWork.Estados.GetAllAsync();
            return _mapper.Map<List<Estado>>(Estadoes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EstadoDto>> Get(int id)
        {
            var Estado = await _unitOfWork.Estados.GetByIdAsync(id);
            if(Estado == null)
            {
                return NotFound();
            }
            return _mapper.Map<EstadoDto>(Estado);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Estado>> Post(EstadoDto EstadoDto)
        {
            var Estado = _mapper.Map<Estado>(EstadoDto);
            this._unitOfWork.Estados.Add(Estado);
            await _unitOfWork.SaveAsync();
            if(Estado == null)
            {
                return BadRequest();
            }
            EstadoDto.Id = Estado.Id;
            return CreatedAtAction(nameof(Post), new {id = EstadoDto.Id}, EstadoDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EstadoDto>> Put(int id, [FromBody] EstadoDto EstadoDto)
        {
            if(EstadoDto == null)
            {
                return NotFound();
            }
            var Estadoes = _mapper.Map<Estado>(EstadoDto);
            _unitOfWork.Estados.Update(Estadoes);
            await _unitOfWork.SaveAsync();
            return EstadoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Estado = await _unitOfWork.Estados.GetByIdAsync(id);
            if(Estado == null)
            {
                return NotFound();
            }
            _unitOfWork.Estados.Remove(Estado);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }